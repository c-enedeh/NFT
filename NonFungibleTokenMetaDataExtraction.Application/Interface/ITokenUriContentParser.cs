namespace NonFungibleTokenMetaDataExtraction.Application.Interface
{
    public interface ITokenUriContentParser
    {
        Task<string> Parse(string value);
        bool IsContentStringSupported(string value);
    }
}
