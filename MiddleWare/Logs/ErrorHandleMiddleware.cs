using Serilog.Context;
using Serilog;
using System.Text;

namespace PadronProveedoresAPI.MiddleWare.Logs
{
    public class ErrorHandleMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandleMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // Lee el cuerpo de la solicitud para capturar los datos del usuario
                context.Request.EnableBuffering(); // Permite leer el cuerpo varias veces
                var requestBody = await new StreamReader(context.Request.Body, Encoding.UTF8).ReadToEndAsync();
                context.Request.Body.Position = 0; // Rebobina el stream para que otros middlewares puedan leerlo

                // Agrega el cuerpo de la solicitud al contexto del log
                using (LogContext.PushProperty("RequestBody", requestBody, destructureObjects: true))
                {
                    await _next(context); // Continúa con el siguiente middleware
                }
            }
            catch (Exception ex)
            {
                // Registra el error en Serilog
                Log.Error(ex, "Error no controlado en la aplicación");

                // Devuelve una respuesta de error al cliente
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(new
                {
                    error = "Ocurrió un error interno en el servidor.",
                    details = ex.Message // Puedes personalizar esto para no exponer detalles sensibles en producción
                }));
            }
        }
    }
}
