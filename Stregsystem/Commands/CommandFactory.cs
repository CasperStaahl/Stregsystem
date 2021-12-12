using System.Collections.Generic;
using System.Linq;
using Stregsystem.Shared;
using Stregsystem.Users;

namespace Stregsystem.Commands
{
    public class CommandFactory
    {
        private IStregsystemUI _ui;
        private IStregsystem _stregsystem;

        public CommandFactory(IStregsystemUI ui, IStregsystem stregsystem)
        {
            _ui = ui;
            _stregsystem = stregsystem;
        }

        // This routine will parse a command string and turn it into a command that interacts with
        // the a IstregsystemUI and Istregsystem.
        public ICommand Parse(string command)
        {
            // Take the command string a split it into a verb and several nouns
            IEnumerable<string> terms = command.Split(" ");
            string verb = terms.First();
            IList<string> nouns = terms.Skip(1).ToList();

            // Switch on the verb and handle
            switch (verb)
            {
                case ":q" or ":quit":
                    return ParseQuit(nouns);
                case ":activate":
                    return ParseActivate(verb, nouns);
                case ":deactivate":
                    return ParseDeactivate(verb, nouns);
                case ":crediton":
                    return ParseCreditOn(verb, nouns);
                case ":creditoff":
                    return ParseCreditOff(nouns);
                case ":addcredit":
                    return ParseAddCredit(nouns);
                default:
                    return ParseUserRequest(verb, nouns);
            }
        }

        private ICommand ParseUserRequest(string verb, IList<string> nouns)
        {
            Username username = new Username(verb);
            IList<int> productIdList = nouns.Select(x => int.Parse(x)).ToList();

            if (nouns.Count <= 0)
                return new GetUserInformatioCommand(_stregsystem, _ui, username);
            else
                return new BuyCommand(_stregsystem, _ui, username, productIdList);
        }

        private ICommand ParseAddCredit(IList<string> nouns)
        {
            Username username = new Username(nouns[0]);
            Ddk credit = new Ddk(int.Parse(nouns[1]));
            if (nouns.Count() <= 2)
                return new AddCreditCommand(_stregsystem, _ui, username, credit);
            else
                throw new TooManyArgumentsException();
        }

        private ICommand ParseCreditOff(IList<string> nouns)
        {
            int productId = int.Parse(nouns[0]);
            if (nouns.Count() <= 1)
                return new CreditOffCommand(_stregsystem, _ui, productId);
            else
                throw new TooManyArgumentsException();
        }

        private ICommand ParseCreditOn(string verb, IList<string> nouns)
        {
            int productId = int.Parse(nouns[0]);
            if (nouns.Count() <= 1)
                return new CreditOnCommand(_stregsystem, _ui, productId);
            else
                throw new TooManyArgumentsException();
        }

        private ICommand ParseDeactivate(string verb, IList<string> nouns)
        {
            int productId = int.Parse(nouns[0]);
            if (nouns.Count() <= 1)
                return new DeactivateCommand(_stregsystem, _ui, productId);
            else
                throw new TooManyArgumentsException();
        }

        private ICommand ParseActivate(string verb, IList<string> nouns)
        {
            int productId = int.Parse(nouns[0]);
            if (nouns.Count() <= 1)
                return new ActivateCommand(_stregsystem, _ui, productId);
            else
                throw new TooManyArgumentsException();
        }

        private ICommand ParseQuit(IList<string> nouns)
        {
            if (nouns.Count() <= 0)
                return new QuitCommand(_ui);
            throw new TooManyArgumentsException();
        }
    }
}