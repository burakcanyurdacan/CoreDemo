using BusinessLogicLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        EfCategoryRepository efCategory;

        public CategoryManager()
        {
            efCategory = new EfCategoryRepository();
        }

        public void CategoryAdd(Category category)
        {
            efCategory.Insert(category);
        }

        public void CategoryDelete(Category category)
        {
            efCategory.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            efCategory.Update(category);
        }

        public Category GetById(int id)
        {
            return efCategory.GetById(id);
        }

        public List<Category> GetList()
        {
            return efCategory.GetListAll();
        }
    }
}