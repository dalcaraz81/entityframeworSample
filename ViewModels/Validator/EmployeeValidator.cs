using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Models;

namespace ViewModels.Validator
{
    /// <summary>
    /// TODO Crear una lista de mensajes de error según las validaciones
    /// de forma que se pase una lista con los errores, ejemplo email, username, password..
    /// </summary>
    public class EmployeeValidator : Validator
    {
        public EmployeeValidator(EmployeeView model) : base(model) {

        }
        public override bool IsValid()
        {
            bool valid = true;
            this.ValidateEmail();

            if (this.ErrorMessages.Count > 0) {
                valid = false;
            }
            return valid;
        }

        private void ValidateEmail() {
            bool valid = false;
            try
            {
                var address = new System.Net.Mail.MailAddress(((EmployeeView)this.Model).Email);
                valid = address.Address == ((EmployeeView)this.Model).Email;
            }
            catch (Exception ex)
            {
                throw new Exception("Error validating email");
            }
            if (!valid) {
                this.ErrorMessages.Add("The email is not valid");
            }
        }
    }
}
