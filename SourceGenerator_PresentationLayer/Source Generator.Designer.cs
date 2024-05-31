namespace SourceGenerator_PresentationLayer
{
    partial class Form1
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
            this.btnGenerate = new System.Windows.Forms.Button();
            this.txtDataAccessLayer = new System.Windows.Forms.TextBox();
            this.tabSource = new System.Windows.Forms.TabControl();
            this.tabDataAccess = new System.Windows.Forms.TabPage();
            this.tabBusinessLayer = new System.Windows.Forms.TabPage();
            this.txtBusinessLayer = new System.Windows.Forms.TextBox();
            this.txtDatabaseName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtBusinessNameSpace = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtBuisnessClassName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDataAccessClassName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDataAccessNameSpace = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAddColumn = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbSearchBy = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cbIsPK = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbIsColumnNullable = new System.Windows.Forms.CheckBox();
            this.cbColumnType = new System.Windows.Forms.ComboBox();
            this.txtColumnName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbGenBusinessLayer = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dgvTableColumns = new System.Windows.Forms.DataGridView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnResetColumns = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.columnType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.columnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPK = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.columnNullable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.columnSearchBy = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tabSource.SuspendLayout();
            this.tabDataAccess.SuspendLayout();
            this.tabBusinessLayer.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableColumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(462, 679);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(85, 65);
            this.btnGenerate.TabIndex = 1;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // txtDataAccessLayer
            // 
            this.txtDataAccessLayer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDataAccessLayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataAccessLayer.Location = new System.Drawing.Point(6, 6);
            this.txtDataAccessLayer.MaxLength = 90000;
            this.txtDataAccessLayer.Multiline = true;
            this.txtDataAccessLayer.Name = "txtDataAccessLayer";
            this.txtDataAccessLayer.ReadOnly = true;
            this.txtDataAccessLayer.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDataAccessLayer.Size = new System.Drawing.Size(660, 463);
            this.txtDataAccessLayer.TabIndex = 0;
            // 
            // tabSource
            // 
            this.tabSource.Controls.Add(this.tabDataAccess);
            this.tabSource.Controls.Add(this.tabBusinessLayer);
            this.tabSource.Location = new System.Drawing.Point(12, 12);
            this.tabSource.Name = "tabSource";
            this.tabSource.SelectedIndex = 0;
            this.tabSource.Size = new System.Drawing.Size(670, 501);
            this.tabSource.TabIndex = 2;
            // 
            // tabDataAccess
            // 
            this.tabDataAccess.Controls.Add(this.txtDataAccessLayer);
            this.tabDataAccess.Location = new System.Drawing.Point(4, 22);
            this.tabDataAccess.Name = "tabDataAccess";
            this.tabDataAccess.Padding = new System.Windows.Forms.Padding(3);
            this.tabDataAccess.Size = new System.Drawing.Size(662, 475);
            this.tabDataAccess.TabIndex = 0;
            this.tabDataAccess.Text = "Data Access Layer";
            this.tabDataAccess.UseVisualStyleBackColor = true;
            // 
            // tabBusinessLayer
            // 
            this.tabBusinessLayer.Controls.Add(this.txtBusinessLayer);
            this.tabBusinessLayer.Location = new System.Drawing.Point(4, 22);
            this.tabBusinessLayer.Name = "tabBusinessLayer";
            this.tabBusinessLayer.Padding = new System.Windows.Forms.Padding(3);
            this.tabBusinessLayer.Size = new System.Drawing.Size(662, 475);
            this.tabBusinessLayer.TabIndex = 1;
            this.tabBusinessLayer.Text = "Business Layer";
            this.tabBusinessLayer.UseVisualStyleBackColor = true;
            // 
            // txtBusinessLayer
            // 
            this.txtBusinessLayer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBusinessLayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusinessLayer.Location = new System.Drawing.Point(6, 6);
            this.txtBusinessLayer.MaxLength = 90000;
            this.txtBusinessLayer.Multiline = true;
            this.txtBusinessLayer.Name = "txtBusinessLayer";
            this.txtBusinessLayer.ReadOnly = true;
            this.txtBusinessLayer.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBusinessLayer.Size = new System.Drawing.Size(644, 463);
            this.txtBusinessLayer.TabIndex = 1;
            // 
            // txtDatabaseName
            // 
            this.txtDatabaseName.Location = new System.Drawing.Point(98, 20);
            this.txtDatabaseName.Name = "txtDatabaseName";
            this.txtDatabaseName.Size = new System.Drawing.Size(175, 20);
            this.txtDatabaseName.TabIndex = 3;
            this.txtDatabaseName.Text = "DB";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Database Name :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtUserName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtDatabaseName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(16, 529);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(306, 136);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Database Info";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(98, 58);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(175, 20);
            this.txtUserName.TabIndex = 7;
            this.txtUserName.Text = "sa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "UserName :";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(98, 96);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(175, 20);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.Text = "sa123456";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Password :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtBusinessNameSpace);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtBuisnessClassName);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtDataAccessClassName);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtDataAccessNameSpace);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtTableName);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(16, 671);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(306, 193);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Class Info";
            // 
            // txtBusinessNameSpace
            // 
            this.txtBusinessNameSpace.Location = new System.Drawing.Point(141, 90);
            this.txtBusinessNameSpace.Name = "txtBusinessNameSpace";
            this.txtBusinessNameSpace.Size = new System.Drawing.Size(132, 20);
            this.txtBusinessNameSpace.TabIndex = 13;
            this.txtBusinessNameSpace.Text = "OnlineStore";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 93);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(117, 13);
            this.label14.TabIndex = 14;
            this.label14.Text = "Business Name Space :";
            // 
            // txtBuisnessClassName
            // 
            this.txtBuisnessClassName.Location = new System.Drawing.Point(141, 156);
            this.txtBuisnessClassName.Name = "txtBuisnessClassName";
            this.txtBuisnessClassName.Size = new System.Drawing.Size(132, 20);
            this.txtBuisnessClassName.TabIndex = 11;
            this.txtBuisnessClassName.Text = "clsPerson";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 159);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(113, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "Buisness Class Name :";
            // 
            // txtDataAccessClassName
            // 
            this.txtDataAccessClassName.Location = new System.Drawing.Point(141, 121);
            this.txtDataAccessClassName.Name = "txtDataAccessClassName";
            this.txtDataAccessClassName.Size = new System.Drawing.Size(132, 20);
            this.txtDataAccessClassName.TabIndex = 9;
            this.txtDataAccessClassName.Text = "clsDataAccessPerson";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Data Access Class Name :";
            // 
            // txtDataAccessNameSpace
            // 
            this.txtDataAccessNameSpace.Location = new System.Drawing.Point(141, 58);
            this.txtDataAccessNameSpace.Name = "txtDataAccessNameSpace";
            this.txtDataAccessNameSpace.Size = new System.Drawing.Size(132, 20);
            this.txtDataAccessNameSpace.TabIndex = 7;
            this.txtDataAccessNameSpace.Text = "OnlineStore";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Data Access Name Space :";
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(98, 20);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(175, 20);
            this.txtTableName.TabIndex = 3;
            this.txtTableName.Text = "People";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Table Name :";
            // 
            // btnAddColumn
            // 
            this.btnAddColumn.Location = new System.Drawing.Point(864, 488);
            this.btnAddColumn.Name = "btnAddColumn";
            this.btnAddColumn.Size = new System.Drawing.Size(114, 25);
            this.btnAddColumn.TabIndex = 11;
            this.btnAddColumn.Text = "Add Column";
            this.btnAddColumn.UseVisualStyleBackColor = true;
            this.btnAddColumn.Click += new System.EventHandler(this.btnAddColumn_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbSearchBy);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.cbIsPK);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.cbIsColumnNullable);
            this.groupBox3.Controls.Add(this.cbColumnType);
            this.groupBox3.Controls.Add(this.txtColumnName);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(800, 300);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(344, 182);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Columns Info";
            // 
            // cbSearchBy
            // 
            this.cbSearchBy.AutoSize = true;
            this.cbSearchBy.Location = new System.Drawing.Point(310, 138);
            this.cbSearchBy.Name = "cbSearchBy";
            this.cbSearchBy.Size = new System.Drawing.Size(15, 14);
            this.cbSearchBy.TabIndex = 14;
            this.cbSearchBy.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(253, 139);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 13);
            this.label13.TabIndex = 13;
            this.label13.Text = "SearchBy:";
            // 
            // cbIsPK
            // 
            this.cbIsPK.AutoSize = true;
            this.cbIsPK.Location = new System.Drawing.Point(75, 139);
            this.cbIsPK.Name = "cbIsPK";
            this.cbIsPK.Size = new System.Drawing.Size(15, 14);
            this.cbIsPK.TabIndex = 12;
            this.cbIsPK.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(43, 139);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "PK :";
            // 
            // cbIsColumnNullable
            // 
            this.cbIsColumnNullable.AutoSize = true;
            this.cbIsColumnNullable.Location = new System.Drawing.Point(202, 139);
            this.cbIsColumnNullable.Name = "cbIsColumnNullable";
            this.cbIsColumnNullable.Size = new System.Drawing.Size(15, 14);
            this.cbIsColumnNullable.TabIndex = 10;
            this.cbIsColumnNullable.UseVisualStyleBackColor = true;
            // 
            // cbColumnType
            // 
            this.cbColumnType.DisplayMember = "0";
            this.cbColumnType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColumnType.FormattingEnabled = true;
            this.cbColumnType.Items.AddRange(new object[] {
            "bool",
            "byte",
            "datetime",
            "decimal",
            "int",
            "string"});
            this.cbColumnType.Location = new System.Drawing.Point(101, 36);
            this.cbColumnType.Name = "cbColumnType";
            this.cbColumnType.Size = new System.Drawing.Size(224, 21);
            this.cbColumnType.Sorted = true;
            this.cbColumnType.TabIndex = 9;
            // 
            // txtColumnName
            // 
            this.txtColumnName.Location = new System.Drawing.Point(101, 72);
            this.txtColumnName.Name = "txtColumnName";
            this.txtColumnName.Size = new System.Drawing.Size(224, 20);
            this.txtColumnName.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Name :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(145, 140);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Nullable :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Type :";
            // 
            // cbGenBusinessLayer
            // 
            this.cbGenBusinessLayer.AutoSize = true;
            this.cbGenBusinessLayer.Checked = true;
            this.cbGenBusinessLayer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbGenBusinessLayer.Location = new System.Drawing.Point(624, 792);
            this.cbGenBusinessLayer.Name = "cbGenBusinessLayer";
            this.cbGenBusinessLayer.Size = new System.Drawing.Size(15, 14);
            this.cbGenBusinessLayer.TabIndex = 14;
            this.cbGenBusinessLayer.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(562, 764);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(134, 13);
            this.label11.TabIndex = 13;
            this.label11.Text = "Generate Business Layer ?";
            // 
            // dgvTableColumns
            // 
            this.dgvTableColumns.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvTableColumns.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTableColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTableColumns.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnType,
            this.columnName,
            this.columnPK,
            this.columnNullable,
            this.columnSearchBy});
            this.dgvTableColumns.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvTableColumns.Location = new System.Drawing.Point(688, 34);
            this.dgvTableColumns.Name = "dgvTableColumns";
            this.dgvTableColumns.Size = new System.Drawing.Size(546, 260);
            this.dgvTableColumns.TabIndex = 10;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(593, 679);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(85, 65);
            this.btnCopy.TabIndex = 15;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnResetColumns
            // 
            this.btnResetColumns.Location = new System.Drawing.Point(984, 488);
            this.btnResetColumns.Name = "btnResetColumns";
            this.btnResetColumns.Size = new System.Drawing.Size(114, 25);
            this.btnResetColumns.TabIndex = 16;
            this.btnResetColumns.Text = "Reset Columns";
            this.btnResetColumns.UseVisualStyleBackColor = true;
            this.btnResetColumns.Click += new System.EventHandler(this.btnResetColumns_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(714, 680);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(85, 65);
            this.btnReset.TabIndex = 17;
            this.btnReset.Text = "Reset All";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // columnType
            // 
            this.columnType.HeaderText = "Type";
            this.columnType.Items.AddRange(new object[] {
            "int",
            "string",
            "byte",
            "decimal",
            "DateTime",
            "bool"});
            this.columnType.Name = "columnType";
            this.columnType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.columnType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // columnName
            // 
            this.columnName.HeaderText = "Name";
            this.columnName.Name = "columnName";
            // 
            // columnPK
            // 
            this.columnPK.HeaderText = "PK";
            this.columnPK.Name = "columnPK";
            // 
            // columnNullable
            // 
            this.columnNullable.HeaderText = "Nullable";
            this.columnNullable.Name = "columnNullable";
            // 
            // columnSearchBy
            // 
            this.columnSearchBy.HeaderText = "SearchBy";
            this.columnSearchBy.Name = "columnSearchBy";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1236, 876);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnResetColumns);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.cbGenBusinessLayer);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnAddColumn);
            this.Controls.Add(this.dgvTableColumns);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabSource);
            this.Controls.Add(this.btnGenerate);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Source Generator";
            this.tabSource.ResumeLayout(false);
            this.tabDataAccess.ResumeLayout(false);
            this.tabDataAccess.PerformLayout();
            this.tabBusinessLayer.ResumeLayout(false);
            this.tabBusinessLayer.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableColumns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.TextBox txtDataAccessLayer;
        private System.Windows.Forms.TabControl tabSource;
        private System.Windows.Forms.TabPage tabDataAccess;
        private System.Windows.Forms.TabPage tabBusinessLayer;
        private System.Windows.Forms.TextBox txtBusinessLayer;
        private System.Windows.Forms.TextBox txtDatabaseName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDataAccessNameSpace;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDataAccessClassName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAddColumn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtColumnName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox cbIsColumnNullable;
        private System.Windows.Forms.ComboBox cbColumnType;
        private System.Windows.Forms.CheckBox cbIsPK;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox cbGenBusinessLayer;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dgvTableColumns;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnResetColumns;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox txtBuisnessClassName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox cbSearchBy;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtBusinessNameSpace;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridViewComboBoxColumn columnType;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn columnPK;
        private System.Windows.Forms.DataGridViewCheckBoxColumn columnNullable;
        private System.Windows.Forms.DataGridViewCheckBoxColumn columnSearchBy;
    }
}

