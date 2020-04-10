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
                        order.cake.name = Convert.ToString(reader["cake_name"]);
                        order.quantity = Convert.ToInt32(reader["cake_quantity"]);
                        order.cake.style = Convert.ToString(reader["style"]);
                        order.cake.size = Convert.ToString(reader["size"]);
                        order.cake.flavor = Convert.ToString(reader["flavor"]);
                        order.cake.frosting = Convert.ToString(reader["frosting"]);
                        order.cake.filling = Convert.ToString(reader["filling"]);
                        order.cake.price = Convert.ToDouble(reader["order_total"]);
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
                    SqlCommand cmd = new SqlCommand("INSERT INTO orders (cake_name, cake_quantity, style, size, flavor, frosting, filling, cake_message, order_total, order_status, customer_name, phone_number, email) VALUES (@cakeName, @quantity, @style, @size, @flavor, @frosting, @filling, @writingOnCake, @orderTotal, @orderStatus, @customerName, @phoneNumber, @email);", conn);

                    cmd.Parameters.AddWithValue("@cakeName", order.cake.name);
                    cmd.Parameters.AddWithValue("@quantity", order.quantity);
                    cmd.Parameters.AddWithValue("@style", order.cake.style);
                    cmd.Parameters.AddWithValue("@size", order.cake.size);
                    cmd.Parameters.AddWithValue("@flavor", order.cake.flavor);
                    cmd.Parameters.AddWithValue("@frosting", order.cake.frosting);
                    cmd.Parameters.AddWithValue("@filling", order.cake.filling);
                    cmd.Parameters.AddWithValue("@orderTotal", order.cake.price);
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
