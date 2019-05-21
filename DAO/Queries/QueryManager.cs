using DAO.Exceptions;
using DAO.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Queries
{
    public enum QueryType {
        Create = 1,
        Update,
        Select,
        Delete
    }
    /// <summary>
    /// TODO: La creación de las queries necesitaría a parte del modelo que se le pasara
    /// el GetValues que contiene las primary keys del modelo
    /// </summary>
    public class QueryManager
    {
        private static QueryManager instance;

        private Hashtable queries;

        private static int START_INDEX = 0;

        public static string SSTRING = "system.string";
        public static string SDATE = "system.datetime";
        public static string ID = "Id";



        private QueryManager()
        {
            this.queries = new Hashtable();
        }

        public static QueryManager GetInstance()
        {
            if (instance == null)
            {
                instance = new QueryManager();
            }
            return instance;
        }


        public string GetQuery(Model model, QueryType query) {
            string result = "";
            try
            {
                Type info = model.GetType();
                if (this.queries.ContainsKey(info.Name + query.ToString()))
                {
                    result = (string)this.queries[info.Name + query.ToString()];
                }
                else {
                    switch (query)
                    {
                        case QueryType.Create:
                            this.GenerateCreate(model);
                            break;
                        case QueryType.Delete:
                            this.GenerateDelete(model);
                            break;
                        case QueryType.Update:
                            this.GenerateUpdate(model);
                            break;
                        case QueryType.Select:
                            this.GenerateSelect(model);
                            break;

                    }
                    result = (string)this.queries[info.Name + query.ToString()];
                }
            }
            catch (Exception ex)
            {
                Type info = model.GetType();
                throw new GenerateQueryException(string.Format("Error generating query type {0} and model {0}", query.ToString(), info.Name));
            }
            return result;
        }

        private void GenerateCreate(Model model)
        {
            Type info = model.GetType();
            PropertyInfo[] properties = info.GetProperties();
            string query = "INSERT INTO " + info.Name + " (";
            foreach (PropertyInfo prop in properties) {
                if(prop.Name != ID)
                    query += prop.Name + ",";
            }
            query = query.Substring(START_INDEX, query.Length - 1);
            query += ") VALUES (";
            //int index = 0;
            //foreach (PropertyInfo prop in properties) {
            //    Type pt = prop.PropertyType;
            //    if (pt.FullName.ToLower() == SSTRING || pt.FullName.ToLower() == SDATE)
            //    {
            //        query += "'{" + index +"}',";
            //    }
            //    else {
            //        query += "{" + index + "},";
            //    }
            //    index++;
            //}
            //query = query.Substring(START_INDEX, query.Length - 1);
            //query += ");";
            this.queries.Add(info.Name + QueryType.Create.ToString(), query);
        }

        private void GenerateDelete(Model model)
        {
            Type info = model.GetType();
            PropertyInfo[] properties = info.GetProperties();
            string query = "DELETE FROM " + info.Name + " WHERE ";
            this.queries.Add(info.Name + QueryType.Delete.ToString(), query);
        }

        private void GenerateUpdate(Model model)
        {
            Type info = model.GetType();
            PropertyInfo[] properties = info.GetProperties();
            string query = "UPDATE " + info.Name + " SET ";
            this.queries.Add(info.Name + QueryType.Update.ToString(), query);
        }

        private void GenerateSelect(Model model)
        {
            Type info = model.GetType();

            PropertyInfo[] properties = info.GetProperties();
            string select = "SELECT ";
            foreach (PropertyInfo prop in properties) {
                select += "[" + prop.Name + "],";
            }
            select = select.Substring(START_INDEX, select.Length - 1);
            select += " FROM " + info.Name + ";";
            this.queries.Add(info.Name + QueryType.Select.ToString(), select);
        }
    }
}
