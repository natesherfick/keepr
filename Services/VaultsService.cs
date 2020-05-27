using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Repositories;
using Keepr.Models;

namespace Keepr.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _repo;

    public VaultsService(VaultsRepository repo)
    {
      _repo = repo;
    }

    public IEnumerable<Vault> Get(string userId)
        {
            return _repo.Get(userId);
        }

    internal Vault Create(Vault newVault)
    {
      return _repo.Create(newVault);
    }
  }
}