using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TuristickaAgencijaIS181089.Domain.Identity;
using TuristickaAgencijaIS181089.Repository.Data;
using TuristickaAgencijaIS181089.Repository.Interfaces;

namespace TuristickaAgencijaIS181089.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<TuristickaAgencijaUser> entities;
        string errorMessage = string.Empty;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<TuristickaAgencijaUser>();
        }
        public IEnumerable<TuristickaAgencijaUser> GetAll()
        {
            return entities.AsEnumerable();
        }

        public TuristickaAgencijaUser Get(string id)
        {
            return entities
               .Include(z => z.UserReservation)
               .Include("UserReservation.ReservedLines")
               .Include("UserReservation.ReservedLines.Line")
               .Include("UserReservation.ReservedLines.Line.StartingDestination")
               .Include("UserReservation.ReservedLines.Line.FinalDestination")
               .Include("UserReservation.ReservedLines.Line.Company")
               .SingleOrDefault(s => s.Id == id);

        }
        public TuristickaAgencijaUser GetByEmail(string email)
        {
            return entities
               .Include(z => z.UserReservation)
               .Include("UserReservation.ReservedLines")
               .Include("UserReservation.ReservedLines.Line")
               .Include("UserReservation.ReservedLines.Line.StartingDestination")
               .Include("UserReservation.ReservedLines.Line.FinalDestination")
               .Include("UserReservation.ReservedLines.Line.Company")
               .SingleOrDefault(s => s.Email == email);

        }
        public void Insert(TuristickaAgencijaUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(TuristickaAgencijaUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }

        public void Delete(TuristickaAgencijaUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }
    }
}
