using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using System.IO;
using System.Configuration;

namespace NguyenVyTruong_QLTG
{
    public partial class Form2 : Form
    {

        private string connectionString = ConfigurationManager.ConnectionStrings["OracleConnection"].ConnectionString;

        public Form2()
        {
            InitializeComponent();
        }

        private OracleConnection GetConnection()
        {
            return new OracleConnection(connectionString);
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                this.bUUCUCTableAdapter.Fill(this.dataSet1.BUUCUC);
                MessageBox.Show("✅ Load dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //them
        private void button1_Click(object sender, EventArgs e)
        {
            using (OracleConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO BUUCUC (MaBuuCuc, TenBuuCuc, Diachi, DienThoai, TinhTP) " +
                                   "VALUES (:MaBuuCuc, :TenBuuCuc, :Diachi, :DienThoai, :TinhTP)";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(":MaBuuCuc", OracleDbType.Varchar2).Value = mbc.Text;
                        cmd.Parameters.Add(":TenBuuCuc", OracleDbType.Varchar2).Value = tenbc.Text;
                        cmd.Parameters.Add(":Diachi", OracleDbType.Varchar2).Value = diachi.Text;
                        cmd.Parameters.Add(":DienThoai", OracleDbType.Varchar2).Value = sdt.Text;
                        cmd.Parameters.Add(":TinhTP", OracleDbType.Varchar2).Value = tinh.Text;

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("✅ Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.bUUCUCTableAdapter.Fill(this.dataSet1.BUUCUC); // Cập nhật DataGridView
                            trong();
                        }
                        else
                        {
                            MessageBox.Show("❌ Không thể thêm dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("❌ Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        //chuyển từ datagirdview sang text box
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0) // Kiểm tra có dòng nào được chọn không
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Lấy dữ liệu từ DataGridView vào TextBox, kiểm tra NULL để tránh lỗi
                mbc.Text = selectedRow.Cells[0].Value?.ToString() ?? "";
                tenbc.Text = selectedRow.Cells[1].Value?.ToString() ?? "";
                diachi.Text = selectedRow.Cells[2].Value?.ToString() ?? "";
                sdt.Text = selectedRow.Cells[3].Value?.ToString() ?? "";
                tinh.Text = selectedRow.Cells[4].Value?.ToString() ?? "";
            }
        }


        //sua
        private void button2_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu chưa chọn sinh viên nào
            if (string.IsNullOrEmpty(mbc.Text))
            {
                MessageBox.Show("⚠ Vui lòng chọn một bưu cục trước khi sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (OracleConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE BUUCUC SET TenBuuCuc = :TenBuuCuc, Diachi = :Diachi, DienThoai = :DienThoai, TinhTP = :TinhTP " +
                                   "WHERE MaBuuCuc = :MaBuuCuc";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        // Gán tham số từ TextBox
                        cmd.Parameters.Add(":TenBuuCuc", OracleDbType.Varchar2).Value = tenbc.Text;
                        cmd.Parameters.Add(":Diachi", OracleDbType.Varchar2).Value = diachi.Text;
                        cmd.Parameters.Add(":DienThoai", OracleDbType.Varchar2).Value = sdt.Text;
                        cmd.Parameters.Add(":TinhTP", OracleDbType.Varchar2).Value = tinh.Text;
                        cmd.Parameters.Add(":MaBuuCuc", OracleDbType.Varchar2).Value = mbc.Text;

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("✅ Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.bUUCUCTableAdapter.Fill(this.dataSet1.BUUCUC);
                            trong();
                        }
                        else
                        {
                            MessageBox.Show("❌ Không thể cập nhật dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("❌ Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        //xoa
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(mbc.Text))
                {
                    MessageBox.Show("⚠ Vui lòng nhập Mã bưu cục muốn xóa!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show("⚠ Bạn có chắc chắn muốn xóa bưu cục với mã " + mbc.Text + " không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    return;
                }

                using (OracleConnection conn = GetConnection())
                {
                    conn.Open();
                    string checkQuery = "SELECT COUNT(*) FROM BUUCUC WHERE MaBuuCuc = :MaBuuCuc";
                    using (OracleCommand checkCmd = new OracleCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.Add(":Msv", OracleDbType.Varchar2).Value = mbc.Text;
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                        if (count == 0)
                        {
                            MessageBox.Show("❌ Không tìm thấy sinh viên với mã số này!");
                            return;
                        }
                    }
                    string query = "DELETE FROM BUUCUC WHERE MaBuuCuc = :MaBuuCuc";
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(":MaBuuCuc", OracleDbType.Varchar2).Value = mbc.Text;
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("✅ Xóa bưu cục thành công!"); this.bUUCUCTableAdapter.Fill(this.dataSet1.BUUCUC);
                            trong();
                        }
                        else
                        {
                            MessageBox.Show("❌ Không tìm thấy bưu cục với mã số này!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi chi tiết
                MessageBox.Show("❌ Có lỗi xảy ra: " + ex.Message + "\nStack Trace: " + ex.StackTrace, "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // tim
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo kết nối đến CSDL Oracle
                using (OracleConnection conn = GetConnection())
                {
                    // Mở kết nối
                    conn.Open();

                    // Xây dựng câu lệnh SQL động
                    string query = "SELECT * FROM BUUCUC WHERE 1=1";
                    List<OracleParameter> parameters = new List<OracleParameter>();

                    if (!string.IsNullOrEmpty(mbc.Text))
                    {
                        query += " AND MaBuuCuc LIKE :MaBuuCuc";
                        parameters.Add(new OracleParameter(":MaBuuCuc", OracleDbType.Varchar2) { Value = "%" + mbc.Text + "%" });
                    }
                    if (!string.IsNullOrEmpty(tenbc.Text))
                    {
                        query += " AND TenBuuCuc LIKE :TenBuuCuc";
                        parameters.Add(new OracleParameter(":TenBuuCuc", OracleDbType.Varchar2) { Value = "%" + tenbc.Text + "%" });
                    }
                    if (!string.IsNullOrEmpty(diachi.Text))
                    {
                        query += " AND Diachi LIKE :Diachi";
                        parameters.Add(new OracleParameter(":Diachi", OracleDbType.Varchar2) { Value = "%" + diachi.Text + "%" });
                    }
                    if (!string.IsNullOrEmpty(sdt.Text))
                    {
                        query += " AND DienThoai LIKE :DienThoai";
                        parameters.Add(new OracleParameter(":DienThoai", OracleDbType.Varchar2) { Value = "%" + sdt.Text + "%" });
                    }
                    if (!string.IsNullOrEmpty(tinh.Text))
                    {
                        query += " AND TinhTP LIKE :TinhTP";
                        parameters.Add(new OracleParameter(":TinhTP", OracleDbType.Varchar2) { Value = "%" + tinh.Text + "%" });
                    }

                    // Thực hiện lệnh SQL
                    using (OracleCommand command = new OracleCommand(query, conn))
                    {
                        command.Parameters.AddRange(parameters.ToArray());

                        using (OracleDataAdapter adapter = new OracleDataAdapter(command))
                        {
                            // Tạo DataSet để chứa kết quả
                            DataSet dataSet = new DataSet();
                            adapter.Fill(dataSet, "ThongTinSinhVien");
                            dataGridView1.DataSource = dataSet.Tables["ThongTinSinhVien"];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Có lỗi xảy ra: " + ex.Message, "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void trong()
        {
            mbc.Text = null;
            tenbc.Text = null;
            diachi.Text = null;
            sdt.Text = null;
            tinh.Text = null;
        }

        
    }
}
