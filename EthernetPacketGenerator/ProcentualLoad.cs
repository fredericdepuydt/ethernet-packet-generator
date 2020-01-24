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
    class ProcentualLoad
    {

        public static PacketCommunicator Communicator;
        public static void LoadExample()
        {
            // Retrieve the device list from the local machine
            PacketBuilder builder = BuildVLanTaggedFramePacketBuilder(ClassOfService.NetworkControl);
            DateTime now = DateTime.Now;
            now = now.AddMilliseconds(20);
            for (int j = 0; j != 10; j++)
            {
                PacketSendBuffer packbuffer = new PacketSendBuffer(100000);
                for (int i = 0; i != 10; i++)
                {
                    packbuffer.Enqueue(builder.Build(now));
                    now = now.AddMicroseconds(1000);
                }
                Communicator.Transmit(packbuffer, true);
            }
        }

        public static void ApplyLoad(int load)
        {
            load = 12000 / load;
            PacketBuilder builder = BuildVLanTaggedFramePacketBuilder(ClassOfService.NetworkControl);
            //PacketBuilder builder = DISTURB(ClassOfService.NetworkControl);
            DateTime now = DateTime.Now;
            now = now.AddMilliseconds(20);
            while(true)
            {
                PacketSendBuffer packbuffer = new PacketSendBuffer(1530000);
                
                for (int i = 0; i != 1000; i++)
                {
                    packbuffer.Enqueue(builder.Build(now));
                    now = now.AddMicroseconds(load);
                }
                Communicator.Transmit(packbuffer, true);
            }
        }
        public static void SetupInterface()
        {
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
        }


        public static PacketBuilder BuildVLanTaggedFramePacketBuilder(ClassOfService CoS)
        {

            EthernetLayer ethernetLayer =
                new EthernetLayer
                {
                    Source = new MacAddress("01:01:01:01:01:01"),
                    Destination = new MacAddress("90:1B:0E:1B:DD:E8"),
                    EtherType = EthernetType.None, // Will be filled automatically.
                };

            VLanTaggedFrameLayer vLanTaggedFrameLayer =
                new VLanTaggedFrameLayer
                {
                    PriorityCodePoint = CoS,
                    CanonicalFormatIndicator = false,
                    VLanIdentifier = 50,
                    EtherType = (EthernetType)34962,
                };

            PayloadLayer payloadLayer =
                new PayloadLayer
                {
                    Data = new Datagram(new byte[1496])
                };

            return new PacketBuilder(ethernetLayer, vLanTaggedFrameLayer, payloadLayer);
        }
        public static PacketBuilder DISTURB(ClassOfService CoS)
        {

            EthernetLayer ethernetLayer =
                new EthernetLayer
                {
                    Source = new MacAddress("90:1B:0E:1B:DD:D8"),
                    Destination = new MacAddress("FF:FF:FF:FF:FF:FF"),
                    EtherType = EthernetType.None, // Will be filled automatically.
                };

            VLanTaggedFrameLayer vLanTaggedFrameLayer =
                new VLanTaggedFrameLayer
                {
                    PriorityCodePoint = CoS,
                    CanonicalFormatIndicator = false,
                    VLanIdentifier = 50,
                    EtherType = EthernetType.Arp,
                };

            ArpLayer arpLayer =
                new ArpLayer
                {
                    ProtocolType = EthernetType.IpV4,
                    Operation = ArpOperation.Request,
                    SenderHardwareAddress = new byte[] { 144, 27, 14, 27, 221,  216}.AsReadOnly(), // 68:05:ca:1e:94:1c
                    SenderProtocolAddress = new byte[] { 10, 128, 24, 71 }.AsReadOnly(), // 1.2.3.4.
                    TargetHardwareAddress = new byte[] { 255, 255, 255, 255, 255, 255 }.AsReadOnly(), // 04:04:04:04:04:04.
                    TargetProtocolAddress = new byte[] { 10, 128, 24, 72 }.AsReadOnly(), // 11.22.33.44.
                };

            PayloadLayer payloadLayer =
                new PayloadLayer
                {
                    Data = new Datagram(new byte[1300])
                };          

            return new PacketBuilder(ethernetLayer, arpLayer, payloadLayer);
        }
    }
}