using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnADifferentNote.Repositories
{
    public interface IUnitOfWork
    {
        IRepository<Product> ProductRepository { get; }
        IRepository<Promotion> PromoRepository { get; }
        IRepository<User> UserRepository { get; }
        IRepository<Cart> CartRepository { get; }
        bool Save();
    }
}
