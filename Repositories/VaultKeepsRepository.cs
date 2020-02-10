using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;

    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }


    internal VaultKeep Find(VaultKeep vk)
    {
      string sql = "SELECT * FROM vaultkeeps WHERE (vaultId = @VaultId AND keepId = @KeepId)";
      return _db.QueryFirstOrDefault(sql, vk);
    }

    internal VaultKeep Create(VaultKeep VaultKeepData)
    {
      string sql = @"INSERT INTO vaultkeeps (keepId, userId, vaultId) VALUES (@KeepId, @UserId, @VaultId);
     SELECT LAST_INSERT_ID();";

      int id = _db.ExecuteScalar<int>(sql, VaultKeepData);
      VaultKeepData.Id = id;
      return VaultKeepData;

    }


    internal VaultKeep GetById(int id)
    {
      string sql = "SELECT * FROM vaultkeeps WHERE id = @Id";
      return _db.QueryFirstOrDefault<VaultKeep>(sql, new { id });
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM vaultkeeps WHERE id = @Id";
      _db.Execute(sql, new { id });
    }

    ////// test //////
    internal IEnumerable<VaultKeep> Get()
    {
      string sql = "SELECT * FROM VaultKeeps";
      return _db.Query<VaultKeep>(sql);
    }


    //////////////////// super awsome best friend test... vaultkeeps by vault it///////

    internal IEnumerable<VaultKeep> GetVKSbyVaultId(int id)
    {
      string sql = @"SELECT v.* FROM vaultkeeps vk JOIN vaults v on v.id = vk.vaultID WHERE vaultId= @VaultId;";
      return _db.Query<VaultKeep>(sql, new { id });
    }
  }
}

