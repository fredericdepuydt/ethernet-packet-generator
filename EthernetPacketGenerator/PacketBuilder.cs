using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PcapDotNet.Base;
using PcapDotNet.Core;
using PcapDotNet.Core.Extensions;
using PcapDotNet.Packets;
using PcapDotNet.Packets.Arp;
using PcapDotNet.Packets.Dns;
using PcapDotNet.Packets.Ethernet;
using PcapDotNet.Packets.Gre;
using PcapDotNet.Packets.Http;
using PcapDotNet.Packets.Icmp;
using PcapDotNet.Packets.Igmp;
using PcapDotNet.Packets.IpV4;
using PcapDotNet.Packets.IpV6;
using PcapDotNet.Packets.Transport;

namespace PacketSender
{
    public class PacketBuilder
    {
        
        #region Variables
        private PacketCommunicator _communicator;
        private Packet _packet;
        private MacAddress _interface_mac;
        private MacAddress _src_mac;
        private MacAddress _dst_mac;
        private IpV4Address _interface_ip;
        private IpV4Address _src_ip;
        private IpV4Address _dst_ip;
        private UInt16 _src_port;
        private UInt16 _dst_port;
        private MacAddress _broadcast_mac = new MacAddress("FF:FF:FF:FF:FF:FF");
        private IpV4Address _broadcast_ip = new IpV4Address("255.255.255.255");
        private MacAddress _pn_multicast_mac = new MacAddress("01:0E:CF:00:00:00");
        private Byte[] _data;
        public UInt16 PN_FrameID;
        
        public uint PN_DCP_ServiceID;
        public uint PN_DCP_ServiceType;
        public UInt32 PN_DCP_Xid;
        public UInt16 PN_DCP_ResponseDelay;
        public UInt16 PN_DCP_DataLength;
        public uint PN_DCP_Block_Option;
        public uint PN_DCP_Block_Suboption;
        public UInt16 PN_DCP_Block_Length;
        public byte[] PN_DCP_NameOfStation;
        private IpV4Address _PN_DCP_Block_IP_Address;
        private IpV4Address _PN_DCP_Block_IP_Subnet;
        private IpV4Address _PN_DCP_Block_IP_Gateway;
        public string PN_DCP_Block_DeviceName;

        public string error_message = "";
        public List<Interface> lst_Interfaces;
        private IList<LivePacketDevice> interfaceDevices;
        private LivePacketDevice _selectedInterface;

        #endregion

