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
    public class CakeInfoSqlDAO : ICakeInfoDAO
    {
        private readonly string connectionString;

        
        /// <summary>
        /// Creates a new sql dao for cake objects.
        /// </summary>
        /// <param name="connectionString">the database connection string</param>
        public CakeInfoSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Looks into our list of cakes, and returns the one with the matching id
        /// </summary>
        /// <param name="id">the id passed in from vue, after the user clicks on a cake</param>
        public Cake GetCake(int id)
        {
            return GetAllCakes().FirstOrDefault(c => c.id == id);
        }



        /// <summary>
        /// Returns a list of all Cakes in the database
        /// </summary>
        public List<Cake> GetAllCakes()
        {

            List<Cake> listOfCakes = new List<Cake>();

            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    string sql = $"SELECT * FROM cakeInfo";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through each row
                    while (reader.Read())
                    {
                    
                        Cake cake = new Cake();
                        cake.id = Convert.ToInt32(reader["id"]);
                        cake.name = Convert.ToString(reader["name"]);
                        cake.price = Convert.ToDouble(reader["price"]);
                        cake.style = Convert.ToString(reader["style"]);
                        cake.size = Convert.ToString(reader["size"]);
                        cake.flavor = Convert.ToString(reader["flavor"]);
                        cake.icing = Convert.ToString(reader["icing"]);
                        cake.filling = Convert.ToString(reader["filling"]);
                        cake.description = Convert.ToString(reader["description"]);
                        cake.imageName = Convert.ToString(reader["image_path"]);
                        cake.isAvailable = Convert.ToBoolean(reader["available"]);

                        listOfCakes.Add(cake);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return listOfCakes;
        }

        /// <summary>
        /// Saves the user to the database.
        /// </summary>
        /// <param name="cake">cake being added</param>
        public bool AddCake(Cake cake)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO cakeinfo VALUES (@name, @price, @style, @size, @flavor, @icing, @filling, @description);", conn);
                    cmd.Parameters.AddWithValue("@name", cake.name);
                    cmd.Parameters.AddWithValue("@price", cake.price);
                    cmd.Parameters.AddWithValue("@style", cake.style);
                    cmd.Parameters.AddWithValue("@size", cake.size);
                    cmd.Parameters.AddWithValue("@flavor", cake.flavor);
                    cmd.Parameters.AddWithValue("@icing", cake.icing);
                    cmd.Parameters.AddWithValue("@filling", cake.filling);
                    cmd.Parameters.AddWithValue("@description", cake.description);
                    cmd.Parameters.AddWithValue("@image_name", cake.imageName);


                    cmd.ExecuteNonQuery();

                 
                }
            }
            catch (SqlException ex)
            {
                
                return false;
            }
            return true;
        }


    }
}
