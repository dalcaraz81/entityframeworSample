using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Validator
{
    public abstract class Validator
    {
        protected List<string> ErrorMessages;

        protected ViewModel Model;

        public Validator(ViewModel model) {
            this.Model = model;
            this.ErrorMessages = new List<string>(); 

        }

        public string GetErrors() {
            string result = "<ul>";
            foreach (string msg in this.ErrorMessages) {
                result += "<li>" + msg + " </li>";
            }
            result += "</ul>";
            return result;
        }

        public abstract bool IsValid();
    }
}
