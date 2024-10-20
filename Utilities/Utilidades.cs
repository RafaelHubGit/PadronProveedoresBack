using System.Text.Json;
using System.Text.Json.Serialization;

namespace PadronProveedoresAPI.Utilities
{
    public class Utilidades
    {
        /// <summary>
        /// Conversor de JSON para convertir números a cadenas.
        /// </summary>
        public class StringConverter : JsonConverter<string>
        {
            /// <summary>
            /// Lee un valor JSON y lo convierte a una cadena.
            /// </summary>
            /// <param name="reader">Lector de JSON.</param>
            /// <param name="typeToConvert">Tipo de dato a convertir.</param>
            /// <param name="options">Opciones de serialización.</param>
            /// <returns>Cadena convertida.</returns>
            public override string? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType == JsonTokenType.Number)
                {
                    return reader.GetInt32().ToString();
                }
                else
                {
                    return reader.GetString();
                }
            }

            /// <summary>
            /// Escribe un valor de cadena como JSON.
            /// </summary>
            /// <param name="writer">Escritor de JSON.</param>
            /// <param name="value">Valor de cadena a escribir.</param>
            /// <param name="options">Opciones de serialización.</param>
            public override void Write(Utf8JsonWriter writer, string? value, JsonSerializerOptions options)
            {
                writer.WriteStringValue(value);
            }
        }
    }
}
