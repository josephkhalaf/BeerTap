using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using BeerTap.Model;
using BeerTap.Repository.Context;
using BeerTap.Service.Constant;
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

        public int Insert(Keg domainModel)
        {
            _db.Kegs.Add(domainModel);
            _db.SaveChanges();

            return domainModel.Id;
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

            if (keg.Size < 0)
                keg.Size = 0;

            keg.KegState = GetKegStatus(keg.Size);
            this.Update(keg);
            _db.SaveChanges();
        }

        private KegState GetKegStatus(int size)
        {
            if (size == KegConstant.NewKegSize)
                return KegState.New;

            if (size >= KegConstant.GoinDownBottom && size <= KegConstant.GoinDownTop)
                return KegState.GoinDown;

            if(size >= KegConstant.AlmostEmptyBottom && size <= KegConstant.AlmostEmptyTop)
                return KegState.AlmostEmpty;

            return KegState.SheIsDryMate;
        }

        public void ReplaceKeg(int officeId, int kegId)
        {
            var keg = _db.Kegs.FirstOrDefault(o => o.OfficeId == officeId && o.Id == kegId);
            keg.Size = KegConstant.NewKegSize;
            keg.KegState = KegState.New;
            this.Update(keg);
            _db.SaveChanges();
        }

        public Keg GetKegByOfficeIdKegId(int officeId, int kegId)
        {
            return _db.Kegs.FirstOrDefault(o => o.OfficeId == officeId && o.Id == kegId);
        }

        public IEnumerable<Keg> GetKegsById(int officeId)
        {
            return GetAll().Where(o => o.OfficeId == officeId).ToList();

        }

        public int AddKeg(int officeId)
        {
            var newKeg = new Keg()
            {
                OfficeId = officeId,
                KegState = KegState.New,
                Size = KegConstant.NewKegSize
            };

            return Insert(newKeg);
        }
    }
}
