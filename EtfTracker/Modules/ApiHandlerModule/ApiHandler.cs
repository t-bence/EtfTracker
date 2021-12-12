namespace EtfTracker.Modules.ApiHandlerModule
{
    public class ApiHandler
    {
        private string apiKey;
        public ApiHandler(string apiKey)
        {
            this.apiKey = apiKey;
        }

        public T GetData<T>(string apiBaseUrl)
        {
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