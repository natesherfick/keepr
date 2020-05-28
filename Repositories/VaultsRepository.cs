using System;
using System.Collections.Generic;
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

    internal IEnumerable<Vault> Get(string userId)
        {
            string sql = "SELECT * FROM Vaults where userId = @userId";
            return _db.Query<Vault>(sql, new {userId});
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

    internal bool Delete(int id, string userId)
    {
      string sql = "DELETE FROM Vaults WHERE id = @Id AND userId = @UserId LIMIT 1";
      int affectedRows = _db.Execute(sql, new { id, userId });
      return affectedRows == 1;
    }
  }
}