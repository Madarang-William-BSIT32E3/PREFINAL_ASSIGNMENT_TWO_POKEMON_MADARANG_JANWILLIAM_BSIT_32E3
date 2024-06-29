using Microsoft.AspNetCore.Mvc;
using PREFINAL_POKEMON_MADARANG_BSIT_32E3.Models;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;



namespace PREFINAL_POKEMON_MADARANG_BSIT_32E3.Controllers
{
    public class PokemonController : Controller
    {
        private readonly HttpClient _httpClient;

        public PokemonController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("pokemon?limit=20"); // Adjust limit as needed
            response.EnsureSuccessStatusCode();

            var pokemons = await response.Content.ReadAsAsync<PokemonResponse>();
            return View(pokemons.Results);
        }

        public async Task<IActionResult> Details(string name)
        {
            var response = await _httpClient.GetAsync($"pokemon/{name}");
            response.EnsureSuccessStatusCode();

            var pokemon = await response.Content.ReadAsAsync<Pokemon>();
            return View(pokemon);
        }
    }
}