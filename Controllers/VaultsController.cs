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
    public class VaultsController : ControllerBase
    {
    private readonly VaultsService _vs;
    private readonly KeepsService _ks;

    public VaultsController(VaultsService vs, KeepsService ks)
      {
        _vs = vs;
        _ks = ks;
      }
    
      [HttpGet]
      public ActionResult<IEnumerable<Vault>> Get()
        {
            try
            {
                return Ok(_vs.Get());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            };
        }

      [HttpPost]
      [Authorize]
      public ActionResult<VaultsController> Create([FromBody] Vault newVault)
      {
        try
        {
          Claim userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
          if(userId == null){
            throw new Exception("Please log in.");
          }
          newVault.UserId = userId.Value;
          return Ok(_vs.Create(newVault));
        }
          catch (System.Exception err)
        {
            
          return BadRequest(err.Message);
        }
        
      }

      [HttpGet("{vaultId}/keeps")]
        public ActionResult<IEnumerable<VaultKeepViewModel>> GetKeepsByVaultId(int vaultId)
        {
          try
          {
            return Ok(_ks.GetKeepsByVaultId(vaultId));
          }
          catch (System.Exception err)
          {
              
              return BadRequest(err.Message);
          }
        }
    }
}