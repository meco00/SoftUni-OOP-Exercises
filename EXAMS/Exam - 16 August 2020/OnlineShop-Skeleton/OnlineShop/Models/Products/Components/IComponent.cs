using OnlineShop.Models.Products;
using OnlineShop.Common.Enums;

namespace OnlineShop 
{ 

    public interface IComponent : IProduct
    {
        int Generation { get; }
    }
}
