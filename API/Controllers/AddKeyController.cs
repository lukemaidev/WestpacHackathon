using Microsoft.AspNetCore.Mvc;
using API.Models.Requests;
using API.Models.Responses;
using PgpCore;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class AddKeyToCommunicationController : ControllerBase
{

    private readonly ILogger<AddKeyToCommunicationController> _logger;

    public AddKeyToCommunicationController(ILogger<AddKeyToCommunicationController> logger)
    {
        _logger = logger;
    }

    [HttpPost(Name = "AddKey")]
    public async Task<AddKeyToCommunicationResponse> Post(AddKeyToCommunicationRequest request)
    {
        if (request.AccountNumber == null)
            return new AddKeyToCommunicationResponse(false, "You must provide a valid account number.", null);
        if (request.Communication == null)
            return new AddKeyToCommunicationResponse(false, "You must provide a communication.", null);

        try
        {
            string signedAccountNumber = await SignAccountNumber(request.AccountNumber!);
            request.Communication += "\n\n" + signedAccountNumber;
            return new AddKeyToCommunicationResponse(true, null, request.Communication);
        } catch (Exception e)
        {
            return new AddKeyToCommunicationResponse(false, e.Message, null);
        }
        
    }

    private async Task<string> SignAccountNumber(string accountNumber)
    {
        FileInfo privateKey = new FileInfo(@"./Keys/private.asc");
        EncryptionKeys encryptionKeys = new EncryptionKeys(privateKey, "password");
        PGP pgp = new PGP(encryptionKeys);

        return await pgp.SignAsync(accountNumber);
    }
}

