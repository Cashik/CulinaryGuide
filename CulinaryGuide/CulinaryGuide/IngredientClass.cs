namespace CulinaryGuide
{
    public class IngredientClass
    {
        public int id;
        public int dish_id;

        public SimpleTableClass product = new SimpleTableClass();
        public string value;

        public IngredientClass()
        {

        }
        public IngredientClass(int _id, int _dish_id, SimpleTableClass _product, string _value)
        {
            id = _id;
            dish_id = _dish_id;
            product = _product;
            value = _value;
        }
        public string getReadyString()
        {
            return string.Format("{0}({1})", product.name, value);
        }
    }
}