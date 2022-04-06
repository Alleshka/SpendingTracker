using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpendingTracker.Model.DomainObjects;
using SpendingTracker.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpendingTracker.Test
{
    public abstract class BaseControllerTest
    {
        protected ApplicationContext _context;
        protected Guid _testedGuid = Guid.Parse("9d8be4cb-c91a-46ca-a747-84693e0838bf");

        public BaseControllerTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new ApplicationContext(options);
            _context.Database.EnsureCreated();
        }

        protected abstract IEnumerable<BaseModel> InitEntities();

        protected void Seed(ApplicationContext context, IEnumerable<BaseModel> entities)
        {
            context.Users.AddRange(entities.OfType<SystemUser>());
            context.SpendingGroups.AddRange(entities.OfType<SpendingGroup>());
            context.Spendings.AddRange(entities.OfType<Spending>());
            context.Categories.AddRange(entities.OfType<SpendingCategory>());
            context.SaveChanges();
        }
    }
}
