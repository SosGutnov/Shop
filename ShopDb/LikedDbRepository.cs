using Microsoft.EntityFrameworkCore;
using ShopDb;
using ShopDb.Models;

namespace ShopDb
{
    public class LikedDbRepository : ILikedRepository
    {
        private readonly DatabaseContext databaseContext;

        public LikedDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public List<Liked> GetAll()
        {
            return databaseContext.Liked.ToList();
        }
        public void AddOrDelete(Liked like)
        {
            var likedb = databaseContext.Liked.FirstOrDefault(x => x.UserId == like.UserId && x.Product.Id == like.Product.Id);
            if (likedb != null)
                databaseContext.Liked.Remove(likedb);
            else
                databaseContext.Liked.Add(like);
            databaseContext.SaveChanges();
        }

        public Liked TryGetByid(Guid id)
        {
            return databaseContext.Liked.FirstOrDefault(like => like.Id == id);
        }

        public List<Liked> TryGetAllByUserId(string id)
        {
            return databaseContext.Liked.Include(x=>x.Product).Where(x => x.UserId == id).ToList();
        }
    }
}
