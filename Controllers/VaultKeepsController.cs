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

namespace Vaults.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsService _vks;
    private readonly KeepsService _ks;

    private readonly VaultsService _vs;
    public VaultKeepsController(VaultKeepsService vks, KeepsService ks, VaultsService vs)
    {
      _vks = vks;
      _ks = ks;
      _vs = vs;
    }


    [HttpGet("{id}")]
    public ActionResult<VaultKeep> Get(int id)
    {
      try
      {
        return Ok(_vks.GetById(id));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      };
    }

    [HttpPost]
    [Authorize]
    public ActionResult<string> Create([FromBody] VaultKeep newVaultKeep)
    {
      try
      {
        var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        newVaultKeep.UserId = userId;
        // System.Console.WriteLine("test info", newVaultKeep);
        // return Ok("relationship created");
        _vks.Create(newVaultKeep);
        return Ok("Success");
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpDelete("{id}")]

    public ActionResult<string> Delete(int id)
    {
      try
      {
        return Ok(_vks.Delete(id));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      };
    }
    /////// test stuff/////

    // public ActionResult<IEnumerable<VaultKeep>> Get()
    // {
    //   try
    //   {
    //     return Ok(_vks.Get());
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   };
    // }

    ///// new addition ////

    [HttpGet("{id}/vaults")]

    public ActionResult<string> GetVaults(int id)
    {
      try
      {
        return Ok(_vks.GetByVkId(id));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }



  }
}