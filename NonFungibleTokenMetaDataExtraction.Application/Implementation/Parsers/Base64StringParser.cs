using System.Text;
using NonFungibleTokenMetaDataExtraction.Application.Interface;

namespace NonFungibleTokenMetaDataExtraction.Application.Implementation.Parsers
{
    public class Base64StringParser : ITokenUriContentParser
    {
        public Task<string> Parse(string value)
        {
            var formattedString = value[(value.LastIndexOf(',') + 1)..];
            var contents = Convert.FromBase64String(formattedString);
            return Task.FromResult(Encoding.UTF8.GetString(contents));
        }

        public bool IsContentStringSupported(string value)
        {
            return value.Contains("base64");
        }
    }
}
