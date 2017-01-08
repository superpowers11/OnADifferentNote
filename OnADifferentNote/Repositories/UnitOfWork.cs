using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Validation;
using System.Text;

namespace OnADifferentNote.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IRepository<Product> _productRepository;
        private IRepository<Promotion> _promoRepository;
        private IRepository<User> _userRepository;
        private IRepository<Cart> _cartRepository;

        private OnADifferentNoteDbEntities _context;

        public UnitOfWork()
        {
            _context = new OnADifferentNoteDbEntities();
        }

        public IRepository<Product> ProductRepository
        {
            get { return _productRepository ?? (_productRepository = new GenericRepository<Product>(_context)); }
            //set method not needed
        }
        public IRepository<Promotion> PromoRepository
        {
            get { return _promoRepository ?? (_promoRepository = new GenericRepository<Promotion>(_context)); }
        }


        public IRepository<User> UserRepository
        {
            get { return _userRepository ?? (_userRepository = new GenericRepository<User>(_context)); }
        }

        public IRepository<Cart> CartRepository
        {
            get { return _cartRepository ?? (_cartRepository = new GenericRepository<Cart>(_context)); }
        }

        public bool Save()
        {

            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                ); // Add the original exception as the innerException
            }
            return true;
        }

    }
}