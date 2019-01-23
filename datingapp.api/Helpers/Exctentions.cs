using System;
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
        public static int Calculateage(this DateTime TheDateTime)
        {
            var age = DateTime.Today.Year-TheDateTime.Year;
            if(TheDateTime.AddYears(age)>DateTime.Today)
            age--;
            return age; 
        }
    }
}