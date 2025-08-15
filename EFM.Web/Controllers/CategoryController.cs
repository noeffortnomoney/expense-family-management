using EFM.Model.Model;
using EFM.Service;
using EFM.Web.Models;
using AutoMapper;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EFM.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        // GET: Category
        public ActionResult Index()
        {
            var categories = _categoryService.GetAll();
            var categoryViewModels = _mapper.Map<IEnumerable<CategoryViewModel>>(categories);
            int orderNumber = 1;
            foreach (var categoryViewModel in categoryViewModels)
            {
                categoryViewModel.OrderNumber = orderNumber++;
            }
            return View(categoryViewModels);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            var category = _categoryService.GetById(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            var categoryViewModel = _mapper.Map<CategoryViewModel>(category);
            return View(categoryViewModel);
        }

        // GET: Category/Create
        public ActionResult CreateCategory()
        {
            var model = new CategoryViewModel();
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCategory(CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                var category = _mapper.Map<Category>(categoryViewModel);
                _categoryService.Add(category);
                _categoryService.Save();
                return RedirectToAction("Index");
            }

            return View(categoryViewModel);
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            var category = _categoryService.GetById(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            var categoryViewModel = _mapper.Map<CategoryViewModel>(category);
            return View(categoryViewModel);
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                var category = _mapper.Map<Category>(categoryViewModel);
                _categoryService.Update(category);
                _categoryService.Save();
                return RedirectToAction("Index");
            }

            return View(categoryViewModel);
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            var category = _categoryService.GetById(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            var categoryViewModel = _mapper.Map<CategoryViewModel>(category);
            return View(categoryViewModel);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _categoryService.Delete(id);
            _categoryService.Save();
            return RedirectToAction("Index");
        }
    }
}
