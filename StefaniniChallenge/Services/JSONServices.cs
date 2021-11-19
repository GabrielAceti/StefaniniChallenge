using System.Text.Json;

namespace StefaniniChallenge.Services
{
    public static class JSONServices
    {
        public static string ToJSON(object obj)
        {
            return JsonSerializer.Serialize(obj);
        }
    }
}
