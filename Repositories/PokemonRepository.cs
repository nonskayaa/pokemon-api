using Microsoft.EntityFrameworkCore;
using PokemonApi.Entities;
using PokemonApi.Data;

namespace PokemonApi.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly DataContext _context;

        public PokemonRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Pokemon>> GetAllPokemonsAsync()
        {
            return await _context.Pokemons.ToListAsync();
        }

        public async Task<Pokemon> GetPokemonByIdAsync(int id)
        {
            return await _context.Pokemons.FindAsync(id);
        }

        public async Task AddPokemonAsync(Pokemon pokemon)
        {
            _context.Pokemons.Add(pokemon);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePokemonAsync(int id)
        {
            var pokemon = await _context.Pokemons.FindAsync(id);
            if (pokemon != null)
            {
                _context.Pokemons.Remove(pokemon);
                await _context.SaveChangesAsync();
            }
        }
    }
}
