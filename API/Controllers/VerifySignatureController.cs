using Microsoft.AspNetCore.Mvc;
using API.Models.Requests;
using API.Models.Responses;
using PgpCore;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class VerifySignatureController : ControllerBase
{

    private readonly ILogger<VerifySignatureController> _logger;

    public VerifySignatureController(ILogger<VerifySignatureController> logger)
    {
        _logger = logger;
    }

    [HttpPost(Name = "VerifySignature")]
    public async Task<VerifySignatureResponse> Post(VerifySignatureRequest request)
    {
        if (request.Signature == null)
            return new VerifySignatureResponse("You must provide a signature to verify", false);

        try
        {
            return new VerifySignatureResponse(request.Communication, PGPVerify.CommunicationVerify(request.Signature));
        }
        catch (Exception e)
        {
            return new VerifySignatureResponse(e.Message, false);
        }

    }
}

