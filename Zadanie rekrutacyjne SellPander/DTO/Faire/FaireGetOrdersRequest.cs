using System.Collections.Generic;

namespace Zadanie_rekrutacyjne_SellPander.DTO.Faire
{
    internal class FaireGetOrdersRequest
    {
        public int page { get; set; }
        public int limit { get; set; }
        public List<Order> orders { get; set; }
    }
}
