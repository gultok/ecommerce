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
                    foreach (var line in ScenarioFileReader.Lines(scenario))
                    {
                        try
                        {
                            Global.ValidateAndRunCommand(line);
                        }
                        catch (Exception exp)
                        {
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
                Console.WriteLine(exp.Message);
                Console.ReadKey();
            }
        }
    }
}
