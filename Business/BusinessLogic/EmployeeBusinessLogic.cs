using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Models;
using ViewModels.Validator;

namespace Business.BusinessLogic
{
    public class EmployeeBusinessLogic
    {
        private Employee.EmployeeBusiness Repository;

        private Role.RoleBusiness RoleRepository;

        public EmployeeBusinessLogic() {
            this.Repository = new Employee.EmployeeBusiness();
            this.RoleRepository = new Role.RoleBusiness(); 
        }

        public bool Create(EmployeeView model) {
            try
            {
                EmployeeValidator validator = new EmployeeValidator(model);
                if (!validator.IsValid()) {
                    throw new Exception(validator.GetErrors());
                }
                return this.Repository.Create(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(EmployeeView model)
        {
            try
            {
                return this.Repository.Update(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(EmployeeView model)
        {
            try
            {
                return this.Repository.Delete(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EmployeeView> GetAll() {
            try
            {
                return this.Repository.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<RoleView> GetRoles() {
            try
            {
                return this.RoleRepository.GetAll();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
