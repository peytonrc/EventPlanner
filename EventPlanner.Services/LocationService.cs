using EventPlanner.Data;
using EventPlanner.Models.LocationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Services
{
    public class LocationService
    {
        private readonly Guid _userId;

        public LocationService(Guid userId)
        {
            _userId = userId;
        }

        // Create Location
        public bool CreateLocation(LocationCreate model)
        {
            var entity =
                new Location()
                {
                    OwnerId = _userId,
                    LocationName = model.LocationName,
                    Address = model.Address,
                    IsInside = model.IsInside,
                    TravelTime = model.TravelTime

                };

            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                ctx.Locations.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // List Locations
        public IEnumerable<LocationListItem> GetLocations()
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Locations
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new LocationListItem
                                {
                                    LocationID = e.LocationID,
                                    LocationName = e.LocationName,
                                    IsInside = e.IsInside
                                }
                        );

                return query.ToArray();
            }
        }

        // Location Details
        public LocationDetail GetLocationById(int id)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Locations
                        .Single(e => e.LocationID == id && e.OwnerId == _userId);
                return
                    new LocationDetail
                    {
                        LocationID = entity.LocationID,
                        LocationName = entity.LocationName,
                        Address = entity.Address,
                        IsInside = entity.IsInside,
                        TravelTime = entity.TravelTime,
                 
                    };
            }
        }

        // Edit Location
        public bool UpdateLocation(LocationEdit model)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Locations
                        .Single(e => e.LocationID == model.LocationID && e.OwnerId == _userId);

                entity.LocationName = model.LocationName;
                entity.Address = model.Address;
                entity.IsInside = model.IsInside;
                entity.TravelTime = model.TravelTime;

                return ctx.SaveChanges() == 1;
            }
        }

        // Delete Location
        public bool DeleteLocation(int locationId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Locations
                        .Single(e => e.LocationID == locationId && e.OwnerId == _userId);

                ctx.Locations.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
