using Serilog;
using Serilog.Context;
using System.Collections.Generic;

namespace PadronProveedoresAPI.MiddleWare.Logs
{
    public class CustomLogger
    {
        public static void LogInformation(string message, Dictionary<string, object> properties = null)
        {
            if (properties != null)
            {
                // Crear una lista para almacenar los IDisposable que devuelve PushProperty
                var disposables = new List<IDisposable>();

                try
                {
                    // Iterar sobre el diccionario y agregar cada propiedad al LogContext
                    foreach (var property in properties)
                    {
                        disposables.Add(LogContext.PushProperty(property.Key, property.Value));
                    }

                    // Loggear el mensaje
                    Log.Information(message);
                }
                finally
                {
                    // Asegurarse de que todos los IDisposable se dispongan correctamente
                    foreach (var disposable in disposables)
                    {
                        disposable.Dispose();
                    }
                }
            }
            else
            {
                // Loggear el mensaje sin propiedades adicionales
                Log.Information(message);
            }
        }

        public static void LogError(string message, Exception ex, Dictionary<string, object> properties = null)
        {
            if (properties != null)
            {
                // Crear una lista para almacenar los IDisposable que devuelve PushProperty
                var disposables = new List<IDisposable>();

                try
                {
                    // Iterar sobre el diccionario y agregar cada propiedad al LogContext
                    foreach (var property in properties)
                    {
                        disposables.Add(LogContext.PushProperty(property.Key, property.Value));
                    }

                    // Loggear el mensaje de error con la excepción
                    Log.Error(ex, message);
                }
                finally
                {
                    // Asegurarse de que todos los IDisposable se dispongan correctamente
                    foreach (var disposable in disposables)
                    {
                        disposable.Dispose();
                    }
                }
            }
            else
            {
                // Loggear el mensaje de error sin propiedades adicionales
                Log.Error(ex, message);
            }
        }
    }
}
