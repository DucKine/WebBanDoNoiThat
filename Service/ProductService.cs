using DAL;
using Model;
using Repository;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;

namespace Service
{
    public class ProductService : IServices<Product>, IListProductService<Product>
    {
        private IRepository<Product> repository;
        private IListProduct<Product> rep;
        public ProductService()
        {
            rep = new ProductReponsitory(new DBEntityContext());
            repository = new ProductReponsitory(new DBEntityContext());
        }
        public int Delete(int id)
        {
            return repository.Delete(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return repository.GetAll();
        }

        public Product GetById(int id)
        {
            return repository.GetById(id);
        }

        public Product GetByUserName(string UserName)
        {
            throw new NotImplementedException();
        }
     

        public Contact GetContact()
        {
            throw new NotImplementedException();
        }

        public int Insert(Product t)
        {
            return repository.Insert(t);
        }

        public IEnumerable<Product> ListProductGetByCategory(int id, int pageIndex, int pageSize)
        {
            return rep.ListProductGetByCategory(id,pageIndex,pageSize);
        }

        public IEnumerable<Product> ListProductHot()
        {
            return rep.ListProductHot();
        }

        public IEnumerable<Product> ListProductNew()
        {
            return rep.ListProductNew();
        }

        public IEnumerable<Product> ListProductrRadom()
        {

            return rep.ListProductrRadom();
        }

        public IEnumerable<Product> ListProductSale()
        {
            return rep.ListProductSale();
        }

        public bool Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> Search(string searchString)
        {
            throw new NotImplementedException();
        }

		public IEnumerable<Product> Search(string searchString, int Page, int Pagesize)
		{
			return repository.Search(searchString, Page, Pagesize);
		}

        //public IEnumerable<Product> SearchName(string searchString, int? Page)
        //{
        //    return rep.SearchName(searchString, Page);
        //}

        public int Update(Product t)
        {
            return repository.Update(t);
        }
    }
}
