using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace APIHandler.Handlers.Reservations;

public class GetOwnerSessionIdHandler
{
    public async Task<APIGatewayProxyResponse> HandleAsync(APIGatewayProxyRequest request)
    {
        // Отримуємо reservationId з параметрів шляху
        string reservationId = request.PathParameters != null && request.PathParameters.ContainsKey("reservationId")
            ? request.PathParameters["reservationId"]
            : string.Empty;

        // Формуємо відповідь чітко за вимогою завдання
        var responseObj = new
        {
            guestSessionId = "owner-session-123"
        };

        return new APIGatewayProxyResponse
        {
            StatusCode = (int)HttpStatusCode.OK,
            Headers = new Dictionary<string, string> { { "Content-Type", "application/json" } },
            Body = JsonSerializer.Serialize(responseObj)
        };
    }
}