using System;
using System.Collections.Generic;
using System.Linq;
using Stregsystem.Shared;
using Stregsystem.Users;

namespace Stregsystem
{
    internal class CommandFactory
    {
        private static Dictionary<string, ICommand> _stringToCommand = new()
        {
            { ":quit", StopUIComand },
            { ":q", StopUICommand },
            { ":activate", ActivateProductCommand },
            { ":deactivate", DeactivateProductCommand },
            { ":crediton,", CreditOnCommand },
            { ":creditoff", CreditOffCommand },
            { ":addcredits", AddCreditsCommand }
        };
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
            List<string> nouns = terms.Skip(1).ToList();

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
                    return ParseUserRequst(verb, nouns);
            }
        }

        private ICommand ParseUserRequst(string verb, List<string> nouns)
        {
            throw new NotImplementedException();
        }

        private ICommand ParseAddCredit(List<string> nouns)
        { 
            Username username = new Username(nouns[0]) ;
            Ddk credit = new Ddk(Int32.Parse(nouns[1]));
            if (nouns.Count() <= 2)
                return new AddCreditCommand(_stregsystem, ui, username, credit);
            else
                throw new TooManyArgumentsException();
        }

        private ICommand ParseCreditOff(List<string> nouns)
        {
            int productId = Int32.Parse(nouns[0]);
            if (nouns.Count() <= 1)
                return new CreditOffCommand(_stregsystem, _ui, productId);
            else
                throw new TooManyArgumentsException();
        }

        private ICommand ParseCreditOn(string verb, List<string> nouns)
        {
            int productId = Int32.Parse(nouns[0]);
            if (nouns.Count() <= 1)
                return new CreditOnCommand(_stregsystem, _ui, productId);
            else
                throw new TooManyArgumentsException();
        }

        private ICommand ParseDeactivate(string verb, List<string> nouns)
        {
            int productId = Int32.Parse(nouns[0]);
            if (nouns.Count() <= 1)
                return new DeactivateCommand(_stregsystem, _ui, productId);
            else
                throw new TooManyArgumentsException();
        }

        private ICommand ParseActivate(string verb, List<string> nouns)
        {
            int productId = Int32.Parse(nouns[0]);
            if (nouns.Count() <= 1)
                return new ActivateCommand(_stregsystem, _ui, productId);
            else
                throw new TooManyArgumentsException();
        }

        private ICommand ParseQuit(string verb, IEnumerable<string> nouns)
        {
            if (nouns.Count() <= 0)
                return new QuitCommand(_ui);
            throw new TooManyArgumentsException();
        }
        // if the verb is :quit or :q and there are no nouns
        // return quit command

        // else if the verb is :activate and there are one noun and the noun is a product id
        // return activate command

        // else if the verb is :deactivate and there are one noun and the noun is a product id
        // return deactivate command

        // else if the verb is :crediton and there are one noun and the noun is a product id
        // return crediton command

        // else if the verb is :creditoff and there are one noun and the noun a product id 
        // return creditoff command

        // else if the verb is :adcredit and there are two nouns and the first noun is a 
        // username and the second noun is a number.
        // return add credits command

        // else if the verb is a user
        // if there are no nouns retun get user information command
        // else if there are several nouns and the nouns are products id
        // return buy command








    }

    [System.Serializable]
    public class TooManyArgumentsException : System.Exception
    {
        public TooManyArgumentsException() { }
        public TooManyArgumentsException(string message) : base(message) { }
        public TooManyArgumentsException(string message, System.Exception inner) : base(message, inner) { }
        protected TooManyArgumentsException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}