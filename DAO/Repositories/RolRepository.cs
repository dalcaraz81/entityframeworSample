using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.Models;
using Utils;

namespace DAO.Repositories
{
    public class RolRepository : Repository
    {
        public RolRepository() 
        {
            this.Init(new Role());
        }
        
        /// <summary>
        /// Es responsabilidad del GetAll de cerrar la conexión
        /// si está abierta
        /// </summary>
        /// <returns></returns>
        public List<Role> GetAll()
        {
            try
            {
                SqlDataReader reader = this.SelectItems();
                return reader.MapModelCollection<Role>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.CloseConnection();
            }

        }

    }
}
