using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiEntering.Models;
using WebApiEntering.ViewModels;

namespace WebApiEntering.Controllers
{
    public class CategoryController : ApiController  //webApi 2 write/read Action sayfası olarak açtık buraları, aşağıdaki kodları hazır olarak geridi. Şimdi üstünde biraz değişiklik yapacağız. 
    {
        // GET: api/Category
        public List<CategoryViewModel> Get() //get all gibi
        {
            return new NorthWind().Categories.Select(x => new CategoryViewModel()
            {
                CategoryID = x.CategoryID,
                CategoryName = x.CategoryName,
                Description = x.Description,
                Picture = x.Picture

            }).ToList();
        }

        // GET: api/Category/5
        public CategoryViewModel Get(int? id)  //getbyid gibi nullable yaptık, object yaptık vs gibi değişiklikler
        {
            if (id == null) return null;

            var category = new NorthWind().Categories.Find(id.Value);
            if (category == null)
            {
                return null;
            }
            var model = new CategoryViewModel()
            {
                CategoryName = category.CategoryName,
                CategoryID = category.CategoryID,
                Picture = category.Picture,
                Description = category.Description

            };
            return model;
        }

        // POST: api/Category
        public object Post([FromBody]CategoryViewModel value)  //insert gibi
        {
            using (NorthWind db = new NorthWind())
            {
                try
                {
                    db.Categories.Add(new Category()
                    {
                        CategoryName = value.CategoryName,
                        Description = value.Description,
                        Picture = value.Picture

                    });
                    db.SaveChanges();
                    return new
                    {
                        message = $"{value.CategoryName} isimli kategori ekleme başarılı"
                    };
                }
                catch (Exception ex)
                {

                    return new
                    {
                        message = $"Kategori ekleme işlemi sırasında bir hata oluştu",
                        detail = ex.Message
                    };
                }

            }
        }

        // PUT: api/Category/5
        public object Put([FromBody]CategoryViewModel value)  // update gibi nullable yaptık, object yaptık vs gibi değişiklikler
        {
            using (NorthWind db = new NorthWind())
            {
                var category = db.Categories.Find(value.CategoryID);
                if (category == null)
                {
                    return new
                    {
                        message = "Kategori bulunamadı"
                    };

                }
                try
                {
                    category.CategoryName = value.CategoryName;
                    category.Description = value.Description;
                    category.Picture = value.Picture;
                    db.SaveChanges();
                    return new
                    {
                        message = "Kategori güncelleme işlemi başarılı"
                    };
                }
                catch (Exception ex)
                {

                    return new
                    {
                        message = "Kategori güncelleme işleminde bir hata oluştu",
                        detail = ex.Message

                    };
                }

            }
        }

        // DELETE: api/Category/5
        public object Delete(int? id)  // delete de delete gibi, nullable yaptık, object yaptık vs gibi değişiklikler var
        {
            using (NorthWind db = new NorthWind())
            {
                var category = db.Categories.Find(id);
                if (category == null)
                {
                    return new
                    {
                        message = "Silinecek kategori bulunamadı"
                    };
                }
                try
                {
                    db.Categories.Remove(category);
                    db.SaveChanges();
                    return new
                    {
                        message = "Kategori Sİlme işlemi başarılı"
                    };

                }
                catch (Exception ex)
                {
                    return new
                    {
                        message = "Kategori silme işleminde bir hata oluştu",
                        details = ex.Message
                    };

                }
            }
        }
    }
}
