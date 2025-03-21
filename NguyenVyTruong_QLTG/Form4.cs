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
    public partial class Form4 : Form
    {

        private string connectionString = ConfigurationManager.ConnectionStrings["OracleConnection"].ConnectionString;

        public Form4()
        {
            InitializeComponent();
        }

        private OracleConnection GetConnection()
        {
            return new OracleConnection(connectionString);
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            try
            {
                this.gIAODICHTableAdapter.Fill(this.dataSet1.GIAODICH);
                MessageBox.Show("✅ Load dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //thêm
        private void button1_Click(object sender, EventArgs e)
        {
            using (OracleConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO GIAODICH (MaGD, MaTK, MaBuuCuc, NgayGD, Sotien, HinhthucGD) " +
                                   "VALUES (:MaGD, :MaTK, :MaBuuCuc, :NgayGD, :Sotien, :HinhthucGD)";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(":MaGD", OracleDbType.Varchar2).Value = mgd.Text;
                        cmd.Parameters.Add(":MaTK", OracleDbType.Varchar2).Value = mtk.Text;
                        cmd.Parameters.Add(":MaBuuCuc", OracleDbType.Varchar2).Value = mbc.Text;

                        // Chuyển đổi ngày  sang kiểu Date trước khi đưa vào Oracle
                        DateTime NgayGD;
                        if (DateTime.TryParse(ngaygd.Text, out NgayGD))
                        {
                            cmd.Parameters.Add(":NgayGD", OracleDbType.Date).Value = NgayGD;
                        }
                        else
                        {
                            MessageBox.Show("❌ Ngày không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        cmd.Parameters.Add(":Sotien", OracleDbType.Varchar2).Value = tien.Text;
                        cmd.Parameters.Add(":HinhthucGD", OracleDbType.Varchar2).Value = ht.Text;


                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("✅ Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.gIAODICHTableAdapter.Fill(this.dataSet1.GIAODICH); // Cập nhật DataGridView
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
                mgd.Text = selectedRow.Cells[0].Value?.ToString() ?? "";
                mtk.Text = selectedRow.Cells[1].Value?.ToString() ?? "";
                mbc.Text = selectedRow.Cells[2].Value?.ToString() ?? "";

                ngaygd.Text = selectedRow.Cells[3].Value != DBNull.Value
                    ? Convert.ToDateTime(selectedRow.Cells[3].Value).ToString("yyyy-MM-dd") : "";

                tien.Text = selectedRow.Cells[4].Value?.ToString() ?? "";
                ht.Text = selectedRow.Cells[5].Value?.ToString() ?? "";
                
            }
        }

        //sửa
        private void button2_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu chưa chọn sinh viên nào
            if (string.IsNullOrEmpty(mbc.Text))
            {
                MessageBox.Show("⚠ Vui lòng chọn một giao dịch trước khi sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (OracleConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE GIAODICH SET MaTk = :MaTk, MaBuuCuc = :MaBuuCuc, NgayGD = TO_DATE(:NgayGD, 'YYYY-MM-DD'), Sotien = :Sotien, HinhthucGD = :HinhthucGD " +
                                   "WHERE MaGD = :MaGD";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        // Gán tham số từ TextBox
                        cmd.Parameters.Add(":MaTk", OracleDbType.Varchar2).Value = mtk.Text;
                        cmd.Parameters.Add(":MaBuuCuc", OracleDbType.Varchar2).Value = mbc.Text;
                        cmd.Parameters.Add(":NgayGD", OracleDbType.Varchar2).Value = ngaygd.Text;
                        cmd.Parameters.Add(":Sotien", OracleDbType.Varchar2).Value = tien.Text;
                        cmd.Parameters.Add(":HinhthucGD", OracleDbType.Varchar2).Value = ht.Text;
                        cmd.Parameters.Add(":MaGD", OracleDbType.Varchar2).Value = mgd.Text;

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("✅ Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.gIAODICHTableAdapter.Fill(this.dataSet1.GIAODICH);
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

        //xóa
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(mgd.Text))
                {
                    MessageBox.Show("⚠ Vui lòng nhập Mã giao dịch muốn xóa!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show("⚠ Bạn có chắc chắn muốn xóa giao dịch với mã " + mgd.Text + " không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    return;
                }

                using (OracleConnection conn = GetConnection())
                {
                    conn.Open();
                    string checkQuery = "SELECT COUNT(*) FROM GIAODICH WHERE MaGD = :MaGD";
                    using (OracleCommand checkCmd = new OracleCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.Add(":MaGD", OracleDbType.Varchar2).Value = mgd.Text;
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                        if (count == 0)
                        {
                            MessageBox.Show("❌ Không tìm thấy giao dịch với mã số này!");
                            return;
                        }
                    }
                    string query = "DELETE FROM GIAODICH WHERE MaGD = :MaGD";
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(":MaGD", OracleDbType.Varchar2).Value = mgd.Text;
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("✅ Xóa giao dịch thành công!"); this.gIAODICHTableAdapter.Fill(this.dataSet1.GIAODICH);
                            trong();
                        }
                        else
                        {
                            MessageBox.Show("❌ Không tìm thấy giao dịch với mã số này!");
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

        //tìm
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
                    string query = "SELECT * FROM GIAODICH WHERE 1=1";
                    List<OracleParameter> parameters = new List<OracleParameter>();

                    if (!string.IsNullOrEmpty(mgd.Text))
                    {
                        query += " AND MaGD LIKE :MaGD";
                        parameters.Add(new OracleParameter(":MaGD", OracleDbType.Varchar2) { Value = "%" + mgd.Text + "%" });
                    }
                    if (!string.IsNullOrEmpty(mtk.Text))
                    {
                        query += " AND MaTK LIKE :MaTK";
                        parameters.Add(new OracleParameter(":MaTK", OracleDbType.Varchar2) { Value = "%" + mtk.Text + "%" });
                    }
                    if (!string.IsNullOrEmpty(mbc.Text))
                    {
                        query += " AND MaBuuCuc LIKE :MaBuuCuc";
                        parameters.Add(new OracleParameter(":MaBuuCuc", OracleDbType.Varchar2) { Value = "%" + mbc.Text + "%" });
                    }
                    if (!string.IsNullOrEmpty(ngaygd.Text))
                    {
                        query += " AND NgayGD LIKE :NgayGD";
                        parameters.Add(new OracleParameter(":NgayGD", OracleDbType.Varchar2) { Value = "%" + ngaygd.Text + "%" });
                    }
                    if (!string.IsNullOrEmpty(tien.Text))
                    {
                        query += " AND Sotien LIKE :Sotien";
                        parameters.Add(new OracleParameter(":Sotien", OracleDbType.Varchar2) { Value = "%" + tien.Text + "%" });
                    }

                    if (!string.IsNullOrEmpty(ht.Text))
                    {
                        query += " AND HinhthucGD LIKE :HinhthucGD";
                        parameters.Add(new OracleParameter(":HinhthucGD", OracleDbType.Varchar2) { Value = "%" + ht.Text + "%" });
                    }

                    // Thực hiện lệnh SQL
                    using (OracleCommand command = new OracleCommand(query, conn))
                    {
                        command.Parameters.AddRange(parameters.ToArray());

                        using (OracleDataAdapter adapter = new OracleDataAdapter(command))
                        {
                            // Tạo DataSet để chứa kết quả
                            DataSet dataSet = new DataSet();
                            adapter.Fill(dataSet, "GIAODICH");
                            dataGridView1.DataSource = dataSet.Tables["GIAODICH"];
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
            mtk.Text = null;
            mgd.Text = null;
            ngaygd.Text = null;
            tien.Text = null;
            ht.Text = null;
        }
    }
}
