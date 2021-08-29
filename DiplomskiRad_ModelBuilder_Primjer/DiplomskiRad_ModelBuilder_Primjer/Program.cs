using System;

namespace DiplomskiRad_ModelBuilder_Primjer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Testiranje na primjeru ---\n");


            //Učitavanje primjera
            var sampleData = new TitanicModel.ModelInput()
            {
                Sex = @"male",
                Age = 24F,
            };

            //Učitavanje modela i predviđanje statusa osobe
            var result = TitanicModel.Predict(sampleData);

            string status = result.Prediction == 1 ? "živ" : "mrtav";
            Console.WriteLine($"Model predviđa da je status {(sampleData.Sex.Equals("male") ? "muške" : "ženske")} osobe nakon nesreće na Titanicu: {status}");

            Console.ReadKey();
        }
    }
}
