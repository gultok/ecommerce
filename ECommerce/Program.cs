using ECommerce.Commands;
using System;

namespace ECommerce
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                foreach (var scenario in ScenarioFileReader.ScenarioFiles)
                {
                    Console.WriteLine($"{scenario} is working");
                    try
                    {
                        foreach (var line in ScenarioFileReader.Lines(scenario))
                        {
                            ICommand command = CommandConverter.GetCommand(line);
                            command.Validate();
                            command.Run();
                        }
                    }
                    catch (Exception exp)
                    {
                        Console.WriteLine($"There was an error while scenario (\"{scenario}\") working {exp.Message}") ;
                    }
                    Console.WriteLine($"{scenario} is ended");
                    // reset data & time
                }
                Console.ReadKey();
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
                Console.ReadKey();
            }
        }
    }
}
