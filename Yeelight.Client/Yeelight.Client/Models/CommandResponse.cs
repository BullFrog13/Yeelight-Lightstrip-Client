namespace Yeelight.Client.Models
{
    public class CommandResponse
    {
        public int Id { get; set; }

        public bool IsSuccessful { get; set; }

        public ErrorResponse ErrorResponse { get; set; }
    }
}