using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using BeerTap.Model;
using BeerTap.Repository.Context;
using BeerTap.Service.Interface;
using Keg = BeerTap.Repository.Model.Keg;

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
            _db.Kegs.AddOrUpdate(o => o.Id, domainModel);

        }

        public void Delete(int id)
        {
            var entity = _db.Kegs.Find(id);
            _db.Kegs.Remove(entity);
        }

        public Keg Get(int id)
        {
            return _db.Kegs.Find(id);
        }

        public IEnumerable<Keg> GetAll()
        {
            return _db.Kegs.ToList();
        }

        public void GetBeer(int officeId, int kegId, int sizeInMl)
        {
            var keg = _db.Kegs.FirstOrDefault(o => o.OfficeId == officeId && o.Id == kegId);
            keg.Size = keg.Size - sizeInMl;
            keg.KegState = GetKegStatus(keg.Size).GetValueOrDefault();
            this.Update(keg);
            _db.SaveChanges();
        }

        private KegState? GetKegStatus(int size)
        {
            if (size == 20000)
                return KegState.New;

            if (size >= 5000 && size <= 19999)
                return KegState.GoinDown;

            if(size >= 1 && size <= 4999)
                return KegState.AlmostEmpty;

            if(size == 0)
                return KegState.SheIsDryMate;

            return null;
        }

        public void ReplaceKeg(int officeId, int kegId)
        {
            var keg = _db.Kegs.FirstOrDefault(o => o.OfficeId == officeId && o.Id == kegId);
            keg.Size = 20000;
            keg.KegState = KegState.New;
            this.Update(keg);
            _db.SaveChanges();
        }
    }
}
