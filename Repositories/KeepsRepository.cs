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

    // internal IEnumberable<Keep> Find()
    //   {
    //     string sql = "SELECT * FROM Keeps WHERE isPrivate = 1)";
    //     return _db.QueryFirstOrDefault<Keep>(sql);
    //   }



    internal IEnumerable<Keep> Get()
    {
      string sql = "SELECT * FROM Keeps WHERE isPrivate = 0;";

      return _db.Query<Keep>(sql);
    }

    internal Keep Create(Keep KeepData)
    {
      string sql = @"INSERT INTO keeps (id, userId, name, description, img, isPrivate, views, shares, keeps) VALUES (@Id, @UserId, @Name, @Description, @Img, @IsPrivate, @Views, @Shares, @Keeps);
     SELECT LAST_INSERT_ID();";

      int id = _db.ExecuteScalar<int>(sql, KeepData);
      KeepData.Id = id;
      return KeepData;

    }


    internal Keep GetById(int id)
    {
      string sql = "SELECT * FROM Keeps WHERE id=@Id";
      return _db.QueryFirstOrDefault<Keep>(sql, new { id });
    }
    //////////////////////


    internal IEnumerable<Keep> GetAllPrivateKeeps(string userId)
    {
      string sql = "SELECT * FROM Keeps WHERE userId =@UserId;";
      return _db.Query<Keep>(sql, new { userId });
    }




    /////////////////////////
    internal void Delete(int id, string userId)
    {
      string sql = "DELETE FROM Keeps WHERE( id = @Id AND userId =@UserId)";
      _db.Execute(sql, new { id, userId });
    }

    ///// was where id = @Id


    internal void Edit(Keep update)
    {
      string sql = @"UPDATE Keeps SET
      userId = @UserId,
      name = @Name,
      description = @description
      WHERE id = @Id;";

      _db.Execute(sql, update);
    }
    ////// new test stuff /////
    internal IEnumerable<VaultKeep> GetKeepByVkId(int id)
    {
      string sql = @"SELECT k.*
      FROM vaultkeeps vk
      JOIN keeps k ON k.id = vk.keepId
      WHERE keepId = @KeepId;";

      return _db.Query<VaultKeep>(sql, new { id });
    }
  }
}
