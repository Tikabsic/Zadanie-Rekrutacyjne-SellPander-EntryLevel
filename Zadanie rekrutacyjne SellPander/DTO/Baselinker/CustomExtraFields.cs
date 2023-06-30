using Newtonsoft.Json;

namespace Zadanie_rekrutacyjne_SellPander.DTO.Baselinker
{
    internal class CustomExtraFields
    {
        [JsonProperty("135")]
        public string _135 { get; set; }

        [JsonProperty("172")]
        public string _172 { get; set; }
    }
}
