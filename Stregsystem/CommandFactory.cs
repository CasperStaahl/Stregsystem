using System;
using System.Collections.Generic;
using System.Linq;

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
                    return ParseQuit(verb, nouns);
                case ":activate":
                    return ParseActivate(verb, nouns);
                case ":deactivate":
                    return ParseDeactivate(verb, nouns);
                case ":crediton":
                    return ParseCreditOn(verb, nouns);
                case ":creditoff":
                    return ParseCreditOff(verb, nouns);
                case ":addcredit":
                    return ParseAddCredit(verb, nouns);
                default:
                    return ParseUserRequst(verb, nouns);
            }
        }

        private ICommand ParseUserRequst(string verb, List<string> nouns)
        {
            if (nouns.Count() == 0)
                return new QuitCommand(_ui);
            else
                throw new Exception();
        }

        private ICommand ParseAddCredit(string verb, List<string> nouns)
        { 
            if (nouns.Count == 2)
            {
                string userName = nouns[0];
                string credit = nouns[1];
                return new AddCreditCommand(_stregsystem, ui, userName, credit);
            }
            else
            {
                throw new Exception();
            }
        }

        private ICommand ParseCreditOff(string verb, IEnumerable<string> nouns)
        {
            throw new NotImplementedException();
        }

        private ICommand ParseCreditOn(string verb, IEnumerable<string> nouns)
        {
            throw new NotImplementedException();
        }

        private ICommand ParseDeactivate(string verb, IEnumerable<string> nouns)
        {
            throw new NotImplementedException();
        }

        private ICommand ParseActivate(string verb, IEnumerable<string> nouns)
        {
            throw new NotImplementedException();
        }

        private ICommand ParseQuit(string verb, IEnumerable<string> nouns)
        {
            throw new NotImplementedException();
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
}