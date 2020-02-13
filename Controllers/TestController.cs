using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class TestsController : ControllerBase
  {
    private readonly KeepsService _ks;
    public TestsController(KeepsService ks)
    {
      _ks = ks;
    }


    ///////

    [HttpGet]

    public ActionResult<IEnumerable<Keep>> Get()
    {
      try
      {
        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_ks.GetAllPrivateKeeps(userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      };
    }
  }
}