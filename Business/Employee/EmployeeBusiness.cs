using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Models;
using DAO.Models;
using ViewModels;

namespace Business.Employee
{
    public class EmployeeBusiness : BaseBusiness
    {
        private DAO.Repositories.EmployeeRepository Repository;

        public EmployeeBusiness() {
            this.Repository = new DAO.Repositories.EmployeeRepository(); 
        }

        public static DAO.Models.Employee ConvertFromView(EmployeeView view) {

            return new DAO.Models.Employee() {
                Id= view.Id,
                CompanyId = view.CompanyId,
                CreatedOn = view.CreatedOn,
                DeletedOn = view.DeletedOn,
                Email = view.Email,
                Fax = view.Fax,
                LastLogin = view.LastLogin,
                Name = view.Name,
                Password = view.Password,
                PortalId = view.PortalId,
                RoleId = view.RoleId,
                StatusId = view.StatusId,
                TelePhone = view.TelePhone,
                UpdatedOn = view.UpdatedOn,
                Username = view.Username
            };
        }

        public static EmployeeView ConvertFromModel(DAO.Models.Employee model) {
            return new EmployeeView()
            {
                Id = model.Id,
                CompanyId = model.CompanyId,
                CreatedOn = model.CreatedOn,
                DeletedOn = model.DeletedOn,
                Email = model.Email,
                Fax = model.Fax,
                LastLogin = model.LastLogin,
                Name = model.Name,
                Password = model.Password,
                PortalId = model.PortalId,
                RoleId = model.RoleId,
                StatusId = model.StatusId,
                TelePhone = model.TelePhone,
                UpdatedOn = model.UpdatedOn,
                Username = model.Username
            };
        }

        public override bool Create(ViewModel model)
        {
            try
            {
                return this.Repository.Create(ConvertFromView((EmployeeView)model));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool Delete(ViewModel model)
        {
            try
            {
                return this.Repository.Delete(ConvertFromView((EmployeeView)model));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool Update(ViewModel model)
        {
            try
            {
                return this.Repository.Update(ConvertFromView((EmployeeView)model));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EmployeeView> GetAll() {
            try
            {
                return this.Repository.GetAll().ConvertAll(
                    new Converter<DAO.Models.Employee, EmployeeView>(ConvertFromModel));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
