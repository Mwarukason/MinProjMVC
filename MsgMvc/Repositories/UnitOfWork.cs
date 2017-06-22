using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MinProjMVC.DataAccessLayer;
using System.Threading.Tasks;

namespace MinProjMVC.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private bool _disposed;
        private msgdbEntities _context;

        private GenericRepository<Message> _messageRepository;
        private GenericRepository<SubmittedFile> _fileRepository;

        public UnitOfWork(msgdbEntities context)
        {
            this._context = context;
            _disposed = false;
        }

        public GenericRepository<Message> MessageRepository
        {
            get
            {
                if(_messageRepository == null)
                {
                    _messageRepository = new GenericRepository<Message>(_context);
                }
                return _messageRepository;
            }
        }

        public GenericRepository<SubmittedFile> FileRepository
        {
            get
            {
                if(_fileRepository == null)
                {
                    _fileRepository = new GenericRepository<SubmittedFile>(_context);
                }
                return _fileRepository;
            }
        }



        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}