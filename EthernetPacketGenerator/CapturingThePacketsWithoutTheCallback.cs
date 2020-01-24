using System;
using System.Collections.Generic;
using PcapDotNet.Base;
using PcapDotNet.Core;
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

namespace Application
{
    class CapturingThePacketsWithoutTheCallback
    {
        
        static PacketCommunicator Communicator;
        public static void HandlePackets()
        {
            // Retrieve the device list from the local machine
            IList<LivePacketDevice> allDevices = LivePacketDevice.AllLocalMachine;

            if (allDevices.Count == 0)
            {
                Console.WriteLine("No interfaces found! Make sure WinPcap is installed.");
                return;
            }

            // Print the list
            for (int i = 0; i != allDevices.Count; ++i)
            {
                LivePacketDevice device = allDevices[i];
                Console.Write((i + 1) + ". " + device.Name);
                if (device.Description != null)
                    Console.WriteLine(" (" + device.Description + ")");
                else
                    Console.WriteLine(" (No description available)");
            }

            int deviceIndex = 0;
            do
            {
                Console.WriteLine("Enter the interface number (1-" + allDevices.Count + "):");
                string deviceIndexString = Console.ReadLine();
                if (!int.TryParse(deviceIndexString, out deviceIndex) ||
                    deviceIndex < 1 || deviceIndex > allDevices.Count)
                {
                    deviceIndex = 0;
                }
            } while (deviceIndex == 0);

            // Take the selected adapter
            PacketDevice selectedDevice = allDevices[deviceIndex - 1];
            Communicator = selectedDevice.Open(128,                // portion of the packet to capture
                                    PacketDeviceOpenAttributes.Promiscuous, // promiscuous mode
                                    1);

            // Open the device
            String Filter = "ether src 28:63:36:88:02:52";
            Communicator.SetFilter(Filter);
            Console.WriteLine("Listening on " + selectedDevice.Description + "...");
            Console.WriteLine("Filter: " + Filter);

            
            Packet receivePacket;

            do
            {
                switch (Communicator.ReceivePacket(out receivePacket))
                {
                    case PacketCommunicatorReceiveResult.Timeout:
                        // Timeout elapsed
                        continue;
                    case PacketCommunicatorReceiveResult.Ok:
                        if (receivePacket.Buffer.Length >= 62)
                        {
                            int cyclecounter = receivePacket.Buffer.ReadByte(59) * 256 + receivePacket.Buffer.ReadByte(60) + 64;
                            if (cyclecounter >= 256 * 256) { cyclecounter = 0; }

                            Packet sendPacket = BuildVLanTaggedFramePacket(cyclecounter);
                            Communicator.SendPacket(sendPacket);
                        }
                        break;
                    default:
                        throw new InvalidOperationException("The result should never be reached here");
                }
            } while (true);
        }

        public static Packet BuildVLanTaggedFramePacket(int cyclecounter)
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
                    PriorityCodePoint = ClassOfService.InternetworkControl,
                    CanonicalFormatIndicator = false,
                    VLanIdentifier = 50,
                    EtherType = (EthernetType)34962,
                };

            PayloadLayer payloadLayer =
                new PayloadLayer
                {
                    Data = new Datagram(new byte[] { 0x80, 0x00,
                    0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0x80, 0xFF, 0x80, 0xFF,
                    0x80, 0x80, 0x80, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                    0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80, 0x80, 0x80,
                    Convert.ToByte((cyclecounter &  0xFF00) > 8), Convert.ToByte(cyclecounter & 0xFF), 0x35, 0x00})
                };

            PacketBuilder builder = new PacketBuilder(ethernetLayer, vLanTaggedFrameLayer, payloadLayer);

            return builder.Build(DateTime.Now);
        }
    }
}