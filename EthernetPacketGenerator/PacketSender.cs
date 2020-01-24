using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PacketSender
{
    public partial class PacketSender : Form
    {
        private PacketBuilder packetBuilder;
        private String txt_data_text = "";
        private int txt_data_selection = 0;
        private Boolean txt_data_setcursor = false;

        int int_prev_protocol = 0;
        int int_curr_protocol = 0;
        int int_prev_sub_protocol = 0;
        int int_curr_sub_protocol = 0;


        byte[] _data;

        Boolean txt_src_mac_enabled = false;
        Boolean txt_dst_mac_enabled = false;
        Boolean txt_src_ip_enabled = false;
        Boolean txt_dst_ip_enabled = false;
        Boolean txt_src_port_enabled = false;
        Boolean txt_dst_port_enabled = false;
        Boolean txt_data_enabled = false;
        Boolean cbo_sub_protocol_enabled = false;
        Boolean txt_dcp_set_ip_enabled = false;
        Boolean txt_dcp_set_devicename_enabled = false;
        Boolean cbo_protocol_enabled = true;
        Boolean cbo_interface_enabled = true;
        Boolean btn_send_packet_enabled = true;
        Boolean tbr_load_percentage_enabled = false;

        Boolean lbl_hdr_interface_enabled = true;
        Boolean lbl_hdr_protocol_enabled = true;
        Boolean lbl_hdr_options_enabled = true;

        public PacketSender()
        {
            InitializeComponent();
        }

        private void PacketSender_Load(object sender, EventArgs e)
        {
            //Build a list
            var dataSource = new List<Protocol>();
            dataSource.Add(new Protocol() { Name = "ARP", Value = 0 });
            dataSource.Add(new Protocol() { Name = "RARP", Value = 1 });
            dataSource.Add(new Protocol() { Name = "ICMP", Value = 2 });

            dataSource.Add(new Protocol() { Name = "TCP/IP", Value = 50 });
            dataSource.Add(new Protocol() { Name = "UDP/IP", Value = 51 });

            dataSource.Add(new Protocol() { Name = "PN-DCP", Value = 100 });
            dataSource.Add(new Protocol() { Name = "Raw Packet", Value = 200 });
            //Setup data binding
            cbo_protocol.DataSource = dataSource;
            cbo_protocol.DisplayMember = "Name";
            cbo_protocol.ValueMember = "Value";
            //
            packetBuilder = new PacketBuilder();
            cbo_interface.DataSource = packetBuilder.lst_Interfaces;
            cbo_interface.DisplayMember = "Name";
            cbo_interface.ValueMember = "Value";

            txt_src_ip.Text = "0.0.0.0";
            txt_dst_ip.Text = "0.0.0.0";
            txt_src_mac.Text = "FF-FF-FF-FF-FF-FF";
            txt_dst_mac.Text = "FF-FF-FF-FF-FF-FF";
            
            cbo_protocol.SelectedIndex = 0;
            cbo_interface.SelectedIndex = 0;

            txt_data.Font = new Font(FontFamily.GenericMonospace, 8);

            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

        }

        private void btn_send_packet_Click(object sender, EventArgs e)
        {
            if (txt_src_mac_enabled)
            {
                try { packetBuilder.src_mac = txt_src_mac.Text; }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid source MAC address: " + ex.Message);
                    MessageBox.Show("Invalid source MAC address", "Packet Sender - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (txt_src_ip_enabled)
            {
                try { packetBuilder.src_ip = txt_src_ip.Text; }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid source IP address: " + ex.Message);
                    MessageBox.Show("Invalid source IP address", "Packet Sender - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (txt_dst_mac_enabled)
            {
                try { packetBuilder.dst_mac = txt_dst_mac.Text; }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid destination MAC address: " + ex.Message);
                    MessageBox.Show("Invalid destination MAC address", "Packet Sender - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (txt_dst_ip_enabled)
            {
                try { packetBuilder.dst_ip = txt_dst_ip.Text; }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid destination IP address: " + ex.Message);
                    MessageBox.Show("Invalid destination IP address", "Packet Sender - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (txt_src_port_enabled)
            {
                try
                { packetBuilder.src_port = UInt16.Parse(txt_src_port.Text); }

                catch (Exception ex) {
                    Console.WriteLine("Invalid source port: " + ex.Message);
                    MessageBox.Show("Invalid source port", "Packet Sender - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (txt_dst_port_enabled) {
                try { packetBuilder.dst_port = UInt16.Parse(txt_dst_port.Text); }


                catch (Exception ex)
                {
                    Console.WriteLine("Invalid destination port: " + ex.Message);
                    MessageBox.Show("Invalid destination port", "Packet Sender - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (txt_data_enabled)
            {
                try { packetBuilder.data = _data;

                    if (packetBuilder.data.Length == 0) {
                        Console.WriteLine("Data field is empty");
                        MessageBox.Show("Data field is empty", "Packet Sender - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Data field is empty: " + ex.Message);
                    MessageBox.Show("Data field is empty", "Packet Sender - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (txt_dcp_set_ip_enabled)
            {
                try { packetBuilder.PN_DCP_Block_IP_Address = txt_PN_DCP_Set_IP_Address.Text; }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid PN-DCP IP address: " + ex.Message);
                    MessageBox.Show("Invalid PN-DCP IP address", "Packet Sender - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try { packetBuilder.PN_DCP_Block_IP_Subnet = txt_PN_DCP_Set_IP_Subnet.Text; }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid PN-DCP Subnet Mask: " + ex.Message);
                    MessageBox.Show("Invalid PN-DCP Subnet Mask", "Packet Sender - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try { packetBuilder.PN_DCP_Block_IP_Gateway = txt_PN_DCP_Set_IP_Gateway.Text; }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid PN-DCP Default Gateway: " + ex.Message);
                    MessageBox.Show("Invalid PN-DCP Default Gateway", "Packet Sender - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (txt_dcp_set_devicename_enabled)
            {
                try { packetBuilder.PN_DCP_Block_DeviceName = txt_dcp_devicename.Text; }
                catch (Exception ex)
                {
                    Console.WriteLine("Invalid PN-DCP Device Name: " + ex.Message);
                    MessageBox.Show("Invalid PN-DCP Device Name", "Packet Sender - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            switch (int_curr_protocol)
            {
                case 0: // ARP
                    packetBuilder.BuildPacket_ARP();
                    packetBuilder.SendPacket();
                    break;
                case 1: // RARP
                    packetBuilder.BuildPacket_RARP();
                    packetBuilder.SendPacket();
                    break;
                case 2: // ICMP
                    packetBuilder.BuildPacket_ICMP();
                    packetBuilder.SendPacket();
                    break;
                case 50: // TCP/IP
                    packetBuilder.BuildPacket_TCP_IP();
                    packetBuilder.SendPacket();
                    break;
                case 51: // UDP/IP
                    packetBuilder.BuildPacket_UDP_IP();
                    packetBuilder.SendPacket();
                    break;
                case 100: // PN-DCP, Ident Req, ALL
                    switch (int_curr_sub_protocol)
                    {
                        case 0: // Ident Req, ALL
                            packetBuilder.BuildPacket_PN_DCP_ID_REQ_All();
                            packetBuilder.SendPacket();
                            break;
                        //case 1: // Ident Req (IP-address) 
                        //case 2: // Ident Req (Device name)
                        case 3: // Set Req (IP-address) 
                            packetBuilder.BuildPacket_PN_DCP_SET_IP();
                            packetBuilder.SendPacket();
                            break;
                        case 4: // Set Req (Device name)
                            packetBuilder.BuildPacket_PN_DCP_SET_DEVICENAME();
                            packetBuilder.SendPacket();
                            break;
                    }
                    break;
                case 200: // Raw Packet (DATA)
                    switch (int_curr_sub_protocol)
                    {
                        case 0:
                            packetBuilder.BuildPacket_RAW_DATA();
                            packetBuilder.SendPacket();
                            break;
                        case 1: // Raw Packet (MAC + DATA)
                            packetBuilder.BuildPacket_RAW_MAC_DATA();
                            packetBuilder.SendPacket();
                            break;
                        case 2: // Raw Packet (MAC + IP + DATA)
                            packetBuilder.BuildPacket_RAW_MAC_IP_DATA();
                            packetBuilder.SendPacket();
                            break;
                    }
                    break;
            }
            MessageBox.Show("Message send succesfull", "Packet Sender", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cbo_interface_SelectedValueChanged(object sender, EventArgs e)
        {
            try {
                packetBuilder.selectedInterface = cbo_interface.SelectedValue.ToString();
                Console.WriteLine(packetBuilder.interface_ip);
                txt_interface_ip.Text = packetBuilder.interface_ip;
                txt_interface_mac.Text = packetBuilder.interface_mac;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error while selecting interface:" + ex.Message);
            }
        }

        private void cbo_protocol_SelectedValueChanged(object sender, EventArgs e)
        {
            fnc_protocol_SelectedValueChanged();
        }
        private void cbo_sub_protocol_SelectedValueChanged(object sender, EventArgs e)
        {
            fnc_protocol_SelectedValueChanged();
        }

        private void fnc_protocol_SelectedValueChanged()
        {
            txt_src_mac_enabled = false;
            txt_dst_mac_enabled = false;
            txt_src_ip_enabled = false;
            txt_dst_ip_enabled = false;
            txt_src_port_enabled = false;
            txt_dst_port_enabled = false;
            txt_data_enabled = false;
            cbo_sub_protocol_enabled = false;
            txt_dcp_set_ip_enabled = false;
            txt_dcp_set_devicename_enabled = false;
            cbo_protocol_enabled = true;
            cbo_interface_enabled = true;
            btn_send_packet_enabled = true;
            tbr_load_percentage_enabled = false;
            lbl_hdr_interface_enabled = true;
            lbl_hdr_protocol_enabled = true;
            lbl_hdr_options_enabled = true;


            try {
                int_prev_protocol = int_curr_protocol;
                int_curr_protocol = int.Parse(cbo_protocol.SelectedValue.ToString());
                switch (int_curr_protocol)
                {
                    case 0: // ARP
                        txt_src_mac_enabled = true;
                        txt_src_ip_enabled = true;
                        txt_dst_ip_enabled = true;
                        break;
                    case 1: // RARP
                        txt_src_mac_enabled = true;
                        txt_dst_mac_enabled = true;
                        txt_src_ip_enabled = true;
                        break;
                    case 2: // ICMP
                        txt_src_mac_enabled = true;
                        txt_dst_mac_enabled = true;
                        txt_src_ip_enabled = true;
                        txt_dst_ip_enabled = true;
                        break;
                    case 50: // TCP/IP
                        txt_src_mac_enabled = true;
                        txt_dst_mac_enabled = true;
                        txt_src_ip_enabled = true;
                        txt_dst_ip_enabled = true;
                        txt_src_port_enabled = true;
                        txt_dst_port_enabled = true;
                        txt_data_enabled = true;
                        break;
                    case 51: // TCP/IP
                        txt_src_mac_enabled = true;
                        txt_dst_mac_enabled = true;
                        txt_src_ip_enabled = true;
                        txt_dst_ip_enabled = true;
                        txt_src_port_enabled = true;
                        txt_dst_port_enabled = true;
                        txt_data_enabled = true;
                        break;
                    case 100: // PN-DCP, Ident Req
                        cbo_sub_protocol_enabled = true;
                        if (int_prev_protocol != int_curr_protocol)
                        {
                            var dataSource = new List<Protocol>();
                            dataSource.Add(new Protocol() { Name = "Ident Req, ALL", Value = 0 });
                            //dataSource.Add(new Protocol() { Name = "Ident Req (IP-address)", Value = 1 });
                            //dataSource.Add(new Protocol() { Name = "Ident Req (Device name)", Value = 2 });
                            dataSource.Add(new Protocol() { Name = "Set Req (IP-address)", Value = 3 });
                            dataSource.Add(new Protocol() { Name = "Set Req (Device name)", Value = 4 });
                            int_prev_sub_protocol = 0;
                            int_curr_sub_protocol = 0;
                            cbo_sub_protocol.DataSource = dataSource;
                            cbo_sub_protocol.DisplayMember = "Name";
                            cbo_sub_protocol.ValueMember = "Value";
                            cbo_sub_protocol.SelectedIndex = 0;
                        }
                        int_prev_sub_protocol = int_curr_sub_protocol;
                        int_curr_sub_protocol = int.Parse(cbo_sub_protocol.SelectedValue.ToString());
                        switch (int_curr_sub_protocol)
                        {

                            case 0: // Ident Req, ALL
                                txt_src_mac_enabled = true;
                                txt_dst_mac_enabled = false;
                                break;
                            case 1: // Ident Req (IP-address)
                                txt_src_mac_enabled = true;
                                txt_dst_mac_enabled = true;
                                txt_dcp_set_ip_enabled = true;
                                break;
                            case 2: // Ident Req (Device name)
                                txt_src_mac_enabled = true;
                                txt_dst_mac_enabled = true;
                                txt_dcp_set_devicename_enabled = true;
                                break;
                            case 3: // Set Req (IP-address)
                                txt_src_mac_enabled = true;
                                txt_dst_mac_enabled = true;
                                txt_dcp_set_ip_enabled = true;
                                break;
                            case 4: // Set Req (Device name)
                                txt_src_mac_enabled = true;
                                txt_dst_mac_enabled = true;
                                txt_dcp_set_devicename_enabled = true;
                                break;
                        }
                        break;
                    case 200: // Raw Packet
                        cbo_sub_protocol_enabled = true;
                        if (int_prev_protocol != int_curr_protocol)
                        {
                            var dataSource = new List<Protocol>();
                            dataSource.Add(new Protocol() { Name = "Raw Packet (DATA)", Value = 0 });
                            dataSource.Add(new Protocol() { Name = "Raw Packet (MAC + DATA)", Value = 1 });
                            dataSource.Add(new Protocol() { Name = "Raw Packet (MAC + IP + DATA)", Value = 2 });
                            int_prev_sub_protocol = 0;
                            int_curr_sub_protocol = 0;
                            cbo_sub_protocol.DataSource = dataSource;
                            cbo_sub_protocol.DisplayMember = "Name";
                            cbo_sub_protocol.ValueMember = "Value";
                            cbo_sub_protocol.SelectedIndex = 0;
                        }
                        int_prev_sub_protocol = int_curr_sub_protocol;
                        int_curr_sub_protocol = int.Parse(cbo_sub_protocol.SelectedValue.ToString());
                        switch (int_curr_sub_protocol)
                        {

                            case 0: // Raw Packet (DATA)
                                txt_data_enabled = true;
                                break;
                            case 1: // Raw Packet (MAC + DATA)
                                txt_src_mac_enabled = true;
                                txt_dst_mac_enabled = true;
                                txt_data_enabled = true;
                                break;
                            case 2: // Raw Packet (MAC + IP + DATA)
                                txt_src_mac_enabled = true;
                                txt_src_ip_enabled = true;
                                txt_dst_mac_enabled = true;
                                txt_dst_ip_enabled = true;
                                txt_data_enabled = true;
                                break;
                        }
                        break;
                }
                
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }





            // DISPLAY ELEMENTS (ROW-wise)
            int row = 40;
            if (lbl_hdr_interface_enabled)
            {
                lbl_hdr_interface.Location = new Point(10, row);
                lbl_hdr_interface.Visible = true;
                row += 45;
            }
            else
            {
                lbl_hdr_interface.Visible = false;
            }



            if (cbo_interface_enabled)
            {
                lbl_interface.Location = new Point(0, row + 3);
                cbo_interface.Location = new Point(100, row);
                cbo_interface.Enabled = cbo_interface_enabled;
                lbl_interface.Visible = true;
                cbo_interface.Visible = true;
                row += 26;
                lbl_interface_mac.Location = new Point(0, row + 3);
                lbl_interface_mac.Visible = true;
                txt_interface_mac.Location = new Point(100, row);
                txt_interface_mac.Visible = true;
                btn_interface_mac.Location = new Point(236, row);
                btn_interface_mac.Visible = true;
                lbl_interface_ip.Location = new Point(243, row + 3);
                lbl_interface_ip.Visible = true;
                txt_interface_ip.Location = new Point(343, row);
                txt_interface_ip.Visible = true;
                btn_interface_ip.Location = new Point(479, row);
                btn_interface_ip.Visible = true;
                row += 26;
            }
            else
            {
                cbo_interface.Enabled = cbo_interface_enabled;
                lbl_interface.Visible = false;
                cbo_interface.Visible = false;
                lbl_interface_mac.Visible = false;
                txt_interface_mac.Visible = false;
                lbl_interface_ip.Visible = false;
                txt_interface_mac.Visible = false;
                btn_interface_mac.Visible = false;
                btn_interface_ip.Visible = false;
            }
            if (lbl_hdr_interface_enabled)
            {
                row += 10;
                lbl_separator.Location = new Point(10, row);
                lbl_separator.Visible = true;
                row += 10;
            }
            else
            {
                lbl_separator.Visible = false;
            }

            if (lbl_hdr_protocol_enabled)
            {
                lbl_hdr_protocol.Location = new Point(10, row);
                lbl_hdr_protocol.Visible = true;
                row += 45;
            }
            else
            {
                lbl_hdr_protocol.Visible = false;
            }

            



            if (cbo_protocol_enabled)
            {
                lbl_protocol.Location = new Point(0, row + 3);
                cbo_protocol.Location = new Point(100, row);
                cbo_protocol.Enabled = cbo_protocol_enabled;
                lbl_protocol.Visible = true;
                cbo_protocol.Visible = true;
                row += 26;
            }
            else
            {
                cbo_protocol.Enabled = cbo_protocol_enabled;
                lbl_protocol.Visible = false;
                cbo_protocol.Visible = false;
            }
            if (cbo_sub_protocol_enabled)
            {
                lbl_sub_protocol.Location = new Point(0, row + 3);
                cbo_sub_protocol.Location = new Point(100, row);
                cbo_sub_protocol.Enabled = cbo_sub_protocol_enabled;
                lbl_sub_protocol.Visible = true;
                cbo_sub_protocol.Visible = true;
                row += 26;
            }
            else
            {
                cbo_sub_protocol.Enabled = cbo_sub_protocol_enabled;
                lbl_sub_protocol.Visible = false;
                cbo_sub_protocol.Visible = false;
            }
            row += 26;


            if (txt_src_mac_enabled || txt_dst_mac_enabled)
            {
                lbl_src_mac.Location = new Point(0, row+3);
                lbl_dst_mac.Location = new Point(270, row+3);
                txt_src_mac.Location = new Point(100, row);
                txt_dst_mac.Location = new Point(370, row);
                txt_src_mac.Enabled = txt_src_mac_enabled;
                txt_dst_mac.Enabled = txt_dst_mac_enabled;
                lbl_src_mac.Visible = true;
                lbl_dst_mac.Visible = true;
                txt_src_mac.Visible = true;
                txt_dst_mac.Visible = true;
                row += 26;
            }
            else
            {
                txt_src_mac.Enabled = txt_src_mac_enabled;
                txt_dst_mac.Enabled = txt_dst_mac_enabled;
                lbl_src_mac.Visible = false;
                lbl_dst_mac.Visible = false;
                txt_src_mac.Visible = false;
                txt_dst_mac.Visible = false;
            }

            if (txt_src_ip_enabled || txt_dst_ip_enabled)
            {
                lbl_src_ip.Location = new Point(0, row + 3);
                lbl_dst_ip.Location = new Point(270, row + 3);
                txt_src_ip.Location = new Point(100, row);
                txt_dst_ip.Location = new Point(370, row);
                txt_src_ip.Enabled = txt_src_ip_enabled;
                txt_dst_ip.Enabled = txt_dst_ip_enabled;
                lbl_src_ip.Visible = true;
                lbl_dst_ip.Visible = true;
                txt_src_ip.Visible = true;
                txt_dst_ip.Visible = true;
                row += 26;
            }
            else
            {
                txt_src_ip.Enabled = txt_src_ip_enabled;
                txt_dst_ip.Enabled = txt_dst_ip_enabled;
                lbl_src_ip.Visible = false;
                lbl_dst_ip.Visible = false;
                txt_src_ip.Visible = false;
                txt_dst_ip.Visible = false;
            }

            if (txt_src_port_enabled || txt_dst_port_enabled)
            {
                lbl_src_port.Location = new Point(0, row + 3);
                lbl_dst_port.Location = new Point(270, row + 3);
                txt_src_port.Location = new Point(100, row);
                txt_dst_port.Location = new Point(370, row);
                txt_src_port.Enabled = txt_src_port_enabled;
                txt_dst_port.Enabled = txt_dst_port_enabled;
                lbl_src_port.Visible = true;
                lbl_dst_port.Visible = true;
                txt_src_port.Visible = true;
                txt_dst_port.Visible = true;
                row += 26;
            }
            else
            {
                txt_src_port.Enabled = txt_src_port_enabled;
                txt_dst_port.Enabled = txt_dst_port_enabled;
                lbl_src_port.Visible = false;
                lbl_dst_port.Visible = false;
                txt_src_port.Visible = false;
                txt_dst_port.Visible = false;
            }
            if (txt_dcp_set_ip_enabled)
            {
                lbl_PN_DCP_Set_IP_Address.Location = new Point(0, row + 3);
                txt_PN_DCP_Set_IP_Address.Location = new Point(100, row);
                txt_PN_DCP_Set_IP_Address.Enabled = true;
                lbl_PN_DCP_Set_IP_Address.Visible = true;
                txt_PN_DCP_Set_IP_Address.Visible = true;
                row += 26;
                lbl_PN_DCP_Set_IP_Subnet.Location = new Point(0, row + 3);
                txt_PN_DCP_Set_IP_Subnet.Location = new Point(100, row);
                txt_PN_DCP_Set_IP_Subnet.Enabled = true;
                lbl_PN_DCP_Set_IP_Subnet.Visible = true;
                txt_PN_DCP_Set_IP_Subnet.Visible = true;
                row += 26;
                lbl_PN_DCP_Set_IP_Gateway.Location = new Point(0, row + 3);
                txt_PN_DCP_Set_IP_Gateway.Location = new Point(100, row);
                txt_PN_DCP_Set_IP_Gateway.Enabled = true;
                lbl_PN_DCP_Set_IP_Gateway.Visible = true;
                txt_PN_DCP_Set_IP_Gateway.Visible = true;
                row += 26;
            }
            else
            {
                txt_PN_DCP_Set_IP_Address.Enabled = false;
                lbl_PN_DCP_Set_IP_Address.Visible = false;
                txt_PN_DCP_Set_IP_Address.Visible = false;
                txt_PN_DCP_Set_IP_Subnet.Enabled = false;
                lbl_PN_DCP_Set_IP_Subnet.Visible = false;
                txt_PN_DCP_Set_IP_Subnet.Visible = false;
                txt_PN_DCP_Set_IP_Gateway.Enabled = false;
                lbl_PN_DCP_Set_IP_Gateway.Visible = false;
                txt_PN_DCP_Set_IP_Gateway.Visible = false;
            }
            if (txt_dcp_set_devicename_enabled)
            {
                lbl_dcp_devicename.Location = new Point(0, row + 3);
                txt_dcp_devicename.Location = new Point(100, row);
                txt_dcp_devicename.Enabled = true; 
                lbl_dcp_devicename.Visible = true;
                txt_dcp_devicename.Visible = true;
                row += 26;
            }
            else
            {
                txt_dcp_devicename.Enabled = false;
                lbl_dcp_devicename.Visible = false;
                txt_dcp_devicename.Visible = false;
            }
            if (txt_data_enabled)
            {
                lbl_data.Location = new Point(0, row + 3);
                txt_data.Location = new Point(100, row);
                txt_data.Enabled = txt_data_enabled;
                lbl_data.Visible = true;
                txt_data.Visible = true;
                row += 104;
            }
            else
            {
                txt_data.Enabled = txt_data_enabled;
                lbl_data.Visible = false;
                txt_data.Visible = false;
            }
            if (tbr_load_percentage_enabled)
            {
                lbl_load_percentage.Location = new Point(0, row + 3);
                tbr_load_percentage.Location = new Point(100, row);
                tbr_load_percentage.Enabled = tbr_load_percentage_enabled;
                lbl_load_percentage.Visible = true;
                tbr_load_percentage.Visible = true;
                row += 26;
            }
            else
            {
                tbr_load_percentage.Enabled = tbr_load_percentage_enabled;
                lbl_load_percentage.Visible = false;
                tbr_load_percentage.Visible = false;
            }
            row += 26;
            if (btn_send_packet_enabled)
            {
                btn_send_packet.Location = new Point(380, row);
                btn_send_packet.Enabled = btn_send_packet_enabled;
                btn_send_packet.Visible = true;
                row += 26;
            }
            else
            {
                btn_send_packet.Enabled = btn_send_packet_enabled;
                btn_send_packet.Visible = false;
            }
            lbl_resizer.Location = new Point(250, row);


        }

        private void txt_data_TextChanged(object sender, EventArgs e)
        {
            String _str;

            if (txt_data_setcursor)
            {
                txt_data.SelectionStart = txt_data_selection;
                txt_data_setcursor = false;
            }
            else
            {
                try
                {
                    txt_data_selection = txt_data.SelectionStart - 1;
                    _str = txt_data.Text;
                    _str = _str.Replace(" ", "");
                    _str = _str.Replace(Environment.NewLine, "");
                    int length = _str.Length;
                    if (length % 2 != 0) length++; _str += 0;
                    
                    _data = new byte[length / 2];
                    while (length > 0)
                    {
                        _data[length/2-1] = byte.Parse(_str.Substring(length - 2, 2), System.Globalization.NumberStyles.HexNumber);
                        length -= 2;
                    }
                    _str = txt_data.Text;
                    _str = _str.Replace(" ", "");
                    _str = _str.Replace(Environment.NewLine, "");
                    length = _str.Length;
                    length += length % 2;
                    while (length > 2)
                    {
                        _str = _str.Substring(0, length - 2) + " " + _str.Substring(length - 2);
                        length -= 2;
                    }
                    length = _str.Length;
                    length -= length % 24;
                    while (length > 0) 
                    {
                        if (length % 48 != 0)
                        {
                            _str = _str.Substring(0, length) + "   " + _str.Substring(length);
                        }
                        else
                        {
                            _str = _str.Substring(0, length) + " " + Environment.NewLine + _str.Substring(length);
                        }
                        length -= 24;
                    }

                    _str = _str.ToUpper();

                    if(txt_data.SelectionStart % 3 == 0)
                    {
                        if ((txt_data.SelectionStart + 3) % 27 == 0)
                        {
                            txt_data_selection = txt_data.SelectionStart + 4;
                        }
                        else
                        {
                            txt_data_selection = txt_data.SelectionStart + 1;
                        }
                        
                    }
                    else
                    {
                        txt_data_selection = txt_data.SelectionStart;
                    }
                    txt_data_setcursor = true;
                    txt_data_text = _str;
                    txt_data.Text = _str;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    txt_data_setcursor = true;
                    txt_data.Text = txt_data_text;
                }
            }
        }
        private Boolean KeyDown_notValid = false;
        private void txt_data_KeyDown(object sender, KeyEventArgs e)
        {
            /*//MessageBox.Show(e.KeyCode.ToString());
            if()
            KeyDown_notValid = true;*/
        }

        private void txt_data_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*if (KeyDown_notValid == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }*/
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 frm = new AboutBox1();
            frm.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lbl_src_mac_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {

            txt_src_mac.Text = packetBuilder.interface_mac;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txt_src_ip.Text = packetBuilder.interface_ip;
        }
    }        
}
