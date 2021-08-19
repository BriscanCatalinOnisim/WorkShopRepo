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
        }
    }
}
