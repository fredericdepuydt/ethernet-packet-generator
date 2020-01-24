namespace PacketSender
{
    partial class PacketSender
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PacketSender));
            this.btn_send_packet = new System.Windows.Forms.Button();
            this.lbl_src_mac = new System.Windows.Forms.Label();
            this.lbl_src_ip = new System.Windows.Forms.Label();
            this.lbl_dst_ip = new System.Windows.Forms.Label();
            this.lbl_dst_mac = new System.Windows.Forms.Label();
            this.cbo_protocol = new System.Windows.Forms.ComboBox();
            this.lbl_protocol = new System.Windows.Forms.Label();
            this.w_errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.txt_dst_ip = new DepuydtControlLib.IPAddressControl();
            this.txt_dst_mac = new DepuydtControlLib.MACAddressControl();
            this.txt_src_ip = new DepuydtControlLib.IPAddressControl();
            this.txt_src_mac = new DepuydtControlLib.MACAddressControl();
            this.cbo_interface = new System.Windows.Forms.ComboBox();
            this.lbl_dst_port = new System.Windows.Forms.Label();
            this.lbl_src_port = new System.Windows.Forms.Label();
            this.txt_src_port = new System.Windows.Forms.TextBox();
            this.txt_dst_port = new System.Windows.Forms.TextBox();
            this.txt_data = new System.Windows.Forms.TextBox();
            this.lbl_data = new System.Windows.Forms.Label();
            this.lbl_interface = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txt_dcp_devicename = new System.Windows.Forms.TextBox();
            this.lbl_dcp_devicename = new System.Windows.Forms.Label();
            this.lbl_sub_protocol = new System.Windows.Forms.Label();
            this.cbo_sub_protocol = new System.Windows.Forms.ComboBox();
            this.tbr_load_percentage = new System.Windows.Forms.TrackBar();
            this.lbl_load_percentage = new System.Windows.Forms.Label();
            this.lbl_resizer = new System.Windows.Forms.Label();
            this.lbl_hdr_interface = new System.Windows.Forms.Label();
            this.lbl_hdr_protocol = new System.Windows.Forms.Label();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.lbl_separator = new System.Windows.Forms.Label();
            this.lbl_interface_mac = new System.Windows.Forms.Label();
            this.lbl_interface_ip = new System.Windows.Forms.Label();
            this.txt_interface_mac = new DepuydtControlLib.MACAddressControl();
            this.txt_interface_ip = new DepuydtControlLib.IPAddressControl();
            this.btn_interface_mac = new System.Windows.Forms.Button();
            this.btn_interface_ip = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.txt_PN_DCP_Set_IP_Address = new DepuydtControlLib.IPAddressControl();
            this.lbl_PN_DCP_Set_IP_Address = new System.Windows.Forms.Label();
            this.txt_PN_DCP_Set_IP_Subnet = new DepuydtControlLib.IPAddressControl();
            this.lbl_PN_DCP_Set_IP_Subnet = new System.Windows.Forms.Label();
            this.txt_PN_DCP_Set_IP_Gateway = new DepuydtControlLib.IPAddressControl();
            this.lbl_PN_DCP_Set_IP_Gateway = new System.Windows.Forms.Label();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            ((System.ComponentModel.ISupportInitialize)(this.w_errorProvider)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbr_load_percentage)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_send_packet
            // 
            this.btn_send_packet.Location = new System.Drawing.Point(380, 787);
            this.btn_send_packet.Name = "btn_send_packet";
            this.btn_send_packet.Size = new System.Drawing.Size(120, 23);
            this.btn_send_packet.TabIndex = 0;
            this.btn_send_packet.Text = "Send Packet";
            this.btn_send_packet.UseVisualStyleBackColor = true;
            this.btn_send_packet.Click += new System.EventHandler(this.btn_send_packet_Click);
            // 
            // lbl_src_mac
            // 
            this.lbl_src_mac.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_src_mac.Location = new System.Drawing.Point(0, 320);
            this.lbl_src_mac.Name = "lbl_src_mac";
            this.lbl_src_mac.Size = new System.Drawing.Size(94, 13);
            this.lbl_src_mac.TabIndex = 1;
            this.lbl_src_mac.Text = "Source MAC";
            this.lbl_src_mac.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lbl_src_mac.Click += new System.EventHandler(this.lbl_src_mac_Click);
            // 
            // lbl_src_ip
            // 
            this.lbl_src_ip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_src_ip.Location = new System.Drawing.Point(0, 346);
            this.lbl_src_ip.Name = "lbl_src_ip";
            this.lbl_src_ip.Size = new System.Drawing.Size(94, 13);
            this.lbl_src_ip.TabIndex = 3;
            this.lbl_src_ip.Text = "Source IP";
            this.lbl_src_ip.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_dst_ip
            // 
            this.lbl_dst_ip.Location = new System.Drawing.Point(270, 346);
            this.lbl_dst_ip.Name = "lbl_dst_ip";
            this.lbl_dst_ip.Size = new System.Drawing.Size(94, 13);
            this.lbl_dst_ip.TabIndex = 7;
            this.lbl_dst_ip.Text = "Destination IP";
            this.lbl_dst_ip.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_dst_mac
            // 
            this.lbl_dst_mac.Location = new System.Drawing.Point(270, 320);
            this.lbl_dst_mac.Name = "lbl_dst_mac";
            this.lbl_dst_mac.Size = new System.Drawing.Size(94, 13);
            this.lbl_dst_mac.TabIndex = 5;
            this.lbl_dst_mac.Text = "Destination MAC";
            this.lbl_dst_mac.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cbo_protocol
            // 
            this.cbo_protocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_protocol.FormattingEnabled = true;
            this.cbo_protocol.Location = new System.Drawing.Point(100, 246);
            this.cbo_protocol.Name = "cbo_protocol";
            this.cbo_protocol.Size = new System.Drawing.Size(400, 21);
            this.cbo_protocol.TabIndex = 9;
            this.cbo_protocol.SelectedValueChanged += new System.EventHandler(this.cbo_protocol_SelectedValueChanged);
            // 
            // lbl_protocol
            // 
            this.lbl_protocol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_protocol.Location = new System.Drawing.Point(0, 249);
            this.lbl_protocol.Name = "lbl_protocol";
            this.lbl_protocol.Size = new System.Drawing.Size(94, 13);
            this.lbl_protocol.TabIndex = 10;
            this.lbl_protocol.Text = "Protocol";
            this.lbl_protocol.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // w_errorProvider
            // 
            this.w_errorProvider.ContainerControl = this;
            // 
            // txt_dst_ip
            // 
            this.txt_dst_ip.AllowInternalTab = false;
            this.txt_dst_ip.AutoHeight = true;
            this.txt_dst_ip.BackColor = System.Drawing.SystemColors.Window;
            this.txt_dst_ip.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txt_dst_ip.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_dst_ip.Location = new System.Drawing.Point(370, 343);
            this.txt_dst_ip.MinimumSize = new System.Drawing.Size(87, 20);
            this.txt_dst_ip.Name = "txt_dst_ip";
            this.txt_dst_ip.ReadOnly = false;
            this.txt_dst_ip.Size = new System.Drawing.Size(130, 20);
            this.txt_dst_ip.TabIndex = 12;
            this.txt_dst_ip.Text = "...";
            // 
            // txt_dst_mac
            // 
            this.txt_dst_mac.AllowInternalTab = false;
            this.txt_dst_mac.AutoHeight = true;
            this.txt_dst_mac.BackColor = System.Drawing.SystemColors.Window;
            this.txt_dst_mac.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txt_dst_mac.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_dst_mac.Location = new System.Drawing.Point(370, 317);
            this.txt_dst_mac.MinimumSize = new System.Drawing.Size(129, 20);
            this.txt_dst_mac.Name = "txt_dst_mac";
            this.txt_dst_mac.ReadOnly = false;
            this.txt_dst_mac.Size = new System.Drawing.Size(130, 20);
            this.txt_dst_mac.TabIndex = 13;
            this.txt_dst_mac.Text = "-----";
            // 
            // txt_src_ip
            // 
            this.txt_src_ip.AllowInternalTab = false;
            this.txt_src_ip.AutoHeight = true;
            this.txt_src_ip.BackColor = System.Drawing.SystemColors.Window;
            this.txt_src_ip.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txt_src_ip.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_src_ip.Location = new System.Drawing.Point(100, 343);
            this.txt_src_ip.MinimumSize = new System.Drawing.Size(87, 20);
            this.txt_src_ip.Name = "txt_src_ip";
            this.txt_src_ip.ReadOnly = false;
            this.txt_src_ip.Size = new System.Drawing.Size(130, 20);
            this.txt_src_ip.TabIndex = 14;
            this.txt_src_ip.Text = "...";
            // 
            // txt_src_mac
            // 
            this.txt_src_mac.AllowInternalTab = false;
            this.txt_src_mac.AutoHeight = true;
            this.txt_src_mac.BackColor = System.Drawing.SystemColors.Window;
            this.txt_src_mac.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txt_src_mac.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_src_mac.Location = new System.Drawing.Point(100, 317);
            this.txt_src_mac.MinimumSize = new System.Drawing.Size(129, 20);
            this.txt_src_mac.Name = "txt_src_mac";
            this.txt_src_mac.ReadOnly = false;
            this.txt_src_mac.Size = new System.Drawing.Size(130, 20);
            this.txt_src_mac.TabIndex = 15;
            this.txt_src_mac.Text = "-----";
            // 
            // cbo_interface
            // 
            this.cbo_interface.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_interface.FormattingEnabled = true;
            this.cbo_interface.Location = new System.Drawing.Point(100, 83);
            this.cbo_interface.Name = "cbo_interface";
            this.cbo_interface.Size = new System.Drawing.Size(400, 21);
            this.cbo_interface.TabIndex = 16;
            this.cbo_interface.SelectedValueChanged += new System.EventHandler(this.cbo_interface_SelectedValueChanged);
            // 
            // lbl_dst_port
            // 
            this.lbl_dst_port.Location = new System.Drawing.Point(270, 372);
            this.lbl_dst_port.Name = "lbl_dst_port";
            this.lbl_dst_port.Size = new System.Drawing.Size(94, 13);
            this.lbl_dst_port.TabIndex = 19;
            this.lbl_dst_port.Text = "Destination Port";
            this.lbl_dst_port.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_src_port
            // 
            this.lbl_src_port.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_src_port.Location = new System.Drawing.Point(0, 372);
            this.lbl_src_port.Name = "lbl_src_port";
            this.lbl_src_port.Size = new System.Drawing.Size(94, 13);
            this.lbl_src_port.TabIndex = 18;
            this.lbl_src_port.Text = "Source Port";
            this.lbl_src_port.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txt_src_port
            // 
            this.txt_src_port.Location = new System.Drawing.Point(100, 369);
            this.txt_src_port.Name = "txt_src_port";
            this.txt_src_port.Size = new System.Drawing.Size(130, 20);
            this.txt_src_port.TabIndex = 20;
            // 
            // txt_dst_port
            // 
            this.txt_dst_port.Location = new System.Drawing.Point(370, 369);
            this.txt_dst_port.Name = "txt_dst_port";
            this.txt_dst_port.Size = new System.Drawing.Size(130, 20);
            this.txt_dst_port.TabIndex = 21;
            // 
            // txt_data
            // 
            this.txt_data.Location = new System.Drawing.Point(100, 683);
            this.txt_data.Multiline = true;
            this.txt_data.Name = "txt_data";
            this.txt_data.Size = new System.Drawing.Size(400, 98);
            this.txt_data.TabIndex = 22;
            this.txt_data.TextChanged += new System.EventHandler(this.txt_data_TextChanged);
            this.txt_data.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_data_KeyDown);
            this.txt_data.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_data_KeyPress);
            // 
            // lbl_data
            // 
            this.lbl_data.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_data.Location = new System.Drawing.Point(0, 686);
            this.lbl_data.Name = "lbl_data";
            this.lbl_data.Size = new System.Drawing.Size(94, 13);
            this.lbl_data.TabIndex = 23;
            this.lbl_data.Text = "Data";
            this.lbl_data.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_interface
            // 
            this.lbl_interface.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_interface.Location = new System.Drawing.Point(0, 91);
            this.lbl_interface.Name = "lbl_interface";
            this.lbl_interface.Size = new System.Drawing.Size(94, 13);
            this.lbl_interface.TabIndex = 25;
            this.lbl_interface.Text = "Interface";
            this.lbl_interface.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem2,
            this.helpToolStripMenuItem2});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(511, 24);
            this.menuStrip1.TabIndex = 26;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem2
            // 
            this.fileToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem2});
            this.fileToolStripMenuItem2.Name = "fileToolStripMenuItem2";
            this.fileToolStripMenuItem2.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem2.Text = "File";
            // 
            // exitToolStripMenuItem2
            // 
            this.exitToolStripMenuItem2.Name = "exitToolStripMenuItem2";
            this.exitToolStripMenuItem2.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem2.Text = "Exit";
            this.exitToolStripMenuItem2.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem2
            // 
            this.helpToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem2});
            this.helpToolStripMenuItem2.Name = "helpToolStripMenuItem2";
            this.helpToolStripMenuItem2.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem2.Text = "Help";
            // 
            // aboutToolStripMenuItem2
            // 
            this.aboutToolStripMenuItem2.Name = "aboutToolStripMenuItem2";
            this.aboutToolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem2.Text = "About";
            this.aboutToolStripMenuItem2.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // txt_dcp_devicename
            // 
            this.txt_dcp_devicename.Location = new System.Drawing.Point(100, 576);
            this.txt_dcp_devicename.Name = "txt_dcp_devicename";
            this.txt_dcp_devicename.Size = new System.Drawing.Size(400, 20);
            this.txt_dcp_devicename.TabIndex = 27;
            // 
            // lbl_dcp_devicename
            // 
            this.lbl_dcp_devicename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_dcp_devicename.Location = new System.Drawing.Point(0, 579);
            this.lbl_dcp_devicename.Name = "lbl_dcp_devicename";
            this.lbl_dcp_devicename.Size = new System.Drawing.Size(94, 13);
            this.lbl_dcp_devicename.TabIndex = 28;
            this.lbl_dcp_devicename.Text = "Device Name";
            this.lbl_dcp_devicename.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_sub_protocol
            // 
            this.lbl_sub_protocol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_sub_protocol.Location = new System.Drawing.Point(0, 276);
            this.lbl_sub_protocol.Name = "lbl_sub_protocol";
            this.lbl_sub_protocol.Size = new System.Drawing.Size(94, 13);
            this.lbl_sub_protocol.TabIndex = 30;
            this.lbl_sub_protocol.Text = "Extra";
            this.lbl_sub_protocol.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lbl_sub_protocol.Click += new System.EventHandler(this.label2_Click);
            // 
            // cbo_sub_protocol
            // 
            this.cbo_sub_protocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_sub_protocol.FormattingEnabled = true;
            this.cbo_sub_protocol.Location = new System.Drawing.Point(100, 273);
            this.cbo_sub_protocol.Name = "cbo_sub_protocol";
            this.cbo_sub_protocol.Size = new System.Drawing.Size(400, 21);
            this.cbo_sub_protocol.TabIndex = 29;
            this.cbo_sub_protocol.SelectedValueChanged += new System.EventHandler(this.cbo_sub_protocol_SelectedValueChanged);
            // 
            // tbr_load_percentage
            // 
            this.tbr_load_percentage.Location = new System.Drawing.Point(100, 632);
            this.tbr_load_percentage.Name = "tbr_load_percentage";
            this.tbr_load_percentage.Size = new System.Drawing.Size(399, 45);
            this.tbr_load_percentage.TabIndex = 37;
            // 
            // lbl_load_percentage
            // 
            this.lbl_load_percentage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_load_percentage.Location = new System.Drawing.Point(0, 636);
            this.lbl_load_percentage.Name = "lbl_load_percentage";
            this.lbl_load_percentage.Size = new System.Drawing.Size(94, 13);
            this.lbl_load_percentage.TabIndex = 38;
            this.lbl_load_percentage.Text = "Load Percentage";
            this.lbl_load_percentage.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_resizer
            // 
            this.lbl_resizer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_resizer.Location = new System.Drawing.Point(208, 797);
            this.lbl_resizer.Name = "lbl_resizer";
            this.lbl_resizer.Size = new System.Drawing.Size(94, 13);
            this.lbl_resizer.TabIndex = 39;
            this.lbl_resizer.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_hdr_interface
            // 
            this.lbl_hdr_interface.AutoSize = true;
            this.lbl_hdr_interface.Font = new System.Drawing.Font("Harlow Solid Italic", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_hdr_interface.Location = new System.Drawing.Point(10, 40);
            this.lbl_hdr_interface.Name = "lbl_hdr_interface";
            this.lbl_hdr_interface.Size = new System.Drawing.Size(202, 30);
            this.lbl_hdr_interface.TabIndex = 40;
            this.lbl_hdr_interface.Text = "Interface properties";
            // 
            // lbl_hdr_protocol
            // 
            this.lbl_hdr_protocol.AutoSize = true;
            this.lbl_hdr_protocol.Font = new System.Drawing.Font("Harlow Solid Italic", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_hdr_protocol.Location = new System.Drawing.Point(10, 207);
            this.lbl_hdr_protocol.Name = "lbl_hdr_protocol";
            this.lbl_hdr_protocol.Size = new System.Drawing.Size(180, 30);
            this.lbl_hdr_protocol.TabIndex = 41;
            this.lbl_hdr_protocol.Text = "Protocol selection";
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // lbl_separator
            // 
            this.lbl_separator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_separator.Location = new System.Drawing.Point(20, 195);
            this.lbl_separator.Name = "lbl_separator";
            this.lbl_separator.Size = new System.Drawing.Size(490, 2);
            this.lbl_separator.TabIndex = 42;
            // 
            // lbl_interface_mac
            // 
            this.lbl_interface_mac.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_interface_mac.Location = new System.Drawing.Point(0, 118);
            this.lbl_interface_mac.Name = "lbl_interface_mac";
            this.lbl_interface_mac.Size = new System.Drawing.Size(94, 13);
            this.lbl_interface_mac.TabIndex = 43;
            this.lbl_interface_mac.Text = "Interface MAC";
            this.lbl_interface_mac.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_interface_ip
            // 
            this.lbl_interface_ip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_interface_ip.Location = new System.Drawing.Point(243, 118);
            this.lbl_interface_ip.Name = "lbl_interface_ip";
            this.lbl_interface_ip.Size = new System.Drawing.Size(94, 13);
            this.lbl_interface_ip.TabIndex = 44;
            this.lbl_interface_ip.Text = "Interface IP";
            this.lbl_interface_ip.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txt_interface_mac
            // 
            this.txt_interface_mac.AllowInternalTab = false;
            this.txt_interface_mac.AutoHeight = true;
            this.txt_interface_mac.BackColor = System.Drawing.SystemColors.Window;
            this.txt_interface_mac.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txt_interface_mac.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_interface_mac.Enabled = false;
            this.txt_interface_mac.Location = new System.Drawing.Point(100, 115);
            this.txt_interface_mac.MinimumSize = new System.Drawing.Size(129, 20);
            this.txt_interface_mac.Name = "txt_interface_mac";
            this.txt_interface_mac.ReadOnly = false;
            this.txt_interface_mac.Size = new System.Drawing.Size(130, 20);
            this.txt_interface_mac.TabIndex = 46;
            this.txt_interface_mac.Text = "-----";
            // 
            // txt_interface_ip
            // 
            this.txt_interface_ip.AllowInternalTab = false;
            this.txt_interface_ip.AutoHeight = true;
            this.txt_interface_ip.BackColor = System.Drawing.SystemColors.Window;
            this.txt_interface_ip.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txt_interface_ip.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_interface_ip.Enabled = false;
            this.txt_interface_ip.Location = new System.Drawing.Point(343, 115);
            this.txt_interface_ip.MinimumSize = new System.Drawing.Size(87, 20);
            this.txt_interface_ip.Name = "txt_interface_ip";
            this.txt_interface_ip.ReadOnly = false;
            this.txt_interface_ip.Size = new System.Drawing.Size(130, 20);
            this.txt_interface_ip.TabIndex = 45;
            this.txt_interface_ip.Text = "...";
            // 
            // btn_interface_mac
            // 
            this.btn_interface_mac.BackColor = System.Drawing.Color.Transparent;
            this.btn_interface_mac.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_interface_mac.Location = new System.Drawing.Point(236, 115);
            this.btn_interface_mac.Name = "btn_interface_mac";
            this.btn_interface_mac.Size = new System.Drawing.Size(20, 20);
            this.btn_interface_mac.TabIndex = 47;
            this.btn_interface_mac.Text = "=";
            this.btn_interface_mac.UseVisualStyleBackColor = false;
            this.btn_interface_mac.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_interface_ip
            // 
            this.btn_interface_ip.Location = new System.Drawing.Point(479, 115);
            this.btn_interface_ip.Name = "btn_interface_ip";
            this.btn_interface_ip.Size = new System.Drawing.Size(20, 20);
            this.btn_interface_ip.TabIndex = 48;
            this.btn_interface_ip.Text = "=";
            this.btn_interface_ip.UseVisualStyleBackColor = true;
            this.btn_interface_ip.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(236, 115);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(20, 20);
            this.button1.TabIndex = 47;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(479, 115);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(20, 20);
            this.button2.TabIndex = 48;
            this.button2.Text = "Send Packet";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem1.Text = "File";
            this.fileToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem1.Text = "About";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.helpToolStripMenuItem1.Text = "Help";
            this.helpToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // txt_PN_DCP_Set_IP_Address
            // 
            this.txt_PN_DCP_Set_IP_Address.AllowInternalTab = false;
            this.txt_PN_DCP_Set_IP_Address.AutoHeight = true;
            this.txt_PN_DCP_Set_IP_Address.BackColor = System.Drawing.SystemColors.Window;
            this.txt_PN_DCP_Set_IP_Address.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txt_PN_DCP_Set_IP_Address.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_PN_DCP_Set_IP_Address.Location = new System.Drawing.Point(234, 466);
            this.txt_PN_DCP_Set_IP_Address.MinimumSize = new System.Drawing.Size(87, 20);
            this.txt_PN_DCP_Set_IP_Address.Name = "txt_PN_DCP_Set_IP_Address";
            this.txt_PN_DCP_Set_IP_Address.ReadOnly = false;
            this.txt_PN_DCP_Set_IP_Address.Size = new System.Drawing.Size(130, 20);
            this.txt_PN_DCP_Set_IP_Address.TabIndex = 50;
            this.txt_PN_DCP_Set_IP_Address.Text = "...";
            // 
            // lbl_PN_DCP_Set_IP_Address
            // 
            this.lbl_PN_DCP_Set_IP_Address.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_PN_DCP_Set_IP_Address.Location = new System.Drawing.Point(134, 469);
            this.lbl_PN_DCP_Set_IP_Address.Name = "lbl_PN_DCP_Set_IP_Address";
            this.lbl_PN_DCP_Set_IP_Address.Size = new System.Drawing.Size(94, 13);
            this.lbl_PN_DCP_Set_IP_Address.TabIndex = 49;
            this.lbl_PN_DCP_Set_IP_Address.Text = "IP Address";
            this.lbl_PN_DCP_Set_IP_Address.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txt_PN_DCP_Set_IP_Subnet
            // 
            this.txt_PN_DCP_Set_IP_Subnet.AllowInternalTab = false;
            this.txt_PN_DCP_Set_IP_Subnet.AutoHeight = true;
            this.txt_PN_DCP_Set_IP_Subnet.BackColor = System.Drawing.SystemColors.Window;
            this.txt_PN_DCP_Set_IP_Subnet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txt_PN_DCP_Set_IP_Subnet.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_PN_DCP_Set_IP_Subnet.Location = new System.Drawing.Point(234, 492);
            this.txt_PN_DCP_Set_IP_Subnet.MinimumSize = new System.Drawing.Size(87, 20);
            this.txt_PN_DCP_Set_IP_Subnet.Name = "txt_PN_DCP_Set_IP_Subnet";
            this.txt_PN_DCP_Set_IP_Subnet.ReadOnly = false;
            this.txt_PN_DCP_Set_IP_Subnet.Size = new System.Drawing.Size(130, 20);
            this.txt_PN_DCP_Set_IP_Subnet.TabIndex = 52;
            this.txt_PN_DCP_Set_IP_Subnet.Text = "...";
            // 
            // lbl_PN_DCP_Set_IP_Subnet
            // 
            this.lbl_PN_DCP_Set_IP_Subnet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_PN_DCP_Set_IP_Subnet.Location = new System.Drawing.Point(134, 495);
            this.lbl_PN_DCP_Set_IP_Subnet.Name = "lbl_PN_DCP_Set_IP_Subnet";
            this.lbl_PN_DCP_Set_IP_Subnet.Size = new System.Drawing.Size(94, 13);
            this.lbl_PN_DCP_Set_IP_Subnet.TabIndex = 51;
            this.lbl_PN_DCP_Set_IP_Subnet.Text = "Subnet Mask";
            this.lbl_PN_DCP_Set_IP_Subnet.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txt_PN_DCP_Set_IP_Gateway
            // 
            this.txt_PN_DCP_Set_IP_Gateway.AllowInternalTab = false;
            this.txt_PN_DCP_Set_IP_Gateway.AutoHeight = true;
            this.txt_PN_DCP_Set_IP_Gateway.BackColor = System.Drawing.SystemColors.Window;
            this.txt_PN_DCP_Set_IP_Gateway.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txt_PN_DCP_Set_IP_Gateway.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_PN_DCP_Set_IP_Gateway.Location = new System.Drawing.Point(234, 518);
            this.txt_PN_DCP_Set_IP_Gateway.MinimumSize = new System.Drawing.Size(87, 20);
            this.txt_PN_DCP_Set_IP_Gateway.Name = "txt_PN_DCP_Set_IP_Gateway";
            this.txt_PN_DCP_Set_IP_Gateway.ReadOnly = false;
            this.txt_PN_DCP_Set_IP_Gateway.Size = new System.Drawing.Size(130, 20);
            this.txt_PN_DCP_Set_IP_Gateway.TabIndex = 54;
            this.txt_PN_DCP_Set_IP_Gateway.Text = "...";
            // 
            // lbl_PN_DCP_Set_IP_Gateway
            // 
            this.lbl_PN_DCP_Set_IP_Gateway.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_PN_DCP_Set_IP_Gateway.Location = new System.Drawing.Point(134, 521);
            this.lbl_PN_DCP_Set_IP_Gateway.Name = "lbl_PN_DCP_Set_IP_Gateway";
            this.lbl_PN_DCP_Set_IP_Gateway.Size = new System.Drawing.Size(94, 13);
            this.lbl_PN_DCP_Set_IP_Gateway.TabIndex = 53;
            this.lbl_PN_DCP_Set_IP_Gateway.Text = "Default Gateway";
            this.lbl_PN_DCP_Set_IP_Gateway.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // helpProvider1
            // 
            this.helpProvider1.HelpNamespace = "C:\\Users\\Frederic Depuydt\\Google Drive\\Projects\\Visual Studio\\PacketSender\\Packet" +
    "Sender\\Test Help Project.chm";
            // 
            // PacketSender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 849);
            this.Controls.Add(this.txt_PN_DCP_Set_IP_Gateway);
            this.Controls.Add(this.lbl_PN_DCP_Set_IP_Gateway);
            this.Controls.Add(this.txt_PN_DCP_Set_IP_Subnet);
            this.Controls.Add(this.lbl_PN_DCP_Set_IP_Subnet);
            this.Controls.Add(this.txt_PN_DCP_Set_IP_Address);
            this.Controls.Add(this.lbl_PN_DCP_Set_IP_Address);
            this.Controls.Add(this.btn_interface_ip);
            this.Controls.Add(this.btn_interface_mac);
            this.Controls.Add(this.txt_interface_mac);
            this.Controls.Add(this.txt_interface_ip);
            this.Controls.Add(this.lbl_interface_ip);
            this.Controls.Add(this.lbl_interface_mac);
            this.Controls.Add(this.lbl_separator);
            this.Controls.Add(this.lbl_hdr_protocol);
            this.Controls.Add(this.lbl_hdr_interface);
            this.Controls.Add(this.lbl_resizer);
            this.Controls.Add(this.lbl_load_percentage);
            this.Controls.Add(this.tbr_load_percentage);
            this.Controls.Add(this.lbl_sub_protocol);
            this.Controls.Add(this.cbo_sub_protocol);
            this.Controls.Add(this.lbl_dcp_devicename);
            this.Controls.Add(this.txt_dcp_devicename);
            this.Controls.Add(this.lbl_interface);
            this.Controls.Add(this.lbl_data);
            this.Controls.Add(this.txt_data);
            this.Controls.Add(this.txt_dst_port);
            this.Controls.Add(this.txt_src_port);
            this.Controls.Add(this.lbl_dst_port);
            this.Controls.Add(this.lbl_src_port);
            this.Controls.Add(this.cbo_interface);
            this.Controls.Add(this.txt_src_mac);
            this.Controls.Add(this.txt_src_ip);
            this.Controls.Add(this.txt_dst_mac);
            this.Controls.Add(this.txt_dst_ip);
            this.Controls.Add(this.lbl_protocol);
            this.Controls.Add(this.cbo_protocol);
            this.Controls.Add(this.lbl_dst_ip);
            this.Controls.Add(this.lbl_dst_mac);
            this.Controls.Add(this.lbl_src_ip);
            this.Controls.Add(this.lbl_src_mac);
            this.Controls.Add(this.btn_send_packet);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PacketSender";
            this.Text = "Packet Sender";
            this.Load += new System.EventHandler(this.PacketSender_Load);
            ((System.ComponentModel.ISupportInitialize)(this.w_errorProvider)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbr_load_percentage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_send_packet;
        private System.Windows.Forms.Label lbl_src_mac;
        private System.Windows.Forms.Label lbl_src_ip;
        private System.Windows.Forms.Label lbl_dst_ip;
        private System.Windows.Forms.Label lbl_dst_mac;
        private System.Windows.Forms.ComboBox cbo_protocol;
        private System.Windows.Forms.Label lbl_protocol;
        private System.Windows.Forms.ErrorProvider w_errorProvider;
        private DepuydtControlLib.MACAddressControl txt_dst_mac;
        private DepuydtControlLib.IPAddressControl txt_dst_ip;
        private DepuydtControlLib.MACAddressControl txt_src_mac;
        private DepuydtControlLib.IPAddressControl txt_src_ip;
        private System.Windows.Forms.ComboBox cbo_interface;
        private System.Windows.Forms.Label lbl_dst_port;
        private System.Windows.Forms.Label lbl_src_port;
        private System.Windows.Forms.Label lbl_data;
        private System.Windows.Forms.TextBox txt_data;
        private System.Windows.Forms.TextBox txt_dst_port;
        private System.Windows.Forms.TextBox txt_src_port;
        private System.Windows.Forms.Label lbl_interface;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label lbl_sub_protocol;
        private System.Windows.Forms.ComboBox cbo_sub_protocol;
        private System.Windows.Forms.Label lbl_dcp_devicename;
        private System.Windows.Forms.TextBox txt_dcp_devicename;
        private System.Windows.Forms.TrackBar tbr_load_percentage;
        private System.Windows.Forms.Label lbl_load_percentage;
        private System.Windows.Forms.Label lbl_resizer;
        private System.Windows.Forms.Label lbl_hdr_interface;
        private System.Windows.Forms.Label lbl_hdr_protocol;
        private System.Windows.Forms.Label lbl_separator;
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private DepuydtControlLib.MACAddressControl txt_interface_mac;
        private DepuydtControlLib.IPAddressControl txt_interface_ip;
        private System.Windows.Forms.Label lbl_interface_ip;
        private System.Windows.Forms.Label lbl_interface_mac;
        private System.Windows.Forms.Button btn_interface_ip;
        private System.Windows.Forms.Button btn_interface_mac;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem2;
        private DepuydtControlLib.IPAddressControl txt_PN_DCP_Set_IP_Gateway;
        private System.Windows.Forms.Label lbl_PN_DCP_Set_IP_Gateway;
        private DepuydtControlLib.IPAddressControl txt_PN_DCP_Set_IP_Subnet;
        private System.Windows.Forms.Label lbl_PN_DCP_Set_IP_Subnet;
        private DepuydtControlLib.IPAddressControl txt_PN_DCP_Set_IP_Address;
        private System.Windows.Forms.Label lbl_PN_DCP_Set_IP_Address;
        private System.Windows.Forms.HelpProvider helpProvider1;
    }
}

