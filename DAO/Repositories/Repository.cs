using DAO.Exceptions;
using DAO.Models;
using DAO.Queries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Utils.Strings;

namespace DAO.Repositories
{
    public class Repository : Base
    {
        protected Models.Model model;

        public Repository() 
        {

        }

        public void Init(Models.Model model) {
            Type info = model.GetType();
            this.model = model;
            this.name = info.Name;
            this.GenerateSelectQuery();
        }
        /// <summary>
        /// Genera el select del modelo
        /// </summary>
        private void GenerateSelectQuery()
        {
            try
            {
                this.query = QueryManager.GetInstance().GetQuery(this.model, QueryType.Select);                
            }
            catch (GenerateQueryException ex)
            {

                throw ex;
            }
        }


        public bool Create(Model model) {
            bool result = false;
            try
            {
                result = this.CreateItem(model);
            }
            catch (Exception ex)
            {
                throw new ExecuteQueryException("CREATE DATABASE ERROR");
            }
            return result;
        }

        public bool Update(Model model)
        {
            bool result = false;
            try
            {
                result = this.UpdateItem(model);
            }
            catch (Exception ex)
            {
                throw new ExecuteQueryException("UPDATE DATABASE ERROR");
            }
            return result;
        }

        public bool Delete(Model model)
        {
            bool result = false;
            try
            {
                result = this.DeleteItem(model);
                result = true;
            }
            catch (Exception ex)
            {
                throw new ExecuteQueryException("DELETE DATABASE ERROR");
            }
            return result;
        }

        /// <summary>
        /// El repositorio del modelo debería sobreescribir este método
        /// Si su primary key es diferente de Id, o si son dos primary keys etc..
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        protected override object[] GetPrimaryKeys(object model)
        {
            object[] list = new object[1];
            list[0] = "Id";
            return list;
        }

        protected override string InsertQuery(object model)
        {
            string query = QueryManager.GetInstance().GetQuery((Model)model, QueryType.Create);
            Type info = model.GetType();
            PropertyInfo[] properties = info.GetProperties();
            foreach (PropertyInfo prop in properties) {

                if (prop.Name != QueryManager.ID) {
                    Type pt = prop.PropertyType;
                    if (pt.FullName.ToLower() == QueryManager.SSTRING)
                    {
                        query += "'" + SanitaizeStrings.ToDb((string)prop.GetValue(model)) + "',";
                    } else if (pt.FullName.ToLower() == QueryManager.SDATE) {
                        query += "'" + prop.GetValue(model).ToString().Replace("/","-") + "',";
                    }
                    else
                    {
                        query += prop.GetValue(model) + ",";
                    }
                }
            }
            query = query.Substring(0, query.Length - 1) + ");";
            return query;
        }

        protected override string UpdateQuery(object model)
        {
            string query = QueryManager.GetInstance().GetQuery((Model)model, QueryType.Update);
            Type info = model.GetType();
            PropertyInfo[] properties = info.GetProperties();
            Hashtable id = new Hashtable();
            foreach (PropertyInfo prop in properties)
            {
                ///TODO Coger primary key del GetValues
                if (prop.Name != QueryManager.ID)
                {
                    Type pt = prop.PropertyType;
                    if (pt.FullName.ToLower() == QueryManager.SSTRING)
                    {
                        query += prop.Name + "=" + "'" + SanitaizeStrings.ToDb((string)prop.GetValue(model)) + "',";
                    }
                    else if (pt.FullName.ToLower() == QueryManager.SDATE)
                    {
                        query += prop.Name + "=" + "'" + prop.GetValue(model) + "',";
                    }
                    else
                    {
                        query += prop.Name + "="+  prop.GetValue(model) + ",";
                    }
                }
                else {
                    ///TODO Coger la primary key de GetValues
                    id[QueryManager.ID] = prop.GetValue(model) + "";
                }
            }
            ///TODO Coger primary keys del GetValues
            query = query.Substring(0, query.Length - 1) 
                + " WHERE " + QueryManager.ID + " = " + id[QueryManager.ID] + ";";
            return query;
        }

        protected override string DeleteQuery(object model)
        {
            string query = QueryManager.GetInstance().GetQuery((Model)model, QueryType.Delete);
            Type info = model.GetType();
            PropertyInfo[] properties = info.GetProperties();
            Hashtable id = new Hashtable();
            foreach (PropertyInfo prop in properties)
            {
                ///TODO Coger primary key del GetValues
                if (prop.Name == QueryManager.ID)
                {
                    query +=  QueryManager.ID + " = " + prop.GetValue(model) + ";";
                }

            }

            return query;
        }
    }
}
