using ClotheBusinessObject.BusinessObject;
using ClotheBusinessObject.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace ClotheSystem.Pages
{
    public class LoginModel : PageModel
    {
        private readonly HttpClient client;
        private string ApiUrl = "";
        public LoginModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ApiUrl = "https://localhost:7112/api/Auth/Login";
        }
        [BindProperty]
        public Account User { get; set; } = default!;
        [BindProperty]
        public LoginVM loginVM { get; set; } = default!;
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                string strData = JsonSerializer.Serialize(loginVM);
                var contentData = new StringContent(strData, Encoding.UTF8, "application/json");


                HttpResponseMessage response = await client.PostAsync(ApiUrl, contentData);

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    var token = JsonSerializer.Deserialize<string>(responseData);

                    if (!string.IsNullOrEmpty(token))
                    {
                        TempData["JwtToken"] = token;

                        var handler = new JwtSecurityTokenHandler();
                        var jsonToken = handler.ReadToken(token) as JwtSecurityToken;
                        var roleClaim = jsonToken?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);

                        if (roleClaim?.Value == "027695AF-C57A-4011-AE68-59967A29ED37") //Staff
                        {
                            HttpContext.Response.Cookies.Append("UserCookie", token);
                            return RedirectToPage("./Staff/CreatePage");
                        }
                   
                        else if (roleClaim?.Value == "Admin") //Admin
                        {
                            HttpContext.Response.Cookies.Append("AdminCookie", token);
                            return RedirectToPage("./AdminPage/UserPage/Index");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            ViewData["ErrorMessage"] = "Email or Password is wrong!";
            return Page();
        }
    }
}
