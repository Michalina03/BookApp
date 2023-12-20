using System.Text.Json;
namespace BookApp.Entities.Extension
{
    public static class EntityExtension
    {
        public static T? Copy<T>(this T itemToCopy) where T : class, IEntity
        {
            var json = JsonSerializer.Serialize<T>(itemToCopy);
            return JsonSerializer.Deserialize<T>(json);
        }

    }
}
