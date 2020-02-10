using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _repo;
    public VaultsService(VaultsRepository repo)
    {
      _repo = repo;
    }
    // public IEnumerable<Vault> Get()
    // {
    //   return _repo.Get();
    // }

    public Vault Create(Vault newVault)
    {
      _repo.Create(newVault);
      return newVault;
    }

    internal Vault GetById(int id)
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

    public IEnumerable<Vault> GetbyUserId(string userId)
    {
      return _repo.GetByUserId(userId);
    }
  }
}

// public IEnumerable<Vault> Get()
// {
//   return _repo.Get();
// }