        #region Get & Sets
        public string selectedInterface
        {
            set
            {
                try {
                    _selectedInterface = interfaceDevices[Int32.Parse(value)];

                    _interface_mac = _selectedInterface.GetMacAddress();

                    foreach (DeviceAddress address in _selectedInterface.Addresses)
                    {
                        if (address.Address.Family.ToString() == "Internet")
                        {
                            if (address.Address != null)
                            {
                                interface_ip = address.Address.ToString().Replace(address.Address.Family.ToString() + " ", "");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    _selectedInterface = null;
                }
            }
        }
        public string interface_mac
        {
            get
            {
                string _addr = "";

                
                _addr += ((_interface_mac.ToValue() >> 40) & 0xFF).ToString("X2") + "-";
                _addr += ((_interface_mac.ToValue() >> 32) & 0xFF).ToString("X2") + "-";
                _addr += ((_interface_mac.ToValue() >> 24) & 0xFF).ToString("X2") + "-";
                _addr += ((_interface_mac.ToValue() >> 16) & 0xFF).ToString("X2") + "-";
                _addr += ((_interface_mac.ToValue() >> 08) & 0xFF).ToString("X2") + "-";
                _addr += ((_interface_mac.ToValue() >> 00) & 0xFF).ToString("X2");

                return _addr;
            }
            set
            {
                _interface_mac = new MacAddress(value.Replace("-", ":"));
            }
        }
        public string src_mac{
            get
            {
                return _src_mac.ToValue().ToString();
            }
            set {
                _src_mac = new MacAddress(value.Replace("-", ":"));
            }
        }
        public string dst_mac
        {
            get
            {
                return _dst_mac.ToValue().ToString();
            }
            set
            {
                _dst_mac = new MacAddress(value.Replace("-", ":"));
            }
        }
        public string interface_ip
        {
            get
            {
                string _addr = "";
                _addr += ((_interface_ip.ToValue() >> 24) & 0xFF).ToString() + ".";
                _addr += ((_interface_ip.ToValue() >> 16) & 0xFF).ToString() + ".";
                _addr += ((_interface_ip.ToValue() >> 08) & 0xFF).ToString() + ".";
                _addr += ((_interface_ip.ToValue() >> 00) & 0xFF).ToString();

                return _addr;
            }
            set
            {
                _interface_ip = new IpV4Address(value);
            }
        }
        public string src_ip
        {
            get
            {
                string _addr = "";
                _addr += ((_src_ip.ToValue() >> 24) & 0xFF).ToString() + ".";
                _addr += ((_src_ip.ToValue() >> 16) & 0xFF).ToString() + ".";
                _addr += ((_src_ip.ToValue() >> 08) & 0xFF).ToString() + ".";
                _addr += ((_src_ip.ToValue() >> 00) & 0xFF).ToString();

                return _addr;
            }
            set
            {
                _src_ip= new IpV4Address(value);
            }
        }
        public string dst_ip
        {
            get
            {
                return _dst_ip.ToValue().ToString();
            }
            set
            {
                _dst_ip = new IpV4Address(value);
            }
        }

        public string PN_DCP_Block_IP_Address
        {
            set
            {
                _PN_DCP_Block_IP_Address = new IpV4Address(value);
            }
        }

        public string PN_DCP_Block_IP_Subnet
        {
            set
            {
                _PN_DCP_Block_IP_Subnet = new IpV4Address(value);
            }
        }

        public string PN_DCP_Block_IP_Gateway
        {
            set
            {
                _PN_DCP_Block_IP_Gateway = new IpV4Address(value);
            }
        }
        public UInt16 src_port
        {
            get
            {
                return _src_port;
            }
            set
            {
                _src_port = value;
            }
        }
        public UInt16 dst_port
        {
            get
            {
                return _dst_port;
            }
            set
            {
                _dst_port = value;
            }
        }
        public Byte[] data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
            }
        }
        #endregion

        #region Constructor
        public PacketBuilder()
        {
            interfaceDevices = LivePacketDevice.AllLocalMachine;
            lst_Interfaces = new List<Interface>();
            
            if (interfaceDevices.Count == 0)
            {
                lst_Interfaces.Add(new Interface() { Name = "No interfaces found", Value = -1 });
            }
            else
            {
                for (int i = 0; i != interfaceDevices.Count; i++)
                {
                    lst_Interfaces.Add(new Interface() { Name = interfaceDevices[i].Description.ToString(), Value = i });
                }
            }
            

            /*
            // Take the selected adapter
            PacketDevice selectedDevice = allDevices[deviceIndex - 1];
            Communicator = selectedDevice.Open(128,                // portion of the packet to capture
                                    PacketDeviceOpenAttributes.Promiscuous, // promiscuous mode
                                    1);*/
        }
        #endregion

        #region Private Functions
        private byte[] MAC2bytes(MacAddress _mac)
        {
            byte[] bytes = new byte[6];
            UInt48 value = _mac.ToValue();
            bytes[0] = (byte)((value >> 40) & 0xFF);
            bytes[1] = (byte)((value >> 32) & 0xFF);
            bytes[2] = (byte)((value >> 24) & 0xFF);
            bytes[3] = (byte)((value >> 16) & 0xFF);
            bytes[4] = (byte)((value >> 08) & 0xFF);
            bytes[5] = (byte)((value >> 00) & 0xFF);
            return bytes;
        }

        private byte[] IP2bytes(IpV4Address _ip)
        {
            byte[] bytes = new byte[4];
            UInt32 value = _ip.ToValue();
            bytes[0] = (byte)((value >> 24) & 0xFF);
            bytes[1] = (byte)((value >> 16) & 0xFF);
            bytes[2] = (byte)((value >> 08) & 0xFF);
            bytes[3] = (byte)((value >> 00) & 0xFF);
            return bytes;
        }

        private byte[] LIST2bytes(List<byte[]> _list) {
            int offset = 0;
            int length = 0;
            for (int i = 0; i < _list.Count; i++)
            {
                length += _list[i].Length;
            }
            byte[] _result = new byte[length];
            for (int i = 0; i < _list.Count; i++)
            {
                System.Buffer.BlockCopy(_list[i], 0, _result, offset, _list[i].Length);
                offset += _list[i].Length;
            }
            return _result;

        }
        #endregion
        
        #region Public Functions


        public void SendPacket()
        {
            try {
                _communicator = _selectedInterface.Open(128,                // portion of the packet to capture
                                        PacketDeviceOpenAttributes.Promiscuous, // promiscuous mode
                                        1);
            }
            catch (Exception ex)
            {
                _communicator = null;
                return;
            }

            try { 
                _communicator.SendPacket(_packet);
            }
            catch(Exception ex)
            {
                
            }
        }
        #endregion

        #region Packet constructors
        public Packet BuildEthernetPacket()
        {
            EthernetLayer ethernetLayer =
                new EthernetLayer
                {
                    Source = _src_mac,
                    Destination = _dst_mac,
                    EtherType = EthernetType.IpV4,
                };

            PayloadLayer payloadLayer =
                new PayloadLayer
                {
                    Data = new Datagram(Encoding.ASCII.GetBytes("hello world")),
                };

            PcapDotNet.Packets.PacketBuilder builder = new PcapDotNet.Packets.PacketBuilder(ethernetLayer, payloadLayer);

            return builder.Build(DateTime.Now);
        }

        public void BuildPacket_RAW_DATA()
        {
            _packet = new Packet(_data, DateTime.Now, DataLinkKind.Ethernet);
        }
        public void BuildPacket_RAW_MAC_DATA()
        {
            byte[] t_data = new byte[_data.Length + 12];
            byte[] t_src_mac = new byte[6];
            byte[] t_dst_mac = new byte[6];
            t_src_mac = BitConverter.GetBytes(_src_mac.ToValue());
            t_dst_mac = BitConverter.GetBytes(_dst_mac.ToValue());
            Array.Reverse(t_src_mac);
            Array.Reverse(t_dst_mac);
            Console.WriteLine(t_dst_mac.ToString());
            Console.WriteLine(t_src_mac.ToString());
            Console.WriteLine(_data.ToString());
            System.Buffer.BlockCopy(t_dst_mac, 2, t_data, 0, 6);
            System.Buffer.BlockCopy(t_src_mac, 2, t_data, 6, 6);
            System.Buffer.BlockCopy(_data,0,t_data,12,_data.Length);


            _packet = new Packet(t_data, DateTime.Now, DataLinkKind.Ethernet);
        }

        public void BuildPacket_RAW_MAC_IP_DATA()
        {
            EthernetLayer ethernetLayer =
                new EthernetLayer
                {
                    Source = _src_mac,
                    Destination = _dst_mac,
                    EtherType = EthernetType.IpV4,
                };

            IpV4Layer ipV4Layer =
                new IpV4Layer
                {
                    Source = _src_ip,
                    CurrentDestination = _dst_ip,
                    Fragmentation = IpV4Fragmentation.None,
                    HeaderChecksum = null, // Will be filled automatically.
                    Identification = 123,
                    Options = IpV4Options.None,
                    Protocol = (IpV4Protocol)0,
                    Ttl = 100,
                    TypeOfService = 0,
                };

            PayloadLayer payloadLayer =
                new PayloadLayer
                {
                    Data = new Datagram(_data),
                };

            PcapDotNet.Packets.PacketBuilder builder = new PcapDotNet.Packets.PacketBuilder(ethernetLayer, ipV4Layer, payloadLayer);
            _packet = builder.Build(DateTime.Now);
        }

        public void BuildPacket_ARP()
        {
            EthernetLayer ethernetLayer =
                new EthernetLayer
                {
                    Source = _src_mac,
                    Destination = _broadcast_mac,
                    EtherType = EthernetType.None, // Will be filled automatically.
                };
            
            ArpLayer arpLayer =
                new ArpLayer
                {
                    ProtocolType = EthernetType.IpV4,
                    Operation = ArpOperation.Request,
                    SenderHardwareAddress = MAC2bytes(_src_mac).AsReadOnly(), // Source MAC
                    SenderProtocolAddress = IP2bytes(_src_ip).AsReadOnly(), // Source IP
                    TargetHardwareAddress = new byte[] { 255, 255, 255, 255, 255, 255 }.AsReadOnly(), // Broadcast MAC
                    TargetProtocolAddress = IP2bytes(_dst_ip).AsReadOnly(), // Destination IP
                };

                PcapDotNet.Packets.PacketBuilder builder = new PcapDotNet.Packets.PacketBuilder(ethernetLayer, arpLayer);
                _packet = builder.Build(DateTime.Now);
        }
        public void BuildPacket_RARP()
        {
            EthernetLayer ethernetLayer =
                new EthernetLayer
                {
                    Source = _src_mac,
                    Destination = _broadcast_mac,
                    EtherType = EthernetType.None, // Will be filled automatically.
                };

            ArpLayer arpLayer =
                new ArpLayer
                {
                    ProtocolType = EthernetType.IpV4,
                    Operation = ArpOperation.InverseRequest,
                    SenderHardwareAddress = MAC2bytes(_src_mac).AsReadOnly(), // Source MAC
                    SenderProtocolAddress = IP2bytes(_src_ip).AsReadOnly(), // Source IP
                    TargetHardwareAddress = MAC2bytes(_dst_mac).AsReadOnly(), // Broadcast MAC
                    TargetProtocolAddress = new byte[] { 255, 255, 255, 255 }.AsReadOnly(), // Destination IP
                };

            PcapDotNet.Packets.PacketBuilder builder = new PcapDotNet.Packets.PacketBuilder(ethernetLayer, arpLayer);
            _packet = builder.Build(DateTime.Now);
        }
        public void BuildPacket_ICMP()
        {
            EthernetLayer ethernetLayer =
                new EthernetLayer
                {
                    Source = _src_mac,
                    Destination = _dst_mac,
                    EtherType = EthernetType.None, // Will be filled automatically.
                };

            IpV4Layer ipV4Layer =
                new IpV4Layer
                {
                    Source = _src_ip,
                    CurrentDestination = _dst_ip,
                    Fragmentation = IpV4Fragmentation.None,
                    HeaderChecksum = null, // Will be filled automatically.
                    Identification = 123,
                    Options = IpV4Options.None,
                    Protocol = null, // Will be filled automatically.
                    Ttl = 100,
                    TypeOfService = 0,
                };

            IcmpEchoLayer icmpLayer =
                new IcmpEchoLayer
                {
                    Checksum = null, // Will be filled automatically.
                    Identifier = 456,
                    SequenceNumber = 800,
                };

            PcapDotNet.Packets.PacketBuilder builder = new PcapDotNet.Packets.PacketBuilder(ethernetLayer, ipV4Layer, icmpLayer);

            _packet = builder.Build(DateTime.Now);
        }

        public void BuildPacket_TCP_IP()
        {
            EthernetLayer ethernetLayer =
                new EthernetLayer
                {
                    Source = _src_mac,
                    Destination = _dst_mac,
                    EtherType = EthernetType.None, // Will be filled automatically.
                };

            IpV4Layer ipV4Layer =
                new IpV4Layer
                {
                    Source = _src_ip,
                    CurrentDestination = _dst_ip,
                    Fragmentation = IpV4Fragmentation.None,
                    HeaderChecksum = null, // Will be filled automatically.
                    Identification = 123,
                    Options = IpV4Options.None,
                    Protocol = null, // Will be filled automatically.
                    Ttl = 100,
                    TypeOfService = 0,
                };

            TcpLayer tcpLayer =
                new TcpLayer
                {
                    SourcePort = _src_port,
                    DestinationPort = _dst_port,
                    Checksum = null, // Will be filled automatically.
                    SequenceNumber = 100,
                    AcknowledgmentNumber = 50,
                    ControlBits = TcpControlBits.Acknowledgment,
                    Window = 100,
                    UrgentPointer = 0,
                    Options = TcpOptions.None,
                };

            PayloadLayer payloadLayer =
                new PayloadLayer
                {
                    Data = new Datagram(_data),
                };

            PcapDotNet.Packets.PacketBuilder builder = new PcapDotNet.Packets.PacketBuilder(ethernetLayer, ipV4Layer, tcpLayer, payloadLayer);

            _packet = builder.Build(DateTime.Now);
        }

        public void BuildPacket_UDP_IP()
        {
            EthernetLayer ethernetLayer =
                new EthernetLayer
                {
                    Source = _src_mac,
                    Destination = _dst_mac,
                    EtherType = EthernetType.None, // Will be filled automatically.
                };

            IpV4Layer ipV4Layer =
                new IpV4Layer
                {
                    Source = _src_ip,
                    CurrentDestination = _dst_ip,
                    Fragmentation = IpV4Fragmentation.None,
                    HeaderChecksum = null, // Will be filled automatically.
                    Identification = 123,
                    Options = IpV4Options.None,
                    Protocol = null, // Will be filled automatically.
                    Ttl = 100,
                    TypeOfService = 0,
                };
            UdpLayer udpLayer =
                new UdpLayer
                {
                    SourcePort = _src_port,
                    DestinationPort = _dst_port,
                    Checksum = null, // Will be filled automatically.
                    CalculateChecksumValue = true,
                };

            PayloadLayer payloadLayer =
                new PayloadLayer
                {
                    Data = new Datagram(_data),
                };

            PcapDotNet.Packets.PacketBuilder builder = new PcapDotNet.Packets.PacketBuilder(ethernetLayer, ipV4Layer, udpLayer, payloadLayer);

            _packet = builder.Build(DateTime.Now);
        }


        public void BuildPacket_PN_DCP_ID_REQ_All()
        {
            // PN-DCP Header
            PN_FrameID = 0xfefe;
            PN_DCP_ServiceID = 5;
            PN_DCP_ServiceType = 0;
            PN_DCP_Xid = 0x01000001;
            PN_DCP_ResponseDelay = 1;
            PN_DCP_DataLength = 4;

            // PN-DCP Block
            PN_DCP_Block_Option = 0xFF;
            PN_DCP_Block_Suboption = 0xFF;
            PN_DCP_Block_Length = 0;

            EthernetLayer ethernetLayer =
                new EthernetLayer
                {
                    Source = _src_mac,
                    Destination = _pn_multicast_mac,
                    EtherType = (EthernetType)34962, // Will be filled automatically.
                };
            
            PayloadLayer DCP_header  =
                new PayloadLayer {
                    Data = new Datagram(new byte[] {
                        (byte)((PN_FrameID >> 8) & 0xFF),
                        (byte)((PN_FrameID >> 0) & 0xFF),
                        (byte)PN_DCP_ServiceID,
                        (byte)PN_DCP_ServiceType,
                        (byte)((PN_DCP_Xid >> 24) & 0xFF),
                        (byte)((PN_DCP_Xid >> 16) & 0xFF),
                        (byte)((PN_DCP_Xid >> 08) & 0xFF),
                        (byte)((PN_DCP_Xid >> 00) & 0xFF),
                        (byte)((PN_DCP_ResponseDelay >> 8) & 0xFF),
                        (byte)((PN_DCP_ResponseDelay >> 0) & 0xFF),
                        (byte)((PN_DCP_DataLength >> 8) & 0xFF),
                        (byte)((PN_DCP_DataLength >> 0) & 0xFF),
                    })
                };
            PayloadLayer DCP_block =
                new PayloadLayer
                {
                    Data = new Datagram(new byte[] {
                        (byte)PN_DCP_Block_Option,
                        (byte)PN_DCP_Block_Suboption,
                        (byte)((PN_DCP_Block_Length >> 8) & 0xFF),
                        (byte)((PN_DCP_Block_Length >> 0) & 0xFF),
                    })
                };
            PcapDotNet.Packets.PacketBuilder builder = new PcapDotNet.Packets.PacketBuilder(ethernetLayer, DCP_header, DCP_block);
            _packet = builder.Build(DateTime.Now);
        }
        public void BuildPacket_PN_DCP_SET_IP()
        {
            // PN-DCP Header
            PN_FrameID = 0xfefd;
            PN_DCP_ServiceID = 4;
            PN_DCP_ServiceType = 0;
            PN_DCP_Xid = 0x01000001;
            PN_DCP_ResponseDelay = 0;
            PN_DCP_DataLength = 18;


            byte[] _DCP_header = new byte[12];
            _DCP_header[0] = (byte)((PN_FrameID >> 8) & 0xFF);
            _DCP_header[1] = (byte)((PN_FrameID >> 0) & 0xFF);
            _DCP_header[2] = (byte)PN_DCP_ServiceID;
            _DCP_header[3] = (byte)PN_DCP_ServiceType;
            _DCP_header[4] = (byte)((PN_DCP_Xid >> 24) & 0xFF);
            _DCP_header[5] = (byte)((PN_DCP_Xid >> 16) & 0xFF);
            _DCP_header[6] = (byte)((PN_DCP_Xid >> 08) & 0xFF);
            _DCP_header[7] = (byte)((PN_DCP_Xid >> 00) & 0xFF);
            _DCP_header[8] = (byte)((PN_DCP_ResponseDelay >> 8) & 0xFF);
            _DCP_header[9] = (byte)((PN_DCP_ResponseDelay >> 0) & 0xFF);
            _DCP_header[10] = (byte)((PN_DCP_DataLength >> 8) & 0xFF);
            _DCP_header[11] = (byte)((PN_DCP_DataLength >> 0) & 0xFF);

            // PN-DCP Block

            PN_DCP_Block_Option = 0x01;
            PN_DCP_Block_Suboption = 0x02;
            PN_DCP_Block_Length = 14;


            byte[] _DCP_block_hdr = new byte[4];
            _DCP_block_hdr[0] = (byte)PN_DCP_Block_Option;
            _DCP_block_hdr[1] = (byte)PN_DCP_Block_Suboption;
            _DCP_block_hdr[2] = (byte)((PN_DCP_Block_Length >> 8) & 0xFF);
            _DCP_block_hdr[3] = (byte)((PN_DCP_Block_Length >> 0) & 0xFF);

            List<byte[]> _DCP_block = new List<byte[]>();
            _DCP_block.Add(_DCP_block_hdr);
            _DCP_block.Add(new byte[] { 0, 1 });
            _DCP_block.Add(IP2bytes(_PN_DCP_Block_IP_Address));
            _DCP_block.Add(IP2bytes(_PN_DCP_Block_IP_Subnet));
            _DCP_block.Add(IP2bytes(_PN_DCP_Block_IP_Gateway));

            _DCP_block.Insert(0, _DCP_header);


            byte[] _payloadLayer = LIST2bytes(_DCP_block);


            EthernetLayer ethernetLayer =
                new EthernetLayer
                {
                    Source = _src_mac,
                    Destination = _dst_mac,
                    EtherType = (EthernetType)34962, // Will be filled automatically.
                };

            PayloadLayer payloadLayer =
                new PayloadLayer
                {
                    Data = new Datagram(_payloadLayer)
                };

            PcapDotNet.Packets.PacketBuilder builder = new PcapDotNet.Packets.PacketBuilder(ethernetLayer, payloadLayer);
            _packet = builder.Build(DateTime.Now);
        }
        public void BuildPacket_PN_DCP_SET_DEVICENAME()
        {
            byte[] _DEVICENAME = Encoding.ASCII.GetBytes(PN_DCP_Block_DeviceName);

            // PN-DCP Header
            PN_FrameID = 0xfefd;
            PN_DCP_ServiceID = 4;
            PN_DCP_ServiceType = 0;
            PN_DCP_Xid = 0x01000001;
            PN_DCP_ResponseDelay = 0;
            if (_DEVICENAME.Length % 2 == 0)
            {
                PN_DCP_DataLength = (UInt16)(12 + _DEVICENAME.Length);
            }
            else
            {

                PN_DCP_DataLength = (UInt16)(13 + _DEVICENAME.Length);
            }


            byte[] _DCP_header = new byte[12];
            _DCP_header[0] = (byte)((PN_FrameID >> 8) & 0xFF);
            _DCP_header[1] = (byte)((PN_FrameID >> 0) & 0xFF);
            _DCP_header[2] = (byte)PN_DCP_ServiceID;
            _DCP_header[3] = (byte)PN_DCP_ServiceType;
            _DCP_header[4] = (byte)((PN_DCP_Xid >> 24) & 0xFF);
            _DCP_header[5] = (byte)((PN_DCP_Xid >> 16) & 0xFF);
            _DCP_header[6] = (byte)((PN_DCP_Xid >> 08) & 0xFF);
            _DCP_header[7] = (byte)((PN_DCP_Xid >> 00) & 0xFF);
            _DCP_header[8] = (byte)((PN_DCP_ResponseDelay >> 8) & 0xFF);
            _DCP_header[9] = (byte)((PN_DCP_ResponseDelay >> 0) & 0xFF);
            _DCP_header[10] = (byte)((PN_DCP_DataLength >> 8) & 0xFF);
            _DCP_header[11] = (byte)((PN_DCP_DataLength >> 0) & 0xFF);

            // PN-DCP Block

            PN_DCP_Block_Option = 0x02;
            PN_DCP_Block_Suboption = 0x02;
            PN_DCP_Block_Length = (UInt16)(2 + _DEVICENAME.Length);


            // PN-DCP END TRANS
            PN_DCP_Block_Option = 0x02;
            PN_DCP_Block_Suboption = 0x02;
            PN_DCP_Block_Length = (UInt16)(2 + _DEVICENAME.Length);


            byte[] _DCP_block_hdr = new byte[4];
            _DCP_block_hdr[0] = (byte)PN_DCP_Block_Option;
            _DCP_block_hdr[1] = (byte)PN_DCP_Block_Suboption;
            _DCP_block_hdr[2] = (byte)((PN_DCP_Block_Length >> 8) & 0xFF);
            _DCP_block_hdr[3] = (byte)((PN_DCP_Block_Length >> 0) & 0xFF);

            List<byte[]> _DCP_block = new List<byte[]>();
            // DCP Block
            _DCP_block.Add(_DCP_block_hdr);
            _DCP_block.Add(new byte[] { 0, 1 });
            _DCP_block.Add(_DEVICENAME);
            if (_DEVICENAME.Length % 2 != 0){ _DCP_block.Add(new byte[] { 0 }); }
            // END TRANS
            _DCP_block.Add(new byte[] { 05, 02, 00, 02, 00, 01 });

            _DCP_block.Insert(0, _DCP_header);


            byte[] _payloadLayer = LIST2bytes(_DCP_block);


            EthernetLayer ethernetLayer =
                new EthernetLayer
                {
                    Source = _src_mac,
                    Destination = _dst_mac,
                    EtherType = (EthernetType)34962, // Will be filled automatically.
                };

            PayloadLayer payloadLayer =
                new PayloadLayer
                {
                    Data = new Datagram(_payloadLayer)
                };
            
            PcapDotNet.Packets.PacketBuilder builder = new PcapDotNet.Packets.PacketBuilder(ethernetLayer, payloadLayer);
            _packet = builder.Build(DateTime.Now);
        }
        public Packet BuildVLanTaggedFramePacket()
        {
            EthernetLayer ethernetLayer =
                new EthernetLayer
                {
                    Source = new MacAddress("01:01:01:01:01:01"),
                    Destination = new MacAddress("02:02:02:02:02:02"),
                    EtherType = EthernetType.None, // Will be filled automatically.
                };

            VLanTaggedFrameLayer vLanTaggedFrameLayer =
                new VLanTaggedFrameLayer
                {
                    PriorityCodePoint = ClassOfService.NetworkControl,
                    CanonicalFormatIndicator = false,
                    VLanIdentifier = 50,
                    EtherType = (EthernetType)34962,
                };

            PayloadLayer payloadLayer =
                new PayloadLayer
                {
                    Data = new Datagram(new byte[] { 0x80, 0x6B,
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                    0x10, 0x10, 0x35, 0x00})
                };

            PcapDotNet.Packets.PacketBuilder builder = new PcapDotNet.Packets.PacketBuilder(ethernetLayer, vLanTaggedFrameLayer, payloadLayer);

            return builder.Build(DateTime.Now);
        }
        public Packet BuildProfinetFramePacket()
        {
            EthernetLayer ethernetLayer =
                new EthernetLayer
                {
                    Source = new MacAddress("28:63:36:88:02:52"),
                    Destination = new MacAddress("00:1b:1b:6b:6b:0e"),
                    EtherType = EthernetType.None, // Will be filled automatically.
                };

            VLanTaggedFrameLayer vLanTaggedFrameLayer =
                new VLanTaggedFrameLayer
                {
                    PriorityCodePoint = ClassOfService.NetworkControl,
                    CanonicalFormatIndicator = false,
                    VLanIdentifier = 50,
                    EtherType = (EthernetType)34962,
                };

            PayloadLayer payloadLayer =
                new PayloadLayer
                {
                    Data = new Datagram(new byte[] { 0x80, 0x00,
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                    0x10, 0x40, 0x35, 0x00})
                };

            PcapDotNet.Packets.PacketBuilder builder = new PcapDotNet.Packets.PacketBuilder(ethernetLayer, vLanTaggedFrameLayer, payloadLayer);

            return builder.Build(DateTime.Now);
        }
        public Packet BuildIpV4Packet()
        {
            EthernetLayer ethernetLayer =
                new EthernetLayer
                {
                    Source = new MacAddress("68:05:CA:1E:94:1C"),
                    Destination = new MacAddress("90:A2:DA:0D:F7:CD"),
                    EtherType = EthernetType.None,
                };

            IpV4Layer ipV4Layer =
                new IpV4Layer
                {
                    Source = new IpV4Address("10.128.24.154"),
                    CurrentDestination = new IpV4Address("10.128.24.165"),
                    Fragmentation = IpV4Fragmentation.None,
                    HeaderChecksum = null, // Will be filled automatically.
                    Identification = 123,
                    Options = IpV4Options.None,
                    Protocol = IpV4Protocol.Udp,
                    Ttl = 100,
                    TypeOfService = 0,
                };

            PayloadLayer payloadLayer =
                new PayloadLayer
                {
                    Data = new Datagram(Encoding.ASCII.GetBytes("hello world")),
                };

            PcapDotNet.Packets.PacketBuilder builder = new PcapDotNet.Packets.PacketBuilder(ethernetLayer, ipV4Layer, payloadLayer);

            return builder.Build(DateTime.Now);
        }
        public Packet BuildIpV6Packet()
        {
            EthernetLayer ethernetLayer =
                new EthernetLayer
                {
                    Source = new MacAddress("68:05:CA:1E:94:1C"),
                    Destination = new MacAddress("90:A2:DA:0D:F7:CD"),
                    EtherType = EthernetType.None,
                };

            IpV6Layer ipV6Layer =
                new IpV6Layer
                {
                    Source = new IpV6Address("0123:4567:89AB:CDEF:0123:4567:89AB:CDEF"),
                    CurrentDestination = new IpV6Address("FEDC:BA98:7654:3210:FEDC:BA98:7654:3210"),
                    FlowLabel = 123,
                    HopLimit = 100,
                    NextHeader = IpV4Protocol.Udp,
                };

            PayloadLayer payloadLayer =
                new PayloadLayer
                {
                    Data = new Datagram(Encoding.ASCII.GetBytes("hello world")),
                };

            PcapDotNet.Packets.PacketBuilder builder = new PcapDotNet.Packets.PacketBuilder(ethernetLayer, ipV6Layer, payloadLayer);

            return builder.Build(DateTime.Now);
        }
        public Packet BuildIcmpPacket()
        {
            EthernetLayer ethernetLayer =
                new EthernetLayer
                {
                    Source = new MacAddress("01:01:01:01:01:01"),
                    Destination = new MacAddress("02:02:02:02:02:02"),
                    EtherType = EthernetType.None, // Will be filled automatically.
                };

            IpV4Layer ipV4Layer =
                new IpV4Layer
                {
                    Source = new IpV4Address("1.2.3.4"),
                    CurrentDestination = new IpV4Address("11.22.33.44"),
                    Fragmentation = IpV4Fragmentation.None,
                    HeaderChecksum = null, // Will be filled automatically.
                    Identification = 123,
                    Options = IpV4Options.None,
                    Protocol = null, // Will be filled automatically.
                    Ttl = 100,
                    TypeOfService = 0,
                };

            IcmpEchoLayer icmpLayer =
                new IcmpEchoLayer
                {
                    Checksum = null, // Will be filled automatically.
                    Identifier = 456,
                    SequenceNumber = 800,
                };

            PcapDotNet.Packets.PacketBuilder builder = new PcapDotNet.Packets.PacketBuilder(ethernetLayer, ipV4Layer, icmpLayer);

            return builder.Build(DateTime.Now);
        }
        public Packet BuildIgmpPacket()
        {
            EthernetLayer ethernetLayer =
                new EthernetLayer
                {
                    Source = new MacAddress("01:01:01:01:01:01"),
                    Destination = new MacAddress("02:02:02:02:02:02"),
                    EtherType = EthernetType.None, // Will be filled automatically.
                };

            IpV4Layer ipV4Layer =
                new IpV4Layer
                {
                    Source = new IpV4Address("1.2.3.4"),
                    CurrentDestination = new IpV4Address("11.22.33.44"),
                    Fragmentation = IpV4Fragmentation.None,
                    HeaderChecksum = null, // Will be filled automatically.
                    Identification = 123,
                    Options = IpV4Options.None,
                    Protocol = null, // Will be filled automatically.
                    Ttl = 100,
                    TypeOfService = 0,
                };

            IgmpQueryVersion1Layer igmpLayer =
                new IgmpQueryVersion1Layer
                {
                    GroupAddress = new IpV4Address("1.2.3.4"),
                };

            PcapDotNet.Packets.PacketBuilder builder = new PcapDotNet.Packets.PacketBuilder(ethernetLayer, ipV4Layer, igmpLayer);

            return builder.Build(DateTime.Now);
        }
        public Packet BuildGrePacket()
        {
            EthernetLayer ethernetLayer =
                new EthernetLayer
                {
                    Source = new MacAddress("01:01:01:01:01:01"),
                    Destination = new MacAddress("02:02:02:02:02:02"),
                    EtherType = EthernetType.None, // Will be filled automatically.
                };

            IpV4Layer ipV4Layer =
                new IpV4Layer
                {
                    Source = new IpV4Address("1.2.3.4"),
                    CurrentDestination = new IpV4Address("11.22.33.44"),
                    Fragmentation = IpV4Fragmentation.None,
                    HeaderChecksum = null, // Will be filled automatically.
                    Identification = 123,
                    Options = IpV4Options.None,
                    Protocol = null, // Will be filled automatically.
                    Ttl = 100,
                    TypeOfService = 0,
                };

            GreLayer greLayer =
                new GreLayer
                {
                    Version = GreVersion.Gre,
                    ProtocolType = EthernetType.None, // Will be filled automatically.
                    RecursionControl = 0,
                    FutureUseBits = 0,
                    ChecksumPresent = true,
                    Checksum = null, // Will be filled automatically.
                    Key = null,
                    SequenceNumber = 123,
                    AcknowledgmentSequenceNumber = null,
                    RoutingOffset = null,
                    Routing = null,
                    StrictSourceRoute = false,
                };

            IpV4Layer innerIpV4Layer =
                new IpV4Layer
                {
                    Source = new IpV4Address("100.200.201.202"),
                    CurrentDestination = new IpV4Address("123.254.132.40"),
                    Fragmentation = IpV4Fragmentation.None,
                    HeaderChecksum = null, // Will be filled automatically.
                    Identification = 123,
                    Options = IpV4Options.None,
                    Protocol = IpV4Protocol.Udp,
                    Ttl = 120,
                    TypeOfService = 0,
                };

            PcapDotNet.Packets.PacketBuilder builder = new PcapDotNet.Packets.PacketBuilder(ethernetLayer, ipV4Layer, greLayer, innerIpV4Layer);

            return builder.Build(DateTime.Now);
        }
        public Packet BuildUdpPacket()
        {
            EthernetLayer ethernetLayer =
                new EthernetLayer
                {
                    Source = new MacAddress("68:05:CA:1E:94:1C"),
                    Destination = new MacAddress("90:A2:DA:0D:F7:CD"),
                    EtherType = EthernetType.None, // Will be filled automatically.
                };

            IpV4Layer ipV4Layer =
                new IpV4Layer
                {
                    Source = new IpV4Address("10.128.24.154"),
                    CurrentDestination = new IpV4Address("10.128.24.165"),
                    Fragmentation = IpV4Fragmentation.None,
                    HeaderChecksum = null, // Will be filled automatically.
                    Identification = 123,
                    Options = IpV4Options.None,
                    Protocol = null, // Will be filled automatically.
                    Ttl = 100,
                    TypeOfService = 0,
                };

            UdpLayer udpLayer =
                new UdpLayer
                {
                    SourcePort = 34964,
                    DestinationPort = 49155,
                    Checksum = null, // Will be filled automatically.
                    CalculateChecksumValue = true,
                };

            PayloadLayer payloadLayer =
                new PayloadLayer
                {
                    Data = new Datagram(Encoding.ASCII.GetBytes("hello world")),
                };

            PcapDotNet.Packets.PacketBuilder builder = new PcapDotNet.Packets.PacketBuilder(ethernetLayer, ipV4Layer, udpLayer, payloadLayer);

            return builder.Build(DateTime.Now);
        }
        public Packet BuildLongUdpPacket()
        {
            EthernetLayer ethernetLayer =
                new EthernetLayer
                {
                    Source = new MacAddress("01:01:01:01:01:01"),
                    Destination = new MacAddress("FF:FF:FF:FF:FF:FF"),
                    EtherType = EthernetType.None, // Will be filled automatically.
                };

            IpV4Layer ipV4Layer =
                new IpV4Layer
                {
                    Source = new IpV4Address("1.1.1.1"),
                    CurrentDestination = new IpV4Address("255.255.255.255"),
                    Fragmentation = IpV4Fragmentation.None,
                    HeaderChecksum = null, // Will be filled automatically.
                    Identification = 123,
                    Options = IpV4Options.None,
                    Protocol = null, // Will be filled automatically.
                    Ttl = 100,
                    TypeOfService = 0,
                };

            UdpLayer udpLayer =
                new UdpLayer
                {
                    SourcePort = 4050,
                    DestinationPort = 25,
                    Checksum = null, // Will be filled automatically.
                    CalculateChecksumValue = true,
                };

            PayloadLayer payloadLayer =
                new PayloadLayer
                {
                    Data = new Datagram(Encoding.ASCII.GetBytes("A very long UDP packet dddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd")),
                };

            PcapDotNet.Packets.PacketBuilder builder = new PcapDotNet.Packets.PacketBuilder(ethernetLayer, ipV4Layer, udpLayer, payloadLayer);

            return builder.Build(DateTime.Now);
        }
        public Packet BuildTcpPacket()
        {
            EthernetLayer ethernetLayer =
                new EthernetLayer
                {
                    Source = new MacAddress("01:01:01:01:01:01"),
                    Destination = new MacAddress("02:02:02:02:02:02"),
                    EtherType = EthernetType.None, // Will be filled automatically.
                };

            IpV4Layer ipV4Layer =
                new IpV4Layer
                {
                    Source = new IpV4Address("1.2.3.4"),
                    CurrentDestination = new IpV4Address("11.22.33.44"),
                    Fragmentation = IpV4Fragmentation.None,
                    HeaderChecksum = null, // Will be filled automatically.
                    Identification = 123,
                    Options = IpV4Options.None,
                    Protocol = null, // Will be filled automatically.
                    Ttl = 100,
                    TypeOfService = 0,
                };

            TcpLayer tcpLayer =
                new TcpLayer
                {
                    SourcePort = 4050,
                    DestinationPort = 25,
                    Checksum = null, // Will be filled automatically.
                    SequenceNumber = 100,
                    AcknowledgmentNumber = 50,
                    ControlBits = TcpControlBits.Acknowledgment,
                    Window = 100,
                    UrgentPointer = 0,
                    Options = TcpOptions.None,
                };

            PayloadLayer payloadLayer =
                new PayloadLayer
                {
                    Data = new Datagram(Encoding.ASCII.GetBytes("hello world")),
                };

            PcapDotNet.Packets.PacketBuilder builder = new PcapDotNet.Packets.PacketBuilder(ethernetLayer, ipV4Layer, tcpLayer, payloadLayer);

            return builder.Build(DateTime.Now);
        }
        public Packet BuildDnsPacket()
        {
            EthernetLayer ethernetLayer =
                new EthernetLayer
                {
                    Source = new MacAddress("01:01:01:01:01:01"),
                    Destination = new MacAddress("02:02:02:02:02:02"),
                    EtherType = EthernetType.None, // Will be filled automatically.
                };

            IpV4Layer ipV4Layer =
                new IpV4Layer
                {
                    Source = new IpV4Address("1.2.3.4"),
                    CurrentDestination = new IpV4Address("11.22.33.44"),
                    Fragmentation = IpV4Fragmentation.None,
                    HeaderChecksum = null, // Will be filled automatically.
                    Identification = 123,
                    Options = IpV4Options.None,
                    Protocol = null, // Will be filled automatically.
                    Ttl = 100,
                    TypeOfService = 0,
                };

            UdpLayer udpLayer =
                new UdpLayer
                {
                    SourcePort = 4050,
                    DestinationPort = 53,
                    Checksum = null, // Will be filled automatically.
                    CalculateChecksumValue = true,
                };

            DnsLayer dnsLayer =
                new DnsLayer
                {
                    Id = 100,
                    IsResponse = false,
                    OpCode = DnsOpCode.Query,
                    IsAuthoritativeAnswer = false,
                    IsTruncated = false,
                    IsRecursionDesired = true,
                    IsRecursionAvailable = false,
                    FutureUse = false,
                    IsAuthenticData = false,
                    IsCheckingDisabled = false,
                    ResponseCode = DnsResponseCode.NoError,
                    Queries = new[]
                                      {
                                          new DnsQueryResourceRecord(new DnsDomainName("pcapdot.net"),
                                                                     DnsType.A,
                                                                     DnsClass.Internet),
                                      },
                    Answers = null,
                    Authorities = null,
                    Additionals = null,
                    DomainNameCompressionMode = DnsDomainNameCompressionMode.All,
                };

            PcapDotNet.Packets.PacketBuilder builder = new PcapDotNet.Packets.PacketBuilder(ethernetLayer, ipV4Layer, udpLayer, dnsLayer);

            return builder.Build(DateTime.Now);
        }
        public Packet BuildHttpPacket()
        {
            EthernetLayer ethernetLayer =
                new EthernetLayer
                {
                    Source = new MacAddress("01:01:01:01:01:01"),
                    Destination = new MacAddress("02:02:02:02:02:02"),
                    EtherType = EthernetType.None, // Will be filled automatically.
                };

            IpV4Layer ipV4Layer =
                new IpV4Layer
                {
                    Source = new IpV4Address("1.2.3.4"),
                    CurrentDestination = new IpV4Address("11.22.33.44"),
                    Fragmentation = IpV4Fragmentation.None,
                    HeaderChecksum = null, // Will be filled automatically.
                    Identification = 123,
                    Options = IpV4Options.None,
                    Protocol = null, // Will be filled automatically.
                    Ttl = 100,
                    TypeOfService = 0,
                };

            TcpLayer tcpLayer =
                new TcpLayer
                {
                    SourcePort = 4050,
                    DestinationPort = 80,
                    Checksum = null, // Will be filled automatically.
                    SequenceNumber = 100,
                    AcknowledgmentNumber = 50,
                    ControlBits = TcpControlBits.Acknowledgment,
                    Window = 100,
                    UrgentPointer = 0,
                    Options = TcpOptions.None,
                };

            HttpRequestLayer httpLayer =
                new HttpRequestLayer
                {
                    Version = HttpVersion.Version11,
                    Header = new HttpHeader(new HttpContentLengthField(11)),
                    Body = new Datagram(Encoding.ASCII.GetBytes("hello world")),
                    Method = new HttpRequestMethod(HttpRequestKnownMethod.Get),
                    Uri = @"http://pcapdot.net/",
                };

            PcapDotNet.Packets.PacketBuilder builder = new PcapDotNet.Packets.PacketBuilder(ethernetLayer, ipV4Layer, tcpLayer, httpLayer);

            return builder.Build(DateTime.Now);
        }
        public Packet BuildComplexPacket()
        {
            return PcapDotNet.Packets.PacketBuilder.Build(
                DateTime.Now,
                new EthernetLayer
                {
                    Source = new MacAddress("01:01:01:01:01:01"),
                    Destination = new MacAddress("02:02:02:02:02:02"),
                    EtherType = EthernetType.None, // Will be filled automatically.
                },
                new VLanTaggedFrameLayer
                {
                    PriorityCodePoint = ClassOfService.ExcellentEffort,
                    CanonicalFormatIndicator = false,
                    EtherType = EthernetType.None, // Will be filled automatically.
                },
                new VLanTaggedFrameLayer
                {
                    PriorityCodePoint = ClassOfService.BestEffort,
                    CanonicalFormatIndicator = false,
                    EtherType = EthernetType.None, // Will be filled automatically.
                },
                new IpV4Layer
                {
                    Source = new IpV4Address("1.2.3.4"),
                    CurrentDestination = new IpV4Address("11.22.33.44"),
                    Fragmentation = IpV4Fragmentation.None,
                    HeaderChecksum = null, // Will be filled automatically.
                    Identification = 123,
                    Options = IpV4Options.None,
                    Protocol = null, // Will be filled automatically.
                    Ttl = 100,
                    TypeOfService = 0,
                },
                new IpV4Layer
                {
                    Source = new IpV4Address("5.6.7.8"),
                    CurrentDestination = new IpV4Address("55.66.77.88"),
                    Fragmentation = IpV4Fragmentation.None,
                    HeaderChecksum = null, // Will be filled automatically.
                    Identification = 456,
                    Options = new IpV4Options(new IpV4OptionStrictSourceRouting(
                                                      new[]
                                                          {
                                                              new IpV4Address("100.200.100.200"),
                                                              new IpV4Address("150.250.150.250")
                                                          }, 1)),
                    Protocol = null, // Will be filled automatically.
                    Ttl = 200,
                    TypeOfService = 0,
                },
                new GreLayer
                {
                    Version = GreVersion.Gre,
                    ProtocolType = EthernetType.None, // Will be filled automatically.
                    RecursionControl = 0,
                    FutureUseBits = 0,
                    ChecksumPresent = true,
                    Checksum = null, // Will be filled automatically.
                    Key = 100,
                    SequenceNumber = 123,
                    AcknowledgmentSequenceNumber = null,
                    RoutingOffset = null,
                    Routing = new[]
                                      {
                                          new GreSourceRouteEntryIp(
                                              new[]
                                                  {
                                                      new IpV4Address("10.20.30.40"),
                                                      new IpV4Address("40.30.20.10")
                                                  }.AsReadOnly(), 1),
                                          new GreSourceRouteEntryIp(
                                              new[]
                                                  {
                                                      new IpV4Address("11.22.33.44"),
                                                      new IpV4Address("44.33.22.11")
                                                  }.AsReadOnly(), 0)
                                      }.Cast<GreSourceRouteEntry>().ToArray().AsReadOnly(),
                    StrictSourceRoute = false,
                },
                new IpV4Layer
                {
                    Source = new IpV4Address("51.52.53.54"),
                    CurrentDestination = new IpV4Address("61.62.63.64"),
                    Fragmentation = IpV4Fragmentation.None,
                    HeaderChecksum = null, // Will be filled automatically.
                    Identification = 123,
                    Options = new IpV4Options(
                            new IpV4OptionTimestampOnly(0, 1,
                                                        new IpV4TimeOfDay(new TimeSpan(1, 2, 3)),
                                                        new IpV4TimeOfDay(new TimeSpan(15, 55, 59))),
                            new IpV4OptionQuickStart(IpV4OptionQuickStartFunction.RateRequest, 10, 200, 300)),
                    Protocol = null, // Will be filled automatically.
                    Ttl = 100,
                    TypeOfService = 0,
                },
                new UdpLayer
                {
                    SourcePort = 53,
                    DestinationPort = 40101,
                    Checksum = null, // Will be filled automatically.
                    CalculateChecksumValue = true,
                },
                new DnsLayer
                {
                    Id = 10012,
                    IsResponse = true,
                    OpCode = DnsOpCode.Query,
                    IsAuthoritativeAnswer = true,
                    IsTruncated = false,
                    IsRecursionDesired = true,
                    IsRecursionAvailable = true,
                    FutureUse = false,
                    IsAuthenticData = true,
                    IsCheckingDisabled = false,
                    ResponseCode = DnsResponseCode.NoError,
                    Queries =
                            new[]
                                {
                                    new DnsQueryResourceRecord(
                                        new DnsDomainName("pcapdot.net"),
                                        DnsType.Any,
                                        DnsClass.Internet),
                                },
                    Answers =
                            new[]
                                {
                                    new DnsDataResourceRecord(
                                        new DnsDomainName("pcapdot.net"),
                                        DnsType.A,
                                        DnsClass.Internet
                                        , 50000,
                                        new DnsResourceDataIpV4(new IpV4Address("10.20.30.44"))),
                                    new DnsDataResourceRecord(
                                        new DnsDomainName("pcapdot.net"),
                                        DnsType.Txt,
                                        DnsClass.Internet,
                                        50000,
                                        new DnsResourceDataText(new[] {new DataSegment(Encoding.ASCII.GetBytes("Pcap.Net"))}.AsReadOnly()))
                                },
                    Authorities =
                            new[]
                                {
                                    new DnsDataResourceRecord(
                                        new DnsDomainName("pcapdot.net"),
                                        DnsType.MailExchange,
                                        DnsClass.Internet,
                                        100,
                                        new DnsResourceDataMailExchange(100, new DnsDomainName("pcapdot.net")))
                                },
                    Additionals =
                            new[]
                                {
                                    new DnsOptResourceRecord(
                                        new DnsDomainName("pcapdot.net"),
                                        50000,
                                        0,
                                        DnsOptVersion.Version0,
                                        DnsOptFlags.DnsSecOk,
                                        new DnsResourceDataOptions(
                                            new DnsOptions(
                                                new DnsOptionUpdateLease(100),
                                                new DnsOptionLongLivedQuery(1,
                                                                            DnsLongLivedQueryOpCode.Refresh,
                                                                            DnsLongLivedQueryErrorCode.NoError,
                                                                            10, 20))))
                                },
                    DomainNameCompressionMode = DnsDomainNameCompressionMode.All,
                });
        }
        #endregion
    }
}
