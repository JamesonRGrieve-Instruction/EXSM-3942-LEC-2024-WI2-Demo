using System.Text.Json;
using System.Text.Json.Serialization;

namespace DemoProject;



class Program
{
    static readonly HttpClient client = new HttpClient();
    static async Task Main(string[] args)
    {
        Console.Write("Please enter a Pokemon ID: ");
        int pokemonID = int.Parse(Console.ReadLine());
        PokeDTO found = await FetchPokemon(pokemonID);
        Console.WriteLine(found.Name);
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
    public string[] Types { get; set; }
    [JsonPropertyName("height")]
    public int Height { get; set; }
    [JsonPropertyName("weight")]
    public int Weight { get; set; }
}