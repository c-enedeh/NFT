using System.Text;

namespace NonFungibleTokenMetaDataExtraction.Application.Model
{
    public class NonFungibleToken
    {
        public NonFungibleToken()
        {
            Properties = new Dictionary<string, NonFungibleTokenProperty>();
        }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ExternalUrl { get; set; }
        public string? Media { get; set; }
        public Dictionary<string, NonFungibleTokenProperty> Properties { get; set; }
    
        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append("Name: ");
            builder.AppendLine(Name);
            builder.Append("Description: ");
            builder.AppendLine(Description);
            builder.Append("ExternalUrl: ");
            builder.AppendLine(ExternalUrl);
            builder.Append("Media: ");
            builder.AppendLine(Media);
            builder.AppendLine("Properties:");
            foreach(var property in Properties)
            {
                builder.Append("\tCategory: ");
                builder.Append(property.Value.Category);
        
                builder.Append("\tProperty: ");
                builder.AppendLine(property.Value.Property);
            }
            return builder.ToString();
        }
    }
}
