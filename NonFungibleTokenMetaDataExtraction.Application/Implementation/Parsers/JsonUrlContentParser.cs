using NonFungibleTokenMetaDataExtraction.Application.Interface;

namespace NonFungibleTokenMetaDataExtraction.Application.Implementation.Parsers
{
    public class JsonUrlContentParser : ITokenUriContentParser
    {
        public virtual async Task<string> Parse(string value)
        {
            return await GetHttpRequestJsonBody(value);
        }

        public virtual bool IsContentStringSupported(string value)
        {
            return value.StartsWith("http");
        }
    
        protected static async Task<string> GetHttpRequestJsonBody(string httpUri)
        {
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(httpUri),
                Method = HttpMethod.Get
            };

            var httpClient = new HttpClient();
            var response = await httpClient.SendAsync(request).ConfigureAwait(false);
        
            response.EnsureSuccessStatusCode();
        
            return  await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        
        }
    }
}
