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

    public Keep Create(Keep newKeep)
    {
      _repo.Create(newKeep);
      return newKeep;
    }

    internal Keep GetById(int id)
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


    internal Keep Edit(Keep update)
    {
      var existenceTest = _repo.GetById(update.Id);
      if (existenceTest == null) { throw new Exception("cant edit bad request or id"); }
      _repo.Edit(update);
      return update;
    }

    //// new addition /////
    internal IEnumerable<VaultKeep> GetByVkId(int id)
    {
      return _repo.GetKeepByVkId(id);
    }
  }
}



// internal Keep Edit(Keep update)
// {
//   var existenceTest = _repo.GetById(update.Id);
//   if (existenceTest == null) { throw new Exception("cant edit bad request or id"); }
//   _repo.Edit(update);
//   return update;
// }