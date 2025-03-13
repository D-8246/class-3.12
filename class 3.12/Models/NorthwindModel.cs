using System.Data.SqlClient;
using System;
using System.Runtime.CompilerServices;

namespace class_3._12.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
    }

    public class NorthwindModel
    {
        private string _connectionString;

        public NorthwindModel(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Order> GetOrders()
        {
            var connection = new SqlConnection(_connectionString);
            var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM Orders";
            connection.Open();
            var reader = cmd.ExecuteReader();
            List<Order> orders = new List<Order>();
            while (reader.Read())
            {
                orders.Add(new Order
                {
                    Id = (int)reader["OrderId"],
                    Date = (DateTime)reader["OrderDate"],
                    ShipName = (string)reader["ShipName"],
                    ShipAddress = (string)reader["ShipAddress"],
                });
            }
            return orders;
        }
    }
}
