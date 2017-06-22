using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MinProjMVC.Models
{
    public class MessageListItemModel
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string FileName { get; set; }
        public DateTime Date { get; set; }
    }
}