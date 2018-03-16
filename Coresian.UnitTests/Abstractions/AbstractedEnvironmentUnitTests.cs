using System;
using AutoFixture;
using Coresian.Abstractions;
using Xunit;

namespace Coresian.UnitTests.Abstractions
{
    public class AbstractedEnvironmentUnitTests
    {

        [Fact]
        public void ThePropertiesAreAllCorrect()
        {
            var target = new AbstractedEnvironment();

            Assert.Equal(Environment.CommandLine, target.CommandLine);

            Assert.Equal(Environment.CurrentManagedThreadId, target.CurrentManagedThreadId);
            Assert.Equal(Environment.HasShutdownStarted, target.HasShutdownStarted);
            Assert.Equal(Environment.Is64BitOperatingSystem, target.Is64BitOperatingSystem);
            Assert.Equal(Environment.Is64BitProcess, target.Is64BitProcess);
            Assert.Equal(Environment.MachineName, target.MachineName);
            Assert.Equal(Environment.NewLine, target.NewLine);
            Assert.Equal(Environment.OSVersion, target.OSVersion);
            Assert.Equal(Environment.ProcessorCount, target.ProcessorCount);
            //Assert.Equal(Environment.StackTrace, environment.StackTrace);
            Assert.True(target.StackTrace.Length>10);
            Assert.Equal(Environment.SystemDirectory, target.SystemDirectory);
            Assert.Equal(Environment.SystemPageSize, target.SystemPageSize);
            Assert.Equal(Environment.TickCount, target.TickCount);
            Assert.Equal(Environment.UserDomainName, target.UserDomainName);
            Assert.Equal(Environment.UserInteractive, target.UserInteractive);
            Assert.Equal(Environment.UserName, target.UserName);
            Assert.Equal(Environment.Version, target.Version);
            //Assert.Equal(Environment.WorkingSet, environment.WorkingSet);
            Assert.True(target.WorkingSet > 100);

            Assert.Equal(Environment.CurrentDirectory, target.CurrentDirectory);
            Assert.Equal(Environment.ExitCode, target.ExitCode);
        }

        [Fact]
        public void WhenISetTheExitCodeItIsSet()
        {
            var fixture = new Fixture();
            var expectedExitCode = fixture.Create<int>();

            var target = new AbstractedEnvironment();

            target.ExitCode = expectedExitCode;

            Assert.Equal(expectedExitCode, Environment.ExitCode);
        }


        [Fact]
        public void WhenISetTheCurrentDirectoryItIsSet()
        {
            var expectedCurrentDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            var target = new AbstractedEnvironment();

            target.CurrentDirectory = expectedCurrentDirectory;

            Assert.Equal(expectedCurrentDirectory, Environment.CurrentDirectory);
        }

        [Fact]
        public void WhenIGetAnEnvironmentVariableItIsGot()
        {
            var fixture = new Fixture();
            var expectedVariableName = fixture.Create<string>();
            var expectedVariableContent = fixture.Create<string>();

            Environment.SetEnvironmentVariable(expectedVariableName, expectedVariableContent);

            var target = new AbstractedEnvironment();
            
            Assert.Equal(expectedVariableContent, target.GetEnvironmentVariable(expectedVariableName));
        }
    }
}