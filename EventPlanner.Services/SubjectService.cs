using EventPlanner.Data;
using EventPlanner.Models;
using EventPlanner.Models.SubjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPlanner.Services
{
    public class SubjectService
    {
        private readonly Guid _userId;

        public SubjectService(Guid userId)
        {
            _userId = userId;
        }

        // Create Subject
        public bool CreateSubject(SubjectCreate model)
        {
            Subject entity =
                new Subject()
                {
                    OwnerId = _userId,
                    TypeOfActivity = model.TypeOfActivity,
                    SubjectName = model.SubjectName
                };

            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                ctx.Subjects.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // List Subjects
        public IEnumerable<SubjectListItem> GetSubjects()
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Subjects
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new SubjectListItem
                                {
                                    SubjectID = e.SubjectID,
                                    TypeOfActivity = e.TypeOfActivity,
                                    SubjectName = e.SubjectName
                                }
                        );

                return query.ToArray();
            }
        }

        // Subject Details
        public SubjectDetail GetSubjectById(int id)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                Subject entity =
                    ctx
                        .Subjects
                        .Single(e => e.SubjectID == id && e.OwnerId == _userId);
                return
                    new SubjectDetail
                    {
                        SubjectID = entity.SubjectID,
                        TypeOfActivity = entity.TypeOfActivity,
                        SubjectName = entity.SubjectName

                    };
            }
        }

        // Edit Subject
        public bool UpdateSubject(SubjectEdit model)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Subjects
                        .Single(e => e.SubjectID == model.SubjectID && e.OwnerId == _userId);

                entity.TypeOfActivity = model.TypeOfActivity;
                entity.SubjectName = model.SubjectName;


                return ctx.SaveChanges() == 1;
            }
        }

        // Delete Subject
        public bool DeleteSubject(int subjectId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Subjects
                        .Single(e => e.SubjectID == subjectId && e.OwnerId == _userId);

                ctx.Subjects.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
