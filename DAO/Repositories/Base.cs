using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DAO.Exceptions;

namespace DAO.Repositories
{
    public abstract class Base
    {

        public Base() {
            //TODO COGER DEL CONFIG
            this.connectionString = "Data Source=DESKTOP-FCK05AC\\SQLEXPRESS; Initial Catalog=Employees; Integrated Security=True";             
        }
        protected SqlConnection conn;

        private string connectionString;        

        protected string name;

        protected string query;

        protected DataTable table;

        protected SqlDataReader SelectItems() {
            this.conn = new SqlConnection(this.connectionString);
            SqlCommand command = new SqlCommand(this.query);
            SqlDataReader reader = null;
            try
            {
                conn.Open();
                command.Connection = conn;
                reader = command.ExecuteReader(CommandBehavior.CloseConnection);

            }
            catch (Exception ex)
            {
                throw new ExecuteQueryException("DATABASE ERROR :: SELECT ITEMS");
            }

            return reader;
        }

        protected bool DeleteItem(object model) {
            bool deleted = false;
            try
            {
                this.ExecuteQuery(this.DeleteQuery(model));
                deleted = true;
            }
            catch (ExecuteQueryException ex)
            {
                throw new ExecuteQueryException(ex.Message + " :: DELETE EXCEPTION");
            }

            return deleted;
        }

        protected bool CreateItem(object model) {
            bool created = false;
            try
            {
                this.ExecuteQuery(this.InsertQuery(model));
                created = true;
            }
            catch (ExecuteQueryException ex)
            {
                throw new ExecuteQueryException(ex.Message + " :: CREATE EXCEPTION");
            }

            return created;
        }

        protected bool UpdateItem(object model)
        {
            bool updated = false;
            try
            {
                this.ExecuteQuery(this.UpdateQuery(model));
                updated = true;
            }
            catch (ExecuteQueryException ex)
            {
                throw new ExecuteQueryException(ex.Message + " :: UPDATE EXCEPTION");
            }

            return updated;
        }

        /// <summary>
        /// TODO: La subclase debería devolver las primary keys de la clase,
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        protected abstract object[] GetPrimaryKeys(object model);

        protected abstract string InsertQuery(object model);

        protected abstract string UpdateQuery(object model);

        protected abstract string DeleteQuery(object model);

        private void ExecuteQuery(string query) {
            SqlConnection conn = new SqlConnection(this.connectionString);
            try
            {
                
                SqlCommand command = new SqlCommand(query);
                conn.Open();
                command.Connection = conn;
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                throw new ExecuteQueryException("DATABASE ERROR");
            }
            finally
            {
                if (conn.State != ConnectionState.Closed) {
                    conn.Close();
                }
            }
        }

        protected void CloseConnection() {
            if (this.conn.State != ConnectionState.Closed)
            {
                this.conn.Close();
            }
        }
        
    }
}
