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

    public string Delete(int id, string userId)
    {
      _repo.Delete(id, userId);
      return "Successfully deleted Vault!";
    }

    internal Vault Edit(Vault vaultToUpdate, string userId)
    {
      return _repo.Edit(vaultToUpdate);
    }

  }
}
