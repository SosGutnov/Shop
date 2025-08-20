using System.ComponentModel.DataAnnotations;

namespace ShopDb.Models
{
    public enum OrderStatus
    {
        Created,
        Processed,
        Delivering,
        Delivered,
        Canceled
    }
}