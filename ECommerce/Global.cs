using ECommerce.Commands;
using ECommerce.Requests;
using System;

namespace ECommerce
{
    public static class Global
    {
        public const string apiUrl = "https://localhost:44309";
        public static string ActionUrl(string actionUrl)
        {
            return $"{apiUrl}{actionUrl}";
        }
        public static void ValidateAndRunCommand(string line)
        {
            ICommand command = new CommandConverter().GetCommand(line);
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