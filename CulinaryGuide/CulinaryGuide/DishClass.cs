using System.Collections.Generic;

namespace CulinaryGuide
{
    public class DishClass
    {

        public int id;
        public int user_id;
       
        public string name;
        public string description;

        public byte[] image;

        public List<IngredientClass> ingredients;
        //список отмеченных категорий блюда
        public List<SubcategoryClass> classes;
        public DishClass()
        {

        }
        public DishClass(int _id, int _user_id, string _name, string _description, byte[] _image, List<IngredientClass> _ingredients)
        {
            id = _id;
            user_id = _user_id;
            name = _name;
            description = _description;
            image = _image;
            ingredients = _ingredients;
        }
    }
}