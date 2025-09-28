using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Inventory
{
    public partial class frmAddProduct : Form
    {
        
        private string _ProductName;
        private string _Category;
        private string _MfgDate;
        private string _ExpDate;
        private string _Description;
        private int _Quantity;
        private double _SellPrice;

        
        private BindingSource showProductList;

        public frmAddProduct()
        {
            InitializeComponent();
            showProductList = new BindingSource();

           
            this.Load += frmAddProduct_Load;
            this.btnAddProduct.Click += btnAddProduct_Click;
        }

        private void frmAddProduct_Load(object sender, EventArgs e)
        {
            string[] ListOfProductCategory = new string[] {
                "Beverages",
                "Bread/Bakery",
                "Canned/Jarred Goods",
                "Dairy",
                "Frozen Goods",
                "Meat",
                "Personal Care",
                "Other"
            };

            foreach (string category in ListOfProductCategory)
            {
                cbCategory.Items.Add(category);
            }
        }

        
        public string Product_Name(string name)
        {
            if (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
                throw new StringFormatException("Product name must contain letters only.");

            return name;
        }

        public int Quantity(string qty)
        {
            if (!Regex.IsMatch(qty, @"^[0-9]"))
                throw new NumberFormatException("Quantity must contain numeric digits.");

            return Convert.ToInt32(qty);
        }

        public double SellingPrice(string price)
        {
            if (!Regex.IsMatch(price.ToString(), @"^(\d*\.)?\d+$"))
                throw new CurrencyFormatException("Selling price must be a valid number.");

            return Convert.ToDouble(price);
        }

        
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                _ProductName = Product_Name(txtProductName.Text);
                _Category = cbCategory.Text;
                _MfgDate = dtPickerMfgDate.Value.ToString("yyyy-MM-dd");
                _ExpDate = dtPickerExpDate.Value.ToString("yyyy-MM-dd");
                _Description = richTxtDescription.Text;
                _Quantity = Quantity(txtQuantity.Text);
                _SellPrice = SellingPrice(txtSellPrice.Text);

                showProductList.Add(new ProductClass(_ProductName, _Category, _MfgDate,
                    _ExpDate, _SellPrice, _Quantity, _Description));

                gridViewProductList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                gridViewProductList.DataSource = showProductList;
            }
            catch (StringFormatException sfx)
            {
                MessageBox.Show(sfx.Message, "String Format Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (NumberFormatException nfx)
            {
                MessageBox.Show(nfx.Message, "Number Format Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (CurrencyFormatException cfx)
            {
                MessageBox.Show(cfx.Message, "Currency Format Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                
                txtProductName.Focus();
            }
        }
    }
}