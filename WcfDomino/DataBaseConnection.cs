using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfDomino
{
    class DataBaseConnection
    {
        SqlConnection sqlConnection;
        public SqlConnection Connection()
        {
            sqlConnection = new SqlConnection("Data Source = 127.0.0.1; Initial Catalog = Kurumino; User id = ElderBike4; Password=123456");
            sqlConnection.Open();
            return sqlConnection;
        }

        public void closeConnection()
        {
            sqlConnection.Close();
        }
    }
}
