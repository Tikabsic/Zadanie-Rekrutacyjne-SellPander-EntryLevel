
namespace Zadanie_rekrutacyjne_SellPander.DTO.Faire
{
    internal class Shipments
    {
        public string id { get; set; }
        public string order_id { get; set; }
        public int maker_cost_cents { get; set; }
        public string carrier { get; set; }
        public string tracking_code { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
    }
}
