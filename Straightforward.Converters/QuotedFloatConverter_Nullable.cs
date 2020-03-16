using System;
using System.Buffers;
using System.Buffers.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Straightforward.Converters
{
    public class QuotedFloatConverterNullable : JsonConverter<float?>
    {
        public override float? Read(ref Utf8JsonReader reader, Type type, JsonSerializerOptions options)
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
                if (Utf8Parser.TryParse(span, out float number, out int bytesConsumed) && span.Length == bytesConsumed)
                    return number;

                if (float.TryParse(reader.GetString(), out number))
                    return number;

                
            }
            return reader.GetSingle();
        }
        
        public override void Write(Utf8JsonWriter writer, float? value, JsonSerializerOptions options)
        {
            if (!value.HasValue)
            {
                writer.WriteNullValue();
            }
            else
            {
                if (float.IsNaN((float)value))
                {
                    writer.WriteStringValue("NaN");
                    return;
                }
                if (float.IsInfinity((float)value))
                {
                    writer.WriteStringValue("Infinity");
                    return;
                }
                writer.WriteNumberValue(value.Value);
            }
            
        }
    }
}
