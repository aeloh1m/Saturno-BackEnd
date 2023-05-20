using Microsoft.AspNetCore.Mvc;
using SATURNO_V2.Services;
using SATURNO_V2.Data.SaturnoModels;

namespace SATURNO_V2.Controllers;

[ApiController]
[Route("administrador")]

public class AdministradorController : ControllerBase
{
    private readonly ProfesionalService _service;
    public AdministradorController(ProfesionalService service)
    {
        _service = service;
    }

}
