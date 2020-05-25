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

    public VaultsController(VaultsService vs)
      {
        _vs = vs;
      }
    
      [HttpPost]
      // [Authorize]
      public ActionResult<VaultsController> Create([FromBody] Vault newVault)
      {
        try
        {
          // var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
          // newKeep.UserId = userId;
          return Ok(_vs.Create(newVault));
        }
          catch (System.Exception err)
        {
            
          return BadRequest(err.Message);
        }
        
      }
    }
}