using System;
using System.Device.Gpio;
using System.Threading;

namespace PiBlinkyTest
{
    class Program
    {
        // Publish this application using:
        // dotnet publish -r linux-arm
        // Copy to the pi.
        // Give the correct permissions to the exe: sudo chmod 755 ./PiBlinkyTest
        // Run the exe: ./PiBlinkyTest

        static void Main(string[] args)
        {
            var pin = 8; // This is GPIO8 - which equates to pin 24 (note that the python RPi.GPIO library treats pin 8 as the physical pin
            var lightTime = 1000;
            var dimTime = 200;

            Console.WriteLine($"Let's blink an LED!");
            using (var controller = new GpioController())
            {
                controller.OpenPin(pin, PinMode.Output);
                Console.WriteLine($"GPIO pin enabled for use: {pin}");

                // turn LED on and off
                while (true)
                {
                    Console.WriteLine($"Light for {lightTime}ms");
                    controller.Write(pin, PinValue.High);
                    Thread.Sleep(lightTime);

                    Console.WriteLine($"Dim for {dimTime}ms");
                    controller.Write(pin, PinValue.Low);
                    Thread.Sleep(dimTime);
                }
            };
        }
    }
}
