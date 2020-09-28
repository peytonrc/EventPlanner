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
                    Title = model.Title,
                    Description = model.Description,
                    StartTime = model.StartTime,
                    EndTime = model.EndTime,
                    IsAllDay = model.IsAllDay
                    
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
                                    Title = e.Title,
                                    IsAllDay = e.IsAllDay
                                }
                        );

                return query.ToArray();
            }
        }
    }
}
