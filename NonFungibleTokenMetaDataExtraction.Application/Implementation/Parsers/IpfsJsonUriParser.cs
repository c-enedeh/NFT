namespace NonFungibleTokenMetaDataExtraction.Application.Implementation.Parsers
{
    public class IpfsJsonUriParser : JsonUrlContentParser
    {
        public override bool IsContentStringSupported(string value)
        {
            return value.StartsWith("ipfs:");
        }
    
        public override async Task<string> Parse(string value)
        {
            var formattedUri = $"https://ipfs.io/ipfs/{value.Replace("ipfs/", "").Replace("ipfs://", "")}";
            return await GetHttpRequestJsonBody(formattedUri);
        }
    }
}
