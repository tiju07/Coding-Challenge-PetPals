using Microsoft.Data.SqlClient;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.util
{
    public class DBConn
    {
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.AppSettings.Get("DefaultConnection"));
        }
    }
}
