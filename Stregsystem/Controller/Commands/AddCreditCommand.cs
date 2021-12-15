using Stregsystem.Model;
using Stregsystem.Model.Shared;
using Stregsystem.Model.Users;
using Stregsystem.View;

namespace Stregsystem.Controller.Commands
{
    public class AddCreditCommand : ICommand
    {
        private IStregsystem _stregsystem;
        private IStregsystemUI _ui;
        private Username _username;
        private Ddk _credit;

        public AddCreditCommand(IStregsystem stregsystem, IStregsystemUI ui, Username username, Ddk credit)
        {
            _stregsystem = stregsystem;
            _ui = ui;
            _username = username;
            _credit = credit;
        }

        public void Execute()
        {
            IUser user = _stregsystem.GetUserByUsername(_username);
            _stregsystem.AddCreditToAccount(user, _credit);
        }
    }
}