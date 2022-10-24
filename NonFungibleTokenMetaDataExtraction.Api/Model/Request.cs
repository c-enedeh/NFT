namespace NonFungibleTokenMetaDataExtraction.Api.Model
{
    public class Request
    {
        public long TokenId { get; set; }
        public string? TokenIndex { get; set; }
        public string? ContractAddress { get; set; }
    }
}
