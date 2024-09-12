using Microsoft.Extensions.Logging;
using PokemonApi.Entities;
using PokemonApi.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokemonApi.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly ILogger<PokemonService> _logger;

        public PokemonService(IPokemonRepository pokemonRepository, ILogger<PokemonService> logger)
        {
            _pokemonRepository = pokemonRepository;
            _logger = logger;
        }

        public async Task<List<Pokemon>> GetAllPokemonsAsync()
        {
            _logger.LogInformation("GetAllPokemonsAsync called at {Time}", DateTime.UtcNow);
            var pokemons = await _pokemonRepository.GetAllPokemonsAsync();
            _logger.LogInformation("GetAllPokemonsAsync returned {Count} pokemons", pokemons.Count);
            return pokemons;
        }

        public async Task<Pokemon> GetPokemonByIdAsync(int id)
        {
            _logger.LogInformation("GetPokemonByIdAsync called at {Time} with id: {Id}", DateTime.UtcNow, id);
            var pokemon = await _pokemonRepository.GetPokemonByIdAsync(id);
            if (pokemon == null)
            {
                _logger.LogWarning("Pokemon with id {Id} not found", id);
            }
            return pokemon;
        }

        public async Task AddPokemonAsync(Pokemon pokemon)
        {
            _logger.LogInformation("AddPokemonAsync called at {Time} with pokemon: {@Pokemon}", DateTime.UtcNow, pokemon);
            await _pokemonRepository.AddPokemonAsync(pokemon);
            _logger.LogInformation("Pokemon added: {@Pokemon}", pokemon);
        }

        public async Task DeletePokemonAsync(int id)
        {
            _logger.LogInformation("DeletePokemonAsync called at {Time} with id: {Id}", DateTime.UtcNow, id);
            var pokemon = await _pokemonRepository.GetPokemonByIdAsync(id);
            if (pokemon != null)
            {
                await _pokemonRepository.DeletePokemonAsync(id);
                _logger.LogInformation("Pokemon deleted with id: {Id}", id);
            }
            else
            {
                _logger.LogWarning("Pokemon with id {Id} not found", id);
            }
        }
    }
}
