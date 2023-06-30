
namespace Zadanie_rekrutacyjne_SellPander.DTO.Faire
{
    internal class Item
    {
        public string id { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string order_id { get; set; }
        public string product_id { get; set; }
        public string product_option_id { get; set; }
        public int quantity { get; set; }
        public string sku { get; set; }
        public int price_cents { get; set; }
        public string product_name { get; set; }
        public string product_option_name { get; set; }
        public bool includes_tester { get; set; }
    }
}
