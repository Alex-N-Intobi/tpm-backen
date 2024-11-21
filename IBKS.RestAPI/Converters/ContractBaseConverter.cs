using System.Text.Json;
using System.Text.Json.Serialization;
using System.Reflection;
using IBKS.Contracts.Base;

namespace IBKS.RestAPI.Converters;

public class ContractBaseConverter<T, TKey> : JsonConverter<T> where T : ContractBase<TKey>
{
    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return JsonSerializer.Deserialize<T>(ref reader, options)!;
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        var type = value.GetType();

        var idProperty = type.GetProperty("Id");
        if (idProperty != null && idProperty.DeclaringType == typeof(ContractBase<TKey>))
        {
            writer.WritePropertyName("id");
            JsonSerializer.Serialize(writer, value.Id, options);
        }

        // Serialize other properties
        foreach (PropertyInfo property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
            if (property.Name == "Id") continue;

            var propertyValue = property.GetValue(value);
            writer.WritePropertyName(JsonNamingPolicy.CamelCase.ConvertName(property.Name));
            JsonSerializer.Serialize(writer, propertyValue, property.PropertyType, options);
        }

        writer.WriteEndObject();
    }
}

public class ContractBaseConverterFactory : JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert)
    {
        if (!typeToConvert.IsGenericType)
            return false;

        var baseType = typeToConvert.GetGenericTypeDefinition();
        return baseType == typeof(ContractBase<>);
    }

    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        var keyType = typeToConvert.GetGenericArguments()[0];
        var converterType = typeof(ContractBaseConverter<,>).MakeGenericType(typeToConvert, keyType);

        return (JsonConverter)Activator.CreateInstance(converterType)!;
    }
}