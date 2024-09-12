using PokemonApi.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokemonApi.Repositories
{
    public interface IPokemonRepository
    {
        Task<List<Pokemon>> GetAllPokemonsAsync();
        Task<Pokemon> GetPokemonByIdAsync(int id);
        Task AddPokemonAsync(Pokemon pokemon);
        Task DeletePokemonAsync(int id);
    }
}
