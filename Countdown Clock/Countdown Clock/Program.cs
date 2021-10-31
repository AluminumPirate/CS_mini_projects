using System;
using System.Diagnostics;
using System.Timers;

namespace Countdown_Clock
{
  class Program
  {
    private static System.Timers.Timer timer;
    private static decimal SecondsToEnd;

    static DateTime GetTimeData()
    {
      Console.Write("Year: ");
      int Year = Convert.ToInt32(Console.ReadLine());
      Console.Write("Month: ");
      int Month = Convert.ToInt32(Console.ReadLine());
      Console.Write("Day: ");
      int Day = Convert.ToInt32(Console.ReadLine());

      Console.Write("Hour: ");
      int Hour = Convert.ToInt32(Console.ReadLine());
      Console.Write("Minute: ");
      int Minute = Convert.ToInt32(Console.ReadLine());
      Console.Write("Second: "); 
      int Second = Convert.ToInt32(Console.ReadLine());

      return new DateTime(Year, Month, Day, Hour, Minute, Second);
    }

    static void Main(string[] args)
    {
      do
      {
        Console.WriteLine("Choose Ending Time");
        DateTime Date = GetTimeData();
        SecondsToEnd = Convert.ToDecimal((Date - DateTime.Now).TotalSeconds);
      } while (SecondsToEnd <= 0);

      timer = new System.Timers.Timer(1000);
      timer.Elapsed += OnTimedEvent;
      timer.AutoReset = true;
      timer.Enabled = true;


      Console.WriteLine("\nPress the Enter key to exit the application...\n");
      Console.WriteLine("The application started at {0:HH:mm:ss.fff}", DateTime.Now);
      Console.ReadLine();

      Console.WriteLine("Terminating the application...");
    }

    private static void OnTimedEvent(Object source, ElapsedEventArgs e)
    {
      SecondsToEnd--;
      if (SecondsToEnd <= 0)
      {
        timer.Stop();
        timer.Dispose();
        Console.WriteLine("Time's up!");
      }
      else
      {
        Console.WriteLine($"${e.SignalTime.ToString("HH:mm:ss")}");
      }
    }

  }
}
