using Stregsystem.Controller.Commands;
using Stregsystem.Model;
using Stregsystem.View;

namespace Stregsystem.Controller
{
    internal class StregsystemController
    {
        private CommandFactory _commandFactory;
        private IStregsystemUI _ui;

        public StregsystemController(IStregsystemUI ui, IStregsystem stregsystem)
        {
            _ui = ui;
            _commandFactory = new CommandFactory(ui, stregsystem);
            ui.CommandEntered += TryExecuteCommand;
        }

        private void TryExecuteCommand(object sender, string commandString)
        {
            try
            {
                ICommand command = _commandFactory.Parse(commandString);
                command.Execute();
            }
            catch (System.Exception e)
            {
                _ui.DisplayGeneralError(e.Message);
            }
        }
    }
}