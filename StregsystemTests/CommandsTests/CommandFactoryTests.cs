using System;
using Stregsystem;
using Stregsystem.Commands;
using StregsystemTests.Fakes;
using Xunit;

namespace StregsystemTests.CommandsTests
{
    public class CommandFactoryTests
    {
        [Theory]
        [InlineData(":")]
        [InlineData(":wrong")]
        [InlineData("    ")]
        [InlineData(":q 10")]
        [InlineData(":quit 10")]
        [InlineData(":activate 10 10")]
        [InlineData(":activate")]
        [InlineData(":deactivate 10 20")]
        [InlineData(":deactivate")]
        [InlineData(":crediton 10 20")]
        [InlineData(":crediton")]
        [InlineData(":creditoff")]
        [InlineData(":addcredit casper")]
        [InlineData(":addcredit 10")]
        [InlineData(":addcredit casper 10 10")]

        public void InvalidCommandThrowsError(string command)
        {
            // Given
            CommandFactory factory 
                = new CommandFactory(new FakeStregsystemUI(), new FakeStregsystem());
        
            // Then
            Assert.Throws<ArgumentException>(() => factory.Parse(command));
        }

        [Theory]
        [InlineData(":q")]
        [InlineData(":quit")]
        public void ValidQuitCommandReturnsQuitCommand(string commandAsString)
        {
            // Given
            CommandFactory factory 
                = new CommandFactory(new FakeStregsystemUI(), new FakeStregsystem());

            // When
            ICommand command = factory.Parse(commandAsString);
        
            // Then
            Assert.IsType<QuitCommand>(command);
        }

        [Fact]
        public void ValidActivateCommandReturnsActivateCommand()
        {
            // Given
            CommandFactory factory 
                = new CommandFactory(new FakeStregsystemUI(), new FakeStregsystem());

            // When
            ICommand command = factory.Parse(":activate 10");
        
            // Then
            Assert.IsType<ActivateCommand>(command);
        }

        [Fact]
        public void ValidDeactivateCommandReturnsDeactivateCommand()
        {
            // Given
            CommandFactory factory 
                = new CommandFactory(new FakeStregsystemUI(), new FakeStregsystem());

            // When
            ICommand command = factory.Parse(":deactivate 10");
        
            // Then
            Assert.IsType<DeactivateCommand>(command);
        }

        [Fact]
        public void ValidCreditOnCommandReturnsCreditOnCommand()
        {
            // Given
            CommandFactory factory 
                = new CommandFactory(new FakeStregsystemUI(), new FakeStregsystem());

            // When
            ICommand command = factory.Parse(":crediton 10");
        
            // Then
            Assert.IsType<CreditOnCommand>(command);
        }

        [Fact]
        public void ValidCreditOffCommandReturnsCreditOffCommand()
        {
            // Given
            CommandFactory factory 
                = new CommandFactory(new FakeStregsystemUI(), new FakeStregsystem());

            // When
            ICommand command = factory.Parse(":creditoff 10");
        
            // Then
            Assert.IsType<CreditOffCommand>(command);
        }

        [Fact]
        public void ValidAddCreditCommandReturnsAddCreditCommand()
        {
            // Given
            CommandFactory factory 
                = new CommandFactory(new FakeStregsystemUI(), new FakeStregsystem());

            // When
            ICommand command = factory.Parse(":addcredit casper 10");
        
            // Then
            Assert.IsType<AddCreditCommand>(command);
        }
    }
}