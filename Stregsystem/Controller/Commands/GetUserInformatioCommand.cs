using Stregsystem.Model;
using Stregsystem.Model.Users;
using Stregsystem.View;

namespace Stregsystem.Controller.Commands
{
    public class GetUserInformatioCommand : ICommand
    {
        private IStregsystem _stregsystem;
        private IStregsystemUI _ui;
        private Username _username;

        public GetUserInformatioCommand(IStregsystem stregsystem, IStregsystemUI ui, Username username)
        {
            _stregsystem = stregsystem;
            _ui = ui;
            _username = username;
        }

        public void Execute()
        {
            IUser user = _stregsystem.GetUserByUsername(_username);
            _ui.DisplayUserInfo(user);
        }
    }
}