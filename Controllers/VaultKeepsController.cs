using Keepr.Services;
using Keepr.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System;

namespace Keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsService _vks;

    public VaultKeepsController(VaultKeepsService vks)
    {
      _vks = vks;
    }

    [HttpPost]
    public ActionResult<VaultKeep> Create([FromBody] VaultKeep newVaultKeep)
    {
      try
      {
        Claim userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
          if(userId == null){
            throw new Exception("Please log in.");
          }
        newVaultKeep.UserId = userId.Value;
        return Ok(_vks.Create(newVaultKeep));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }

    }

    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
          return Ok(_vks.Delete(id));
      }
      catch (System.Exception err)
      {
          
          return BadRequest(err.Message);
      }
    }
  }
}