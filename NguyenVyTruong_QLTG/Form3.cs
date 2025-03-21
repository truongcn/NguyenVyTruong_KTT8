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
    public partial class Form3 : Form
    {

        private string connectionString = ConfigurationManager.ConnectionStrings["OracleConnection"].ConnectionString;

        public Form3()
        {
            InitializeComponent();
        }

        private OracleConnection GetConnection()
        {
            return new OracleConnection(connectionString);
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            try
            {
                this.tAIKHOANTableAdapter.Fill(this.dataSet1.TAIKHOAN);
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
                    string query = "INSERT INTO TAIKHOAN (MaTK, HotenKH, Diachi, CCCD, MaBuuCuc, NgaymoTK) " +
                                   "VALUES (:MaTK, :HotenKH, :Diachi, :CCCD, :MaBuuCuc, :NgaymoTK)";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(":MaTK", OracleDbType.Varchar2).Value = mtk.Text;
                        cmd.Parameters.Add(":HotenKH", OracleDbType.Varchar2).Value = htk.Text;
                        cmd.Parameters.Add(":Diachi", OracleDbType.Varchar2).Value = diachi.Text;
                        cmd.Parameters.Add(":CCCD", OracleDbType.Varchar2).Value = cccd.Text;
                        cmd.Parameters.Add(":MaBuuCuc", OracleDbType.Varchar2).Value = mbc.Text;

                        // Chuyển đổi ngày  sang kiểu Date trước khi đưa vào Oracle
                        DateTime NgaymoTK;
                        if (DateTime.TryParse(ngaymtk.Text, out NgaymoTK))
                        {
                            cmd.Parameters.Add(":NgaymoTK", OracleDbType.Date).Value = NgaymoTK;
                        }
                        else
                        {
                            MessageBox.Show("❌ Ngày không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("✅ Thêm dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.tAIKHOANTableAdapter.Fill(this.dataSet1.TAIKHOAN); // Cập nhật DataGridView
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
                mtk.Text = selectedRow.Cells[0].Value?.ToString() ?? "";
                htk.Text = selectedRow.Cells[1].Value?.ToString() ?? "";
                diachi.Text = selectedRow.Cells[2].Value?.ToString() ?? "";
                cccd.Text = selectedRow.Cells[3].Value?.ToString() ?? "";
                mbc.Text = selectedRow.Cells[4].Value?.ToString() ?? "";
                ngaymtk.Text = selectedRow.Cells[5].Value != DBNull.Value
                    ? Convert.ToDateTime(selectedRow.Cells[5].Value).ToString("yyyy-MM-dd") : "";
            }
        }

        //sửa
        private void button2_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu chưa chọn sinh viên nào
            if (string.IsNullOrEmpty(mbc.Text))
            {
                MessageBox.Show("⚠ Vui lòng chọn một tài khoản trước khi sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (OracleConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE TAIKHOAN SET HotenKH = :HotenKH, Diachi = :Diachi, CCCD = :CCCD, MaBuuCuc = :MaBuuCuc, NgaymoTK = TO_DATE(:NgaymoTK, 'YYYY-MM-DD') " +
                                   "WHERE MaTK = :MaTK";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        // Gán tham số từ TextBox
                        cmd.Parameters.Add(":HotenKH", OracleDbType.Varchar2).Value = htk.Text;
                        cmd.Parameters.Add(":Diachi", OracleDbType.Varchar2).Value = diachi.Text;
                        cmd.Parameters.Add(":CCCD", OracleDbType.Varchar2).Value = cccd.Text;
                        cmd.Parameters.Add(":MaBuuCuc", OracleDbType.Varchar2).Value = mbc.Text;
                        cmd.Parameters.Add(":NgaymoTK", OracleDbType.Varchar2).Value = ngaymtk.Text;
                        cmd.Parameters.Add(":MaTK", OracleDbType.Varchar2).Value = mtk.Text;

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("✅ Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.tAIKHOANTableAdapter.Fill(this.dataSet1.TAIKHOAN);
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
                if (string.IsNullOrEmpty(mbc.Text))
                {
                    MessageBox.Show("⚠ Vui lòng nhập Mã tài khoản muốn xóa!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show("⚠ Bạn có chắc chắn muốn xóa tài khoản với mã " + mtk.Text + " không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    return;
                }

                using (OracleConnection conn = GetConnection())
                {
                    conn.Open();
                    string checkQuery = "SELECT COUNT(*) FROM TAIKHOAN WHERE MaTK = :MaTK";
                    using (OracleCommand checkCmd = new OracleCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.Add(":MaTK", OracleDbType.Varchar2).Value = mbc.Text;
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                        if (count == 0)
                        {
                            MessageBox.Show("❌ Không tìm thấy tài khoản với mã số này!");
                            return;
                        }
                    }
                    string query = "DELETE FROM TAIKHOAN WHERE MaTK = :MaTK";
                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(":MaTK", OracleDbType.Varchar2).Value = mbc.Text;
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("✅ Xóa tài khoản thành công!"); this.tAIKHOANTableAdapter.Fill(this.dataSet1.TAIKHOAN);
                            trong();
                        }
                        else
                        {
                            MessageBox.Show("❌ Không tìm thấy tài khoản với mã số này!");
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

        //tìm kiếm
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
                    string query = "SELECT * FROM TAIKHOAN WHERE 1=1";
                    List<OracleParameter> parameters = new List<OracleParameter>();

                    if (!string.IsNullOrEmpty(mtk.Text))
                    {
                        query += " AND MaTK LIKE :MaTK";
                        parameters.Add(new OracleParameter(":MaTK", OracleDbType.Varchar2) { Value = "%" + mtk.Text + "%" });
                    }
                    if (!string.IsNullOrEmpty(htk.Text))
                    {
                        query += " AND HotenKH LIKE :HotenKH";
                        parameters.Add(new OracleParameter(":HotenKH", OracleDbType.Varchar2) { Value = "%" + htk.Text + "%" });
                    }
                    if (!string.IsNullOrEmpty(diachi.Text))
                    {
                        query += " AND Diachi LIKE :Diachi";
                        parameters.Add(new OracleParameter(":Diachi", OracleDbType.Varchar2) { Value = "%" + diachi.Text + "%" });
                    }
                    if (!string.IsNullOrEmpty(cccd.Text))
                    {
                        query += " AND CCCD LIKE :CCCD";
                        parameters.Add(new OracleParameter(":CCCD", OracleDbType.Varchar2) { Value = "%" + cccd.Text + "%" });
                    }
                    if (!string.IsNullOrEmpty(mbc.Text))
                    {
                        query += " AND MaBuuCuc LIKE :MaBuuCuc";
                        parameters.Add(new OracleParameter(":MaBuuCuc", OracleDbType.Varchar2) { Value = "%" + mbc.Text + "%" });
                    }

                    if (!string.IsNullOrEmpty(ngaymtk.Text))
                    {
                        query += " AND NgaymoTK LIKE :NgaymoTK";
                        parameters.Add(new OracleParameter(":NgaymoTK", OracleDbType.Varchar2) { Value = "%" + ngaymtk.Text + "%" });
                    }

                    // Thực hiện lệnh SQL
                    using (OracleCommand command = new OracleCommand(query, conn))
                    {
                        command.Parameters.AddRange(parameters.ToArray());

                        using (OracleDataAdapter adapter = new OracleDataAdapter(command))
                        {
                            // Tạo DataSet để chứa kết quả
                            DataSet dataSet = new DataSet();
                            adapter.Fill(dataSet, "TAIKHOAN");
                            dataGridView1.DataSource = dataSet.Tables["TAIKHOAN"];
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
            diachi.Text = null;
            htk.Text = null;
            cccd.Text = null;
            ngaymtk.Text = null;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void ngaymtk_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cccd_TextChanged(object sender, EventArgs e)
        {

        }

        private void diachi_TextChanged(object sender, EventArgs e)
        {

        }

        private void htk_TextChanged(object sender, EventArgs e)
        {

        }

        private void mbc_TextChanged(object sender, EventArgs e)
        {

        }

        private void mtk_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
