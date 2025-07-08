// using system and system collections generic namespaces for the Booking class.
using System;
using System.Collections.Generic;

namespace TechnicalAssesmentBackendDeveloper
{
    public class Booking
    {
        // changed to private set to ensure encapsulation and prevent external modification of booking details.
        public string guestname { get; private set; }
        public string roomnumber { get; private set; }
        public DateTime checkindate { get; private set; }
        public DateTime checkoutdate { get; private set; }
        public int totaldays { get; private set; }
        public double rateperday { get; private set; }
        public double discount { get; private set; }
        public double totalamount { get; private set; }

        // async method to simulate logging booking details.
        public async Task LogBookingDetailsAsync()
        {
            // Simulate writing to a log file or remote system
            await Task.Delay(1000);
            Console.WriteLine("Booking log saved.");
        }

        public async Task BookRoom(string name, string room, DateTime checkin, DateTime checkout, double rate, double discountRate)
        {
            guestname = name;
            roomnumber = room;
            checkindate = checkin;
            checkoutdate = checkout;
            rateperday = rate;
            discount = discountRate;

            totaldays = (checkout - checkin).Days;
            totalamount = totaldays * rateperday;
            totalamount = totalamount - (totalamount * discount / 100);

            await LogBookingDetailsAsync();

            // Calling the method to print booking summary.
            PrintbookingSummary();
        }

        // Added a method to print booking summary.
        private void PrintbookingSummary()
        {
            Console.WriteLine($"Room Booked for: {guestname}");
            Console.WriteLine($"Room No: {roomnumber}");
            Console.WriteLine($"Check-In: {checkindate}");
            Console.WriteLine($"Check-Out: {checkoutdate}");
            Console.WriteLine($"Total Days: {totaldays}");
            Console.WriteLine($"Amount: {totalamount}");
        }

        public void Cancel()
        {
            guestname = null;
            roomnumber = null;
            checkindate = DateTime.MinValue;
            checkoutdate = DateTime.MinValue;
            rateperday = 0;
            discount = 0;
            totalamount = 0;

            Console.WriteLine("Booking cancelled");
        }
    }

    // AppHost class to run the Booking functionality.
    public static class AppHost
    {
        public static async Task RunAsync(string[] args)
        {
            Booking b = new Booking();
            await b.BookRoom("Alice", "101", DateTime.Now, DateTime.Now.AddDays(3), 150.5, 10);
            b.Cancel();
        }
    }

    // Main program to run the application.
    // This is the entry point of the application.
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await AppHost.RunAsync(args);
        }
    }
}
