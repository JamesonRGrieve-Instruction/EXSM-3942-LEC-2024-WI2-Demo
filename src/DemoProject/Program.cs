using System.Text.Json;
using System.Text.Json.Serialization;

namespace DemoProject;



class Program
{
    static readonly HttpClient client = new HttpClient()
    {
        Timeout = TimeSpan.FromSeconds(5)
    };
    static async Task Main(string[] args)
    {
        List<PokeDTO> cachedPokemon = new List<PokeDTO>();
        int userChoice = 1;
        do
        {
            Console.Write("Pokemon Information\n1. Retrieve Pokemon\n2. Exit\n\tChoice: ");
            userChoice = int.Parse(Console.ReadLine());
            if (userChoice == 1)
            {
                Console.Write("Enter a Pokemon ID: ");
                int pokemonID = int.Parse(Console.ReadLine());
                try
                {
                    PokeDTO found;
                    if (cachedPokemon.Any(pokemon => pokemon.ID == pokemonID))
                    {
                        found = cachedPokemon.Single(pokemon => pokemon.ID == pokemonID);
                    }
                    else
                    {
                        found = await FetchPokemon(pokemonID);
                        cachedPokemon.Add(found);
                    }
                    Console.WriteLine($"-- {found.Name} --\nTypes: {string.Join(",", found.Types.Select(type => type.Type.Name))}\nWeight: {found.Weight}\nHeight: {found.Height}");
                }
                catch (Exception e)
                {
                    Console.WriteLine("ERROR: " + e.Message);
                }
            }
        } while (userChoice != 2);

    }
    static async Task<PokeDTO> FetchPokemon(int id)
    {
        HttpResponseMessage response = await client.GetAsync($"https://pokeapi.co/api/v2/pokemon/{id}");
        response.EnsureSuccessStatusCode();
        string responseText = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<PokeDTO>(responseText);
    }

}
class PokeDTO
{
    [JsonPropertyName("id")]
    public int ID { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("types")]
    public PokeTypeWrapper[] Types { get; set; }
    [JsonPropertyName("height")]
    public int Height { get; set; }
    [JsonPropertyName("weight")]
    public int Weight { get; set; }
}
class PokeTypeWrapper
{
    [JsonPropertyName("type")]
    public PokeTypeDTO Type { get; set; }
}
class PokeTypeDTO
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
}