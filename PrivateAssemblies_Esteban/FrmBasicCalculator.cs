using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CalculatorPrivateAssembly;
namespace PrivateAssemblies_Esteban
{
    public partial class FrmBasicCalculator : Form
    {
        public FrmBasicCalculator()
        {
            InitializeComponent();
            InitializeComboBox();
        }
        private void InitializeComboBox()
        {

            cmbOperator.Items.Add("+");
            cmbOperator.Items.Add("-");
            cmbOperator.Items.Add("*");
            cmbOperator.Items.Add("/");
            cmbOperator.SelectedIndex = 0;
        }

        private void btnCompute_Click(object sender, EventArgs e)
        {
            try
            {

                float num1 = float.Parse(txtInput1.Text);
                float num2 = float.Parse(txtInput2.Text);
                string selectedOperator = cmbOperator.SelectedItem.ToString();
                float result = 0;


                switch (selectedOperator)
                {
                    case "+":
                        result = BasicComputation.Add(num1, num2);
                        break;
                    case "-":
                        result = BasicComputation.Subtract(num1, num2);
                        break;
                    case "*":
                        result = BasicComputation.Multiply(num1, num2);
                        break;
                    case "/":
                        result = BasicComputation.Divide(num1, num2);
                        break;
                    default:
                        lblResult.Text = "Error: Invalid Operator";
                        return;
                }


                lblResult.Text = result.ToString("N0");



            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numerical input in both fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblResult.Text = "Error";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblResult.Text = "Error";
            }
        }
    }
}
