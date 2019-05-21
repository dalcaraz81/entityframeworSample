using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using ViewModels.Models;

namespace Business.Role
{
    public class RoleBusiness : BaseBusiness
    {
        private DAO.Repositories.RolRepository Repository;

        public RoleBusiness() {
            this.Repository = new DAO.Repositories.RolRepository();
        }

        public static DAO.Models.Role ConvertFromView(RoleView role) {
            return new DAO.Models.Role()
            {
                Id = role.Id,
                Name = role.Name
            };
        }

        public static RoleView ConvertFromModel(DAO.Models.Role model) {
            return new RoleView() {
                Id = model.Id,
                Name = model.Name
            };
        }

        public override bool Create(ViewModel role) {
            try
            {
                return this.Repository.Create(ConvertFromView((RoleView)role));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool Update(ViewModel role) {
            try
            {
                return this.Repository.Update(ConvertFromView((RoleView)role));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool Delete(ViewModel role)
        {
            try
            {
                return this.Repository.Delete(ConvertFromView((RoleView)role));
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
                return this.Repository.GetAll().ConvertAll(
                    new Converter<DAO.Models.Role, RoleView>(ConvertFromModel));
;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
