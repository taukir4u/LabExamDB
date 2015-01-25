using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LabExamDB.BLL;
using LabExamDB.DAL.DAO;
using LabExamDB.DAL.Gateway;

namespace LabExamDB
{
    public partial class MainUI : Form
    {
        public MainUI()
        {
            InitializeComponent();
        }
        ProductManager aProductManager= new ProductManager();
        private Product aProduct;

        private void saveButton_Click(object sender, EventArgs e)
        {

            aProduct = new Product();
            aProduct.Code = productCodeTextBox.Text;
            aProduct.Description = productDescriptionTextBox.Text;
            aProduct.Quantity = Convert.ToInt32(productQuantityTextBox.Text);
            aProductManager.InsertData(aProduct);

           }

        private void showButton_Click(object sender, EventArgs e)
        {
            aProduct = new Product();
            List<Product> products = aProductManager.GetAllProduct(aProduct);
            productListView.Items.Clear();
            foreach (Product product in products)
            {
                ListViewItem lvi = new ListViewItem(product.Code);
                lvi.SubItems.Add(product.Description);
                lvi.SubItems.Add(product.Quantity.ToString());
                productListView.Items.Add(lvi);
            }
            viewQuantityTextBox.Text = aProductManager.GetTotalQuantity().ToString();
        }
        }
}
