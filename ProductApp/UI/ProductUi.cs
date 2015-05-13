using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ProductApp.BLL;
using ProductApp.MODEL;

namespace ProductApp
{
    public partial class ProductUi : Form
    {
        public ProductUi()
        {
            InitializeComponent();
        }

        private void ProductUi_Load(object sender, EventArgs e)
        {

        }

        ProductManager manager = new ProductManager();
        private void saveButton_Click(object sender, EventArgs e)
        {
            Product aProduct = new Product();
            aProduct.Code = codeTextBox.Text;
            aProduct.Description = descriptionTextBox.Text;
            aProduct.Quantity = int.Parse(quantityTextBox.Text);
            MessageBox.Show(manager.Save(aProduct));
            ClearTextFields();
        }

        List<Product> products = new List<Product>(); 
        private void showButton_Click(object sender, EventArgs e)
        {
            int count = 0;
            productListView.Items.Clear();
            products.Clear();
            products = manager.GetAllProducts();
            foreach (var product in products)
            {
                ListViewItem item = new ListViewItem(product.Code);
                item.SubItems.Add(product.Description);
                item.SubItems.Add(product.Quantity.ToString());
                productListView.Items.Add(item);
                count+= product.Quantity;
            }
            totalQuantityTextBox.Text = count.ToString();
        }

        private void ClearTextFields()
        {
            codeTextBox.Clear();
            descriptionTextBox.Clear();
            quantityTextBox.Clear();
        }
    }
}
