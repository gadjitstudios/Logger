# Logger
A basic logging library

NOTE: This library is DEFINATELY a work in progress, and there are many things that need to be "better defined" and tested.

## HOW TO USE THE LOGGER LIBRARY:
First thing to do: Change the location of the log paths. This is done by suppling environmental variables ERROR_LOG_PATH, WARNING_LOG_PATH, and INFO_LOG_PATH. When testing, this is done in the Setup method of the Logger.Tests.LoggerTest.cs class (shown below)
```
[SetUp]
        public void Setup()
        {
            Environment.SetEnvironmentVariable("ERROR_LOG_PATH",    "[YOUR PATH HERE]");
            Environment.SetEnvironmentVariable("WARNING_LOG_PATH",  "[YOUR PATH HERE]");
            Environment.SetEnvironmentVariable("INFO_LOG_PATH",     "[YOUR PATH HERE]");
        }
 ```

The Logger library contains a class Logger.cs, which currently contains 3 static public functions for consumtion:

    1. Write - a function that writes a single string to the log
    2. Write - a function that writes a list of string to the log
    3. GetLogLocation - a function that returns the location of the log

The Logger.cs class is typed, using the ILogLevel.cs class as a base type, which is how the library determines which log to minipulate.
Current ILogLevel types (found in the Logger/Models):

    1.ErrorLog.cs
    2.InfoLog.cs
    3.WarningLog.cs

Example usage:
    ``` Logger<ErrorLog>.Write("Write this line to the Error Log"); ```

## DESIGN JUSTIFICATION / COMPOSITION:
### Adding a function to the library:

    1. Add a public method to the ILogLevel. This will require each of the log types to implement this function
    2. Add a public method to the Logger.cs class. This will expose the function to the library user
    3. Implement the method in each of the Log Level models (this could be done for each model, or applied to any inherited generic (IE inside of the 
    Logger/Generics/TFileLog.cs class))

### Generics Justification:
Logger was designed to use Generic logging classes (found in the Logger/Generics; and prefixed with a 'T'), so that common functionality can be used accross
multiple LogLevel models (found in Logger/Models). This allows the log to store entries in any type of log store (IE database, XML file, TXT file ...).

## POTENTIAL IMPROVEMENTS:

There a few things that stick out with this implementation of the Logger library:

    1. Writing to the log file does not maintain any type of order, or organization; meaning log entries are appeneded to the file on a first come first server basis (this may or may not be desirable)
    2. There is not indexing on the file to allow it to be searched very easily
    3. There is no check for whether the file is open or not (this could cause an exception when written to)
    4. Tests for the items mentioned above should be added
