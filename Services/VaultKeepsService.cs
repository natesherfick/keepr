using System;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _repo;

    public VaultKeepsService(VaultKeepsRepository repo)
   {
    _repo = repo;
   }

    internal VaultKeep Create(VaultKeep newVaultKeep)
    {
      return _repo.Create(newVaultKeep);
    }

    internal string Delete(int id, string user)
    {
      if(_repo.Delete(id, user))
      {
        return "Removed from Vault!";
      }
      throw new Exception("Unable to perform this Delete action.");
    }
  }
}