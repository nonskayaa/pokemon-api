using PokemonApi.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokemonApi.Services
{
    public interface IPokemonService
    {
        Task<List<Pokemon>> GetAllPokemonsAsync();
        Task<Pokemon> GetPokemonByIdAsync(int id);
        Task AddPokemonAsync(Pokemon pokemon);
        Task DeletePokemonAsync(int id);
    }
}
