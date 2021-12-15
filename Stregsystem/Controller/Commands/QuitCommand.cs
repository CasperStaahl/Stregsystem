using Stregsystem.View;

namespace Stregsystem.Controller.Commands
{
    public class QuitCommand : ICommand
    {
        private IStregsystemUI _ui;

        public QuitCommand(IStregsystemUI ui)
        {
            _ui = ui;
        }

        public void Execute()
        {
            _ui.Close();
        }
    }
}