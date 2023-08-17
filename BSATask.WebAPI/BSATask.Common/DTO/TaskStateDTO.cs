using Newtonsoft.Json;

namespace BSATask.Common.DTO;

public enum TaskStateDTO
{
    [JsonProperty("ToDo")]
    ToDo =0,
    [JsonProperty("InProgress")]
    InProgress = 1,
    [JsonProperty("Done")]
    Done = 2,
    [JsonProperty("Canceled")]
    Canceled = 3
}