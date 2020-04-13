﻿using SampleApi.Models;
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

        /// <summary>
        /// Adds a style option to our database so that a customer can order it from the drop down menu
        /// </summary>
        /// <param name="newStyle">the style being added is passed in</param>
        /// <returns></returns>
        public bool AddStyleOption(Styles newStyle)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO styles VALUES (@id, @available, @style, @price);", conn);

                    cmd.Parameters.AddWithValue("@id", newStyle.id);
                    cmd.Parameters.AddWithValue("@available", newStyle.isAvailable);
                    cmd.Parameters.AddWithValue("@style", newStyle.style);
                    cmd.Parameters.AddWithValue("@price", newStyle.price);
                
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {

                return false;
            }
            return true;
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

                    string sql = $"SELECT * from sizes JOIN style_size ON sizes.id = style_size.size_id JOIN styles ON styles.id = style_size.style_id";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through each row
                    while (reader.Read())
                    {

                        Sizes size = new Sizes();
                        size.id = Convert.ToInt32(reader["id"]);
                        size.size = Convert.ToString(reader["size"]);
                        size.basePrice = Convert.ToDouble(reader["base_price"]);
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

        public bool AddSizeOption(Sizes newSize)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO sizes VALUES (@id, @available, @size, @base_price);", conn);

                    cmd.Parameters.AddWithValue("@id", newSize.id);
                    cmd.Parameters.AddWithValue("@available", newSize.isAvailable);
                    cmd.Parameters.AddWithValue("@style", newSize.size);
                    cmd.Parameters.AddWithValue("@price", newSize.basePrice);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                return false;
            }
            return true;
        }

        public List<Frostings> GetAllCakeFrostings()
        {

            List<Frostings> listOfFrostings = new List<Frostings>();

            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    string sql = $"SELECT * FROM frostings";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through each row
                    while (reader.Read())
                    {

                        Frostings frosting = new Frostings();
                        frosting.id = Convert.ToInt32(reader["id"]);
                        frosting.frosting = Convert.ToString(reader["frosting"]);
                        frosting.isAvailable = Convert.ToBoolean(reader["available"]);

                        listOfFrostings.Add(frosting);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return listOfFrostings;
        }

        public bool AddFrostingOption(Frostings newFrosting)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO frostings VALUES (@id, @available, @frosting);", conn);

                    cmd.Parameters.AddWithValue("@id", newFrosting.id);
                    cmd.Parameters.AddWithValue("@available", newFrosting.isAvailable);
                    cmd.Parameters.AddWithValue("@frosting", newFrosting.frosting);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                return false;
            }
            return true;
        }

        public List<Fillings> GetAllCakeFillings()
        {

            List<Fillings> listOfFillings = new List<Fillings>();

            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    string sql = $"SELECT * FROM fillings";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through each row
                    while (reader.Read())
                    {

                        Fillings filling = new Fillings();
                        filling.id = Convert.ToInt32(reader["id"]);
                        filling.filling = Convert.ToString(reader["filling"]);
                        filling.isAvailable = Convert.ToBoolean(reader["available"]);

                        listOfFillings.Add(filling);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return listOfFillings;
        }
        public List<Flavors> GetAllCakeFlavors()
        {

            List<Flavors> listOfFlavors = new List<Flavors>();

            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    string sql = $"SELECT * FROM flavors";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through each row
                    while (reader.Read())
                    {

                        Flavors flavor = new Flavors();
                        flavor.id = Convert.ToInt32(reader["id"]);
                        flavor.flavor = Convert.ToString(reader["flavor"]);
                        flavor.isAvailable = Convert.ToBoolean(reader["available"]);

                        listOfFlavors.Add(flavor);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return listOfFlavors;
        }


    }
}
