using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MinProjMVC.Validations
{
    sealed public class FileSizeAttribute : ValidationAttribute
    {
        private int _maxLength;

        public FileSizeAttribute(int length)
        {
            this._maxLength = length;
        }

        public override bool IsValid(object value)
        {
            if (value != null)
            {
                HttpPostedFileBase file = (HttpPostedFileBase)value;
                return (file.ContentLength <= _maxLength);
            }

            return true;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format("{0} size must be less than {1} bytes", name, _maxLength);
        }
    }
}