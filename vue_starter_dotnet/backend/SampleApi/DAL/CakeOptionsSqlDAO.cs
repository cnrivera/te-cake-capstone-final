using SampleApi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApi.DAL
{
    /// <summary>
    /// An interface for cake objects.
    /// </summary>
    public class CakeOptionsSqlDAO : ICakeOptionsDAO
    {
        private readonly string connectionString;

        
        /// <summary>
        /// Creates a new sql dao for cake options.
        /// </summary>
        /// <param name="connectionString">the database connection string</param>
        public CakeOptionsSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }


        /// <summary>
        /// Returns a list of all Cake Styles
        /// </summary>
        public List<Styles> GetAllCakeStyles()
        {

            List<Styles> listOfStyles = new List<Styles>();

            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    string sql = $"SELECT * FROM styles";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through each row
                    while (reader.Read())
                    {
                    
                        Styles style = new Styles();
                        style.id = Convert.ToInt32(reader["id"]);
                        style.style = Convert.ToString(reader["style"]);
                        style.price = Convert.ToDouble(reader["price"]);
                        style.isAvailable = Convert.ToBoolean(reader["available"]);

                        listOfStyles.Add(style);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return listOfStyles;
        }

        public List<Sizes> GetAllCakeSizes()
        {

            List<Sizes> listOfSizes = new List<Sizes>();

            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    string sql = $"SELECT * FROM sizes";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through each row
                    while (reader.Read())
                    {

                        Sizes size = new Sizes();
                        size.id = Convert.ToInt32(reader["id"]);
                        size.size = Convert.ToString(reader["size"]);
                        size.priceMultiplier = Convert.ToDouble(reader["price_multiplier"]);
                        size.isAvailable = Convert.ToBoolean(reader["available"]);

                        listOfSizes.Add(size);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return listOfSizes;
        }




    }
}
