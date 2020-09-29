using EventPlanner.Models;
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
    public class EventController : Controller
    {
        // GET: Event
        public ActionResult Index()
        {
            var service = CreateEventService();
            var model = service.GetEvents();
            return View(model);
        }

        // GET: Event/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Event/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateEventService();

            if (service.CreateEvent(model))
            {
                TempData["SaveResult"] = "Your event has been created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Event could not be created.");

            return View(model);
        }

        // GET: Event/Details
        public ActionResult Details(int id)
        {
            EventService service = CreateEventService();
            var model = service.GetEventById(id);

            return View(model);
        }

        // GET: Event/Edit
        public ActionResult Edit(int id)
        {
            var service = CreateEventService();
            var detail = service.GetEventById(id);
            var model =
                new EventEdit
                {
                    EventID = detail.EventID,
                    SubjectID = detail.SubjectID,
                    Title = detail.Title,
                    Description = detail.Description,
                    StartTime = detail.StartTime,
                    EndTime = detail.EndTime,
                    IsAllDay = detail.IsAllDay
                };
            return View(model);
        }

        // POST: Event/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EventEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.EventID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateEventService();

            if (service.UpdateEvent(model))
            {
                TempData["SaveResult"] = "Your event has been updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your event could not be updated.");
            return View(model);
        }

        // GET: Event/Delete
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateEventService();
            var model = svc.GetEventById(id);

            return View(model);
        }

        // POST: Event/Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateEventService();

            service.DeleteEvent(id);

            TempData["SaveResult"] = "Your event has been deleted";

            return RedirectToAction("Index");
        }

        // Helper Method
        private EventService CreateEventService()
        {
            Guid userId = Guid.Parse(User.Identity.GetUserId());
            EventService service = new EventService(userId);
            return service;
        }
    }
}