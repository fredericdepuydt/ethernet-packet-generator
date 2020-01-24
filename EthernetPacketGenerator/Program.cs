using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Threading;
namespace PacketSender
{
    

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            int startTry = 0;
            while (startTry < 10)
            {
                SelectQuery query = new SelectQuery("Win32_SystemDriver");
                query.Condition = "Name = 'NPF'";
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
                var drivers = searcher.Get();


                if (drivers.Count > 0)
                {
                    foreach (ManagementBaseObject driverObject in drivers)
                    {
                        ManagementObject driver = (ManagementObject)driverObject;

                        string state = driver["State"].ToString();
                        if (state == "Running")
                        {
                            Application.EnableVisualStyles();
                            Application.SetCompatibleTextRenderingDefault(false);
                            Application.Run(new PacketSender());
                            return;
                        }
                        else
                        {

                            Console.WriteLine("Try starting service");

                            System.Diagnostics.ProcessStartInfo procStartInfo =
                                new System.Diagnostics.ProcessStartInfo("cmd", "/c net start npf");

                            procStartInfo.Verb = "runas";
                            // The following commands are needed to redirect the standard output.
                            // This means that it will be redirected to the Process.StandardOutput StreamReader.
                            procStartInfo.UseShellExecute = true;
                            // Do not create the black window.
                            procStartInfo.CreateNoWindow = true;
                            // Now we create a process, assign its ProcessStartInfo and start it
                            System.Diagnostics.Process proc = new System.Diagnostics.Process();
                            proc.StartInfo = procStartInfo;
                            try
                            {
                                proc.Start();
                                Thread.Sleep(1000);
                                startTry++;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                                MessageBox.Show("Failed to start WinPcap Driver.");
                                return;
                            }

                        }
                    }
                }
                else
                {
                    MessageBox.Show("WinPcap Driver could not be found.");
                }
            }
            MessageBox.Show("Failed to start WinPcap Driver.");
        }
    }
}
