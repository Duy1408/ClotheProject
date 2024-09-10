using ClotheBusinessObject.DTO.Create;
using ClotheBusinessObject.DTO.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;

namespace ClotheSystem.Pages.StaffPage
{

    public class CreateModel : PageModel
    {
        [BindProperty]
        public ClotheRequestDTO Clothe { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Create an HttpClient to call your API
            using (var httpClient = new HttpClient())
            {
                var apiUrl = "https://localhost:7296/api/Clothes"; // Your API endpoint

                // Create a Multipart Form Data Content
                var formData = new MultipartFormDataContent();

                // Add other form fields
                formData.Add(new StringContent(Clothe.ClotheName), nameof(Clothe.ClotheName));
                formData.Add(new StringContent(Clothe.Price.ToString()), nameof(Clothe.Price));
                formData.Add(new StringContent(Clothe.Description), nameof(Clothe.Description));
                formData.Add(new StringContent(Clothe.Rent.ToString()), nameof(Clothe.Rent));
                formData.Add(new StringContent(Clothe.ShopID.ToString()), nameof(Clothe.ShopID));

                // Add Image
                if (Clothe.Image != null)
                {
                    var fileContent = new StreamContent(Clothe.Image.OpenReadStream());
                    fileContent.Headers.ContentType = new MediaTypeHeaderValue(Clothe.Image.ContentType);
                    formData.Add(fileContent, "Image", Clothe.Image.FileName);
                }

                // Call the API
                var response = await httpClient.PostAsync(apiUrl, formData);

                if (response.IsSuccessStatusCode)
                {
                    // Handle success (redirect, display a message, etc.)
                    return RedirectToPage("./Index");
                }
                else
                {
                    // Handle failure
                    ModelState.AddModelError(string.Empty, "An error occurred while creating the clothe.");
                    return Page();
                }
            }
        }
    }
}
