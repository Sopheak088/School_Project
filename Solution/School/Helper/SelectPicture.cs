using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.Helper;

namespace School
{
    public static class SelectPicture
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="fieldName">Field Name</param>
        /// <param name="tableName">Table Name</param>
        /// <param name="id">Where by ID</param>
        /// <returns>return will return byte[]</returns>
        public static byte[] GetPhoto(string fieldName, string tableName, Guid id)
        {
            try
            {
                string query = "SELECT " + fieldName + " FROM " + tableName + " WHERE ID = '" + id + "'";
                SqlCommand cm = Connect.ToDatabase().CreateCommand();
                cm.CommandText = query;
                return cm.ExecuteScalar() as byte[];
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                if (Connect.ToDatabase().State != ConnectionState.Closed)
                {
                    Connect.ToDatabase().Close();
                }
            }
        }
    }
}