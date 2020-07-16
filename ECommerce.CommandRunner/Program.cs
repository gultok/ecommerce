using System;
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "App.config")]

namespace ECommerce.CommandRunner
{
    class Program
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            try
            {
                foreach (var scenario in ScenarioFileReader.ScenarioFiles)
                {
                    Console.WriteLine($"{scenario} is working");
                    foreach (var line in ScenarioFileReader.Lines(scenario))
                    {
                        try
                        {
                            Global.ValidateAndRunCommand(line, logger);
                        }
                        catch (Exception exp)
                        {
                            logger.Error($"There was an error while scenario (\"{scenario}\") working {exp.Message}");
                            Console.WriteLine($"There was an error while scenario (\"{scenario}\") working {exp.Message}");
                        }
                    }
                    Console.WriteLine($"{scenario} is ended");
                    Global.ResetSystemDataAndTime();
                }
                Console.ReadKey();
            }
            catch (Exception exp)
            {
                logger.Error(exp.Message);
                Console.WriteLine(exp.Message);
                Console.ReadKey();
            }
        }
    }
}
