using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using BeerTap.Repository.Context;
using BeerTap.Repository.Model;
using BeerTap.Service.Interface;

namespace BeerTap.Service.Services
{
    public class OfficeService : IService<Office>
    {
        private readonly BeerTapContext _db;

        public OfficeService()
        {
            _db = new BeerTapContext();
        }

        public void Insert(Office domainModel)
        {
            _db.Offices.Add(domainModel);
            _db.SaveChanges();
        }

        public void Update(Office domainModel)
        {
            _db.Offices.AddOrUpdate(o => o.Id, domainModel);

        }

        public void Delete(int id)
        {
            var entity = _db.Offices.Find(id);
            _db.Offices.Remove(entity);
        }

        public Office Get(int id)
        {
            return _db.Offices.Find(id);
        }

        public IEnumerable<Office> GetAll()
        {
            return _db.Offices.ToList();
        }
    }
}
