using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROG6221_ICE3_19014225
{
    public partial class Form1 : Form
    {
        private string path = System.IO.Path.GetFullPath(@"..\..\" + "productInfo.txt");// File located inside Main Project folder.
        ProductsInfo<String> sa = new ProductsInfo<string>(5);//call product info class.
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //Push values through to objects
            sa.push(txtProdID.Text.ToString(),
                txtProdName.Text.ToString(),
                txtProdQuan.Text.ToString(),
                txtProdPrice.Text.ToString());
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //clears all text boxes
            this.txtProdID.Clear();
            this.txtProdName.Clear();
            this.txtProdPrice.Clear();
            this.txtProdQuan.Clear();
            this.rtxtView.Clear();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            //Call read method to read from text file.
            this.rtxtView.Clear();
            this.rtxtView.Text = sa.read();
        }
    }
}
