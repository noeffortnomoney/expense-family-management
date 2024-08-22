using EFM.Model.Model;
using EFM.Repository.Infrastructure;
using EFM.Repository.Repositories;
using System.Collections.Generic;

namespace EFM.Service
{
    public interface ICategoryService
    {
        Category Add(Category postCategory);

        void Update(Category postCategory);

        Category Delete(int id);

        IEnumerable<Category> GetAll();
        Category GetById(int id);

        void Save();
    }

    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _postCategoryRepository;
        private IUnitOfWork _unitOfWork;

        public CategoryService(ICategoryRepository postCategoryRepository, IUnitOfWork unitOfWork)
        {
            this._postCategoryRepository = postCategoryRepository;
            this._unitOfWork = unitOfWork;
        }

        public Category Add(Category postCategory)
        {
            return _postCategoryRepository.Add(postCategory);
        }

        public Category Delete(int id)
        {
            return _postCategoryRepository.Delete(id);
        }

        public IEnumerable<Category> GetAll()
        {
            return _postCategoryRepository.GetAll();
        }

        public Category GetById(int id)
        {
            return _postCategoryRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Category postCategory)
        {
            _postCategoryRepository.Update(postCategory);
        }
    }
}