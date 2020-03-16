using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Straightforward.Converters
{
    public class IsoDateTimeConverterNullable : JsonConverter<DateTime?>
    {
        public IsoDateTimeConverterNullable() { }
        public IsoDateTimeConverterNullable(string format)
        {
            DateTimeFormat = format;
        }
        public string DateTimeFormat { get; set; } = "dd/MM/yyyy";
        public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (string.IsNullOrWhiteSpace(reader.GetString()) && (Nullable.GetUnderlyingType(typeToConvert) != null))
            {
                    return null;
            }
            DateTime date;
            try
            {
                date = DateTime.ParseExact(reader.GetString(), DateTimeFormat, CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                date = DateTime.Parse(reader.GetString());
            }

            return date;
        }

        public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
        {
            if (!value.HasValue)
            {
                writer.WriteNullValue();
            }
            else
            {
                writer.WriteStringValue(value.Value.ToString(DateTimeFormat));
            }
        }
    }
}
