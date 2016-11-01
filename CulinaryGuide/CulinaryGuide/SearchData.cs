using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CulinaryGuide
{
    class SearchData
    {
        public List<SubcategoryClass> reqSubclasses= new List<SubcategoryClass>();
        public List<SimpleTableClass> reqProducts = new List<SimpleTableClass>();
        public string reqWord = "";
        public SearchData()
        {

        }

        public bool DishIsValid(DishClass item)
        {
            if (reqSubclasses!=null)
                foreach (SubcategoryClass item1 in reqSubclasses)
                {
                    bool machesIsFind = false;
                    foreach (SubcategoryClass item2 in item.classes)
                    {
                        if (item1.id == item2.id) machesIsFind = true;
                    }
                    if (!machesIsFind) return false;
                }
            if (reqProducts != null)
                foreach (SimpleTableClass item1 in reqProducts)
                {
                    bool machesIsFind = false;
                    foreach (IngredientClass item2 in item.ingredients)
                    {
                        if (item1.id == item2.product.id) machesIsFind = true;
                    }
                    if (!machesIsFind) return false;
                }

            if (reqWord != "")
            {
                // если поискового слова нет ни в описании, ни в названии
                // то говорим, что блюдо не прошло проверку
                if (item.name.IndexOf(reqWord) == -1 && item.description.IndexOf(reqWord) == -1)
                    return false;
            }

            // если до этого не выкинуло из метода, тогда блюдо 
            // подходит по критериям поиска
            return true;
        }
    }
}
