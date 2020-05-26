using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
    public class KeepsService
    {
        private readonly KeepsRepository _repo;
        public KeepsService(KeepsRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Keep> Get()
        {
            return _repo.Get();
        }

        public Keep GetById(int id)
        {
            Keep foundKeep = _repo.GetById(id);
            if (foundKeep == null)
            {
                throw new Exception("No Keep found under that id.");
            }
            return foundKeep;
        }

        public Keep Create(Keep newKeep)
        {
            return _repo.Create(newKeep);
        }

        public Keep Delete(int id)
        {
            Keep foundKeep = GetById(id);
            if(_repo.Delete(id))
            {
            return foundKeep;
            }
            throw new Exception("Could not delete a Keep under requested id.");
        }

    internal IEnumerable<VaultKeepViewModel> GetKeepsByVaultId(int vaultId)
    {
      return _repo.GetKeepsByVaultId(vaultId);
    }
  }
}