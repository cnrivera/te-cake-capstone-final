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
    public class OrderSqlDAO : IOrderDAO
    {
        private readonly string connectionString;

        
        /// <summary>
        /// Creates a new sql dao for order objects.
        /// </summary>
        /// <param name="connectionString">the database connection string</param>
        public OrderSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        
        /// <summary>
        /// Returns a list of all orders in the database
        /// </summary>
        public List<Order> GetAllOrders()
        {

            List<Order> listOfOrders = new List<Order>();

            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    string sql = $"SELECT * FROM orders";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through each row
                    while (reader.Read())
                    {

                        Order order = new Order();

                        order.orderId = Convert.ToInt32(reader["order_id"]);
                        order.cakeName = Convert.ToString(reader["cake_name"]);
                        order.quantity = Convert.ToInt32(reader["cake_quantity"]);
                        order.style = Convert.ToString(reader["style"]);
                        order.size = Convert.ToString(reader["size"]);
                        order.flavor = Convert.ToString(reader["flavor"]);
                        order.icing = Convert.ToString(reader["icing"]);
                        order.filling = Convert.ToString(reader["filling"]);
                        order.orderTotal = Convert.ToDouble(reader["order_total"]);
                        order.orderStatus = Convert.ToString(reader["order_status"]);
                        order.customerName = Convert.ToString(reader["customer_name"]);
                        order.phoneNumber = Convert.ToString(reader["phone_number"]);
                        order.email = Convert.ToString(reader["email"]);
                        order.writingOnCake = Convert.ToString(reader["cake_message"]);

                        listOfOrders.Add(order);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return listOfOrders;
        }

        /// <summary>
        /// Saves the user to the database.
        /// </summary>
        /// <param name="cake">cake being added</param>
        public bool AddOrder(Order order)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO orders VALUES ();", conn);

                    cmd.Parameters.AddWithValue("@orderId", order.orderId);
                    cmd.Parameters.AddWithValue("@cakeName", order.cakeName);
                    cmd.Parameters.AddWithValue("@quantity", order.quantity);
                    cmd.Parameters.AddWithValue("@style", order.style);
                    cmd.Parameters.AddWithValue("@size", order.size);
                    cmd.Parameters.AddWithValue("@flavor", order.flavor);
                    cmd.Parameters.AddWithValue("@icing", order.icing);
                    cmd.Parameters.AddWithValue("@filling", order.filling);
                    cmd.Parameters.AddWithValue("@orderTotal", order.orderTotal);
                    cmd.Parameters.AddWithValue("@orderStatus", order.orderStatus);
                    cmd.Parameters.AddWithValue("@customerName", order.customerName);
                    cmd.Parameters.AddWithValue("@phoneNumber", order.phoneNumber);
                    cmd.Parameters.AddWithValue("@email", order.email);
                    cmd.Parameters.AddWithValue("@writingOnCake", order.writingOnCake);

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
