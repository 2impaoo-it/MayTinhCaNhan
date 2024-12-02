using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MayTinhCaNhan
{
    public partial class FrmMain : Form
    {   
        public FrmMain()
        {
            //Console.OutputEncoding = Encoding.UTF8;
            InitializeComponent();
        }

        private void btnCaculator_Click(object sender, EventArgs e)
        {
            if(errNhapSo.GetError(txtFirstNum) != string.Empty || (errNhapSo.GetError(txtSecondNum) != string.Empty))
            {
                MessageBox.Show("Vui lòng kiểm tra lại thông tin đã nhập", "Thông báo");
                return;
            }

            double a = double.Parse(txtFirstNum.Text);
            double b = double.Parse(txtSecondNum.Text);

            Button btn = (Button)sender;
            double results = 0;
            switch (btn.Name)
            {
                case "btnCong":
                    results = a + b;
                    break;
                case "btnTru":
                    results = a - b;
                    break;
                case "btnNhan":
                    results = a * b;
                    break;
                case "btnChia":
                    if (b == 0)
                    {
                        MessageBox.Show("Phân số không hợp lệ");
                        return;
                    }
                    results = a / b;
                    break;
            }
            txtResult.Text = results.ToString();
        }

        private void txtFirstNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra xem phím vừa nhập vào có phải là số không, được phép nhập số âm, số thập phân
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != ',')
            {
                e.Handled = true;
                errNhapSo.SetError(txtFirstNum, "Chỉ cho phép nhập số!");
            }
            else
                errNhapSo.SetError(txtFirstNum, string.Empty);

        }

        private void txtSecondNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != ',')
            {
                e.Handled = true;
                errNhapSo.SetError(txtSecondNum, "Chỉ cho phép nhập số!");
            }
            else
                errNhapSo.SetError(txtSecondNum, string.Empty);
        }

        private void txtFirstNum_Validating(object sender, CancelEventArgs e)
        {
                if (string.IsNullOrEmpty(txtFirstNum.Text))
                {
                    errNhapSo.SetError(txtFirstNum, "Không được để trống!");
                }
                else
                    errNhapSo.SetError(txtFirstNum, string.Empty);
            
        }

        private void txtSecondNum_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSecondNum.Text))
            {
                errNhapSo.SetError(txtSecondNum, "Không được để trống!");
            }
            else
                errNhapSo.SetError(txtSecondNum, string.Empty);
        }
    }
}
