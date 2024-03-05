using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json; 
using Newtonsoft.Json.Serialization;
using TaskKeep.Model;


namespace TaskKeep.Pages
{
    public class Todos : PageModel
    {
        // private readonly ILogger<Todos> _logger;
        private readonly HttpClient _httpClient;

        public Todos(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<Todo> Todo { get; set; }

        public async Task OnGetAsync()
        {

            var response = await _httpClient.GetAsync("http://localhost:5148/todoitems");

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                // Tasks = JsonSerializer.Deserialize<List<Task>>(jsonString);
                Todo = JsonConvert.DeserializeObject<List<Todo>>(jsonString);
                Console.WriteLine("Json Accpteted");
            }
            else
            {
                Todo = new List<Todo>();
                Console.WriteLine("Json Failed");
            }
        }

    }
}