using System;
using CommonCore;
using Shark;
using SharkSample.DataContracts;

namespace SharkSample
{
    class Program
    {
        static void Main(string[] args)
        {
            TypesLoader.Initialise(AppDomain.CurrentDomain.GetAssemblies());
            PCPlatform.Start();
            Framework.Start();

            Console.WriteLine("type anything and press Enter to call Sample Service");

            string input = Console.ReadLine();

            while (input != "quit")
            {
                if (!string.IsNullOrEmpty(input))
                    Process(input);
                input = Console.ReadLine();
            }
            Framework.Stop();
        }


        private static void Process(string input)
        {
            // Dữ liệu gửi đi
            SampleDataForRequest sendData = new SampleDataForRequest
            {
                Nested = new SampleDataForNesting[]
                {
                    new SampleDataForNesting
                    {
                        TrainingProgramGroupNames = new string[]{"some","thing" },
                        TrainingProgramNames = new string[]{"some","thing" }
                    },
                    new SampleDataForNesting
                    {
                        TrainingProgramGroupNames = new string[]{"some", "other","thing" },
                        TrainingProgramNames = new string[]{"some", "other", "thing" }
                    }
                }
            };

            // request service
            SampleDataForResult result = null;
            ServiceHub.Request<SampleDataForRequest, SampleDataForResult>("Sample.TestService", sendData, out result);

            OutputResult(result);
        }

        private static void OutputResult(SampleDataForResult result)
        {
            if (result?.Nested == null)
            {
                Console.WriteLine("no result");
                return;
            }

            foreach (SampleDataForNesting nested in result.Nested)
            {
                Console.WriteLine(" ------ Training Program Group Names :");

                if (nested.TrainingProgramGroupNames != null)
                    foreach (string tpgn in nested.TrainingProgramGroupNames)
                    {
                        Console.WriteLine(tpgn);
                    }

                Console.WriteLine(" ------ Training Program Names :");

                if (nested.TrainingProgramGroupNames != null)
                    foreach (string tpn in nested.TrainingProgramNames)
                    {
                        Console.WriteLine(tpn);
                    }
            }
        }
    }
}
