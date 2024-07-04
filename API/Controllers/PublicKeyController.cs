using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class PublicKeyController : ControllerBase
{

    private readonly ILogger<PublicKeyController> _logger;

    public PublicKeyController(ILogger<PublicKeyController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "PublicKey")]
    public async Task<string> Get()
    {
        try
        {
            FileInfo file = new FileInfo(@"./Keys/public.asc");
            return await file.OpenText().ReadToEndAsync();
        } catch (Exception e)
        {
            return e.Message;
        }
    }
}
