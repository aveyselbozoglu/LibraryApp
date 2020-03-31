using LibraryApp.BusinessLayer;
using LibraryApp.Entities;
using System.Collections.Generic;
using System.Web.Helpers;

namespace LibraryApp.WebApp.Models
{
    public class CacheHelper
    {
        public static List<Category> GetCategoriesFromCache()
        {
            var result = WebCache.Get("category-cache");

            if (result == null)
            {
                CategoryManager categoryManager = new CategoryManager();
                result = categoryManager.GetCategories();

                WebCache.Set("category-cache", result, 20, true);
            }

            return result;
        }

        public static void RemoveCategoriesFromCache()
        {
            Remove("category-cache");
        }

        public static void Remove(string key)
        {
            WebCache.Remove(key);
        }
    }
}