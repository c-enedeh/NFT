using Nethereum.Web3;
using NonFungibleTokenMetaDataExtraction.Application.Implementation.Converters;
using NonFungibleTokenMetaDataExtraction.Application.Implementation.Parsers;
using NonFungibleTokenMetaDataExtraction.Application.Interface;
using NonFungibleTokenMetaDataExtraction.Application.Model;

namespace NonFungibleTokenMetaDataExtraction.Application.Services
{
    public class NonFungibleTokenClient
    {
        private readonly IEnumerable<ITokenUriContentParser> _tokenUriContentParsers;
    private readonly JsonModelConverter _jsonModelConverter;
    private readonly Web3 _web3Client;
    
    public NonFungibleTokenClient(string httpUri, IEnumerable<ITokenUriContentParser> tokenUriContentParsers,
        JsonModelConverter jsonModelConverter)
    {
        _tokenUriContentParsers = tokenUriContentParsers;
        _jsonModelConverter = jsonModelConverter;
        _web3Client = new Web3(httpUri);
    }
    
    public static NonFungibleTokenClient GetNonFungibleTokenClient(string apiKey)
    {
        var tokenUriContentParsers = new ITokenUriContentParser[]
        {
            new Base64StringParser(),
            new IpfsJsonUriParser(),
            new JsonUrlContentParser()
        };

        return new NonFungibleTokenClient($"https://mainnet.infura.io/v3/{apiKey}", tokenUriContentParsers,
            JsonModelConverter.GetJsonModelConverter());
    }
    
