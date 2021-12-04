using System.Collections.Generic;

namespace Stregsystem
{
    internal class CommandFactory
    {
        private static Dictionary<string, ICommand> _stringToCommand = new()
        {
            { ":quit", StopUIComand },
            { ":q", StopUICommand },
            { ":activate", ActivateProductCommand},
            { ":deactivate", DeactivateProductCommand},
            { ":crediton," CreditOnCommand},
            { ":creditoff", CreditOffCommand},
            { ":addcredits", AddCreditsCommand}
        };
        private IStregsystemUI _ui;
        private IStregsystem _stregsystem;

        public CommandFactory(IStregsystemUI ui, IStregsystem stregsystem)
        {
            _ui = ui;
            _stregsystem = stregsystem;
        }

        public ICommand ParseCommand(string command)
        {`

        }
    }
}