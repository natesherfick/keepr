using System;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class VaultsRepository
  {
    private readonly IDbConnection _db;

    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }
    internal Vault Create(Vault newVault)
    {
      string sql = @"
      INSERT INTO Vaults
      (userId, name, description)
      VALUES
      (@UserId, @Name, @Description);
      SELECT LAST_INSERT_ID()";
      newVault.Id = _db.ExecuteScalar<int>(sql, newVault);
      return newVault;
    }
  }
}