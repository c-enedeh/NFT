using NonFungibleTokenMetaDataExtraction.Application.Model;
using NonFungibleTokenMetaDataExtraction.Application.Services;
using Org.BouncyCastle.Asn1.Ocsp;

namespace NonFungibleTokenMetaDataExtraction.Application.Tests
{
    public class NonFungibleTokenClientShould
    {
        private const string ApiKey = "4441cc2988c64bc1bc3029f55d39dbe6";
       
        private static NonFungibleTokenClient SetUpTestTokenClient()
        {
            return NonFungibleTokenClient.GetNonFungibleTokenClient(ApiKey);
        }

        [Fact]
        public void ReturnTokenUriSampleContract()
        {
            var sut = SetUpTestTokenClient();

            var request = new NonFungibleTokenInputRequest
            {
                TokenId = 1823502,
                TokenIndeX = "1234",
                ContractAddress = "0xbc4ca0eda7647a8ab7c2061c2e118a18a936f13d"
            };

            var tokenUri = sut.GetTokenUri(request);
            tokenUri.Wait();

            Assert.Equal("ipfs://QmeSjSinHpPnmXmspMjwiXyN6zS4E9zccariGR3jxcaWtq/1234", tokenUri.Result);
        }

        [Fact]
        public void ReturnTokenUriContentSampleContract()
        {
            var sut = SetUpTestTokenClient();

            var request = new NonFungibleTokenInputRequest
            {
                TokenId = 1823502,
                TokenIndeX = "1234",
                ContractAddress = "0xbc4ca0eda7647a8ab7c2061c2e118a18a936f13d"
            };

            var tokenUriContent = sut.GetTokenUriContent(request);
            tokenUriContent.Wait();

            Assert.Equal(@"{""image"":""ipfs://QmZ2ddtVUV1brVGjpq6vgrG6jEgEK3CqH19VURKzdwCSRf"",""attributes"":[{""trait_type"":""Eyes"",""value"":""Sleepy""},{""trait_type"":""Background"",""value"":""Army Green""},{""trait_type"":""Clothes"",""value"":""Leather Jacket""},{""trait_type"":""Fur"",""value"":""Blue""},{""trait_type"":""Mouth"",""value"":""Bored Bubblegum""},{""trait_type"":""Hat"",""value"":""Fisherman's Hat""}]}", tokenUriContent.Result.Trim());
        }
    }
}