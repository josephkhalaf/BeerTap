using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using BeerTap.Repository.Context;
using BeerTap.Repository.Model;
using BeerTap.Service.Interface;

namespace BeerTap.Service.Services
{
    public class KegService : IService<Keg>
    {
        private readonly BeerTapContext _db;

        public KegService()
        {
            _db = new BeerTapContext();
        }

        public void Insert(Keg domainModel)
        {
            _db.Kegs.Add(domainModel);
            _db.SaveChanges();
        }

        public void Update(Keg domainModel)
        {
            _db.Kegs.AddOrUpdate(o => o.KegId, domainModel);

        }

        public void Delete(Guid id)
        {
            var entity = _db.Kegs.Find(id);
            _db.Kegs.Remove(entity);
        }

        public Keg Get(Guid id)
        {
            return _db.Kegs.Find(id);
        }

        public IEnumerable<Keg> GetAll()
        {
            return _db.Kegs.ToList();
        }
    }
}
