using System;
using System.Collections.Generic;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using Zadanie_rekrutacyjne_SellPander.DTO.Baselinker;
using Zadanie_rekrutacyjne_SellPander.DTO.Faire;
using Zadanie_rekrutacyjne_SellPander.Helpers;

namespace Zadanie_rekrutacyjne_SellPander
{
    public class TransferOrdersFromFaireFunction
    {

        private readonly IConfiguration _configuration;

        public TransferOrdersFromFaireFunction(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [FunctionName("TransferOrdersFromFaireToBaselinker")]
        public void Run([TimerTrigger("0 */10* * * *")] TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            string faireAccessToken = _configuration["X-FAIRE-ACCESS-TOKEN"];
            string baselinkerAccessToken = _configuration["X-BLToken"];

            var faireOrders = GetFaireOrdersFromAPI(faireAccessToken);
            var existingBaselinkserOrders = GetExistingFaireOrdersInBaselinker(baselinkerAccessToken);

            foreach (var faireOrder in faireOrders.orders)
            {
                if (!existingBaselinkserOrders.Contains(faireOrder.id))
                {
                    var newBaselinkerOrder = MapFaireOrderToBaselinkerOrderRequest.MapFaireOrderToBaselinkerOrder(faireOrder);
                    AddOrdersToBaselinker(newBaselinkerOrder, baselinkerAccessToken);
                }
            }
        }

        private FaireGetOrdersRequest GetFaireOrdersFromAPI(string faireAccessToken)
        {
            var restClient = new RestClient("https://www.faire.com/api/v1");
            var request = new RestRequest("/orders", Method.Get);
            request.AddHeader("X-FAIRE-ACCESS-TOKEN", $"{faireAccessToken}");

            RestResponse response = restClient.Execute(request);

            var faireOrders = JsonConvert.DeserializeObject<FaireGetOrdersRequest>(response.Content);

            return faireOrders;
        }

        private void AddOrdersToBaselinker(BaselinkerAddOrderRequest baselinkerOrderRequest, string baselinkerToken)
        {
            var restClient = new RestClient("https://api.baselinker.com/connector.php");
            var request = new RestRequest("POST");
            request.AddHeader("X-BLToken", $"{baselinkerToken}");

            var requestBody = new
            {
                method = "addOrder",
                parameters = baselinkerOrderRequest
            };

            request.AddJsonBody(requestBody);

            restClient.Execute(request);
        }
        private List<string> GetExistingFaireOrdersInBaselinker(string baselinkerToken)
        {
            var apiMethod = "getOrderSources";
            var methodParams = new
            {
                filter_order_source_id = "1024"
            };
            var restClient = new RestClient("https://api.baselinker.com/connector.php");
            var request = new RestRequest("POST");
            request.AddHeader("X-BLToken", $"{baselinkerToken}");

            var requestBody = new
            {
                method = apiMethod,
                parameters = methodParams
            };

            request.AddJsonBody(requestBody);
            RestResponse response = restClient.Execute(request);

            var baselinkerResponse = JsonConvert.DeserializeObject<dynamic>(response.Content);

            var faireOrdersId = new List<string>();
            foreach (var order in baselinkerResponse.orders)
            {
                faireOrdersId.Add(order.extra_field_1.ToString());
            }

            return faireOrdersId;
        }
    }
}
