namespace NonFungibleTokenMetaDataExtraction.Application.Model
{
    public class NonFungibleTokenInputRequest
    {
        public long TokenId { get; set; }
        public string TokenIndeX { get; set; }
        public string? ContractAddress { get; set; }
    }
}
