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
    internal void Create(VaultKeep newVaultKeep)
    {
      VaultKeep existenceTest = _repo.Find(newVaultKeep);
      if (existenceTest != null) { throw new Exception("relationship object already exists"); }
      _repo.Create(newVaultKeep);
      // return newVaultKeep;
    }



    internal VaultKeep GetById(int id)
    {
      var existenceTest = _repo.GetById(id);
      if (existenceTest == null) { throw new Exception("Bad Id"); }
      return existenceTest;
    }

    internal object Delete(int id)
    {
      var existenceTest = _repo.GetById(id);
      if (existenceTest == null) { throw new Exception("Bad request or Id"); }
      _repo.Delete(id);
      return "Yay you deleted it";
    }
    ///////////// test///////////

    public IEnumerable<VaultKeep> Get()
    {
      return _repo.Get();
    }


  }
}