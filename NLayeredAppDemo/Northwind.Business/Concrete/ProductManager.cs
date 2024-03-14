using Northwind.Entities.Concrete;
using System;
using Northwind.DataAccess.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.DataAccess.Concrete.EntityFramework;
using Northwind.DataAccess.Abstract;
using Northwind.Business.Abstract;
using Northwind.Entities.Abstract;
using System.Data.Entity.Infrastructure;
using Northwind.Business.ValidationRules.FluentValidation;
using FluentValidation;
using Northwind.Business.Utilities;

namespace Northwind.Business.Concrete
{
    //Manager ifadesi genllikle iş sınıfları için kullanılan standart bir ifadedir.
    public class ProductManager:IProductService
    {
        ////Aşağıdaki kod bizi bağımlı yapan bir kod bloğu bunu değiştirelim
        //EfProductDal productDal = new EfProductDal();

        private IProductDal _productDal;

        //_productDal'ı hangi veri tabanından kullanıcağımızı constructor ile belirliyoruz
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        //Validation işlemini gerçekleştirelim
        public void Add(Product product)
        {
            //Burada bir hata var onu çözücem sonra
            //ValidationTool.Validate(new ProductValidator(),product);
            _productDal.Add(product);
        }

        public void Delete(Product product)
        {
            //Hatayı verdiğimiz katman burası oldu
            try
            {
                _productDal.Delete(product);
            }
            catch 
            {
                throw new Exception("Silme Gerçekleşemedi");
            }
        }

        public List<Product> GetAll()
        {
            //Burada business codeları yazılır genelde.Data çekiyo ama çekebilir mi, okuyabilir mi,
            //ne kadarını çekebilir gibi
            return _productDal.GetAll();
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            return _productDal.GetAll(p => p.CategoryId == categoryId);
        }

        public List<Product> GetProductsByProductName(string productName)
        {
            return _productDal.GetAll(p=>p.ProductName.ToLower().Contains(productName.ToLower()));
        }

        public void Update(Product product)
        {
            _productDal.Update(product);
        }
    }
}
