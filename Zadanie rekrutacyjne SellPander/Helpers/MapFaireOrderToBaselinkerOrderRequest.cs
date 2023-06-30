using System.Collections.Generic;
using Zadanie_rekrutacyjne_SellPander.DTO.Baselinker;
using Zadanie_rekrutacyjne_SellPander.DTO.Faire;

namespace Zadanie_rekrutacyjne_SellPander.Helpers
{
    internal static class MapFaireOrderToBaselinkerOrderRequest
    {
        private static readonly int _sourceId = 1024;
        private static readonly int _statusId = 8069;
        private static readonly string _storageType = "shop";

        private static List<Product> MapFaireItemsToBaselinkerOrderProducts(Order order)
        {
            var items = order.items;
            var products = new List<Product>();
            foreach (var item in items)
            {
                var newProduct = new Product()
                {
                    storage = _storageType,
                    product_id = item.product_id,
                    name = item.product_name,
                    sku = item.sku,
                    warehouse_id = _sourceId,
                    attributes = item.product_option_name,
                    price_brutto = item.price_cents,
                    quantity = item.quantity
                };
                products.Add(newProduct);
            }
            return products;
        }

        internal static BaselinkerAddOrderRequest MapFaireOrderToBaselinkerOrder(Order faireOrdersData)
        {
            var newBaselinkerOrder = new BaselinkerAddOrderRequest()
            {
                order_status_id = _statusId,
                custom_source_id = _sourceId,
                date_add = ConvertToUnix.ConvertISOToUnix(faireOrdersData.created_at),
                phone = faireOrdersData.address.phone_number,
                paid = CheckForPayment.CheckForOrderPayment(faireOrdersData),
                delivery_price = faireOrdersData.shipments.maker_cost_cents,
                delivery_fullname = faireOrdersData.address.name,
                delivery_company = faireOrdersData.shipments.carrier,
                delivery_address = faireOrdersData.address.address1 + " " + faireOrdersData.address.address2,
                delivery_city = faireOrdersData.address.city,
                delivery_state = faireOrdersData.address.state,
                delivery_postcode = faireOrdersData.address.postal_code,
                delivery_country_code = faireOrdersData.address.country_code,
                extra_field_1 = faireOrdersData.id,
                products = MapFaireItemsToBaselinkerOrderProducts(faireOrdersData),
            };
            return newBaselinkerOrder;
        }
    }
}