    public async Task<string> GetTokenUri(NonFungibleTokenInputRequest nonFungibleTokenInputRequest)
        {   
            const string tokenUri ="tokenURI";
            const string applicationBinaryInterfaceFormat = @"[{""inputs"":[{""internalType"":""string"",""name"":""name"",""type"":""string""},{""internalType"":""string"",""name"":""symbol"",""type"":""string""},{""internalType"":""uint256"",""name"":""maxNftSupply"",""type"":""uint256""},{""internalType"":""uint256"",""name"":""saleStart"",""type"":""uint256""}],""stateMutability"":""nonpayable"",""type"":""constructor""},{""anonymous"":false,""inputs"":[{""indexed"":true,""internalType"":""address"",""name"":""owner"",""type"":""address""},{""indexed"":true,""internalType"":""address"",""name"":""approved"",""type"":""address""},{""indexed"":true,""internalType"":""uint256"",""name"":""tokenId"",""type"":""uint256""}],""name"":""Approval"",""type"":""event""},{""anonymous"":false,""inputs"":[{""indexed"":true,""internalType"":""address"",""name"":""owner"",""type"":""address""},{""indexed"":true,""internalType"":""address"",""name"":""operator"",""type"":""address""},{""indexed"":false,""internalType"":""bool"",""name"":""approved"",""type"":""bool""}],""name"":""ApprovalForAll"",""type"":""event""},{""anonymous"":false,""inputs"":[{""indexed"":true,""internalType"":""address"",""name"":""previousOwner"",""type"":""address""},{""indexed"":true,""internalType"":""address"",""name"":""newOwner"",""type"":""address""}],""name"":""OwnershipTransferred"",""type"":""event""},{""anonymous"":false,""inputs"":[{""indexed"":true,""internalType"":""address"",""name"":""from"",""type"":""address""},{""indexed"":true,""internalType"":""address"",""name"":""to"",""type"":""address""},{""indexed"":true,""internalType"":""uint256"",""name"":""tokenId"",""type"":""uint256""}],""name"":""Transfer"",""type"":""event""},{""inputs"":[],""name"":""BAYC_PROVENANCE"",""outputs"":[{""internalType"":""string"",""name"":"""",""type"":""string""}],""stateMutability"":""view"",""type"":""function""},{""inputs"":[],""name"":""MAX_APES"",""outputs"":[{""internalType"":""uint256"",""name"":"""",""type"":""uint256""}],""stateMutability"":""view"",""type"":""function""},{""inputs"":[],""name"":""REVEAL_TIMESTAMP"",""outputs"":[{""internalType"":""uint256"",""name"":"""",""type"":""uint256""}],""stateMutability"":""view"",""type"":""function""},{""inputs"":[],""name"":""apePrice"",""outputs"":[{""internalType"":""uint256"",""name"":"""",""type"":""uint256""}],""stateMutability"":""view"",""type"":""function""},{""inputs"":[{""internalType"":""address"",""name"":""to"",""type"":""address""},{""internalType"":""uint256"",""name"":""tokenId"",""type"":""uint256""}],""name"":""approve"",""outputs"":[],""stateMutability"":""nonpayable"",""type"":""function""},{""inputs"":[{""internalType"":""address"",""name"":""owner"",""type"":""address""}],""name"":""balanceOf"",""outputs"":[{""internalType"":""uint256"",""name"":"""",""type"":""uint256""}],""stateMutability"":""view"",""type"":""function""},{""inputs"":[],""name"":""baseURI"",""outputs"":[{""internalType"":""string"",""name"":"""",""type"":""string""}],""stateMutability"":""view"",""type"":""function""},{""inputs"":[],""name"":""emergencySetStartingIndexBlock"",""outputs"":[],""stateMutability"":""nonpayable"",""type"":""function""},{""inputs"":[],""name"":""flipSaleState"",""outputs"":[],""stateMutability"":""nonpayable"",""type"":""function""},{""inputs"":[{""internalType"":""uint256"",""name"":""tokenId"",""type"":""uint256""}],""name"":""getApproved"",""outputs"":[{""internalType"":""address"",""name"":"""",""type"":""address""}],""stateMutability"":""view"",""type"":""function""},{""inputs"":[{""internalType"":""address"",""name"":""owner"",""type"":""address""},{""internalType"":""address"",""name"":""operator"",""type"":""address""}],""name"":""isApprovedForAll"",""outputs"":[{""internalType"":""bool"",""name"":"""",""type"":""bool""}],""stateMutability"":""view"",""type"":""function""},{""inputs"":[],""name"":""maxApePurchase"",""outputs"":[{""internalType"":""uint256"",""name"":"""",""type"":""uint256""}],""stateMutability"":""view"",""type"":""function""},{""inputs"":[{""internalType"":""uint256"",""name"":""numberOfTokens"",""type"":""uint256""}],""name"":""mintApe"",""outputs"":[],""stateMutability"":""payable"",""type"":""function""},{""inputs"":[],""name"":""name"",""outputs"":[{""internalType"":""string"",""name"":"""",""type"":""string""}],""stateMutability"":""view"",""type"":""function""},{""inputs"":[],""name"":""owner"",""outputs"":[{""internalType"":""address"",""name"":"""",""type"":""address""}],""stateMutability"":""view"",""type"":""function""},{""inputs"":[{""internalType"":""uint256"",""name"":""tokenId"",""type"":""uint256""}],""name"":""ownerOf"",""outputs"":[{""internalType"":""address"",""name"":"""",""type"":""address""}],""stateMutability"":""view"",""type"":""function""},{""inputs"":[],""name"":""renounceOwnership"",""outputs"":[],""stateMutability"":""nonpayable"",""type"":""function""},{""inputs"":[],""name"":""reserveApes"",""outputs"":[],""stateMutability"":""nonpayable"",""type"":""function""},{""inputs"":[{""internalType"":""address"",""name"":""from"",""type"":""address""},{""internalType"":""address"",""name"":""to"",""type"":""address""},{""internalType"":""uint256"",""name"":""tokenId"",""type"":""uint256""}],""name"":""safeTransferFrom"",""outputs"":[],""stateMutability"":""nonpayable"",""type"":""function""},{""inputs"":[{""internalType"":""address"",""name"":""from"",""type"":""address""},{""internalType"":""address"",""name"":""to"",""type"":""address""},{""internalType"":""uint256"",""name"":""tokenId"",""type"":""uint256""},{""internalType"":""bytes"",""name"":""_data"",""type"":""bytes""}],""name"":""safeTransferFrom"",""outputs"":[],""stateMutability"":""nonpayable"",""type"":""function""},{""inputs"":[],""name"":""saleIsActive"",""outputs"":[{""internalType"":""bool"",""name"":"""",""type"":""bool""}],""stateMutability"":""view"",""type"":""function""},{""inputs"":[{""internalType"":""address"",""name"":""operator"",""type"":""address""},{""internalType"":""bool"",""name"":""approved"",""type"":""bool""}],""name"":""setApprovalForAll"",""outputs"":[],""stateMutability"":""nonpayable"",""type"":""function""},{""inputs"":[{""internalType"":""string"",""name"":""baseURI"",""type"":""string""}],""name"":""setBaseURI"",""outputs"":[],""stateMutability"":""nonpayable"",""type"":""function""},{""inputs"":[{""internalType"":""string"",""name"":""provenanceHash"",""type"":""string""}],""name"":""setProvenanceHash"",""outputs"":[],""stateMutability"":""nonpayable"",""type"":""function""},{""inputs"":[{""internalType"":""uint256"",""name"":""revealTimeStamp"",""type"":""uint256""}],""name"":""setRevealTimestamp"",""outputs"":[],""stateMutability"":""nonpayable"",""type"":""function""},{""inputs"":[],""name"":""setStartingIndex"",""outputs"":[],""stateMutability"":""nonpayable"",""type"":""function""},{""inputs"":[],""name"":""startingIndex"",""outputs"":[{""internalType"":""uint256"",""name"":"""",""type"":""uint256""}],""stateMutability"":""view"",""type"":""function""},{""inputs"":[],""name"":""startingIndexBlock"",""outputs"":[{""internalType"":""uint256"",""name"":"""",""type"":""uint256""}],""stateMutability"":""view"",""type"":""function""},{""inputs"":[{""internalType"":""bytes4"",""name"":""interfaceId"",""type"":""bytes4""}],""name"":""supportsInterface"",""outputs"":[{""internalType"":""bool"",""name"":"""",""type"":""bool""}],""stateMutability"":""view"",""type"":""function""},{""inputs"":[],""name"":""symbol"",""outputs"":[{""internalType"":""string"",""name"":"""",""type"":""string""}],""stateMutability"":""view"",""type"":""function""},{""inputs"":[{""internalType"":""uint256"",""name"":""index"",""type"":""uint256""}],""name"":""tokenByIndex"",""outputs"":[{""internalType"":""uint256"",""name"":"""",""type"":""uint256""}],""stateMutability"":""view"",""type"":""function""},{""inputs"":[{""internalType"":""address"",""name"":""owner"",""type"":""address""},{""internalType"":""uint256"",""name"":""index"",""type"":""uint256""}],""name"":""tokenOfOwnerByIndex"",""outputs"":[{""internalType"":""uint256"",""name"":"""",""type"":""uint256""}],""stateMutability"":""view"",""type"":""function""},{""inputs"":[{""internalType"":""uint256"",""name"":""tokenId"",""type"":""uint256""}],""name"":""tokenURI"",""outputs"":[{""internalType"":""string"",""name"":"""",""type"":""string""}],""stateMutability"":""view"",""type"":""function""},{""inputs"":[],""name"":""totalSupply"",""outputs"":[{""internalType"":""uint256"",""name"":"""",""type"":""uint256""}],""stateMutability"":""view"",""type"":""function""},{""inputs"":[{""internalType"":""address"",""name"":""from"",""type"":""address""},{""internalType"":""address"",""name"":""to"",""type"":""address""},{""internalType"":""uint256"",""name"":""tokenId"",""type"":""uint256""}],""name"":""transferFrom"",""outputs"":[],""stateMutability"":""nonpayable"",""type"":""function""},{""inputs"":[{""internalType"":""address"",""name"":""newOwner"",""type"":""address""}],""name"":""transferOwnership"",""outputs"":[],""stateMutability"":""nonpayable"",""type"":""function""},{""inputs"":[],""name"":""withdraw"",""outputs"":[],""stateMutability"":""nonpayable"",""type"":""function""}]";
            var contractObject = _web3Client.Eth.GetContract(applicationBinaryInterfaceFormat, nonFungibleTokenInputRequest.ContractAddress);
            var tokenFunction = contractObject.GetFunction(tokenUri);
            
            var response = await tokenFunction.CallAsync<string>(long.Parse(nonFungibleTokenInputRequest.TokenIndeX));
            return response;
        }
    
    public async Task<string> GetTokenUriContent(NonFungibleTokenInputRequest nonFungibleTokenInputRequest)
    {
        var getTokenUriContent = await GetTokenUri(nonFungibleTokenInputRequest);

        var supportedContentParser = _tokenUriContentParsers
            .FirstOrDefault(t=> t.IsContentStringSupported(getTokenUriContent));

        if(supportedContentParser == null)
        {
            return $"parser NOT FOUND for token string: {getTokenUriContent}";
        }
        return await supportedContentParser.Parse(getTokenUriContent);
    }
    
    public async Task<NonFungibleToken> GetNonFungibleTokenModel(NonFungibleTokenInputRequest nonFungibleTokenInputRequest)
    {
        var response = await GetTokenUriContent(nonFungibleTokenInputRequest);
        var result = _jsonModelConverter.Convert(response);
        return result;
    }
    }
}
