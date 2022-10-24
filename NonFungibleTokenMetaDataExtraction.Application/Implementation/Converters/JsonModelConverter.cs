using Newtonsoft.Json.Linq;
using NonFungibleTokenMetaDataExtraction.Application.Interface;
using NonFungibleTokenMetaDataExtraction.Application.Model;

namespace NonFungibleTokenMetaDataExtraction.Application.Implementation.Converters
{
    public class JsonModelConverter
    {
        private readonly IEnumerable<IPropertyParser> _propertyParser;

    public JsonModelConverter(IEnumerable<IPropertyParser> propertyParser)
    {
        _propertyParser = propertyParser;
    }
    
    public static JsonModelConverter GetJsonModelConverter()
    {
        var propertyParsers = new IPropertyParser[]
        {
            new IpfsImagePropertyParser(),
            new AnimationUrlPropertyParser(),
            new ExternalUrlPropertyParser(),
            new GenericPropertyParser(),
            new ImageDataPropertyParser(),
            new NamePropertyParser(),
            new DescriptionPropertyParser(),
            new ImagePropertyParser(),
        };

        return new JsonModelConverter(propertyParsers);
    }
    
    public NonFungibleToken Convert(string jsonString)
    {
        var model = new NonFungibleToken();

        var jsonObject = JObject.Parse(jsonString);

        foreach (var property in jsonObject)
        {
            var isPropertyHandled = false;

            foreach (var parser in _propertyParser)
            {
                if (parser.PropertyName.ToLower() != property.Key) continue;
                parser.SwapValue(model, property.Value);
                isPropertyHandled = true;
                break;
            }
            if (isPropertyHandled) continue;
            var key = property.Key;
            var value = property.Value?.ToString();
            if (!model.Properties.ContainsKey(key))
            {
                model.Properties[key] = new NonFungibleTokenProperty
                {
                    Category = key, 
                    Property = value
                };
            }
        }

        if (string.IsNullOrWhiteSpace(model.ExternalUrl) && !string.IsNullOrWhiteSpace(model.Media))
        {
            model.ExternalUrl = model.Media;
        }
        else if (!string.IsNullOrWhiteSpace(model.ExternalUrl) && string.IsNullOrWhiteSpace(model.Media))
        {
            model.Media = model.ExternalUrl;
        }
        
        return model;
    }
    }
}
