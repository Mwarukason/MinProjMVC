using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MinProjMVC.DataAccessLayer;
using MinProjMVC.Models;
using MinProjMVC.Repositories;
using MinProjMVC.Exceptions;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MinProjMVC.Services
{
    public class MessageService
    {
        private UnitOfWork _uow;

        public MessageService(UnitOfWork uow)
        {
            this._uow = uow;
        }

        public async Task InsertMessageAsync(MessageModel model)
        {
            DateTime date = DateTime.Now;
            DateTime dateUtc = date.ToUniversalTime();

            var msg = _uow.MessageRepository.GetQueryable().Where(a => (DbFunctions.DiffDays(a.CreatedDateUTC, dateUtc) < 1)  && string.Compare(a.MessageText, model.Message, true) == 0).FirstOrDefault();

            if(msg != null)
            {
                throw new DuplicateMessageException();
            }
            
            SubmittedFile file = new SubmittedFile()
            {
                FileName = model.SubmittedFile.FileName,
                ContentType = model.SubmittedFile.ContentType,
                RowGuid = Guid.NewGuid()
            };

            using (MemoryStream ms = new MemoryStream())
            {
                await model.SubmittedFile.InputStream.CopyToAsync(ms);
                file.Stream = ms.ToArray();
            }

            Message message = new Message()
            {
                MessageText = model.Message,
                SubmittedFile = file,
                CreatedDate = date,
                CreatedDateUTC = dateUtc
            };

            _uow.MessageRepository.Insert(message);
            await _uow.SaveAsync();
        }

        public async Task<List<MessageListItemModel>> GetMessagesAsync()
        {
            var data = await _uow.MessageRepository.GetAsync();
            var list = (from t in data
                        orderby t.CreatedDateUTC descending
                        select new MessageListItemModel()
                        {
                            Id = t.Id,
                            Message = t.MessageText,
                            Date = t.CreatedDate,
                            FileName = t.SubmittedFile.FileName,
                        }).ToList();

            return list;
        }

        public async Task<FileModel> GetFileByIdAsync(int id)
        {
            SubmittedFile file = await _uow.FileRepository.GetByIdAsync(id);
            FileModel model = new FileModel
            {
                Content = new MemoryStream(file.Stream),
                ContentType = file.ContentType
            };

            return model;
        }
    }
}