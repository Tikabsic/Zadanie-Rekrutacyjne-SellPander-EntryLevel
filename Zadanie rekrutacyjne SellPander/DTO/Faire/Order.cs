using System.Collections.Generic;
using Zadanie_rekrutacyjne_SellPander.DTO.Faire.Enums;

namespace Zadanie_rekrutacyjne_SellPander.DTO.Faire
{
    internal class Order
    {
        public string id { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public OrderStates state { get; set; }
        public List<Item> items { get; set; }
        public Shipments shipments { get; set; }
        public Address address { get; set; }
        public string retailer_id { get; set; }
        public PayoutCosts payout_costs { get; set; }
        public string source { get; set; }
    }
}
