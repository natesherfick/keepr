using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
    public class KeepsRepository
    {
        private readonly IDbConnection _db;

        public KeepsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Keep> Get()
        {
            string sql = "SELECT * FROM Keeps WHERE isPrivate = 0;";
            return _db.Query<Keep>(sql);
        }

        internal Keep GetById(int id)
        {
            string sql = "SELECT * FROM Keeps WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Keep>(sql, new {id});
        }

        internal Keep Create(Keep KeepData)
        {
            string sql = @"
            INSERT INTO keeps
            (userId, name, description, img, isPrivate, views, shares, keeps)
            VALUES
            (@UserId, @Name, @Description, @Img, @IsPrivate, @Views, @Shares, @Keeps);
            SELECT LAST_INSERT_ID()";
            KeepData.Id = _db.ExecuteScalar<int>(sql, KeepData);
            return KeepData;
        }

        internal bool Delete(int id)
        {
            string sql = "DELETE FROM Keeps WHERE id = @Id LIMIT 1";
            int affectedRows = _db.Execute(sql, new {id});
            return affectedRows == 1;
        }
    } 
}