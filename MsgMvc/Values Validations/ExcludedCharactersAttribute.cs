using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace MinProjMVC.Validations
{
    sealed public class ExcludedCharactersAttribute : ValidationAttribute
    {
        private string _charList;
        private HashSet<char> _characters;

        public ExcludedCharactersAttribute(string characters)
        {
            _characters = new HashSet<char>();
            StringBuilder sb = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(characters))
            {
                for (int i = 0; i < characters.Length; i++)
                {
                    sb.Append(characters[i] + ((i != characters.Length - 1) ? ", " : ""));
                    _characters.Add(characters[i]);
                }
            }

            _charList = sb.ToString();
        }

        public override bool IsValid(object value)
        {
            if (value != null)
            {
                string val = (string)value;
                for (int i = 0; i < val.Length; i++)
                {
                    if(_characters.Contains(val[i]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format("{0} should not contain the following characters {1}", name, _charList);
        }
    }
}