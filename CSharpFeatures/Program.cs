using System;
using System.IO;
using System.Text.Json;

namespace CSharpFeatures
{
    class Program
    {
        static void Main(string[] args)
        {
            TeamMember teamMember = new TeamMember() { Name = "Memeber1" };
            string jsonString = JsonSerializer.Serialize(teamMember);

            Console.WriteLine(jsonString);
            File.WriteAllText("TeamMember.json", jsonString);
            var realFromFile = File.ReadAllTextAsync("TeamMember.json");

            realFromFile.Wait();
            var expectedOutput = realFromFile.Result;
            var teamMemberDeserializer = JsonSerializer.Deserialize<TeamMember>(expectedOutput);
            Console.WriteLine(teamMemberDeserializer);

            Coffe coffe = MakeCoffe("grain", "milk", "water", " sugar", Espresso);
            Console.WriteLine($"Here is your coffe: {coffe} .");

        }

        static Coffe MakeCoffe(string grains, string milk, string water, string sugar, Func<string, string, string, string, Coffe> recipe)
        {
            try
            {
                Console.WriteLine("Start preparing coffe.");
                var coffe = recipe(grains, milk, water, sugar);
                return coffe;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Console.WriteLine("Finishes.");
            }
        }

        static Coffe Espresso(string grains, string milk, string water, string sugar)
        {
            return new Coffe("Espresso");
        }

    }
}
