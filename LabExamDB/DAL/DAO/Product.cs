using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExamDB.DAL.DAO
{
    class Product
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }

        public Product(string code, string description, int quantity)
            : this()
        {
            Code = code;
            Description = description;
            Quantity = quantity;
        }

        public Product()
        {
        }
    }
}
