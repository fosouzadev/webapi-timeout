using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace WebApiTimeOut.Controllers;

[ApiController]
[Route("api/star-wars")]
public class StarWarsController : ControllerBase
{
    [HttpPost]
    public async Task<IResult> ImportCharacters(CancellationToken cancellationToken)
    {
        try
        {
            HttpClient httpClient = new()
            {
                BaseAddress = new Uri("https://swapi.dev/api/")
            };

            int peopleId = 0;

            while (true)
            {
                HttpResponseMessage response = await httpClient.GetAsync($"people/{++peopleId}");
                Console.WriteLine($"HttpStatusCode: {response.StatusCode} Response: {await response.Content.ReadAsStringAsync()}\n");

                if (response.IsSuccessStatusCode == false)
                    break;

                await Task.Delay(TimeSpan.FromSeconds(5));

                cancellationToken.ThrowIfCancellationRequested();
            }

            return TypedResults.Ok();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nException: {ex.Message}");
            return TypedResults.StatusCode((int)HttpStatusCode.RequestTimeout);
        }
    }
}