namespace API.Models.Responses
{
    public class VerifySignatureResponse
    {

        public string? Communication { get; set; }

        public bool Validation { get; set; }

        public VerifySignatureResponse(string? communication, bool validation)
        {
            Communication = communication;
            Validation = validation;
        }
    }
}
