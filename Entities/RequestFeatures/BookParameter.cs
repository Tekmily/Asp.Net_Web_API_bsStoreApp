namespace Entities.RequestFeatures
{
    public class BookParameter : RequestParameters
    {
        public uint MinPrice { get; set; }
        public uint MaxPrice { get; set; } = 1000;
        public bool ValidPriceRange => MinPrice < MaxPrice;
        public String? SearchTrem { get; set; }
    }
}
