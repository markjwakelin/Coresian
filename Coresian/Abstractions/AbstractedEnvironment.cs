using System;
using System.Collections.Generic;
using Coresian.Interfaces.Abstractions;

namespace Coresian.Abstractions
{
    public class AbstractedEnvironment : IEnvironment
    {
        public string CommandLine => Environment.CommandLine;
        public int CurrentManagedThreadId => Environment.CurrentManagedThreadId;
        public bool HasShutdownStarted => Environment.HasShutdownStarted;
        public bool Is64BitOperatingSystem => Environment.Is64BitOperatingSystem;
        public bool Is64BitProcess => Environment.Is64BitProcess;
        public string MachineName => Environment.MachineName;
        public string NewLine => Environment.NewLine;
        public OperatingSystem OSVersion => Environment.OSVersion;
        public int ProcessorCount => Environment.ProcessorCount;
        public string StackTrace => Environment.StackTrace;
        public string SystemDirectory => Environment.SystemDirectory;
        public int SystemPageSize => Environment.SystemPageSize;
        public int TickCount => Environment.TickCount;
        public string UserDomainName => Environment.UserDomainName;
        public bool UserInteractive => Environment.UserInteractive;
        public string UserName => Environment.UserName;
        public Version Version => Environment.Version;
        public long WorkingSet => Environment.WorkingSet;

        public string CurrentDirectory {
            get => Environment.CurrentDirectory;
            set => Environment.CurrentDirectory = value;
        }
        public int ExitCode
        {
            get => Environment.ExitCode;
            set => Environment.ExitCode = value;
        }
        public void Exit(int exitCode)
        {
            throw new NotImplementedException();
        }

        public string ExpandEnvironmentVariables(string name)
        {
            throw new NotImplementedException();
        }

        public void FailFast(string message)
        {
            throw new NotImplementedException();
        }

        public void FailFast(string message, Exception exception)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetCommandLineArgs()
        {
            throw new NotImplementedException();
        }

        public string GetEnvironmentVariable(string variable)
        {
            return Environment.GetEnvironmentVariable(variable);
        }

        public string GetEnvironmentVariable(string variable, EnvironmentVariableTarget target)
        {
            throw new NotImplementedException();
            //return Environment.GetEnvironmentVariable(variable, target);
        }

        public IReadOnlyDictionary<string, string> GetEnvironmentVariables()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyDictionary<string, string> GetEnvironmentVariables(EnvironmentVariableTarget target)
        {
            throw new NotImplementedException();
        }

        public string GetFolderPath(Environment.SpecialFolder folder)
        {
            throw new NotImplementedException();
        }

        public string GetFolderPath(Environment.SpecialFolder folder, Environment.SpecialFolderOption option)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetLogicalDrives()
        {
            throw new NotImplementedException();
        }

        public void SetEnvironmentVariable(string variable, string value)
        {
            throw new NotImplementedException();
        }

        public void SetEnvironmentVariable(string variable, string value, EnvironmentVariableTarget target)
        {
            throw new NotImplementedException();
        }
    }
}