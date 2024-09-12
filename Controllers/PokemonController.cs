using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PokemonApi.Entities;
using PokemonApi.Services;

namespace PokemonApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;
        private readonly ILogger<PokemonController> _logger;

        public PokemonController(IPokemonService pokemonService, ILogger<PokemonController> logger)
        {
            _pokemonService = pokemonService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<Pokemon>>> GetAllPokemons()
        {
            _logger.LogInformation("GetAllPokemons called at {Time}", DateTime.UtcNow);
            var pokemons = await _pokemonService.GetAllPokemonsAsync();
            _logger.LogInformation("GetAllPokemons returned {Count} pokemons", pokemons.Count);
            return Ok(pokemons);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pokemon>> GetPokemon(int id)
        {
            _logger.LogInformation("GetPokemon called at {Time} with id: {Id}", DateTime.UtcNow, id);
            var pokemon = await _pokemonService.GetPokemonByIdAsync(id);
            if (pokemon == null)
            {
                _logger.LogWarning("Pokemon with id {Id} not found", id);
                return NotFound();
            }

            _logger.LogInformation("GetPokemon returned pokemon with id: {Id}", id);
            return Ok(pokemon);
        }

        [HttpPost]
        public async Task<ActionResult<Pokemon>> AddPokemon(Pokemon pokemon)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("AddPokemon called with invalid model state at {Time}", DateTime.UtcNow);
                return BadRequest(ModelState);
            }

            _logger.LogInformation("AddPokemon called at {Time} with pokemon: {@Pokemon}", DateTime.UtcNow, pokemon);
            await _pokemonService.AddPokemonAsync(pokemon);
            _logger.LogInformation("Pokemon added: {@Pokemon}", pokemon);
            return CreatedAtAction(nameof(GetPokemon), new { id = pokemon.Id }, pokemon);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePokemon(int id)
        {
            _logger.LogInformation("DeletePokemon called at {Time} with id: {Id}", DateTime.UtcNow, id);
            var pokemon = await _pokemonService.GetPokemonByIdAsync(id);
            if (pokemon == null)
            {
                _logger.LogWarning("Pokemon with id {Id} not found", id);
                return NotFound();
            }

            await _pokemonService.DeletePokemonAsync(id);
            _logger.LogInformation("Pokemon deleted with id: {Id}", id);
            return NoContent();
        }
    }
}