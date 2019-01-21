using Microsoft.AspNetCore.Http;

namespace datingapp.api.Helpers
{
    public static class Exctentions
    {
        public static void AddApplicationException(this HttpResponse response,string message)
        {
            response.Headers.Add("Application-Error",message);
            response.Headers.Add("Access-control-Expose-Headers","Application-Error");
            response.Headers.Add("Access-control-allow-Origin","*");

        }
    }
}