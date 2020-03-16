using System.Text.Json;

namespace Straightforward.Converters
{
    public static class Serializer
    {

        public static T Deserialize<T>(string value, JsonSerializerOptions options = null)
        {
            if (options == null)
            {
                options = new JsonSerializerOptions
                {
                    IgnoreNullValues = true,
                    PropertyNameCaseInsensitive = true,
                    AllowTrailingCommas = true,
                };
            }

            options.Converters.Add(new IsoDateTimeConverter());
            options.Converters.Add(new QuotedIntConverter());
            options.Converters.Add(new QuotedDoubleConverter());
            options.Converters.Add(new QuotedFloatConverter());
            options.Converters.Add(new QuotedLongConverter());

            options.Converters.Add(new IsoDateTimeConverterNullable());
            options.Converters.Add(new QuotedIntConverterNullable());
            options.Converters.Add(new QuotedDoubleConverterNullable());
            options.Converters.Add(new QuotedFloatConverterNullable());
            options.Converters.Add(new QuotedLongConverterNullable());
            return JsonSerializer.Deserialize<T>(value, options);
        }

        public static T Deserialize<T>(string value, string DateFormat, JsonSerializerOptions options = null)
        {
            if (options == null)
            {
                options = new JsonSerializerOptions
                {
                    IgnoreNullValues = true,
                    PropertyNameCaseInsensitive = true,
                    AllowTrailingCommas = true,
                };
            }


            options.Converters.Add(new IsoDateTimeConverter(DateFormat));
            options.Converters.Add(new QuotedIntConverter());
            options.Converters.Add(new QuotedDoubleConverter());
            options.Converters.Add(new QuotedFloatConverter());
            options.Converters.Add(new QuotedLongConverter());

            options.Converters.Add(new IsoDateTimeConverterNullable());
            options.Converters.Add(new QuotedIntConverterNullable());
            options.Converters.Add(new QuotedDoubleConverterNullable());
            options.Converters.Add(new QuotedFloatConverterNullable());
            options.Converters.Add(new QuotedLongConverterNullable());
            return JsonSerializer.Deserialize<T>(value, options);
        }

        public static string Serialize<T>(T value, JsonSerializerOptions options = null)
        {
            if (options == null)
            {
                options = new JsonSerializerOptions
                {
                    IgnoreNullValues = true,
                    PropertyNameCaseInsensitive = true,
                    AllowTrailingCommas = true,
                };
            }
            options.Converters.Add(new IsoDateTimeConverter());
            return JsonSerializer.Serialize<T>(value, options);
        }

        public static string Serialize<T>(T value, string format, JsonSerializerOptions options = null)
        {
            if (options == null)
            {
                options = new JsonSerializerOptions
                {
                    IgnoreNullValues = true,
                    PropertyNameCaseInsensitive = true,
                    AllowTrailingCommas = true,
                };
            }
            options.Converters.Add(new IsoDateTimeConverter(format));
            return JsonSerializer.Serialize<T>(value, options);
        }
    }
}
