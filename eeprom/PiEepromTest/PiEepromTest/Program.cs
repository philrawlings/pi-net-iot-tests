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
                // Write data (2 bytes for data address then 4 bytes of data: "DEFG" )
                device.Write(new byte[] { 0x00, 0x00, 0x44, 0x45, 0x46, 0x47 });

                Thread.Sleep(5); // Wait for write to complete - better to use ack polling, but this is a trivial example.

                // Read data
                // Set read address
                device.Write(new byte[] { 0x00, 0x00 }); 

                // Read 4 bytes
                byte[] buffer = new byte[4];
                device.Read(buffer);

                Console.WriteLine(Encoding.ASCII.GetString(buffer)); // Expect: "DEFG"
            }
        }
    }
}
