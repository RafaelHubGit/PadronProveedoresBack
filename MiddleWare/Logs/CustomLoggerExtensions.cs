namespace PadronProveedoresAPI.MiddleWare.Logs
{
    public static class CustomLoggerExtensions
    {
        public static void LogInformationWithContext(
        this CustomLogger logger,
        string message,
        string archivo,
        params (string Key, object Value)[] properties)
        {
            var propertyDictionary = new Dictionary<string, object>
        {
            { "Archivo", archivo }
        };

            foreach (var (key, value) in properties)
            {
                propertyDictionary.Add(key, value);
            }

            CustomLogger.LogInformation(message, propertyDictionary);
        }

        public static void LogErrorWithContext(
            this CustomLogger logger,
            string message,
            Exception ex,
            string archivo,
            params (string Key, object Value)[] properties)
        {
            var propertyDictionary = new Dictionary<string, object>
        {
            { "Archivo", archivo }
        };

            foreach (var (key, value) in properties)
            {
                propertyDictionary.Add(key, value);
            }

            CustomLogger.LogError(message, ex, propertyDictionary);
        }
    }
}
