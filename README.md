This application is a command line utility that monitors and kills Windows processes that live longer than a specified threshold.

To use the application go to windowsMonitor/bin/Debug/net6.0/ on a command line. There the monitor expects 3 arguments: the name of the process you want to monitor, how long that process is allowed to live, monitoring frequency.

In the following example every other minute the monitor will kill any notepad processes that live longer than 5 minutes. 

>windowsMonitor.exe notepad 5 1
