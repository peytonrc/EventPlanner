using EventPlanner.Data;
using EventPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Services
{
    public class EventService
    {
        private readonly Guid _userId;

        public EventService(Guid userId)
        {
            _userId = userId;
        }

        // Create Event
        public bool CreateEvent(EventCreate model)
        {
            Event entity =
                new Event()
                {
                    OwnerId = _userId,
                    SubjectID = model.SubjectID,
                    Description = model.Description,
                    Date = model.Date,
                    Time = model.Time,
                    IsAllDay = model.IsAllDay,
                    LocationID = model.LocationID
                    
                };

            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                ctx.Events.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // List Events
        public IEnumerable<EventListItem> GetEvents()
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Events
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new EventListItem
                                {
                                    EventID = e.EventID,
                                    SubjectID = e.SubjectID,
                                    Subject = e.Subject,
                                    IsAllDay = e.IsAllDay
                                }
                        );

                return query.ToArray();
            }
        }

        // Event Details
        public EventDetail GetEventById(int id)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                Event entity =
                    ctx
                        .Events
                        .Single(e => e.EventID == id && e.OwnerId == _userId);
                return
                    new EventDetail
                    {
                        EventID = entity.EventID,
                        SubjectID = entity.SubjectID,
                        Subject = entity.Subject,
                        Description = entity.Description,
                        Date = entity.Date,
                        Time = entity.Time,
                        IsAllDay = entity.IsAllDay,
                        LocationID = entity.LocationID,
                        Location = entity.Location
                    };
            }
        }

        // Edit Event
        public bool UpdateEvent(EventEdit model)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Events
                        .Single(e => e.EventID == model.EventID && e.OwnerId == _userId);

                entity.Description = model.Description;
                entity.Date = model.Date;
                entity.Time = model.Time;
                entity.IsAllDay = model.IsAllDay;

                return ctx.SaveChanges() == 1;
            }
        }

        // Delete Event
        public bool DeleteEvent(int eventId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Events
                        .Single(e => e.EventID == eventId && e.OwnerId == _userId);

                ctx.Events.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
