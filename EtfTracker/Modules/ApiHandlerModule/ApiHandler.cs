namespace EtfTracker.Modules.ApiHandlerModule
{
    public class ApiHandler
    {
        private IConfiguration configuration;
        public ApiHandler(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public T GetData<T>(string apiBaseUrl, string configKey)
        {
            string apiKey = configuration.GetValue<string>(configKey);
            
            var url = string.Format(apiBaseUrl, apiKey);

            T data;

            using (HttpClient client = new HttpClient())
            {
                data = client.GetFromJsonAsync<T>(url).Result;
            }

            return data;
        }
    }
}