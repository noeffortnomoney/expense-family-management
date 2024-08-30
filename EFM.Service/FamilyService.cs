using System;
using System.Collections.Generic;
using System.Linq;
using EFM.Common.Helpers;
using EFM.Model.Model;
using EFM.Repository.Infrastructure;
using EFM.Repository.Repositories;

namespace EFM.Service
{
    public interface IFamilyService
    {
        void Add(Family family);

        void Update(Family family);

        void Delete(int id);

        IEnumerable<Family> GetAll();

        Family GetById(int id);

        void SaveChanges();

        Family AddFamily(Family family);

        Family DeleteAccount(int id);
    }

    public class FamilyService : IFamilyService
    {
        IFamilyRepository _familyRepository;
        IUnitOfWork _unitOfWork;

        public FamilyService(IFamilyRepository familyRepository, IUnitOfWork unitOfWork)
        {
            this._familyRepository = familyRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(Family family)
        {
            _familyRepository.Add(family);
        }

        public void Delete(int id)
        {
            _familyRepository.Delete(id);
        }

        public IEnumerable<Family> GetAll()
        {
            return _familyRepository.GetAll();
        }

        public Family GetById(int id)
        {
            return _familyRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Family family)
        {
            _familyRepository.Update(family);
        }

        public Family AddFamily(Family family)
        {
            family.CreatedDate = DateTime.Now;
            family.CreatedBy = 1; //tạm thời cho = 1 vì chưa phân quyền

            _familyRepository.Add(family);
            SaveChanges();
            return family;
        }
        public Family DeleteAccount(int id)
        {
            var family = _familyRepository.GetById(id);

            if (family != null)
            {
                family.DeletedDate = DateTime.Now;
                family.DeletedBy = 1;

                _familyRepository.SoftDelete(id);

                SaveChanges();
            }
            return family;
        }       
    }
}