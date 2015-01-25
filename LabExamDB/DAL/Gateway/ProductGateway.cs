using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LabExamDB.DAL.DAO;

namespace LabExamDB.DAL.Gateway
{
    internal class ProductGateway
    {
        private string connectionString;
        private SqlConnection aConnection;
        private SqlCommand aCommand;

        public ProductGateway()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ProductDBConnection"].ConnectionString;
            aConnection = new SqlConnection(connectionString);
        }

        public void InsertData(Product aProduct)
        {
            string insertCommandString = "INSERT INTO tProduct VALUES ('" + aProduct.Code + "','" +
                                         aProduct.Description + "','" + aProduct.Quantity + "')";
            aConnection.Open();
            aCommand = new SqlCommand(insertCommandString, aConnection);
            int dataSaveInDataBaseEfact = aCommand.ExecuteNonQuery();
            aConnection.Close();

            if (dataSaveInDataBaseEfact > 0)
            {
                MessageBox.Show("Product Saved..");
            }
            else
            {
                MessageBox.Show("Product Save Failed..");
            }
        }

        public List<Product> GetAllProduct(Product aProduct)
        {
            aConnection.Open();
            string query = string.Format("SELECT * FROM tProduct");
            SqlCommand command = new SqlCommand(query, aConnection);
            List<Product> products = new List<Product>();
            SqlDataReader aReader = command.ExecuteReader();
            bool HasHow = aReader.HasRows;

            if (HasHow)
            {
                while (aReader.Read())
                {
                    Product product = new Product();
                    product.Id = (int)aReader[0];
                    product.Code = aReader[1].ToString();
                    product.Description = aReader[2].ToString();
                    product.Quantity = (int)aReader[3];
                    products.Add(product);
                }
            }
            aConnection.Close();
            return products;
        }

        //public bool HasThisProductNameStored(string name)
        //{
        //    aConnection.Open();
        //    string query = string.Format("SELECT description FROM tProduct WHERE description='{0}'", description);
        //    SqlCommand command = new SqlCommand(query, aConnection);
        //    SqlDataReader aReader = command.ExecuteReader();
        //    bool HasHow = aReader.HasRows;
        //    aConnection.Close();
        //    return HasHow;
        //}

        public bool CheckAlreadyExist(Product aProduct)
        {
            aConnection.Open();
            string query = string.Format("SELECT * FROM tProduct WHERE (code='{0}')", aProduct.Code);
            SqlCommand aCommand = new SqlCommand(query, aConnection);
            SqlDataReader aReader = aCommand.ExecuteReader();

            if (aReader.HasRows)
            {
                aReader.Close();
                aConnection.Close();
                return true;
            }
            else
            {
                aReader.Close();
                aConnection.Close();
                return false;
            }
        }

        public int GetTotalQuantity()
        {
            aConnection.Open();
            string query = string.Format("SELECT SUM(Quantity) AS quantity FROM tProduct");
            SqlCommand command = new SqlCommand(query, aConnection);
            object totalQuantity = command.ExecuteScalar();
            aConnection.Close();
            return (int)totalQuantity;
        }
    }
}
