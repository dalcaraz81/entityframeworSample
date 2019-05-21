using Business.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Models;

namespace Business.BusinessLogic
{
    public class RoleBusinessLogic
    {
        private RoleBusiness Repository;

        public bool Create(RoleView model)
        {
            try
            {
                return this.Repository.Create(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(RoleView model)
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

        public bool Delete(RoleView model)
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

        public List<RoleView> GetAll()
        {
            try
            {
                return this.Repository.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
