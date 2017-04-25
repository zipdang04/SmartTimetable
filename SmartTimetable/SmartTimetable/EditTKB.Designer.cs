    namespace SmartTimetable
{
    partial class EditTKB
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cboThuData = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.PaleGreen;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 113);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(454, 320);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::SmartTimetable.Properties.Resources.Delete;
            this.btnDelete.Location = new System.Drawing.Point(256, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(82, 58);
            this.btnDelete.TabIndex = 4;
            this.toolTip1.SetToolTip(this.btnDelete, "Xoá");
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = global::SmartTimetable.Properties.Resources.Edit;
            this.btnEdit.Location = new System.Drawing.Point(134, 12);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(82, 58);
            this.btnEdit.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btnEdit, "Sửa");
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnExit
            // 
            this.btnExit.Image = global::SmartTimetable.Properties.Resources.Exit;
            this.btnExit.Location = new System.Drawing.Point(378, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(82, 58);
            this.btnExit.TabIndex = 5;
            this.toolTip1.SetToolTip(this.btnExit, "Thoát");
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::SmartTimetable.Properties.Resources.New;
            this.btnAdd.Location = new System.Drawing.Point(12, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(82, 58);
            this.btnAdd.TabIndex = 2;
            this.toolTip1.SetToolTip(this.btnAdd, "Thêm");
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cboThuData
            // 
            this.cboThuData.ForeColor = System.Drawing.Color.Black;
            this.cboThuData.Items.AddRange(new object[] {
            "Tất cả",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "CN"});
            this.cboThuData.Location = new System.Drawing.Point(48, 86);
            this.cboThuData.Name = "cboThuData";
            this.cboThuData.Size = new System.Drawing.Size(75, 21);
            this.cboThuData.TabIndex = 6;
            this.cboThuData.Text = "Tất cả";
            this.cboThuData.SelectedValueChanged += new System.EventHandler(this.cboThuData_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(10, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Thứ";
            // 
            // EditTKB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.ClientSize = new System.Drawing.Size(475, 445);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboThuData);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dataGridView1);
            this.Name = "EditTKB";
            this.Text = "Sửa Thời khoá biểu";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EditTKB2_FormClosed);
            this.Load += new System.EventHandler(this.EditTKB2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox cboThuData;
        private System.Windows.Forms.Label label1;
    }
}