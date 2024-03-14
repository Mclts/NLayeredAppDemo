using FluentValidation;
using Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Business.ValidationRules.FluentValidation
{
    //Ürün için kurallar gerçekleitrircem demek oluyor aşağıdaki kod
    public class ProductValidator:AbstractValidator<Product>
    {
        //Fluent Validation
        public ProductValidator()
        {
            //fluent validation un 19 dil desteği var kendi hata mesajlarımızı da üretebiliyoruz.
            RuleFor(p => p.ProductName).NotEmpty().WithMessage("Ürün İsmi Boş Olamaz");
            RuleFor(p => p.CategoryId).NotEmpty();
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.QuantityPerUnit).NotEmpty();
            RuleFor(p => p.UnitsInStock).NotEmpty();

            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.UnitsInStock).GreaterThanOrEqualTo((short)0);
            RuleFor(p => p.UnitPrice).GreaterThan(10).When(p => p.CategoryId == 2);

            ////Kendi Kurallarımızı da yazabiliyoruz aşağıdaki gibi
            //RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürün Adı A ile Başlamalı");
        }

        //A ile başlıyorsa true döner yukarıdaki methodda sıkıntı çıkmaz ama false dönerse hata olur.
        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
