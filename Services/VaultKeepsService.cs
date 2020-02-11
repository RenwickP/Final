using System;
using System.Collections.Generic;
using System.Data;
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


    // public VaultKeep Create(VaultKeep newVaultKeep)
    public VaultKeep Create(VaultKeep newVaultKeep)
    {


      /////removing this part for testing...
      // VaultKeep existenceTest = _repo.Find(newVaultKeep);
      // if (existenceTest != null) { throw new Exception("already ready created, vaultkeep service creator"); }




      //  {return existenceTest;}
      // { throw new Exception("already ready created, vaultkeep service creator"); }
      // { return; }
      _repo.Create(newVaultKeep);
      return newVaultKeep;
    }

    // internal void Create(VaultKeep newVaultKeep)
    // {
    //   VaultKeep existence = _repo.Find(newVaultKeep);
    //   if (existence != null) { return; }
    //   _repo.Create(newVaultKeep);
    // }



    internal VaultKeep GetById(int id)
    {
      var existenceTest = _repo.GetById(id);
      if (existenceTest == null) { throw new Exception("Bad Id"); }
      return existenceTest;
    }

    internal object Delete(int vaultId, int keepId)
    {
      // var existenceTest = _repo.GetById(vaultId);
      // if (existenceTest == null) { throw new Exception("Bad request or Id"); }
      _repo.Delete(vaultId, keepId);
      return "Yay you deleted it";
    }
    ///////////// test///////////

    // public IEnumerable<VaultKeep> Get(userId)
    // {
    //   return _repo.Get(userId);
    // }
    /////////////////////////////////////////////////////////// supers awsome test time(vault keeps by vault it)/////////
    // internal IEnumerable<VaultKeep> GetByVaultID(int id)
    // {
    //   return _repo.GetVKSbyVaultId(id);
    // }

    public IEnumerable<Keep> GetByVkId(int vaultId, string userId)
    {
      var test = _repo.GetVKSbyVaultId(vaultId, userId);
      if (test == null) { throw new Exception("bad id"); }
      return test;
    }
  }
}
