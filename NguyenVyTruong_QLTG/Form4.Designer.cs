﻿namespace NguyenVyTruong_QLTG
{
    partial class Form4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ht = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ngaygd = new System.Windows.Forms.TextBox();
            this.mbc = new System.Windows.Forms.TextBox();
            this.mtk = new System.Windows.Forms.TextBox();
            this.tien = new System.Windows.Forms.TextBox();
            this.mgd = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataSet1 = new NguyenVyTruong_QLTG.DataSet1();
            this.gIAODICHBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gIAODICHTableAdapter = new NguyenVyTruong_QLTG.DataSet1TableAdapters.GIAODICHTableAdapter();
            this.mAGDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mATKDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mABUUCUCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nGAYGDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sOTIENDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hINHTHUCGDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gIAODICHBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ht
            // 
            this.ht.Location = new System.Drawing.Point(164, 304);
            this.ht.Name = "ht";
            this.ht.Size = new System.Drawing.Size(212, 20);
            this.ht.TabIndex = 54;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(33, 302);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 20);
            this.label7.TabIndex = 53;
            this.label7.Text = "Hình thức ";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(238, 454);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 34);
            this.button5.TabIndex = 52;
            this.button5.Text = "Tìm kiếm";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Salmon;
            this.button4.Location = new System.Drawing.Point(285, 542);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 34);
            this.button4.TabIndex = 51;
            this.button4.Text = "Đóng";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(81, 454);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 34);
            this.button3.TabIndex = 50;
            this.button3.Text = "Xóa";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(238, 386);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 34);
            this.button2.TabIndex = 49;
            this.button2.Text = "Sửa";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(81, 386);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 34);
            this.button1.TabIndex = 48;
            this.button1.Text = "Thêm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mAGDDataGridViewTextBoxColumn,
            this.mATKDataGridViewTextBoxColumn,
            this.mABUUCUCDataGridViewTextBoxColumn,
            this.nGAYGDDataGridViewTextBoxColumn,
            this.sOTIENDataGridViewTextBoxColumn,
            this.hINHTHUCGDDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.gIAODICHBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(411, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(646, 564);
            this.dataGridView1.TabIndex = 47;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // ngaygd
            // 
            this.ngaygd.Location = new System.Drawing.Point(164, 222);
            this.ngaygd.Name = "ngaygd";
            this.ngaygd.Size = new System.Drawing.Size(212, 20);
            this.ngaygd.TabIndex = 46;
            // 
            // mbc
            // 
            this.mbc.Location = new System.Drawing.Point(164, 185);
            this.mbc.Name = "mbc";
            this.mbc.Size = new System.Drawing.Size(212, 20);
            this.mbc.TabIndex = 45;
            // 
            // mtk
            // 
            this.mtk.Location = new System.Drawing.Point(164, 145);
            this.mtk.Name = "mtk";
            this.mtk.Size = new System.Drawing.Size(212, 20);
            this.mtk.TabIndex = 44;
            // 
            // tien
            // 
            this.tien.Location = new System.Drawing.Point(164, 263);
            this.tien.Name = "tien";
            this.tien.Size = new System.Drawing.Size(212, 20);
            this.tien.TabIndex = 43;
            // 
            // mgd
            // 
            this.mgd.Location = new System.Drawing.Point(164, 106);
            this.mgd.Name = "mgd";
            this.mgd.Size = new System.Drawing.Size(212, 20);
            this.mgd.TabIndex = 42;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(33, 261);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 20);
            this.label6.TabIndex = 41;
            this.label6.Text = "Số tiền";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(33, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 20);
            this.label5.TabIndex = 40;
            this.label5.Text = "Ngày giao dịch";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(33, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 20);
            this.label4.TabIndex = 39;
            this.label4.Text = "Mã bưu cục";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(33, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.TabIndex = 38;
            this.label3.Text = "Mã tài khoản";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 20);
            this.label2.TabIndex = 37;
            this.label2.Text = "Mã giao dịch";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 25);
            this.label1.TabIndex = 36;
            this.label1.Text = "Quản lý giao dịch";
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gIAODICHBindingSource
            // 
            this.gIAODICHBindingSource.DataMember = "GIAODICH";
            this.gIAODICHBindingSource.DataSource = this.dataSet1;
            // 
            // gIAODICHTableAdapter
            // 
            this.gIAODICHTableAdapter.ClearBeforeFill = true;
            // 
            // mAGDDataGridViewTextBoxColumn
            // 
            this.mAGDDataGridViewTextBoxColumn.DataPropertyName = "MAGD";
            this.mAGDDataGridViewTextBoxColumn.HeaderText = "MAGD";
            this.mAGDDataGridViewTextBoxColumn.Name = "mAGDDataGridViewTextBoxColumn";
            // 
            // mATKDataGridViewTextBoxColumn
            // 
            this.mATKDataGridViewTextBoxColumn.DataPropertyName = "MATK";
            this.mATKDataGridViewTextBoxColumn.HeaderText = "MATK";
            this.mATKDataGridViewTextBoxColumn.Name = "mATKDataGridViewTextBoxColumn";
            // 
            // mABUUCUCDataGridViewTextBoxColumn
            // 
            this.mABUUCUCDataGridViewTextBoxColumn.DataPropertyName = "MABUUCUC";
            this.mABUUCUCDataGridViewTextBoxColumn.HeaderText = "MABUUCUC";
            this.mABUUCUCDataGridViewTextBoxColumn.Name = "mABUUCUCDataGridViewTextBoxColumn";
            // 
            // nGAYGDDataGridViewTextBoxColumn
            // 
            this.nGAYGDDataGridViewTextBoxColumn.DataPropertyName = "NGAYGD";
            this.nGAYGDDataGridViewTextBoxColumn.HeaderText = "NGAYGD";
            this.nGAYGDDataGridViewTextBoxColumn.Name = "nGAYGDDataGridViewTextBoxColumn";
            // 
            // sOTIENDataGridViewTextBoxColumn
            // 
            this.sOTIENDataGridViewTextBoxColumn.DataPropertyName = "SOTIEN";
            this.sOTIENDataGridViewTextBoxColumn.HeaderText = "SOTIEN";
            this.sOTIENDataGridViewTextBoxColumn.Name = "sOTIENDataGridViewTextBoxColumn";
            // 
            // hINHTHUCGDDataGridViewTextBoxColumn
            // 
            this.hINHTHUCGDDataGridViewTextBoxColumn.DataPropertyName = "HINHTHUCGD";
            this.hINHTHUCGDDataGridViewTextBoxColumn.HeaderText = "HINHTHUCGD";
            this.hINHTHUCGDDataGridViewTextBoxColumn.Name = "hINHTHUCGDDataGridViewTextBoxColumn";
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 597);
            this.Controls.Add(this.ht);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.ngaygd);
            this.Controls.Add(this.mbc);
            this.Controls.Add(this.mtk);
            this.Controls.Add(this.tien);
            this.Controls.Add(this.mgd);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form4";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gIAODICHBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ht;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox ngaygd;
        private System.Windows.Forms.TextBox mbc;
        private System.Windows.Forms.TextBox mtk;
        private System.Windows.Forms.TextBox tien;
        private System.Windows.Forms.TextBox mgd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource gIAODICHBindingSource;
        private DataSet1TableAdapters.GIAODICHTableAdapter gIAODICHTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn mAGDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mATKDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mABUUCUCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nGAYGDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sOTIENDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hINHTHUCGDDataGridViewTextBoxColumn;
    }
}