==================================================================================================================
Pegasus - LogFileSuite v1.0 Readme
==================================================================================================================

Collection of utility apps for monitoring various kinds of log files

System and Software Requirements:
---------------------------------

Microsoft Visual Studio 2013

How to use:
-----------

1) Initialize the module to load the resources.
2) Check for the latest log files. 
3) Choose your monitoring method (Auto or Manual).
4) Let the app do its thing!!

LogMonitor:
-----------

Allows you to monitor logfiles in realtime.

    param1,2,3,4 = [optional] path to logfile(s) to be configured in app.config
    
    example:
    
    LogMonitor.exe "c:\logs\myfile.log"

    When param(s) is provided, the UI will open and instantly start 
    monitoring the specified file(s)
Pegasus Agent:
-------------

The core file for providing 
--file access/create & analize based on entered keyword.
-- Reporting and Search suppot.


Credits
-------

Bibhuti B Beura
Deepak Vasudevan
Vinodhkumar Danda
