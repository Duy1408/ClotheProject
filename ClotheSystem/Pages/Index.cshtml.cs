using ClotheBusinessObject.BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;

namespace ClotheSystem.Pages
{
    public class IndexModel : PageModel
    {

        private readonly HttpClient client = null!;
        private string ApiUrl = "";
        public IndexModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ApiUrl = "https://localhost:7296/api/Clothes";
        }
        public IList<Clothe> Clothe { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync()
        {
            HttpResponseMessage response = await client.GetAsync(ApiUrl);
            string strData = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            List<Clothe> clothes = JsonSerializer.Deserialize<List<Clothe>>(strData, options)!;

            Clothe = clothes;

            return Page();
        }
    }
}