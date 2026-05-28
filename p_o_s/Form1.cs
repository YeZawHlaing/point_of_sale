using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace p_o_s
{
    public partial class Form1 : Form
    {
        public int lCash { get; set; }  // Property to store cash value
        private Timer timeoutTimer;

        public Form1()
        {
            InitializeComponent();

            timeoutTimer = new Timer();
            timeoutTimer.Interval = 2000; // 5000 milliseconds = 5 seconds
            timeoutTimer.Tick += TimeoutTimer_Tick; // Event handler when timer ticks
        }


        private void TimeoutTimer_Tick(object sender, EventArgs e)
        {
            // Stop the timer after 5 seconds
            timeoutTimer.Stop();

            // Enable the button again if needed
            bPay.Enabled = true;

            // Show message or perform any action after timeout
            MessageBox.Show(
    string.Format("{0,-10}: {1}\n{2,-10}: {3}\n{4,-10}: {5}\n{6,-10}: {7}",
    "Tax", lbl2.Text,
    "Total", lbl3.Text,
    "Cost", lbl4.Text,
    "Change", lbl5.Text));

            //MessageBox.Show("Tax " + lbl2.Text + '\n' + "Total " + lbl3.Text + '\n' + "Cost " + lbl4.Text + '\n' + "Change " + lbl5.Text);
        }
        public double Cost_of_privateItems()
        {
            Double sum = 0;
            int i = 0;
            for(;i < dataGridView1.RowCount; i ++)
            {
                sum = sum + Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);
            }
            return sum; 
        }


        private void AddCost()
        {
            Double tax, q;
            tax = 3.9;
            if(dataGridView1.Rows.Count>0)
            {
                lbl2.Text = String.Format("{0:c2}" , ( ( (Cost_of_privateItems() * tax) / 100 ) ) );
                lbl1.Text = String.Format("{0:c2}", (Cost_of_privateItems()));
                q = ((Cost_of_privateItems() * tax) / 100);
                lbl3.Text = String.Format("{0:c2}", ((Cost_of_privateItems() + q)));

            }
        }


        private void Change()
        {


            Double tax, q, c; 
            tax = 3.9;
            if (dataGridView1.Rows.Count > 0)
            {
                q = ((Cost_of_privateItems() * tax) / 100) + Cost_of_privateItems();
                string cWithoutDollar = lbl4.Text.Replace("$", "");
                double.TryParse(cWithoutDollar, out c);
                lbl5.Text = "" + (c-q);
                // Start the timer when the "Pay" button is clicked
                timeoutTimer.Start();
            }

        }
        Bitmap bitmap;
       
        

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bPrint_Click(object sender, EventArgs e)
        {
            try
            {
                int height = dataGridView1.Height;
                dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 2;
                bitmap = new Bitmap(dataGridView1.Width, dataGridView1.Height);
                dataGridView1.DrawToBitmap(bitmap, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
                printPreviewDialog1.PrintPreviewControl.Zoom = 1;
                printPreviewDialog1.ShowDialog();
                dataGridView1.Height = height;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                e.Graphics.DrawImage(bitmap, 0, 0);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bReset_Click(object sender, EventArgs e)
        {
          
            try
            {
                lbl1.Text = "";
                lbl2.Text = "";
                lbl3.Text = "";
                lbl4.Text = "";
                lbl5.Text = "";
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                comboBox1.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private string C()
        {
            throw new NotImplementedException();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
        }

        private void NumbersOnly(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (lbl4.Text == "0")
            {
                lbl4.Text = "";
                lbl4.Text = b.Text;

            }
            else if (b.Text == ("."))
            {
                lbl4.Text = lbl4.Text + b.Text;

            }
            else
                lbl4.Text = lbl4.Text + b.Text;

        }
        private void btn_Click(object sender,EventArgs e)
        {
            lbl4.Text ="0";
        }

        private void bRemove_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
            }
            AddCost();
            if (comboBox1.Text == "Cash")
            {
                Change();
            }
            else
            {
                lbl5.Text = "";
                
            }
        }

        private void bPay_Click(object sender, EventArgs e)
        {
            bPay.Enabled = false;
            if (comboBox1.Text == "Cash")
            {
                Change();
            }
            else
            {
                lbl5.Text = "";
                //lCash = "0";
                
            }
        }

        private void pic1_Click(object sender, EventArgs e)
        {
            Double CostofItems = 10.3;
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                if((bool)(row.Cells[0].Value="bbq"))
                {
                    row.Cells[1].Value = Double.Parse((string)row.Cells[1].Value + 1);
                    row.Cells[2].Value = Double.Parse((string)row.Cells[1].Value) * CostofItems;
                }
            }
            dataGridView1.Rows.Add("bbq", "1", CostofItems);
            AddCost();

        }
    }
}


    
