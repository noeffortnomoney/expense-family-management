using EFM.Model.Model;
using EFM.Service;
using EFM.Web.Models;
using AutoMapper;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EFM.Web.Controllers
{
    public class FamilyController : Controller
    {
        private readonly IFamilyService _familyService;
        private readonly IMapper _mapper;

        public FamilyController(IFamilyService familyService, IMapper mapper)
        {
            _familyService = familyService;
            _mapper = mapper;
        }

        // GET: family
        public ActionResult Index()
        {
            var families = _familyService.GetAll();
            var familyViewModels = _mapper.Map<IEnumerable<FamilyViewModel>>(families);
            return View(familyViewModels);
        }

        // GET: familyDetails/5
        public ActionResult Details(int id)
        {
            var family = _familyService.GetById(id);
            if (family == null)
            {
                return HttpNotFound();
            }
            var familyViewModel = _mapper.Map<FamilyViewModel>(family);
            return View(familyViewModel);
        }

        // GET: Family/Create
        public ActionResult CreateMember()
        {
            return View();
        }

        // POST: Family/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateMember(FamilyViewModel familyViewModel)
        {
            if (ModelState.IsValid)
            {
                var family = _mapper.Map<Family>(familyViewModel);
                _familyService.Add(family);
                _familyService.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(familyViewModel);
        }

        // GET: family/Edit/5
        public ActionResult Edit(int id)
        {
            var family = _familyService.GetById(id);
            if (family == null)
            {
                return HttpNotFound();
            }
            var familyViewModel = _mapper.Map<FamilyViewModel>(family);
            return View(familyViewModel);
        }

        // POST: family/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FamilyViewModel familyViewModel)
        {
            if (ModelState.IsValid)
            {
                var family = _mapper.Map<Family>(familyViewModel);
                _familyService.Update(family);
                _familyService.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(familyViewModel);
        }

        // GET: family/Delete/5
        public ActionResult Delete(int id)
        {
            var family = _familyService.GetById(id);
            if (family == null)
            {
                return HttpNotFound();
            }
            var familyViewModel = _mapper.Map<FamilyViewModel>(family);
            return View(familyViewModel);
        }

        // POST: family/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _familyService.Delete(id);
            _familyService.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
