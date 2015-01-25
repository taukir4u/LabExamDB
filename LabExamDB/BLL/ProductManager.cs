using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabExamDB.DAL.DAO;
using LabExamDB.DAL.Gateway;

namespace LabExamDB.BLL
{
    internal class ProductManager
    {
        private ProductGateway aProductGateway;

        public ProductManager()
        {
            aProductGateway = new ProductGateway();
        }

        public void InsertData(Product aProduct)
        {
            aProductGateway.InsertData(aProduct);
        }

        
        public List<Product> GetAllProduct(Product aProduct)
        {
            return aProductGateway.GetAllProduct(aProduct);
        }

        public int GetTotalQuantity()
        {
            return aProductGateway.GetTotalQuantity();
        }
    }
}
