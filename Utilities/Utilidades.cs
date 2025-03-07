using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Net.Mime.MediaTypeNames;

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.PixelFormats;


// Definir alias para evitar conflicto con System.Drawing.Image
using ImageSharpImage = SixLabors.ImageSharp.Image;



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

        public class ArchivoUtilidades {

            public class ArchivoResultado
            {
                public string Ruta { get; set; }
                public string NombreArchivo { get; set; }
                public string Extension { get; set; }
            }

            /// <summary>
            /// Guarda un archivo en una ruta específica.
            /// </summary>
            /// <param name="ruta">Ruta donde se guardará el archivo.</param>
            /// <param name="contenido">Contenido del archivo.</param>
            public ArchivoResultado GuardarArchivo(IFormFile archivo, string ruta)
            {

                var nombreSinExtension = Path.GetFileNameWithoutExtension(archivo.FileName);
                var extension = Path.GetExtension(archivo.FileName);


                // Crea una carpeta para almacenar los archivos si no existe
                var carpetaArchivos = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", ruta);
                if (!Directory.Exists(carpetaArchivos))
                {
                    Directory.CreateDirectory(carpetaArchivos);
                }

                // Genera un nombre único para el archivo
                var nombreArchivo = nombreSinExtension + "_" + Guid.NewGuid().ToString() + extension;

                // Guarda el archivo en la carpeta
                var rutaArchivo = Path.Combine(carpetaArchivos, nombreArchivo);
                using (var stream = new FileStream(rutaArchivo, FileMode.Create))
                {
                    archivo.CopyTo(stream);
                }

                // Retorna la ruta del archivo
                //return $"/{ruta}/{nombreArchivo}";
                return new ArchivoResultado
                {
                    Ruta = ruta,
                    NombreArchivo = nombreArchivo,
                    Extension = extension
                };
            }

            /// <summary>
            /// Recupera el contenido de un archivo.
            /// </summary>
            /// <param name="ruta">Ruta del archivo que se quiere recuperar.</param>
            /// <returns>Contenido del archivo.</returns>
            public byte[] RecuperarArchivo(string carpeta, string nombre, bool? thumb = false )
            {
                try
                {
                    var nombreArchivo = nombre;
                    if (thumb == true) {
                        nombreArchivo = $"thumb_{nombre}";
                    }
                    var rutaCompleta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", carpeta, nombreArchivo);
                    return File.ReadAllBytes(rutaCompleta);
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("El archivo no existe.");
                    return null;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al recuperar el archivo: " + ex.Message);
                    return null;
                }
            }

            public bool EliminaArchivo(string ruta, string nombreArchivo)
            {
                try {
                    var rutaCompleta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", ruta, nombreArchivo);
                    if (File.Exists(rutaCompleta))
                    {
                        File.Delete(rutaCompleta);
                        return true;
                    } else { 
                        return false; 
                    }

                }
                catch (FileNotFoundException)
                {
                    return false;
                }
            }

            public void GenerarMiniatura(string carpetaOrigen, string carpetaDestino, string archivoOrigen, string archivoDestino, int ancho, int alto)
            {
                var rutaCompletaOrigen = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", carpetaOrigen, archivoOrigen);
                var rutaCompletaMiniatura = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", carpetaDestino, archivoDestino);

                using (Image<Rgba32> image = ImageSharpImage.Load<Rgba32>(rutaCompletaOrigen))
                {
                    image.Mutate(x => x.Resize(ancho, alto));
                    image.Save(rutaCompletaMiniatura);
                }
            }






            /// <summary>
            /// Verifica si un archivo existe en una ruta específica.
            /// </summary>
            /// <param name="ruta">Ruta del archivo que se quiere verificar.</param>
            /// <returns>True si el archivo existe, false en caso contrario.</returns>
            public bool ExisteArchivo(string ruta)
            {
                return File.Exists(ruta);
            }

        }

    }
}
