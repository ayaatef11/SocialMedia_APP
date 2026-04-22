using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SocialMedia.Application.Helpers.General;
public static class JsonHelper
{
    public static List<Guid> ConvertToList(string? data)
    {
        return string.IsNullOrEmpty(data)
            ? new List<Guid>()
            : JsonSerializer.Deserialize<List<Guid>>(data) ?? new List<Guid>();
    }

    public static string ConvertToString(List<Guid> list)
    {
        return JsonSerializer.Serialize(list);
    }
}
