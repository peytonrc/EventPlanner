using EventPlanner.Models.SubjectModels;
using EventPlanner.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventPlanner.WebMVC.Controllers
{
    [Authorize]
    public class SubjectController : Controller
    {
        // GET: Subject
        public ActionResult Index()
        {
            var service = CreateSubjectService();

            var model = service.GetSubjects();

            return View(model);
        }

        // GET: Subject/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Subject/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubjectCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateSubjectService();

            if (service.CreateSubject(model))
            {
                TempData["SaveResult"] = "Your subject has been created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Subject could not be created.");

            return View(model);
        }

        // GET: Subject/Details
        public ActionResult Details(int id)
        {
           SubjectService service = CreateSubjectService();
            var model = service.GetSubjectById(id);

            return View(model);
        }

        // GET: Subject/Edit
        public ActionResult Edit(int id)
        {
            var service = CreateSubjectService();
            var detail = service.GetSubjectById(id);
            var model =
                new SubjectEdit
                {
                    SubjectID = detail.SubjectID,
                    TypeOfEvent = detail.TypeOfEvent,
                    SubjectName = detail.SubjectName
                };
            return View(model);
        }

        // POST: Subject/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SubjectEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.SubjectID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateSubjectService();

            if (service.UpdateSubject(model))
            {
                TempData["SaveResult"] = "Your subject has been updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your subject could not be updated.");
            return View(model);
        }

        // GET: Subject/Delete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateSubjectService();
            var model = svc.GetSubjectById(id);

            return View(model);
        }

        // POST: Subject/Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateSubjectService();

            service.DeleteSubject(id);

            TempData["SaveResult"] = "Your subject has been deleted";

            return RedirectToAction("Index");
        }

        // Helper Method
        private SubjectService CreateSubjectService()
        {
            Guid userId = Guid.Parse(User.Identity.GetUserId());
            SubjectService service = new SubjectService(userId);
            return service;
        }
    }
}