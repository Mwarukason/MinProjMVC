using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MinProjMVC.Models;
using System.Threading.Tasks;
using MinProjMVC.Repositories;
using MinProjMVC.Services;
using MinProjMVC.DataAccessLayer;
using MinProjMVC.Exceptions;

namespace MinProjMVC.Controllers
{
    public class MessageController : Controller
    {
        private UnitOfWork _uow;
        private msgdbEntities _context;
        private MessageService _messageService;
        
        public MessageController()
        {
            _context = new msgdbEntities();
            _uow = new UnitOfWork(_context);
            _messageService = new MessageService(_uow);
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            ViewBag.Messages = await _messageService.GetMessagesAsync();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(MessageModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _messageService.InsertMessageAsync(model);
                    return RedirectToAction("Index");
                }
                catch (DuplicateMessageException)
                {
                    ModelState.AddModelError(string.Empty, "No dublication of messages, The message has already been added today");
                }
            }

            ViewBag.Messages = await _messageService.GetMessagesAsync();
            return View(model);
        }

        public async Task<ActionResult> File(int id)
        {
            FileModel model = await _messageService.GetFileByIdAsync(id);
            return new FileStreamResult(model.Content, model.ContentType);
        }
    }
}