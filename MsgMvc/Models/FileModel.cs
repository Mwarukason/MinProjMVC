using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace MinProjMVC.Models
{
    public class FileModel
    {
        public Stream Content { get; set; }
        public String ContentType { get; set; }
    }
}