using NUnit.Framework;
using System.Diagnostics;

namespace WindowsMonitorNUnitTests
{
    public class MonitorTests
    {
        [Test]
        public void ProcessKiller_Kills_Processes()
        {
            //Arrange
            string processName = "notepad";
            var process = new Process();

            //Act
            process.StartInfo.FileName = processName;
            process.Start();
            Monitor.ProcessKiller(processName, 0);
            var runningProcesses = Process.GetProcessesByName(processName);

            //Assert
            Assert.That(runningProcesses.Length, Is.EqualTo(0)); // check if there are no processes with the name notepad running 
        }

        [Test]
        public void ProcessKiller_Kills_Processes_AfterThreshold()
        {
            //Arrange
            string processName = "notepad";
            int maxLifetime = 1;
            var process = new Process();

            //Act
            process.StartInfo.FileName = processName;
            process.Start();
            process.WaitForExit(maxLifetime*60000);
            Monitor.ProcessKiller(processName, maxLifetime);
            var runningProcesses = Process.GetProcessesByName(processName);

            //Assert
            Assert.That(runningProcesses.Length, Is.EqualTo(0)); // check if there are no processes with the name notepad running after one minute
        }
    }
}