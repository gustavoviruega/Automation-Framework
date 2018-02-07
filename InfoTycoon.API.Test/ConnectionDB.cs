using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTycoon.API.Test
{
    
    public class ConnectionDB
    {
        
        public static IEnumerable<long> GetInspections()
        {
            List<long> result = new List<long>();

            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            string queryString = "SELECT *  FROM vwVNextAPITest";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                try
                {
                    while (reader.Read())
                    {

                        Console.WriteLine(String.Format("{0}", reader["InspectionId"]));

                        long id = (long)reader["InspectionId"];
                        result.Add(id);

                    }
                }
                finally
                {
                    reader.Close();
                }

            }

            return result;
        }
    }
}

