using Newtonsoft.Json;

namespace PlantLookUp.data
{
    class LogData
    {
        [JsonProperty("address")] public string Address { get; set; }
       // [JsonProperty("topics")] public string Topics { get; set; }
        [JsonProperty("data")] public string Data { get; set; }
        [JsonProperty("blockNumber")] public string BlockNumber { get; set; }
        [JsonProperty("timeStamp")] public string TimeStamp { get; set; }
        [JsonProperty("gasPrice")] public string GasPrice { get; set; }
        [JsonProperty("gasUsed")] public string GasUsed { get; set; }
        [JsonProperty("logIndex")] public string logIndex { get; set; }
        [JsonProperty("transactionHash")] public string TransactionHash { get; set; }
        [JsonProperty("transactionIndex")] public string TransactionIndex { get; set; }
        
    }
}
