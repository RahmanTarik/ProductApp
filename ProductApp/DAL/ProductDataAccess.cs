using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductApp.MODEL;

namespace ProductApp.DAL
{
   public class ProductDataAccess
    {
       string connectionString = ConfigurationManager.ConnectionStrings["productConnection"].ConnectionString;
        internal int Save(MODEL.Product aProduct)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = String.Format("INSERT INTO Products Values ('{0}','{1}','{2}')", aProduct.Code,
                aProduct.Description, aProduct.Quantity);
            SqlCommand comamand = new SqlCommand(query,connection);
            connection.Open();
            int result =  comamand.ExecuteNonQuery();
            connection.Close();
            return result;
        }

       List<Product> products = new List<Product>(); 
        internal List<Product> GetAllProducts()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Products";
            SqlCommand comamand = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = comamand.ExecuteReader();
            
            while (reader.Read())
            {
                Product aProduct = new Product();
                aProduct.Id = int.Parse(reader[0].ToString());
                aProduct.Code = reader[1].ToString();
                aProduct.Description = reader[2].ToString();
                aProduct.Quantity = int.Parse(reader[3].ToString());
                products.Add(aProduct);
            }
            reader.Close();
            connection.Close();
            return products;
        }

        internal Product GetProductByCode(string code)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Products WHERE Code = '" + code + "'";
            SqlCommand comamand = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = comamand.ExecuteReader();

            Product aProduct = null;
            while (reader.Read())
            {
                if (aProduct == null)
                {
                    aProduct = new Product();    
                }
                aProduct.Id = int.Parse(reader[0].ToString());
                aProduct.Code = reader[1].ToString();
                aProduct.Description = reader[2].ToString();
                aProduct.Quantity = int.Parse(reader[3].ToString());
                
            }
            reader.Close();
            connection.Close();
            return aProduct ;
        }

        internal int Update(Product aProduct)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "UPDATE Products SET Description = '" + aProduct.Description + "', Quantity = '" +aProduct.Quantity + "' WHERE ID = '" + aProduct.Id + "'" ;
            SqlCommand comamand = new SqlCommand(query, connection);
            connection.Open();
            int result = comamand.ExecuteNonQuery();
            connection.Close();
            return result;
        }
    }
}
