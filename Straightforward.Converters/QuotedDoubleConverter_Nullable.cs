using System;
using System.Buffers;
using System.Buffers.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Straightforward.Converters
{
    public class QuotedDoubleConverterNullable : JsonConverter<double?>
    {
        public override double? Read(ref Utf8JsonReader reader, Type type, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                if (string.IsNullOrWhiteSpace(reader.GetString()))
                {
                    if (Nullable.GetUnderlyingType(type) != null)
                    {
                        return null;
                    }
                    return 0;
                }

                ReadOnlySpan<byte> span = reader.HasValueSequence ? reader.ValueSequence.ToArray() : reader.ValueSpan;
                if (Utf8Parser.TryParse(span, out double number, out int bytesConsumed) && span.Length == bytesConsumed)
                    return number;

                if (Double.TryParse(reader.GetString(), out number))
                    return number;

                
            }
            
            return reader.GetDouble();
        }
        
        public override void Write(Utf8JsonWriter writer, double? value, JsonSerializerOptions options)
        {

            if (!value.HasValue)
            {
                writer.WriteNullValue();
            }
            else
            {
                if (double.IsNaN((double) value))
                {
                    writer.WriteStringValue("NaN");
                    return;
                }
                if (double.IsInfinity((double) value))
                {
                    writer.WriteStringValue("Infinity");
                    return;
                }
                writer.WriteNumberValue(value.Value);
            }
        }
    }
}
