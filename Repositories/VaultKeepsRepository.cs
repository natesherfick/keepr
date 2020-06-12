using System;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;

    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal VaultKeep Create(VaultKeep newVaultKeep)
    {
      string sql = @"
      INSERT INTO VaultKeeps
      (keepId, VaultId, UserId)
      VALUES
      (@KeepId, @VaultId, @UserId);
      SELECT LAST_INSERT_ID()";
      newVaultKeep.Id = _db.ExecuteScalar<int>(sql, newVaultKeep);
      return newVaultKeep;
    }

    internal bool Delete(int id, string userId)
    {
      string sql = "DELETE FROM vaultkeeps WHERE id = @Id AND userId = @userId LIMIT 1";
      int affectedRows = _db.Execute(sql, new { id, userId });
      return affectedRows == 1;
    }
    
  }
}