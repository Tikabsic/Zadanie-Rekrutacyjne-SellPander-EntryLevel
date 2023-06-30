
namespace Zadanie_rekrutacyjne_SellPander.DTO.Baselinker
{
    internal class Product
    {
        public string storage { get; set; }
        public int storage_id { get; set; }
        public string product_id { get; set; }
        public int variant_id { get; set; }
        public string name { get; set; }
        public string sku { get; set; }
        public string ean { get; set; }
        public string location { get; set; }
        public int warehouse_id { get; set; }
        public string attributes { get; set; }
        public float price_brutto { get; set; }
        public float tax_rate { get; set; }
        public int quantity { get; set; }
        public float weight { get; set; }
    }
}
