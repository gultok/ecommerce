using ECommerce.Commands;
using System;
using System.Linq;

namespace ECom.Commands
{
    public class TimeCommand : ICommand
    {
        public TimeCommand(string commandStr)
        {
            _commandStr = commandStr;
        }
        public string _commandStr { get; set; }

        public void Run()
        {
            var commandName = _commandStr.Split(' ')[0];
            var firstParameter = Convert.ToInt16(_commandStr.Split(' ')[1]);
            //if (commandName.ToLower().Contains("increase"))
            //    new CommandRunner().IncreaseTime(firstParameter);           
        }

        public void Validate()
        {
            if (string.IsNullOrEmpty(_commandStr) || string.IsNullOrWhiteSpace(_commandStr))
                throw new Exception("Command should not be null, space or empty");

            string[] commandAry = _commandStr.Split(' ');
            /*it verifies command has least 1 parameter 
            but it is not sufficient becasue command may not has parameter*/
            if (commandAry.Count() < 2)
                throw new Exception("Should be least 1 parameter");
            int hours;
            if (!Int32.TryParse(commandAry[1], out hours))
                throw new Exception("Second parameter must be an int");
        }
    }
}
