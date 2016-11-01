using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace CulinaryGuide
{
    public class DBWorker
    {
        SqlConnectionStringBuilder connectStringBuilder;
        public SqlConnection connection;
        public DBWorker()
        {
            connectStringBuilder = new SqlConnectionStringBuilder();
            connectStringBuilder.DataSource = @"(localdb)\MSSQLLocalDB";
            connectStringBuilder.ConnectTimeout = 30;
            connectStringBuilder.IntegratedSecurity = true;
            connectStringBuilder.AttachDBFilename = @"|DataDirectory|CulinaryGuide.mdf";

            connection = new SqlConnection();
            connection.ConnectionString = connectStringBuilder.ConnectionString;
        }
        public bool Connect()
        {
            try
            {
                //Открыть подключение
                connection.Open();
                return true;
            }
            catch (SqlException ex)
            {
                // Протоколировать исключение
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public void Close()
        {
            connection.Close();
        }
        public bool IsOpen()
        {
            return connection.State == System.Data.ConnectionState.Open;
        }

        public bool UserExist(string login)
        {
            bool result = false;
            string command = string.Format("SELECT * FROM [User] WHERE Login ='{0}'", login);

            try
            {
                SqlCommand cmd = new SqlCommand(command, connection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    result = true;
                }
                dr.Close();
            }
            catch (SqlException ex)
            {
                // Протоколировать исключение
                Console.WriteLine(ex.Message);
            }


            return result;
        }

        public bool RefreshConnect()
        {
            Close();
            return Connect();
        }
        public UserClass GetUserByLoginPassword(string login,string password)
        {
            UserClass result = new UserClass();

            string command = string.Format("SELECT * FROM [User] WHERE Login ='{0}' and Password = '{1}'", login,password);

            bool allFine = false;
            try
            {
                SqlCommand cmd = new SqlCommand(command, connection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    result.id = (int)dr[dr.GetOrdinal("Id")];
                    result.login = (string)dr[dr.GetOrdinal("Login")];
                    result.password = (string)dr[dr.GetOrdinal("Password")];
                    result.trusted = (((int)dr[dr.GetOrdinal("Trusted")]==1)? true : false);
                    result.name = (string)dr[dr.GetOrdinal("Name")];
                    if (dr.IsDBNull(dr.GetOrdinal("Image"))) result.image = null;
                    else result.image = (byte[])dr[dr.GetOrdinal("Image")];

                    allFine = true;
                }
                dr.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Data.ToString(),"Ошибка подключения к базе!");
            }


            if (allFine)
                return result;
            else
                return null;
        }
        public DishClass GetDishById(int id)
        {
            DishClass result = new DishClass();

            string command = string.Format("SELECT * FROM [Dish] WHERE Id ='{0}'", id);
            bool allFine = false;
            try
            {
                SqlCommand cmd = new SqlCommand(command, connection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    result.id = (int)dr[dr.GetOrdinal("Id")];
                    result.description = (string)dr[dr.GetOrdinal("Description")];
                    result.user_id = (int)dr[dr.GetOrdinal("User_id")];
                    result.name = (string)dr[dr.GetOrdinal("Name")];
                    if (dr.IsDBNull(dr.GetOrdinal("Image"))) result.image = null;
                    else result.image = (byte[])dr[dr.GetOrdinal("Image")];
                    
                    allFine = true;
                }
                dr.Close();
            }
            catch (SqlException )
            {
                MessageBox.Show("Ошибка подключения к базе!");
            }

            result.ingredients = GetIngredientsByDishId(result.id);
            result.classes = GetDishCatigoriesByDishId(result.id);



            if (allFine)
                return result;
            else
                return null;
        }
        private List<SubcategoryClass> GetDishCatigoriesByDishId(int id)
        {
            List<SubcategoryClass> b = new List<SubcategoryClass>();
            List<int> subCategoriesId = new List<int>();
            string command = string.Format("SELECT * FROM [Linker] where Dish_id = '{0}'",id);
            bool allFine = false;
            try
            {

                SqlCommand cmd = new SqlCommand(command, connection);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    subCategoriesId.Add((int)dr[dr.GetOrdinal("Subclass_id")]);
                }
                allFine = true;
                dr.Close();
            }
            catch (SqlException )
            {
                MessageBox.Show("Ошибка подключения к базе!");
            }

            foreach(int a in subCategoriesId)
            {
                try
                {
                    string command1 = string.Format("SELECT * FROM [Subclass] where Id = '{0}'", a);

                    SqlCommand cmd = new SqlCommand(command1, connection);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        SubcategoryClass buf = new SubcategoryClass();

                        buf.id = (int)dr[dr.GetOrdinal("Id")];
                        buf.name = (string)dr[dr.GetOrdinal("Name")];
                        buf.parent_id = (int)dr[dr.GetOrdinal("Parent_id")];

                        b.Add(buf);
                    }
                    allFine = true;
                    dr.Close();
                }
                catch (SqlException )
                {
                    MessageBox.Show("Ошибка подключения к базе!");
                }
            }
            if (allFine)
                return b;
            else
                return null;
        }

        


        // возвращает все блюда только для заполнения минимизированной формы
        // и поиска (экономия памяти)
        public List<DishClass> GetAllMinDishs()
        {
            List<DishClass> result = new List<DishClass>();

            string command = string.Format("SELECT * FROM [Dish]");

            bool allFine = false;
            try
            {

                SqlCommand cmd = new SqlCommand(command, connection);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DishClass buf = new DishClass();

                    buf.id = (int)dr[dr.GetOrdinal("Id")];
                    buf.description = (string)dr[dr.GetOrdinal("Description")];
                    buf.name = (string)dr[dr.GetOrdinal("Name")];


                    result.Add(buf);
                }
                allFine = true;
                dr.Close();
            }
            catch (SqlException )
            {
                MessageBox.Show("Ошибка подключения к базе!");
            }

            foreach (DishClass item in result)
            {
                item.ingredients = GetIngredientsByDishId(item.id);
                item.classes = GetDishCatigoriesByDishId(item.id);
            }

            if (allFine)
                return result;
            else
                return null;
        }

        public List<IngredientClass> GetIngredientsByDishId(int id)
        {
            List<IngredientClass> result = new List<IngredientClass>();

            string command = string.Format("SELECT * FROM [Ingredient] where Dish_id = '{0}'",id);
            bool allFine = false;

            try
            {

                SqlCommand cmd = new SqlCommand(command, connection);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    IngredientClass buf = new IngredientClass();

                    buf.id = (int)dr[dr.GetOrdinal("Id")];
                    buf.value = (string)dr[dr.GetOrdinal("Value")];

                    buf.product.id = (int)dr[dr.GetOrdinal("Product_id")];
                    
                    
                    result.Add(buf);
                }
                allFine = true;
                dr.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Ошибка подключения к базе!"+ex.Data);
            }

            foreach (IngredientClass item in result)
            {
                item.product.name = GetSimpleClassById("Product", item.product.id);
            }

            if (allFine)
                return result;
            else
                return null;
        }

        // методы, работающие для таблиц Product и Meshure одновременно
        public List<SimpleTableClass> GetAllProducts()
        {
            List<SimpleTableClass> result = new List<SimpleTableClass>();

            string command = string.Format("SELECT * FROM [Product]");
            try
            {
                SqlCommand cmd = new SqlCommand(command, connection);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    SimpleTableClass buf = new SimpleTableClass();
                    buf.id = (int)dr[dr.GetOrdinal("Id")];
                    buf.name = (string)dr[dr.GetOrdinal("Name")];

                    result.Add(buf);
                }
                dr.Close();
            }
            catch (SqlException )
            {
                MessageBox.Show("Ошибка подключения к базе!");
            }

            return result;
        }
        public int GetProductIdByName(string name)
        {
            int result = -1;

            string command = string.Format("SELECT [Id] FROM [Product] where name = '{0}'", name);

            try
            {

                SqlCommand cmd = new SqlCommand(command, connection);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    result = (int)dr[dr.GetOrdinal("Id")];

                }

                dr.Close();
            }
            catch (SqlException )
            {
                MessageBox.Show("Ошибка подключения к базе!");
            }

            return result;



        }
        public string GetSimpleClassById(string tableName, int id)
        {
            string result="";

            string command = string.Format("SELECT [Name] FROM [{0}] WHERE Id = '{1}'",tableName,id);
            bool allFine = false;

            try
            {

                SqlCommand cmd = new SqlCommand(command, connection);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    result = (string)dr[dr.GetOrdinal("Name")];
                    allFine = true;

                }
                dr.Close();
            }
            catch (SqlException )
            {
                MessageBox.Show("Ошибка подключения к базе!");
            }


            if (allFine)
                return result;
            else
                return null;


        }

        public List<DishCategoryClass> GetAllDishClasses()
        {
            List<DishCategoryClass> result = new List<DishCategoryClass>();

            string command = string.Format("SELECT * FROM [Class]");

            bool allFine = false;
            try
            {
                SqlCommand cmd = new SqlCommand(command, connection);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DishCategoryClass buf = new DishCategoryClass();

                    buf.id = (int)dr[dr.GetOrdinal("Id")];
                    buf.name = (string)dr[dr.GetOrdinal("Name")];


                    result.Add(buf);
                }
                allFine = true;
                dr.Close();
            }
            catch (SqlException )
            {
                MessageBox.Show("Ошибка подключения к базе!");
            }

            foreach (DishCategoryClass item in result)
            {
                item.subCategoryElements = GetAllSubCategoryByCategoryId(item.id);
            }

            if (allFine)
                return result;
            else
                return null;
        }
        public List<SimpleTableClass> GetAllSubCategoryByCategoryId(int id)
        {
            List<SimpleTableClass> result = new List<SimpleTableClass>();

            string command = string.Format("SELECT * FROM [Subclass] where Parent_id = '{0}'",id);
            bool allFine = false;

            try
            {

                SqlCommand cmd = new SqlCommand(command, connection);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    SimpleTableClass buf = new SimpleTableClass();

                    buf.id = (int)dr[dr.GetOrdinal("Id")];
                    buf.name = (string)dr[dr.GetOrdinal("Name")];

                    result.Add(buf);
                }
                allFine = true;
                dr.Close();
            }
            catch (SqlException )
            {
                MessageBox.Show("Ошибка подключения к базе!");
            }


            if (allFine)
                return result;
            else
                return null;
        }
        public SubcategoryClass GetSubCategoryById(int id)
        {
            SubcategoryClass result = new SubcategoryClass();

            string command = string.Format("SELECT * FROM [Subclass] where Id = '{0}'", id);
            bool allFine = false;

            try
            {
                SqlCommand cmd = new SqlCommand(command, connection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    result.id = (int)dr[dr.GetOrdinal("Id")];
                    result.name = (string)dr[dr.GetOrdinal("Name")];
                    result.parent_id = (int)dr[dr.GetOrdinal("Parent_id")];
                    allFine = true;
                }
                dr.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Ошибка подключения к базе!");
            }


            if (allFine)
                return result;
            else
                return null;
        }
        public List<int> GetAllDishIdFromUserBookmarks(int user_id)
        {
            List<int> result = new List<int>();
            string command = string.Format("SELECT * FROM [Bookmark] where User_id = '{0}'", user_id);
            try
            {

                SqlCommand cmd = new SqlCommand(command, connection);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    result.Add((int)dr[dr.GetOrdinal("Dish_id")]);
                }
                dr.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Ошибка подключения к базе!");
            }
            return result;
            
        }


        public bool UpdateDish(DishClass dish)
        {

            //add car info
            bool allFine = false;
            string Command = string.Format("UPDATE [Dish] set Name=@Name,Description=@Description, Image=@Image where id='{0}'", dish.id.ToString());
            try
            {
                using (SqlCommand cmd = new SqlCommand(Command, connection))
                {
                    // Добавить параметры
                    cmd.Parameters.AddWithValue("@Description", dish.description);
                    cmd.Parameters.AddWithValue("@Name", dish.name);
                    if (dish.image != null)
                        cmd.Parameters.AddWithValue("@Image", dish.image);
                    else
                    {
                        cmd.Parameters.Add("@Image", SqlDbType.Image).Value = DBNull.Value;
                    }

                    cmd.ExecuteNonQuery();
                    allFine = true;
                }
            }
            catch (SqlException )
            {
                MessageBox.Show("Ошибка подключения к базе!");

            }

            return allFine;
        }


        // возвращает id созданной таблицы
        public int AddDish(DishClass dish)
        {
            //add car info
            string Command = "INSERT INTO [Dish](Description,Name,User_id,Image) Values(@Description,@Name,@User_id,@Image)";
            try
            {
                using (SqlCommand cmd = new SqlCommand(Command, connection))
                {
                    // Добавить параметры
                    cmd.Parameters.AddWithValue("@Description", dish.description);
                    cmd.Parameters.AddWithValue("@Name", dish.name);
                    cmd.Parameters.AddWithValue("@User_id", dish.user_id);
                    if (dish.image!=null)
                        cmd.Parameters.AddWithValue("@Image", dish.image);
                    else
                    {
                        cmd.Parameters.Add("@Image", SqlDbType.Image).Value = DBNull.Value;
                    }



                    int a = cmd.ExecuteNonQuery();
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Data.ToString(),"Ошибка подключения к базе!");

            }

            int addedDishId = -1;
            Command = "select @@IDENTITY";

            try
            {
                using (SqlCommand cmd = new SqlCommand(Command, connection))
                {
                    addedDishId = Int32.Parse(cmd.ExecuteScalar().ToString());
                }

            }
            catch (SqlException )
            {
                MessageBox.Show("Ошибка подключения к базе!");

            }

            return addedDishId;
        }

        public bool DeleteAllDishIngredientsByDishId(int id)
        {
            bool result = false;

            string Command = string.Format("Delete from [Ingredient] where Dish_id = '{0}'", id);
            using (SqlCommand cmd = new SqlCommand(Command, connection))
            {
                try
                {
                    if (1 == cmd.ExecuteNonQuery()) result = true;
                }
                catch (SqlException)
                {
                    MessageBox.Show("Ошибка удаления");

                }
            }

            return result;
        }

        public bool DeleteAllDishSubclassesByDihId(int id)
        {
            bool result = false;

            string Command = string.Format("Delete from [Linker] where Dish_id = '{0}'", id);
            using (SqlCommand cmd = new SqlCommand(Command, connection))
            {
                try
                {
                    if (1 == cmd.ExecuteNonQuery()) result = true;
                }
                catch (SqlException)
                {
                    MessageBox.Show("Ошибка удаления");

                }
            }

            return result;
        }

        public bool AddLink(int dish_id, int subclass_id)
        {
            
            bool allFine = false;
            string Command = "INSERT INTO [Linker](Dish_id,Subclass_id) Values(@Dish_id,@Subclass_id)";
            try
            {
                using (SqlCommand cmd = new SqlCommand(Command, connection))
                {
                    // Добавить параметры
                    cmd.Parameters.AddWithValue("@Dish_id", dish_id);
                    cmd.Parameters.AddWithValue("@Subclass_id", subclass_id);


                    if (cmd.ExecuteNonQuery() > 0)
                        allFine = true;
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Data.ToString(), "Ошибка подключения к базе!");

            }

            return allFine;
        }


        public bool AddUser(UserClass user)
        {
            bool allFine=false;
            string Command = "INSERT INTO [User](Login,Password,Name,Trusted) Values(@Login,@Password,@Name,@Trusted)";
            try
            {
                using (SqlCommand cmd = new SqlCommand(Command, connection))
                {
                    // Добавить параметры
                    cmd.Parameters.AddWithValue("@Login", user.login);
                    cmd.Parameters.AddWithValue("@Password", user.password);
                    cmd.Parameters.AddWithValue("@Name", user.name);
                    cmd.Parameters.AddWithValue("@Trusted", ((user.trusted== true)?1:0));

                   if (cmd.ExecuteNonQuery()>0)
                        allFine =true;
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Data.ToString(),"Ошибка подключения к базе!");

            }

            return allFine;
        }
        public bool AddBookmark(int user_id, int dish_id)
        {
            bool allFine = false;
            string Command = "INSERT INTO [Bookmark](User_id,Dish_id) Values(@User_id,@Dish_id)";
            try
            {
                using (SqlCommand cmd = new SqlCommand(Command, connection))
                {
                    // Добавить параметры
                    cmd.Parameters.AddWithValue("@User_id", user_id);
                    cmd.Parameters.AddWithValue("@Dish_id", dish_id);
                    

                    if (cmd.ExecuteNonQuery() > 0) allFine = true;
                }

            }
            catch (SqlException )
            {
                MessageBox.Show("Ошибка подключения к базе!");

            }

            return allFine;
        }

        // может добавить экземпляр таблицы в Class,Product,Meshure
        public bool AddProduct(string name)
        {
            bool allFine = false;
            string Command = string.Format("INSERT INTO [Product](Name) Values(@Name)");
            try
            {
                using (SqlCommand cmd = new SqlCommand(Command, connection))
                {
                    // Добавить параметры
                    cmd.Parameters.AddWithValue("@Name", name);


                    if (cmd.ExecuteNonQuery() > 0) allFine = true;
                }

            }
            catch (SqlException )
            {
                MessageBox.Show("Ошибка подключения к базе!");

            }

            return allFine;
        }
        public bool AddIngredient(IngredientClass ing)
        {
            bool allFine = false;
            string Command = string.Format("INSERT INTO [Ingredient](Dish_id,Product_id,Value) Values(@Dish_id,@Product_id,@Value)");
            try
            {
                using (SqlCommand cmd = new SqlCommand(Command, connection))
                {
                    // Добавить параметры
                    cmd.Parameters.AddWithValue("@Dish_id", ing.dish_id);
                    cmd.Parameters.AddWithValue("@Product_id", ing.product.id);
                    cmd.Parameters.AddWithValue("@Value", ing.value);

                    if (cmd.ExecuteNonQuery() > 0) allFine = true;
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Ошибка подключения к базе!");

            }

            return allFine;
        }
        public bool AddSubclass(int parent_id, string name)
        {
            bool allFine = false;
            string Command = string.Format("INSERT INTO [Subclass](Name,Parent_id) Values(@Name,@Parent_id)");
            try
            {
                using (SqlCommand cmd = new SqlCommand(Command, connection))
                {
                    // Добавить параметры
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Parent_id", parent_id);


                    if (cmd.ExecuteNonQuery() > 0) allFine = true;
                }

            }
            catch (SqlException )
            {
                MessageBox.Show("Ошибка подключения к базе!");

            }

            return allFine;
        }





        public bool DeleteTableById(string tableName, int tableExpIndex)
        {
            bool result = false;

            string Command = string.Format("Delete from [{0}] where Id = {1}", tableName, tableExpIndex);
            using (SqlCommand cmd = new SqlCommand(Command, connection))
            {
                try
                {
                    if (1==cmd.ExecuteNonQuery())
                        result = true;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Data.ToString(),"Ошибка удаления "+tableName);

                }
            }

            return result;
        }

        public bool DeleteBookmark(int user_id, int dish_id)
        {
            bool result = false;

            string Command = string.Format("Delete from [Bookmark] where User_id = '{0}' and Dish_id = '{1}'", user_id,dish_id);
            using (SqlCommand cmd = new SqlCommand(Command, connection))
            {
                try
                {
                    if (1 == cmd.ExecuteNonQuery()) result = true;
                }
                catch (SqlException )
                {
                    MessageBox.Show("Ошибка удаления закладки!");

                }
            }

            return result;
        }

    }
}
