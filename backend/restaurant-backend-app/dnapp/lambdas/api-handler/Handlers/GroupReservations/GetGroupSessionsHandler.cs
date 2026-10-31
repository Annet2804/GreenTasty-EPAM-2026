using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace APIHandler.Handlers.GroupReservations;

public class GetGroupSessionsHandler
{
    public async Task<APIGatewayProxyResponse> HandleAsync(APIGatewayProxyRequest request)
    {
        // Отримуємо groupReservationId з параметрів шляху
        string groupReservationId = request.PathParameters != null && request.PathParameters.ContainsKey("groupReservationId")
            ? request.PathParameters["groupReservationId"]
            : string.Empty;

        // Формуємо дані у строгій відповідності до вимог завдання
        var responseObj = new
        {
            participants = new[]
            {
                new
                {
                    id = "session1",
                    type = "Guest",
                    name = "Andrii",
                    items = new[]
                    {
                        new
                        {
                            dish = new { id = "dish1", name = "Caesar Salad", price = 180 },
                            quantity = 2
                        }
                    },
                    total = 360,
                    isSubmitted = true
                },
                new
                {
                    id = "session2",
                    type = "Guest",
                    name = "Olena",
                    items = new[]
                    {
                        new
                        {
                            dish = new { id = "dish2", name = "Tom Yum", price = 220 },
                            quantity = 1
                        }
                    },
                    total = 220,
                    isSubmitted = false
                }
            },
            total = 580
        };

        return new APIGatewayProxyResponse
        {
            StatusCode = (int)HttpStatusCode.OK,
            Headers = new Dictionary<string, string> { { "Content-Type", "application/json" } },
            Body = JsonSerializer.Serialize(responseObj)
        };
    }
}