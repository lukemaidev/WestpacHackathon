namespace API.Models.Requests
{
    public class VerifySignatureRequest
    {
        public string? Communication { get; set; }
        public string? Signature { get; set; }


        public VerifySignatureRequest(string communication, string signature)
        {
            Communication = communication;
            Signature = signature;
        }
    }
}
