namespace Stregsystem
{
    internal class StregsystemController
    {
        private CommandFactory _commandFactory;

        public StregsystemController(IStregsystemUI ui, IStregsystem stregsystem)
        {
            _commandFactory = new CommandFactory(ui, stregsystem);
            ui.CommandEntered += TryExecuteCommand;
        }

        private void TryExecuteCommand(object sender, string e)
        {
            ICommand command = _commandFactory.ParseCommand(e);
            command.Execute();
        }
    }
}