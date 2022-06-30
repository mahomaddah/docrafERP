using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using docrafERP.Models;
using System.Data.SqlClient;

namespace docrafERP.DataAccessLayer
{
    public class DataService
    {
        public SqlConnection Connection { get; set; }
        //server will be ip later server=192.168.1.39

        public DataService()
        {
            string conString = "Server=MAHOLAPTOP\\SQLEXPRESS;Database=docrafERPDB;User Id=abcd;Password=abcd;";

            Connection = new SqlConnection(conString);

            if (Connection.State== ConnectionState.Closed)
            {
                Connection.Open();
            }
        }

        public List<Asset> GetAllAssets()
        {
            string query = "SELECT * FROM [docrafERPDB].[dbo].[ASSET]";
            return Connection.Query<Asset>(query).ToList();
        }


    }
}
