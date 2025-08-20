
using ShopDb.Models;

namespace ShopDb
{
    public interface ILikedRepository
    {
        List<Liked> GetAll();
        List<Liked> TryGetAllByUserId(string id);
        public void AddOrDelete(Liked like);
        Liked TryGetByid(Guid id);
    }
}