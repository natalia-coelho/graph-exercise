using Microsoft.AspNetCore.Mvc;
using GraphsBenner.Service;

namespace GraphsBenner.Controllers;

[ApiController]
[Route("[controller]")]
public class NetworkController : ControllerBase
{
    private readonly ILogger<NetworkController> _logger;
    private readonly Network _network;

    public NetworkController(ILogger<NetworkController> logger, Network network)
    {
        _logger = logger;
        _network = network;
    }

    [HttpPost]
    public void Connect(int elementA, int elementB)
    {
        _network.Connect(elementA, elementB);
    }

    [HttpGet]
    public bool Query(int elementA, int elementB)
    {
        return _network.Query(elementA, elementB);
    }
}