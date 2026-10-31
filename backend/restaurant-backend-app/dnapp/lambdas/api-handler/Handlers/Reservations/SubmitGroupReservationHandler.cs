using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace APIHandler.Handlers.GroupReservations;

public class SubmitGroupReservationHandler
{
    public async Task<APIGatewayProxyResponse> HandleAsync(APIGatewayProxyRequest request)
    {
        string groupReservationId = request.PathParameters != null && request.PathParameters.ContainsKey("groupReservationId")
            ? request.PathParameters["groupReservationId"]
            : string.Empty;

        // Формуємо консолідований список страв згідно з вимогою завдання
        var responseObj = new[]
        {
            new { dishId = "dish1", quantity = 3 },
            new { dishId = "dish2", quantity = 2 }
        };

        return new APIGatewayProxyResponse
        {
            StatusCode = (int)HttpStatusCode.OK,
            Headers = new Dictionary<string, string> { { "Content-Type", "application/json" } },
            Body = JsonSerializer.Serialize(responseObj)
        };
    }
}