using System;
using System.Device.I2c;
using System.Text;
using System.Threading;

namespace PiEepromTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var settings = new I2cConnectionSettings(1, 0x50);

            using (var device = I2cDevice.Create(settings))
            {
                // Write data
                device.Write(new byte[] { 0x00, 0x00, 0x44, 0x45, 0x46, 0x47 });

                Thread.Sleep(5);

                device.Write(new byte[] { 0x00, 0x00 });

                // Read data
                byte[] buffer = new byte[4];
                device.Read(buffer);

                Console.WriteLine(Encoding.ASCII.GetString(buffer));
            }
        }
    }
}
