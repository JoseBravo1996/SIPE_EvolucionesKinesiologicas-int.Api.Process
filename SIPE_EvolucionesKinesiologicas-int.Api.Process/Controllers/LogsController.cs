using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SIPE_Evolucion.Api.Process.Controllers;
public class LogsController : ApiControllerBase
{
    private readonly ILogger<LogsController> _logger;
    private readonly bool _endpointsEnabled;

    public LogsController(IConfiguration configuration, ILogger<LogsController> logger)
    {
        _endpointsEnabled = Convert.ToBoolean(configuration.GetSection("Serilog:EnableEndpoints").Value);
        _logger = logger;
    }

    [HttpGet(Name = "GetLogs")]
    [AllowAnonymous]
    public ActionResult<List<string>> GetLogs()
    {
        if (!_endpointsEnabled)
            return StatusCode((int)System.Net.HttpStatusCode.Unauthorized);

        var result = LeerArchivo($"{DateTime.UtcNow:yyyyMMdd}");
        if (result.Any())
            return Ok(result);
        else
            return NotFound();
    }

    [HttpPost(Name = "TestPostException")]
    [AllowAnonymous]
    public ActionResult TestPostException()
    {
        if (!_endpointsEnabled)
            return StatusCode((int)System.Net.HttpStatusCode.Unauthorized);
        _logger.LogCritical($"TestPostException");
        throw new NotImplementedException();
    }

    [HttpGet("{fecha}", Name = "GetLog")]
    [AllowAnonymous]
    public ActionResult<List<string>> GetLog(string fecha)
    {
        if (!_endpointsEnabled)
            return StatusCode((int)System.Net.HttpStatusCode.Unauthorized);

        var result = LeerArchivo(fecha);
        if (result.Any())
            return Ok(result);
        else
            return NotFound();
    }

    private static List<string> LeerArchivo(string fecha)
    {
        if (!System.IO.File.Exists($"logs/sipe-evolucion-piscys-api-process-{fecha}.log"))
        {
            return new List<string>();
        }
        var lines = System.IO.File.ReadAllLines($"logs/sipe-evolucion-piscys-api-process-{fecha}.log");
        return lines.ToList();
    }
}