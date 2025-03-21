using System;
using System.Windows.Forms;
using System.Configuration;
using Oracle.DataAccess.Client;

namespace NguyenVyTruong_QLTG
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        //bc
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 bc = new Form2();
            bc.Show();
        }

        //tk
        private void button2_Click(object sender, EventArgs e)
        {
            Form3 tk = new Form3();
            tk.Show();
        }

        //gd
        private void button3_Click(object sender, EventArgs e)
        {
            Form4 gd = new Form4();
            gd.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void KiemTraKetNoi()
        {
            var connSetting = ConfigurationManager.ConnectionStrings["OracleConnection"];
            if (connSetting == null)
            {
                MessageBox.Show("❌ Không tìm thấy chuỗi kết nối trong App.config!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string connString = connSetting.ConnectionString;

            using (OracleConnection conn = new OracleConnection(connString))
            {
                try
                {
                    conn.Open();
                    MessageBox.Show("✅ Kết nối Oracle thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("❌ Lỗi kết nối Oracle: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            KiemTraKetNoi();
        }
    }
}
