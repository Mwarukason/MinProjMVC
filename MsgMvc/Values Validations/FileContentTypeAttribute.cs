using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace MinProjMVC.Validations
{
    sealed public class FileContentTypeAttribute : ValidationAttribute
    {
        private string _extensionList;
        private HashSet<string> _extensions;

        public FileContentTypeAttribute(params string[] extensions)
        {
            StringBuilder sb = new StringBuilder();
            _extensions = new HashSet<string>();

            for (int i = 0; i < extensions.Length; i++)
            {
                _extensions.Add(extensions[i]);
                sb.Append(extensions[i] + ((i != (extensions.Length - 1)) ? ", " : " "));
            }

            _extensionList = sb.ToString();
        }


        public override bool IsValid(object value)
        {
            if(value != null)
            {
                HttpPostedFileBase file = (HttpPostedFileBase)value;
                string extension = Path.GetExtension(file.FileName);
                return _extensions.Contains(extension);
            }

            return true;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format("{0} type must be one of the following file types {1}", name, _extensionList);
        }
    }
}