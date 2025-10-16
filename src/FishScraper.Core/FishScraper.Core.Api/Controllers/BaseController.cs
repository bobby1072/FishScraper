using Microsoft.AspNetCore.Mvc;

namespace FishScraper.Core.Api.Controllers;

[ApiController]
[Route("Api/[controller]")]
public abstract class BaseController: ControllerBase { }