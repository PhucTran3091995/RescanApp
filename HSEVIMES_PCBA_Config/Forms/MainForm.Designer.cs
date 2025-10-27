namespace HSEVIMES_PCBA_Config
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            btnScan = new Button();
            lblMessage = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            label1 = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            txtBarcode = new TextBox();
            btnPrinter = new Button();
            tableLayoutPanel3 = new TableLayoutPanel();
            lblResult = new Label();
            tableLayoutPanel4 = new TableLayoutPanel();
            gridResults = new DataGridView();
            tbRescanLabel = new TableLayoutPanel();
            tableLayoutPanel6 = new TableLayoutPanel();
            lblWO = new Label();
            lblPartNo = new Label();
            lblModelSuffix = new Label();
            lblModelName = new Label();
            label6 = new Label();
            label3 = new Label();
            label4 = new Label();
            tableLayoutPanel11 = new TableLayoutPanel();
            lblProdDate = new Label();
            lblQty = new Label();
            tableLayoutPanel10 = new TableLayoutPanel();
            label8 = new Label();
            label7 = new Label();
            label5 = new Label();
            label9 = new Label();
            label10 = new Label();
            lblYearPBA = new Label();
            lblMonthPBA = new Label();
            picBarcodePBA = new PictureBox();
            label2 = new Label();
            tabPage2 = new TabPage();
            tableLayoutPanel5 = new TableLayoutPanel();
            tableLayoutPanel7 = new TableLayoutPanel();
            label11 = new Label();
            tableLayoutPanel9 = new TableLayoutPanel();
            btnDeletePBA = new Button();
            txtDeletePBA = new TextBox();
            tableLayoutPanel8 = new TableLayoutPanel();
            label12 = new Label();
            tableLayoutPanel12 = new TableLayoutPanel();
            tableLayoutPanel13 = new TableLayoutPanel();
            btnDownLoad = new Button();
            btnSearchPBA = new Button();
            txtSearchPBA = new TextBox();
            dtPBADate = new DateTimePicker();
            grSearchPBAdata = new DataGridView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            tabPage3 = new TabPage();
            tableLayoutPanel14 = new TableLayoutPanel();
            tableLayoutPanel15 = new TableLayoutPanel();
            lbCom = new Label();
            cbCheckCom = new ComboBox();
            lblCheckServer = new Label();
            tableLayoutPanel16 = new TableLayoutPanel();
            btnCheckSQL = new Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridResults).BeginInit();
            tbRescanLabel.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            tableLayoutPanel11.SuspendLayout();
            tableLayoutPanel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picBarcodePBA).BeginInit();
            tabPage2.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            tableLayoutPanel7.SuspendLayout();
            tableLayoutPanel9.SuspendLayout();
            tableLayoutPanel8.SuspendLayout();
            tableLayoutPanel12.SuspendLayout();
            tableLayoutPanel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)grSearchPBAdata).BeginInit();
            tabPage3.SuspendLayout();
            tableLayoutPanel14.SuspendLayout();
            tableLayoutPanel15.SuspendLayout();
            tableLayoutPanel16.SuspendLayout();
            SuspendLayout();
            // 
            // btnScan
            // 
            btnScan.Anchor = AnchorStyles.None;
            btnScan.Location = new Point(10, 31);
            btnScan.Name = "btnScan";
            btnScan.Size = new Size(80, 47);
            btnScan.TabIndex = 3;
            btnScan.Text = "Scan";
            btnScan.UseVisualStyleBackColor = true;
            btnScan.Click += btnScan_Click;
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.BackColor = SystemColors.ActiveCaption;
            lblMessage.Dock = DockStyle.Fill;
            lblMessage.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMessage.Location = new Point(329, 0);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(1100, 109);
            lblMessage.TabIndex = 3;
            lblMessage.Text = "Message";
            lblMessage.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(341, 751);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(300, 150);
            flowLayoutPanel1.TabIndex = 5;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1454, 1119);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(tableLayoutPanel1);
            tabPage1.Location = new Point(4, 34);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1446, 1081);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Main";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 2);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel4, 0, 3);
            tableLayoutPanel1.Controls.Add(tbRescanLabel, 0, 4);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 13.04348F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10.869565F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10.869565F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10.869565F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 54.3478279F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 10F));
            tableLayoutPanel1.Size = new Size(1440, 1075);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(64, 64, 64);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(4, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1432, 132);
            panel1.TabIndex = 7;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(21, 31);
            label1.Name = "label1";
            label1.Size = new Size(332, 65);
            label1.TabIndex = 0;
            label1.Text = "HSMRESCAN";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = Color.Transparent;
            tableLayoutPanel2.ColumnCount = 4;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 500F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 118F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(txtBarcode, 1, 0);
            tableLayoutPanel2.Controls.Add(btnScan, 0, 0);
            tableLayoutPanel2.Controls.Add(btnPrinter, 2, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(4, 143);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(1432, 109);
            tableLayoutPanel2.TabIndex = 10;
            // 
            // txtBarcode
            // 
            txtBarcode.Anchor = AnchorStyles.Left;
            txtBarcode.BackColor = Color.FromArgb(255, 255, 192);
            txtBarcode.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBarcode.Location = new Point(103, 32);
            txtBarcode.Name = "txtBarcode";
            txtBarcode.Size = new Size(494, 45);
            txtBarcode.TabIndex = 0;
            // 
            // btnPrinter
            // 
            btnPrinter.Anchor = AnchorStyles.None;
            btnPrinter.Image = (Image)resources.GetObject("btnPrinter.Image");
            btnPrinter.Location = new Point(626, 17);
            btnPrinter.Name = "btnPrinter";
            btnPrinter.Size = new Size(66, 74);
            btnPrinter.TabIndex = 4;
            btnPrinter.UseVisualStyleBackColor = true;
            btnPrinter.Click += btnPrinter_Click;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 21.0526314F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 32F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 78.94737F));
            tableLayoutPanel3.Controls.Add(lblResult, 0, 0);
            tableLayoutPanel3.Controls.Add(lblMessage, 2, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(4, 259);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(1432, 109);
            tableLayoutPanel3.TabIndex = 11;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.BackColor = SystemColors.ActiveCaption;
            lblResult.Dock = DockStyle.Fill;
            lblResult.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblResult.ForeColor = SystemColors.ActiveCaptionText;
            lblResult.Location = new Point(3, 0);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(288, 109);
            lblResult.TabIndex = 5;
            lblResult.Text = "Results";
            lblResult.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Controls.Add(gridResults, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(4, 375);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Size = new Size(1432, 109);
            tableLayoutPanel4.TabIndex = 12;
            // 
            // gridResults
            // 
            gridResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridResults.Dock = DockStyle.Fill;
            gridResults.Location = new Point(3, 3);
            gridResults.Name = "gridResults";
            gridResults.RowHeadersWidth = 62;
            gridResults.Size = new Size(1426, 103);
            gridResults.TabIndex = 0;
            // 
            // tbRescanLabel
            // 
            tbRescanLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            tbRescanLabel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tbRescanLabel.ColumnCount = 1;
            tbRescanLabel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tbRescanLabel.Controls.Add(tableLayoutPanel6, 0, 1);
            tbRescanLabel.Controls.Add(label2, 0, 0);
            tbRescanLabel.Location = new Point(203, 491);
            tbRescanLabel.Name = "tbRescanLabel";
            tbRescanLabel.RowCount = 2;
            tbRescanLabel.RowStyles.Add(new RowStyle(SizeType.Percent, 18.26087F));
            tbRescanLabel.RowStyles.Add(new RowStyle(SizeType.Percent, 81.73913F));
            tbRescanLabel.Size = new Size(1033, 569);
            tbRescanLabel.TabIndex = 13;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel6.ColumnCount = 3;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel6.Controls.Add(lblWO, 1, 3);
            tableLayoutPanel6.Controls.Add(lblPartNo, 1, 2);
            tableLayoutPanel6.Controls.Add(lblModelSuffix, 1, 1);
            tableLayoutPanel6.Controls.Add(lblModelName, 1, 0);
            tableLayoutPanel6.Controls.Add(label6, 0, 3);
            tableLayoutPanel6.Controls.Add(label3, 0, 0);
            tableLayoutPanel6.Controls.Add(label4, 0, 1);
            tableLayoutPanel6.Controls.Add(tableLayoutPanel11, 1, 4);
            tableLayoutPanel6.Controls.Add(tableLayoutPanel10, 0, 4);
            tableLayoutPanel6.Controls.Add(label5, 0, 2);
            tableLayoutPanel6.Controls.Add(label9, 2, 2);
            tableLayoutPanel6.Controls.Add(label10, 2, 3);
            tableLayoutPanel6.Controls.Add(lblYearPBA, 2, 0);
            tableLayoutPanel6.Controls.Add(lblMonthPBA, 2, 1);
            tableLayoutPanel6.Controls.Add(picBarcodePBA, 2, 4);
            tableLayoutPanel6.Dock = DockStyle.Fill;
            tableLayoutPanel6.Location = new Point(4, 108);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 5;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 17.05435F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 17.05435F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 16.77477F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 16.3721771F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 32.7443542F));
            tableLayoutPanel6.Size = new Size(1025, 457);
            tableLayoutPanel6.TabIndex = 0;
            // 
            // lblWO
            // 
            lblWO.Anchor = AnchorStyles.None;
            lblWO.AutoSize = true;
            lblWO.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWO.Location = new Point(485, 255);
            lblWO.Name = "lblWO";
            lblWO.Size = new Size(54, 25);
            lblWO.TabIndex = 16;
            lblWO.Text = "W/O";
            // 
            // lblPartNo
            // 
            lblPartNo.Anchor = AnchorStyles.None;
            lblPartNo.AutoSize = true;
            lblPartNo.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPartNo.Location = new Point(474, 180);
            lblPartNo.Name = "lblPartNo";
            lblPartNo.Size = new Size(76, 25);
            lblPartNo.TabIndex = 15;
            lblPartNo.Text = "PartNo";
            // 
            // lblModelSuffix
            // 
            lblModelSuffix.Anchor = AnchorStyles.None;
            lblModelSuffix.AutoSize = true;
            lblModelSuffix.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblModelSuffix.Location = new Point(450, 103);
            lblModelSuffix.Name = "lblModelSuffix";
            lblModelSuffix.Size = new Size(123, 25);
            lblModelSuffix.TabIndex = 14;
            lblModelSuffix.Text = "ModelSuffix";
            // 
            // lblModelName
            // 
            lblModelName.Anchor = AnchorStyles.None;
            lblModelName.AutoSize = true;
            lblModelName.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblModelName.Location = new Point(451, 26);
            lblModelName.Name = "lblModelName";
            lblModelName.Size = new Size(121, 25);
            lblModelName.TabIndex = 13;
            lblModelName.Text = "ModelName";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.None;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(144, 255);
            label6.Name = "label6";
            label6.Size = new Size(54, 25);
            label6.TabIndex = 7;
            label6.Text = "W/O";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(108, 26);
            label3.Name = "label3";
            label3.Size = new Size(126, 25);
            label3.TabIndex = 4;
            label3.Text = "Model Name";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(107, 103);
            label4.Name = "label4";
            label4.Size = new Size(128, 25);
            label4.TabIndex = 5;
            label4.Text = "Model Suffix";
            // 
            // tableLayoutPanel11
            // 
            tableLayoutPanel11.ColumnCount = 1;
            tableLayoutPanel11.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel11.Controls.Add(lblProdDate, 0, 1);
            tableLayoutPanel11.Controls.Add(lblQty, 0, 0);
            tableLayoutPanel11.Location = new Point(345, 308);
            tableLayoutPanel11.Name = "tableLayoutPanel11";
            tableLayoutPanel11.RowCount = 2;
            tableLayoutPanel11.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel11.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel11.Size = new Size(334, 144);
            tableLayoutPanel11.TabIndex = 3;
            // 
            // lblProdDate
            // 
            lblProdDate.Anchor = AnchorStyles.None;
            lblProdDate.AutoSize = true;
            lblProdDate.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProdDate.Location = new Point(118, 95);
            lblProdDate.Name = "lblProdDate";
            lblProdDate.Size = new Size(97, 25);
            lblProdDate.TabIndex = 18;
            lblProdDate.Text = "ProdDate";
            // 
            // lblQty
            // 
            lblQty.Anchor = AnchorStyles.None;
            lblQty.Font = new Font("Segoe UI Black", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblQty.Location = new Point(3, 0);
            lblQty.Name = "lblQty";
            lblQty.Size = new Size(328, 72);
            lblQty.TabIndex = 17;
            lblQty.Text = "Q/ty";
            lblQty.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel10
            // 
            tableLayoutPanel10.ColumnCount = 1;
            tableLayoutPanel10.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel10.Controls.Add(label8, 0, 1);
            tableLayoutPanel10.Controls.Add(label7, 0, 0);
            tableLayoutPanel10.Location = new Point(4, 308);
            tableLayoutPanel10.Name = "tableLayoutPanel10";
            tableLayoutPanel10.RowCount = 2;
            tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel10.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel10.Size = new Size(331, 144);
            tableLayoutPanel10.TabIndex = 2;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.None;
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(114, 95);
            label8.Name = "label8";
            label8.Size = new Size(102, 25);
            label8.TabIndex = 9;
            label8.Text = "Prod Date";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.None;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(124, 23);
            label7.Name = "label7";
            label7.Size = new Size(83, 25);
            label7.TabIndex = 8;
            label7.Text = "Box Qty";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(130, 180);
            label5.Name = "label5";
            label5.Size = new Size(81, 25);
            label5.TabIndex = 6;
            label5.Text = "Part No";
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.None;
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(785, 180);
            label9.Name = "label9";
            label9.Size = new Size(136, 25);
            label9.TabIndex = 8;
            label9.Text = "☑️ Inspection";
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.None;
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(824, 255);
            label10.Name = "label10";
            label10.Size = new Size(59, 25);
            label10.TabIndex = 9;
            label10.Text = "None";
            // 
            // lblYearPBA
            // 
            lblYearPBA.Anchor = AnchorStyles.None;
            lblYearPBA.AutoSize = true;
            lblYearPBA.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblYearPBA.Location = new Point(806, 26);
            lblYearPBA.Name = "lblYearPBA";
            lblYearPBA.Size = new Size(95, 25);
            lblYearPBA.TabIndex = 11;
            lblYearPBA.Text = "Year PBA";
            // 
            // lblMonthPBA
            // 
            lblMonthPBA.Anchor = AnchorStyles.None;
            lblMonthPBA.AutoSize = true;
            lblMonthPBA.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMonthPBA.Location = new Point(796, 103);
            lblMonthPBA.Name = "lblMonthPBA";
            lblMonthPBA.Size = new Size(114, 25);
            lblMonthPBA.TabIndex = 12;
            lblMonthPBA.Text = "Month PBA";
            // 
            // picBarcodePBA
            // 
            picBarcodePBA.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            picBarcodePBA.Location = new Point(775, 308);
            picBarcodePBA.Name = "picBarcodePBA";
            picBarcodePBA.Size = new Size(156, 145);
            picBarcodePBA.TabIndex = 17;
            picBarcodePBA.TabStop = false;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Black", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(213, 25);
            label2.Name = "label2";
            label2.Size = new Size(607, 54);
            label2.TabIndex = 1;
            label2.Text = "Material Tag (Supplier : HSM)";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(tableLayoutPanel5);
            tabPage2.Location = new Point(4, 34);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1446, 1081);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Search PBA";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 1;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel5.Controls.Add(tableLayoutPanel7, 0, 0);
            tableLayoutPanel5.Controls.Add(tableLayoutPanel8, 0, 1);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(3, 3);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 2;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 15.3488369F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 84.65116F));
            tableLayoutPanel5.Size = new Size(1440, 1075);
            tableLayoutPanel5.TabIndex = 0;
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel7.ColumnCount = 1;
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30.3347282F));
            tableLayoutPanel7.Controls.Add(label11, 0, 0);
            tableLayoutPanel7.Controls.Add(tableLayoutPanel9, 0, 1);
            tableLayoutPanel7.Dock = DockStyle.Fill;
            tableLayoutPanel7.Location = new Point(3, 3);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 2;
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Absolute, 98F));
            tableLayoutPanel7.Size = new Size(1434, 159);
            tableLayoutPanel7.TabIndex = 0;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI Black", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(4, 1);
            label11.Name = "label11";
            label11.Size = new Size(197, 58);
            label11.TabIndex = 2;
            label11.Text = "Delete PBA";
            label11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel9
            // 
            tableLayoutPanel9.ColumnCount = 2;
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableLayoutPanel9.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel9.Controls.Add(btnDeletePBA, 0, 0);
            tableLayoutPanel9.Controls.Add(txtDeletePBA, 1, 0);
            tableLayoutPanel9.Dock = DockStyle.Fill;
            tableLayoutPanel9.Location = new Point(4, 63);
            tableLayoutPanel9.Name = "tableLayoutPanel9";
            tableLayoutPanel9.RowCount = 1;
            tableLayoutPanel9.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel9.Size = new Size(1426, 92);
            tableLayoutPanel9.TabIndex = 0;
            // 
            // btnDeletePBA
            // 
            btnDeletePBA.Anchor = AnchorStyles.None;
            btnDeletePBA.BackColor = Color.FromArgb(255, 128, 128);
            btnDeletePBA.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDeletePBA.ForeColor = SystemColors.ButtonHighlight;
            btnDeletePBA.Location = new Point(3, 9);
            btnDeletePBA.Name = "btnDeletePBA";
            btnDeletePBA.Size = new Size(194, 73);
            btnDeletePBA.TabIndex = 0;
            btnDeletePBA.Text = "PBA Delete";
            btnDeletePBA.UseVisualStyleBackColor = false;
            btnDeletePBA.Click += btnDeletePBA_Click;
            // 
            // txtDeletePBA
            // 
            txtDeletePBA.Anchor = AnchorStyles.Left;
            txtDeletePBA.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDeletePBA.Location = new Point(203, 23);
            txtDeletePBA.Name = "txtDeletePBA";
            txtDeletePBA.Size = new Size(453, 45);
            txtDeletePBA.TabIndex = 1;
            // 
            // tableLayoutPanel8
            // 
            tableLayoutPanel8.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel8.ColumnCount = 1;
            tableLayoutPanel8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel8.Controls.Add(label12, 0, 0);
            tableLayoutPanel8.Controls.Add(tableLayoutPanel12, 0, 1);
            tableLayoutPanel8.Dock = DockStyle.Fill;
            tableLayoutPanel8.Location = new Point(3, 168);
            tableLayoutPanel8.Name = "tableLayoutPanel8";
            tableLayoutPanel8.RowCount = 2;
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 10.3651352F));
            tableLayoutPanel8.RowStyles.Add(new RowStyle(SizeType.Percent, 89.6348648F));
            tableLayoutPanel8.Size = new Size(1434, 904);
            tableLayoutPanel8.TabIndex = 1;
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI Black", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(4, 1);
            label12.Name = "label12";
            label12.Size = new Size(200, 93);
            label12.TabIndex = 3;
            label12.Text = "Search PBA";
            label12.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel12
            // 
            tableLayoutPanel12.ColumnCount = 1;
            tableLayoutPanel12.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel12.Controls.Add(tableLayoutPanel13, 0, 0);
            tableLayoutPanel12.Controls.Add(grSearchPBAdata, 0, 1);
            tableLayoutPanel12.Dock = DockStyle.Fill;
            tableLayoutPanel12.Location = new Point(4, 98);
            tableLayoutPanel12.Name = "tableLayoutPanel12";
            tableLayoutPanel12.RowCount = 2;
            tableLayoutPanel12.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel12.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel12.Size = new Size(1426, 802);
            tableLayoutPanel12.TabIndex = 0;
            // 
            // tableLayoutPanel13
            // 
            tableLayoutPanel13.ColumnCount = 4;
            tableLayoutPanel13.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tableLayoutPanel13.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 500F));
            tableLayoutPanel13.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 500F));
            tableLayoutPanel13.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel13.Controls.Add(btnDownLoad, 3, 0);
            tableLayoutPanel13.Controls.Add(btnSearchPBA, 0, 0);
            tableLayoutPanel13.Controls.Add(txtSearchPBA, 1, 0);
            tableLayoutPanel13.Controls.Add(dtPBADate, 2, 0);
            tableLayoutPanel13.Dock = DockStyle.Fill;
            tableLayoutPanel13.Location = new Point(3, 3);
            tableLayoutPanel13.Name = "tableLayoutPanel13";
            tableLayoutPanel13.RowCount = 1;
            tableLayoutPanel13.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel13.Size = new Size(1420, 94);
            tableLayoutPanel13.TabIndex = 0;
            // 
            // btnDownLoad
            // 
            btnDownLoad.Anchor = AnchorStyles.Left;
            btnDownLoad.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDownLoad.Location = new Point(1203, 12);
            btnDownLoad.Name = "btnDownLoad";
            btnDownLoad.Size = new Size(117, 69);
            btnDownLoad.TabIndex = 3;
            btnDownLoad.Text = "Download";
            btnDownLoad.UseVisualStyleBackColor = true;
            btnDownLoad.Click += btnDownLoad_Click;
            // 
            // btnSearchPBA
            // 
            btnSearchPBA.Anchor = AnchorStyles.None;
            btnSearchPBA.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSearchPBA.Location = new Point(3, 12);
            btnSearchPBA.Name = "btnSearchPBA";
            btnSearchPBA.Size = new Size(194, 69);
            btnSearchPBA.TabIndex = 2;
            btnSearchPBA.Text = "Go";
            btnSearchPBA.UseVisualStyleBackColor = true;
            btnSearchPBA.Click += btnSearchPBA_Click;
            // 
            // txtSearchPBA
            // 
            txtSearchPBA.Anchor = AnchorStyles.None;
            txtSearchPBA.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSearchPBA.Location = new Point(224, 24);
            txtSearchPBA.Name = "txtSearchPBA";
            txtSearchPBA.Size = new Size(452, 45);
            txtSearchPBA.TabIndex = 0;
            // 
            // dtPBADate
            // 
            dtPBADate.Anchor = AnchorStyles.None;
            dtPBADate.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtPBADate.Location = new Point(718, 24);
            dtPBADate.Name = "dtPBADate";
            dtPBADate.Size = new Size(464, 45);
            dtPBADate.TabIndex = 1;
            // 
            // grSearchPBAdata
            // 
            grSearchPBAdata.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grSearchPBAdata.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            grSearchPBAdata.DefaultCellStyle = dataGridViewCellStyle3;
            grSearchPBAdata.Dock = DockStyle.Fill;
            grSearchPBAdata.EditMode = DataGridViewEditMode.EditOnF2;
            grSearchPBAdata.Location = new Point(3, 103);
            grSearchPBAdata.Name = "grSearchPBAdata";
            grSearchPBAdata.RowHeadersWidth = 62;
            grSearchPBAdata.Size = new Size(1420, 696);
            grSearchPBAdata.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(24, 24);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(tableLayoutPanel14);
            tabPage3.Location = new Point(4, 34);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1446, 1081);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Setting";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel14
            // 
            tableLayoutPanel14.ColumnCount = 2;
            tableLayoutPanel14.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel14.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel14.Controls.Add(tableLayoutPanel15, 0, 0);
            tableLayoutPanel14.Controls.Add(tableLayoutPanel16, 1, 0);
            tableLayoutPanel14.Dock = DockStyle.Fill;
            tableLayoutPanel14.Location = new Point(3, 3);
            tableLayoutPanel14.Name = "tableLayoutPanel14";
            tableLayoutPanel14.RowCount = 2;
            tableLayoutPanel14.RowStyles.Add(new RowStyle(SizeType.Percent, 9.465792F));
            tableLayoutPanel14.RowStyles.Add(new RowStyle(SizeType.Percent, 90.53421F));
            tableLayoutPanel14.Size = new Size(1440, 1075);
            tableLayoutPanel14.TabIndex = 0;
            // 
            // tableLayoutPanel15
            // 
            tableLayoutPanel15.ColumnCount = 2;
            tableLayoutPanel15.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24.2296925F));
            tableLayoutPanel15.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75.77031F));
            tableLayoutPanel15.Controls.Add(lbCom, 0, 0);
            tableLayoutPanel15.Controls.Add(cbCheckCom, 1, 0);
            tableLayoutPanel15.Dock = DockStyle.Fill;
            tableLayoutPanel15.Location = new Point(3, 3);
            tableLayoutPanel15.Name = "tableLayoutPanel15";
            tableLayoutPanel15.RowCount = 1;
            tableLayoutPanel15.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel15.Size = new Size(714, 95);
            tableLayoutPanel15.TabIndex = 0;
            // 
            // lbCom
            // 
            lbCom.Anchor = AnchorStyles.None;
            lbCom.AutoSize = true;
            lbCom.Location = new Point(61, 35);
            lbCom.Name = "lbCom";
            lbCom.Size = new Size(50, 25);
            lbCom.TabIndex = 0;
            lbCom.Text = "Com";
            // 
            // cbCheckCom
            // 
            cbCheckCom.Anchor = AnchorStyles.Left;
            cbCheckCom.FormattingEnabled = true;
            cbCheckCom.Location = new Point(176, 21);
            cbCheckCom.Name = "cbCheckCom";
            cbCheckCom.Size = new Size(201, 33);
            cbCheckCom.TabIndex = 1;
            // 
            // lblCheckServer
            // 
            lblCheckServer.Anchor = AnchorStyles.None;
            lblCheckServer.AutoSize = true;
            lblCheckServer.Location = new Point(42, 35);
            lblCheckServer.Name = "lblCheckServer";
            lblCheckServer.Size = new Size(59, 25);
            lblCheckServer.TabIndex = 1;
            lblCheckServer.Text = "Check";
            // 
            // tableLayoutPanel16
            // 
            tableLayoutPanel16.ColumnCount = 2;
            tableLayoutPanel16.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.0280113F));
            tableLayoutPanel16.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 79.97199F));
            tableLayoutPanel16.Controls.Add(lblCheckServer, 0, 0);
            tableLayoutPanel16.Controls.Add(btnCheckSQL, 1, 0);
            tableLayoutPanel16.Dock = DockStyle.Fill;
            tableLayoutPanel16.Location = new Point(723, 3);
            tableLayoutPanel16.Name = "tableLayoutPanel16";
            tableLayoutPanel16.RowCount = 1;
            tableLayoutPanel16.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel16.Size = new Size(714, 95);
            tableLayoutPanel16.TabIndex = 2;
            // 
            // btnCheckSQL
            // 
            btnCheckSQL.Anchor = AnchorStyles.Left;
            btnCheckSQL.Location = new Point(146, 25);
            btnCheckSQL.Name = "btnCheckSQL";
            btnCheckSQL.Size = new Size(159, 44);
            btnCheckSQL.TabIndex = 2;
            btnCheckSQL.Text = "Check Server";
            btnCheckSQL.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1454, 1119);
            Controls.Add(tabControl1);
            Controls.Add(flowLayoutPanel1);
            Name = "MainForm";
            Text = "Rescan App";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridResults).EndInit();
            tbRescanLabel.ResumeLayout(false);
            tbRescanLabel.PerformLayout();
            tableLayoutPanel6.ResumeLayout(false);
            tableLayoutPanel6.PerformLayout();
            tableLayoutPanel11.ResumeLayout(false);
            tableLayoutPanel11.PerformLayout();
            tableLayoutPanel10.ResumeLayout(false);
            tableLayoutPanel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picBarcodePBA).EndInit();
            tabPage2.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel7.ResumeLayout(false);
            tableLayoutPanel7.PerformLayout();
            tableLayoutPanel9.ResumeLayout(false);
            tableLayoutPanel9.PerformLayout();
            tableLayoutPanel8.ResumeLayout(false);
            tableLayoutPanel8.PerformLayout();
            tableLayoutPanel12.ResumeLayout(false);
            tableLayoutPanel13.ResumeLayout(false);
            tableLayoutPanel13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)grSearchPBAdata).EndInit();
            tabPage3.ResumeLayout(false);
            tableLayoutPanel14.ResumeLayout(false);
            tableLayoutPanel15.ResumeLayout(false);
            tableLayoutPanel15.PerformLayout();
            tableLayoutPanel16.ResumeLayout(false);
            tableLayoutPanel16.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button btnScan;
        private Label lblMessage;
        private FlowLayoutPanel flowLayoutPanel1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TableLayoutPanel tableLayoutPanel1;
        private TabPage tabPage2;
        private Label lblResult;
        private Panel panel1;
        private Label label1;
        private TextBox txtBarcode;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel4;
        private DataGridView gridResults;
        private TableLayoutPanel tbRescanLabel;
        private TableLayoutPanel tableLayoutPanel6;
        private TableLayoutPanel tableLayoutPanel10;
        private TableLayoutPanel tableLayoutPanel11;
        private Label label3;
        private Label label2;
        private Label label6;
        private Label label4;
        private Label label8;
        private Label label7;
        private Label label5;
        private Label label9;
        private Label lblWO;
        private Label lblPartNo;
        private Label lblModelSuffix;
        private Label lblModelName;
        private Label lblProdDate;
        private Label lblQty;
        private Label label10;
        private Label lblYearPBA;
        private Label lblMonthPBA;
        private PictureBox picBarcodePBA;
        private Button btnPrinter;
        private TableLayoutPanel tableLayoutPanel5;
        private TableLayoutPanel tableLayoutPanel7;
        private TableLayoutPanel tableLayoutPanel8;
        private ContextMenuStrip contextMenuStrip1;
        private Button btnDeletePBA;
        private Label label11;
        private TableLayoutPanel tableLayoutPanel9;
        private TextBox txtDeletePBA;
        private Label label12;
        private TableLayoutPanel tableLayoutPanel12;
        private TableLayoutPanel tableLayoutPanel13;
        private DataGridView grSearchPBAdata;
        private TextBox txtSearchPBA;
        private DateTimePicker dtPBADate;
        private Button btnSearchPBA;
        private Button btnDownLoad;
        private TabPage tabPage3;
        private TableLayoutPanel tableLayoutPanel14;
        private TableLayoutPanel tableLayoutPanel15;
        private Label lbCom;
        private ComboBox cbCheckCom;
        private Label lblCheckServer;
        private TableLayoutPanel tableLayoutPanel16;
        private Button btnCheckSQL;
    }
}
