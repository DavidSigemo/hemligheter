using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using inlämning2_albin_eklundh.Controllers;
using inlämning2_albin_eklundh.Models;


namespace inlämning2_albin_eklundh.Views
{
    public partial class frmMainWindow : Form
    {
        private readonly ProductController _prodControl;
        private readonly CategoryController _catControl;
        private BindingList<Product> _products;

        public frmMainWindow()
        {
            _prodControl = new ProductController();
            _catControl = new CategoryController();
            InitializeComponent();
        }

        private void frmMainWindow_Load(object sender, EventArgs e)
        {
            cmbProducts.DataSource = _prodControl.GetAllProducts();
            cmbProducts.DisplayMember = "Name";

            cmbCategory.DataSource = _catControl.GetAllCategories();
            cmbCategory.DisplayMember = "Name";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            List<ValidationResult> result = _prodControl.Create(new Product {
                Name = txtName.Text,
                Brand = txtBrand.Text,
                Size = txtSize.Text,
                Price = decimal.Parse(txtPrice.Text),
                CategoryID = ((Category)cmbCategory.SelectedItem).CategoryID
            });

            if (result.Count() > 0)
            {
                MessageBox.Show(string.Join(Environment.NewLine, result), "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                cmbProducts.DataSource = _prodControl.GetAllProducts();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            List<ValidationResult> result = _prodControl.Update(new Product {
                ProductID = ((Product)cmbProducts.SelectedItem).ProductID,
                Name = txtName.Text,
                Brand = txtBrand.Text,
                Size = txtSize.Text,
                Price = decimal.Parse(txtPrice.Text),
                CategoryID = ((Category)cmbCategory.SelectedItem).CategoryID
            });

            if (result.Count() > 0)
            {
                MessageBox.Show(string.Join(Environment.NewLine, result), "Validation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                cmbProducts.DataSource = _prodControl.GetAllProducts();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool success = _prodControl.Delete((Product)cmbProducts.SelectedItem);
            if (success)
            {
                MessageBox.Show("Product deleted");
                cmbProducts.DataSource = _prodControl.GetAllProducts();
            }
            else
            {
                MessageBox.Show("Something went wrong");
            }
        }

        private void cmbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtName.Text = ((Product)cmbProducts.SelectedItem).Name;
            txtBrand.Text = ((Product)cmbProducts.SelectedItem).Brand;
            txtSize.Text = ((Product)cmbProducts.SelectedItem).Size;
            txtPrice.Text = ((Product)cmbProducts.SelectedItem).Price.ToString();
            //cmbCategory.SelectedItem = ((Product)cmbProducts.SelectedItem).Category;
        }

        private void btnShowSales_Click(object sender, EventArgs e)
        {
            //todo add show sales report
        }

        private void btnListByCategory_Click(object sender, EventArgs e)
        {
            cmbProducts.DataSource = _prodControl.GetAllProducts(((Category)cmbCategory.SelectedItem));
            cmbProducts.DisplayMember = "Name";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
        }
    }
}
