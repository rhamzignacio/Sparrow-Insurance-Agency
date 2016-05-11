namespace Sparrow_Insurance_Agency.Car_Insurance
{
    partial class PolicyList
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxPaid = new System.Windows.Forms.CheckBox();
            this.checkBoxUnpaid = new System.Windows.Forms.CheckBox();
            this.checkBoxVoid = new System.Windows.Forms.CheckBox();
            this.checkBoxCancel = new System.Windows.Forms.CheckBox();
            this.lblVoidCount = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.lblPaidCount = new System.Windows.Forms.Label();
            this.lblUnpaidCount = new System.Windows.Forms.Label();
            this.lblCancelCount = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listViewPolicy = new System.Windows.Forms.ListView();
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelTop.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.label2);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Controls.Add(this.groupBox1);
            this.panelTop.Controls.Add(this.btnRefresh);
            this.panelTop.Controls.Add(this.btnOpen);
            this.panelTop.Controls.Add(this.btnSearch);
            this.panelTop.Controls.Add(this.btnNew);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1142, 69);
            this.panelTop.TabIndex = 0;
            this.panelTop.Paint += new System.Windows.Forms.PaintEventHandler(this.lblVoidCount_Paint);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1089, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 73;
            this.label2.Text = "Search";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1046, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 72;
            this.label1.Text = "Refresh";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxPaid);
            this.groupBox1.Controls.Add(this.checkBoxUnpaid);
            this.groupBox1.Controls.Add(this.checkBoxVoid);
            this.groupBox1.Controls.Add(this.checkBoxCancel);
            this.groupBox1.Controls.Add(this.lblVoidCount);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.lblTotal);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.lblPaidCount);
            this.groupBox1.Controls.Add(this.lblUnpaidCount);
            this.groupBox1.Controls.Add(this.lblCancelCount);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(240, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(579, 56);
            this.groupBox1.TabIndex = 71;
            this.groupBox1.TabStop = false;
            // 
            // checkBoxPaid
            // 
            this.checkBoxPaid.AutoSize = true;
            this.checkBoxPaid.Checked = true;
            this.checkBoxPaid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxPaid.Location = new System.Drawing.Point(363, 16);
            this.checkBoxPaid.Name = "checkBoxPaid";
            this.checkBoxPaid.Size = new System.Drawing.Size(15, 14);
            this.checkBoxPaid.TabIndex = 77;
            this.checkBoxPaid.UseVisualStyleBackColor = true;
            this.checkBoxPaid.CheckedChanged += new System.EventHandler(this.checkBoxPaid_CheckedChanged);
            // 
            // checkBoxUnpaid
            // 
            this.checkBoxUnpaid.AutoSize = true;
            this.checkBoxUnpaid.Checked = true;
            this.checkBoxUnpaid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxUnpaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxUnpaid.Location = new System.Drawing.Point(246, 16);
            this.checkBoxUnpaid.Name = "checkBoxUnpaid";
            this.checkBoxUnpaid.Size = new System.Drawing.Size(15, 14);
            this.checkBoxUnpaid.TabIndex = 76;
            this.checkBoxUnpaid.UseVisualStyleBackColor = true;
            this.checkBoxUnpaid.CheckedChanged += new System.EventHandler(this.checkBoxUnpaid_CheckedChanged);
            // 
            // checkBoxVoid
            // 
            this.checkBoxVoid.AutoSize = true;
            this.checkBoxVoid.Checked = true;
            this.checkBoxVoid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxVoid.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxVoid.Location = new System.Drawing.Point(129, 16);
            this.checkBoxVoid.Name = "checkBoxVoid";
            this.checkBoxVoid.Size = new System.Drawing.Size(15, 14);
            this.checkBoxVoid.TabIndex = 75;
            this.checkBoxVoid.UseVisualStyleBackColor = true;
            this.checkBoxVoid.CheckedChanged += new System.EventHandler(this.checkBoxVoid_CheckedChanged);
            // 
            // checkBoxCancel
            // 
            this.checkBoxCancel.AutoSize = true;
            this.checkBoxCancel.Checked = true;
            this.checkBoxCancel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxCancel.Location = new System.Drawing.Point(12, 16);
            this.checkBoxCancel.Name = "checkBoxCancel";
            this.checkBoxCancel.Size = new System.Drawing.Size(15, 14);
            this.checkBoxCancel.TabIndex = 74;
            this.checkBoxCancel.UseVisualStyleBackColor = true;
            this.checkBoxCancel.CheckedChanged += new System.EventHandler(this.checkBoxCancel_CheckedChanged);
            // 
            // lblVoidCount
            // 
            this.lblVoidCount.AutoSize = true;
            this.lblVoidCount.BackColor = System.Drawing.SystemColors.Control;
            this.lblVoidCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVoidCount.ForeColor = System.Drawing.Color.DimGray;
            this.lblVoidCount.Location = new System.Drawing.Point(147, 34);
            this.lblVoidCount.Name = "lblVoidCount";
            this.lblVoidCount.Size = new System.Drawing.Size(91, 13);
            this.lblVoidCount.TabIndex = 8;
            this.lblVoidCount.Text = "100000000000";
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.LightSteelBlue;
            this.textBox5.Enabled = false;
            this.textBox5.Location = new System.Drawing.Point(150, 13);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(90, 20);
            this.textBox5.TabIndex = 7;
            this.textBox5.Text = "Void";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.BackColor = System.Drawing.SystemColors.Control;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.DimGray;
            this.lblTotal.Location = new System.Drawing.Point(480, 33);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(91, 13);
            this.lblTotal.TabIndex = 6;
            this.lblTotal.Text = "100000000000";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.textBox4.Enabled = false;
            this.textBox4.Location = new System.Drawing.Point(481, 13);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(90, 20);
            this.textBox4.TabIndex = 5;
            this.textBox4.Text = "Total";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPaidCount
            // 
            this.lblPaidCount.AutoSize = true;
            this.lblPaidCount.BackColor = System.Drawing.SystemColors.Control;
            this.lblPaidCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaidCount.ForeColor = System.Drawing.Color.DimGray;
            this.lblPaidCount.Location = new System.Drawing.Point(383, 34);
            this.lblPaidCount.Name = "lblPaidCount";
            this.lblPaidCount.Size = new System.Drawing.Size(91, 13);
            this.lblPaidCount.TabIndex = 4;
            this.lblPaidCount.Text = "100000000000";
            // 
            // lblUnpaidCount
            // 
            this.lblUnpaidCount.AutoSize = true;
            this.lblUnpaidCount.BackColor = System.Drawing.SystemColors.Control;
            this.lblUnpaidCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnpaidCount.ForeColor = System.Drawing.Color.DimGray;
            this.lblUnpaidCount.Location = new System.Drawing.Point(264, 33);
            this.lblUnpaidCount.Name = "lblUnpaidCount";
            this.lblUnpaidCount.Size = new System.Drawing.Size(91, 13);
            this.lblUnpaidCount.TabIndex = 3;
            this.lblUnpaidCount.Text = "100000000000";
            // 
            // lblCancelCount
            // 
            this.lblCancelCount.AutoSize = true;
            this.lblCancelCount.BackColor = System.Drawing.SystemColors.Control;
            this.lblCancelCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCancelCount.ForeColor = System.Drawing.Color.DimGray;
            this.lblCancelCount.Location = new System.Drawing.Point(36, 34);
            this.lblCancelCount.Name = "lblCancelCount";
            this.lblCancelCount.Size = new System.Drawing.Size(91, 13);
            this.lblCancelCount.TabIndex = 1;
            this.lblCancelCount.Text = "100000000000";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.PaleGreen;
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(385, 14);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(90, 20);
            this.textBox3.TabIndex = 2;
            this.textBox3.Text = "Paid";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.Yellow;
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(267, 13);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(90, 20);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "Unpaid";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Tomato;
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(29, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(90, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Canceled";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.Transparent;
            this.btnRefresh.BackgroundImage = global::Sparrow_Insurance_Agency.Properties.Resources.Button_Refresh_icon;
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Location = new System.Drawing.Point(1049, 5);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(37, 33);
            this.btnRefresh.TabIndex = 70;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnOpen.FlatAppearance.BorderSize = 0;
            this.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpen.Location = new System.Drawing.Point(126, 12);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(108, 34);
            this.btnOpen.TabIndex = 69;
            this.btnOpen.Text = " Open";
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.BackgroundImage = global::Sparrow_Insurance_Agency.Properties.Resources.Zoom_icon;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(1092, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(37, 33);
            this.btnSearch.TabIndex = 69;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Location = new System.Drawing.Point(12, 12);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(108, 34);
            this.btnNew.TabIndex = 68;
            this.btnNew.Text = "New ";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.listViewPolicy);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 69);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1142, 556);
            this.panel1.TabIndex = 1;
            // 
            // listViewPolicy
            // 
            this.listViewPolicy.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader10,
            this.columnHeader12,
            this.columnHeader1,
            this.columnHeader11,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.listViewPolicy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewPolicy.FullRowSelect = true;
            this.listViewPolicy.GridLines = true;
            this.listViewPolicy.Location = new System.Drawing.Point(0, 0);
            this.listViewPolicy.MultiSelect = false;
            this.listViewPolicy.Name = "listViewPolicy";
            this.listViewPolicy.Size = new System.Drawing.Size(1142, 556);
            this.listViewPolicy.TabIndex = 0;
            this.listViewPolicy.UseCompatibleStateImageBehavior = false;
            this.listViewPolicy.View = System.Windows.Forms.View.Details;
            this.listViewPolicy.DoubleClick += new System.EventHandler(this.listViewPolicy_DoubleClick);
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "ID";
            this.columnHeader10.Width = 0;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "#";
            this.columnHeader12.Width = 36;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Status";
            this.columnHeader1.Width = 87;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Classification";
            this.columnHeader11.Width = 78;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Policy No";
            this.columnHeader2.Width = 168;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Assured";
            this.columnHeader3.Width = 180;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Plate No";
            this.columnHeader4.Width = 102;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Motor No";
            this.columnHeader5.Width = 117;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Serial/Chasis No";
            this.columnHeader6.Width = 119;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Total";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader7.Width = 100;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Paid";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader8.Width = 100;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Balance";
            this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader9.Width = 100;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 625);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1142, 32);
            this.panel2.TabIndex = 2;
            // 
            // PolicyList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 657);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelTop);
            this.Name = "PolicyList";
            this.Text = "Policy List";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.ListView listViewPolicy;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPaidCount;
        private System.Windows.Forms.Label lblUnpaidCount;
        private System.Windows.Forms.Label lblCancelCount;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label lblVoidCount;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.CheckBox checkBoxCancel;
        private System.Windows.Forms.CheckBox checkBoxPaid;
        private System.Windows.Forms.CheckBox checkBoxUnpaid;
        private System.Windows.Forms.CheckBox checkBoxVoid;
    }
}