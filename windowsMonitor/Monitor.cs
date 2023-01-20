using System.Diagnostics;

public class Monitor
{
    static void Main(string[] args)
    {

        if (args.Length != 3)
        {
            Console.WriteLine("Usage: [process name] [max lifetime (minutes)] [monitoring frequency (minutes)]");
            return;
        }

    
        string processName = args[0];

        int timeOut;

        int timeToCheck;

        if (int.TryParse(args[1], out timeOut))
        {
            timeOut = int.Parse(args[1]);
        }
        else
        {
            Console.WriteLine("The second argument must be a number");
            return;
        }
        if (int.TryParse(args[2], out timeToCheck))
        {
            timeToCheck = int.Parse(args[2]);
        }
        else
        {
            Console.WriteLine("The third argument must be a number");
            return;
        }


        while (true)
        {
            Thread.Sleep(timeToCheck * 60000);
         // Console.WriteLine("Checking if {0} is open", processName); //Debug Line
            ProcessKiller(processName, timeOut);

        }
        
    }

     public static void ProcessKiller(string processName, int timeOut)
    {
        TimeSpan runtime;
        

        foreach (var process in Process.GetProcessesByName(processName))
        {
            runtime = DateTime.Now - process.StartTime;

            if (runtime.Minutes >= timeOut)
            {
                process.Kill();
                Console.WriteLine($"{processName} has been killed at {DateTime.Now}");
                using (StreamWriter writer = File.AppendText("log.txt"))
                {
                    writer.WriteLine($"{DateTime.Now} - {processName} process has been killed.");
                }
            }
         //   Console.WriteLine("{0}", runtime.ToString()); // Debug Line
        }

    }
}
