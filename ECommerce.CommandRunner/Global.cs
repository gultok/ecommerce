using ECommerce.CommandRunner.Commands;
using ECommerce.CommandRunner.Requests;
using System;

namespace ECommerce.CommandRunner
{
    public static class Global
    {
        public const string apiUrl = "https://localhost:44309";
        public static string ActionUrl(string actionUrl)
        {
            return $"{apiUrl}{actionUrl}";
        }
        public static void ValidateAndRunCommand(string line, log4net.ILog logger)
        {
            ICommand command = new CommandConverter(logger).GetCommand(line);
            if (command == null)
                throw new Exception("Command does not found");
            command.Validate();
            command.Run();
        }
        public static void ResetSystemDataAndTime()
        {
            SystemRequest.ResetTime();
            SystemRequest.ResetSystemData();
        }
    }
}