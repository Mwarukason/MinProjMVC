using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MinProjMVC.Validations;
using System.ComponentModel.DataAnnotations;

namespace MinProjMVC.Models
{
    public class MessageModel
    {
        [ExcludedCharacters("$#@&%€")]
        [StringLength(160, MinimumLength = 20)]
        [Required(ErrorMessage = "Message is required")]
        public string Message { get; set; }
        
        [FileSize(25000000)]
        [Display(Name = "File")]
        [FileContentType(".csv", ".xls", ".xlsx")]
        [Required(ErrorMessage = "File is required")]
        public HttpPostedFileBase SubmittedFile { get; set; }
    }
}