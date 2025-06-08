namespace Nexus_Photography_API.Models.Response
{
    public class APIResponse
    {
        public int Code { get; set; }
        public string? Status { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }

    }
}
