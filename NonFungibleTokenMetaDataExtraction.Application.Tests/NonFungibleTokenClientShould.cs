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

            var nonFungibleTokenInputRequest = new NonFungibleTokenInputRequest
            {
                TokenId = 1823502,
                TokenIndeX = "1234",
                ContractAddress = "0xbc4ca0eda7647a8ab7c2061c2e118a18a936f13d"
            };

            var tokenUri = sut.GetTokenUri(nonFungibleTokenInputRequest);
            tokenUri.Wait();

            Assert.Equal("ipfs://QmeSjSinHpPnmXmspMjwiXyN6zS4E9zccariGR3jxcaWtq/1234", tokenUri.Result);
        }

        [Fact]
        public void ReturnTokenUriContentSampleContract()
        {
            var sut = SetUpTestTokenClient();

            var nonFungibleTokenInputRequest = new NonFungibleTokenInputRequest
            {
                TokenId = 1823502,
                TokenIndeX = "1234",
                ContractAddress = "0xbc4ca0eda7647a8ab7c2061c2e118a18a936f13d"
            };

            var tokenUriContent = sut.GetTokenUriContent(nonFungibleTokenInputRequest);
            tokenUriContent.Wait();

            Assert.Equal(@"{""image"":""ipfs://QmZ2ddtVUV1brVGjpq6vgrG6jEgEK3CqH19VURKzdwCSRf"",""attributes"":[{""trait_type"":""Eyes"",""value"":""Sleepy""},{""trait_type"":""Background"",""value"":""Army Green""},{""trait_type"":""Clothes"",""value"":""Leather Jacket""},{""trait_type"":""Fur"",""value"":""Blue""},{""trait_type"":""Mouth"",""value"":""Bored Bubblegum""},{""trait_type"":""Hat"",""value"":""Fisherman's Hat""}]}", tokenUriContent.Result.Trim());
        }

        [Fact]
        public void ReturnNonFungibleTokenModelForContractAddress0x0b22fe0a2995c5389ac093400e52471dca8bb48a_Correctly()
        {
            var sut = SetUpTestTokenClient();
            var nonFungibleTokenInputRequest = new NonFungibleTokenInputRequest
            {
                TokenId = 1823502,
                TokenIndeX = "0",
                ContractAddress = "0x0b22fe0a2995c5389ac093400e52471dca8bb48a"
            };

            var fungibleTokenModel = sut.GetNonFungibleTokenModel(nonFungibleTokenInputRequest);
            fungibleTokenModel.Wait();

            const int propertyCount = 6;

            var model = fungibleTokenModel.Result;

            Assert.Equal("Little Lemon #0", model.Name);
            Assert.Equal("9,999 Little lemons that fell from the giant lemon tree \ud83c\udf4b\ud83c\udf33 Each lemon finding their own little adventures in this big big world!", model.Description);
            Assert.Equal("https://littlelemonfriends.mypinata.cloud/ipfs/QmZjQq1R1mpNhRxP87ZdrJPC1ZhJpKRMAkpJEA9wzQUDoj/0.html", model.ExternalUrl);
            Assert.Equal("https://littlelemonfriends.mypinata.cloud/ipfs/QmTrkgowgs8onSvXyyeKjwMSHkkwBnMFUEVHAZZF1rK7zs", model.Media);

            Assert.Equal(propertyCount, model.Properties.Count);

            Assert.True(model.Properties.ContainsKey("Body"));
            Assert.Equal("Body", model.Properties["Body"].Category);
            Assert.Equal("Zombie", model.Properties["Body"].Property);

            Assert.True(model.Properties.ContainsKey("Background"));
            Assert.Equal("Background", model.Properties["Background"].Category);
            Assert.Equal("Blue", model.Properties["Background"].Property);

            Assert.True(model.Properties.ContainsKey("Face"));
            Assert.Equal("Face", model.Properties["Face"].Category);
            Assert.Equal("Zombie Dazed", model.Properties["Face"].Property);

            Assert.True(model.Properties.ContainsKey("Hat"));
            Assert.Equal("Hat", model.Properties["Hat"].Category);
            Assert.Equal("Laurel Wreath", model.Properties["Hat"].Property);

            Assert.True(model.Properties.ContainsKey("Clothing"));
            Assert.Equal("Clothing", model.Properties["Clothing"].Category);
            Assert.Equal("Magic Cape", model.Properties["Clothing"].Property);

            Assert.True(model.Properties.ContainsKey("Face Hair"));
            Assert.Equal("Face Hair", model.Properties["Face Hair"].Category);
            Assert.Equal("Moustache", model.Properties["Face Hair"].Property);

        }

        [Fact]
        public void ReturnNonFungibleTokenModelForContractAddress0xec9c519d49856fd2f8133a0741b4dbe002ce211b_Correctly()
        {
            var sut = SetUpTestTokenClient();
            var nonFungibleTokenInputRequest = new NonFungibleTokenInputRequest
            {
                TokenId = 1823502,
                TokenIndeX = "30",
                ContractAddress = "0xec9c519d49856fd2f8133a0741b4dbe002ce211b"
            };

            var fungibleTokenModel = sut.GetNonFungibleTokenModel(nonFungibleTokenInputRequest);
            fungibleTokenModel.Wait();

            const int propertyCount = 8;

            var model = fungibleTokenModel.Result;

            Assert.Equal("Bonsai #30", model.Name);
            Assert.Equal("[Image (.png)](https://ipfs.io/ipfs/QmbVz7CfgsaM3ePdHc8TVtEL7WYZ46CbzRs9yAep8D6m6M)\n\n[Animation (.mp4)](https://ipfs.io/ipfs/QmXnB2KBnBeYwD2dixBpCfKuSzYfwhtK6yAZHJagNXyuiN)\n\n[3D Model (.glb)](https://ipfs.io/ipfs/QmbT4cX1bdgfU8GiJ6w4eJJrfht4z2LqoD1KgHdiZsU1Di)\n\n[AR Object (.usdz)](https://ipfs.io/ipfs/Qmf8wxxBzzwBtingLYaZanfAQwJMEKC8uqkGvBuK5fd2BX)\n", model.Description);
            Assert.Equal("https://ipfs.io/ipfs/QmXnB2KBnBeYwD2dixBpCfKuSzYfwhtK6yAZHJagNXyuiN", model.ExternalUrl);
            Assert.Equal("https://ipfs.io/ipfs/QmbVz7CfgsaM3ePdHc8TVtEL7WYZ46CbzRs9yAep8D6m6M", model.Media);

            Assert.Equal(propertyCount, model.Properties.Count);
            Assert.True(model.Properties.ContainsKey("Pot"));
            Assert.Equal("Pot", model.Properties["Pot"].Category);
            Assert.Equal("Red Terra Cotta", model.Properties["Pot"].Property);

            Assert.True(model.Properties.ContainsKey("Pet"));
            Assert.Equal("Pet", model.Properties["Pet"].Category);
            Assert.Equal("Golden Mantis", model.Properties["Pet"].Property);

            Assert.True(model.Properties.ContainsKey("Leaves"));
            Assert.Equal("Leaves", model.Properties["Leaves"].Category);
            Assert.Equal("Momo Maple", model.Properties["Leaves"].Property);

            Assert.True(model.Properties.ContainsKey("Number of fruit"));
            Assert.Equal("Number of fruit", model.Properties["Number of fruit"].Category);
            Assert.Equal("0", model.Properties["Number of fruit"].Property);

            Assert.True(model.Properties.ContainsKey("Ground cover"));
            Assert.Equal("Ground cover", model.Properties["Ground cover"].Category);
            Assert.Equal("grass", model.Properties["Ground cover"].Property);

            Assert.True(model.Properties.ContainsKey("Fruit"));
            Assert.Equal("Fruit", model.Properties["Fruit"].Category);
            Assert.Equal("None", model.Properties["Fruit"].Property);

            Assert.True(model.Properties.ContainsKey("Background"));
            Assert.Equal("Background", model.Properties["Background"].Category);
            Assert.Equal("day", model.Properties["Background"].Property);

            Assert.True(model.Properties.ContainsKey("Bark"));
            Assert.Equal("Bark", model.Properties["Bark"].Category);
            Assert.Equal("Cedar", model.Properties["Bark"].Property);
        }

        [Fact]
        public void ReturnNonFungibleTokenModelForContractAddress0x1a92f7381b9f03921564a437210bb9396471050c_Correctly()
        {
            var sut = SetUpTestTokenClient();
            var nonFungibleTokenInputRequest = new NonFungibleTokenInputRequest
            {
                TokenId = 1823502,
                TokenIndeX = "0",
                ContractAddress = "0x1a92f7381b9f03921564a437210bb9396471050c"
            };

            var fungibleTokenModel = sut.GetNonFungibleTokenModel(nonFungibleTokenInputRequest);
            fungibleTokenModel.Wait();

            const int propertyCount = 7;

            var model = fungibleTokenModel.Result;

            Assert.Equal("Cool Cat #0", model.Name);
            Assert.Equal("Cool Cats is a collection of 9,999 randomly generated and stylistically curated NFTs that exist on the Ethereum Blockchain. Cool Cat holders can participate in exclusive events such as NFT claims, raffles, community giveaways, and more. Remember, all cats are cool, but some are cooler than others. Visit [www.coolcatsnft.com](https://www.coolcatsnft.com/) to learn more.", model.Description);
            Assert.Equal("https://ipfs.io/ipfs/QmXT9Gaiu6Znoz8hwf4788vTy2MnhpWCLBET1gS5XNvf4r", model.ExternalUrl);
            Assert.Equal("https://ipfs.io/ipfs/QmXT9Gaiu6Znoz8hwf4788vTy2MnhpWCLBET1gS5XNvf4r", model.Media);
            
            Assert.Equal(propertyCount, model.Properties.Count);
            Assert.True(model.Properties.ContainsKey("body"));
            Assert.Equal("body", model.Properties["body"].Category);
            Assert.Equal("blue cat skin", model.Properties["body"].Property);

            Assert.True(model.Properties.ContainsKey("hats"));
            Assert.Equal("hats", model.Properties["hats"].Category);
            Assert.Equal("knight blue", model.Properties["hats"].Property);

            Assert.True(model.Properties.ContainsKey("shirt"));
            Assert.Equal("shirt", model.Properties["shirt"].Category);
            Assert.Equal("tshirt yellow", model.Properties["shirt"].Property);

            Assert.True(model.Properties.ContainsKey("face"));
            Assert.Equal("face", model.Properties["face"].Category);
            Assert.Equal("happy", model.Properties["face"].Property);

            Assert.True(model.Properties.ContainsKey("tier"));
            Assert.Equal("tier", model.Properties["tier"].Category);
            Assert.Equal("wild_1", model.Properties["tier"].Property);

        }
    }
}