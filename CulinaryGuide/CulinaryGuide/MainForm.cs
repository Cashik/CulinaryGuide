using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CulinaryGuide
{
    public partial class MainForm : Form
    {
        SettingsClass settings = new SettingsClass();
        public DBWorker db = new DBWorker();

        Point PanelMouseDownLocation;
        public UserClass user =null;
        public DishClass dish=null;
        // список с данными о всех блюдах для поиска
        // в переменные не записываются параметры, 
        // корорые не участвуют в поиске(картики)
        List<DishClass> minDishList;
        List<DishCategoryClass> classes;
        List<SimpleTableClass> products;


        public MainForm()
        {
            InitializeComponent();
            OpenHelpPage();
            if (!db.Connect())
            {
                MessageBox.Show("Нет соединения с базой данных!");
                Close();
            }
            // применяем настройки
            ReloadSettings();
            // обновляем локальные переменные
            RefreshLocalData();
            RefreshMainWindowUIElements();
        }

        private void ReloadSettings()
        {
            // считываем с файла настройки
            settings.Reload();

            // применяем настройки
            Width = settings.windowWidth;
            Height = settings.windowHeight;

        }

        public void RefreshMainWindowUIElements()
        {
            if (user == null)
            {
                userNameLbl.Text = "Гость";
                logoutBtn.Visible = false;
                loginBtn.Visible = true;
                bookmarkBtn.Visible = false;
                addDishBtn.Visible = false;
            }
            else
            {
                userNameLbl.Text = user.name;
                logoutBtn.Visible = true;
                loginBtn.Visible = false;
                bookmarkBtn.Visible = true;
                if (user.trusted) addDishBtn.Visible = true;
                else addDishBtn.Visible = false;
            }

            



        }

        public Image SetImageOpacity(Image image, float opacity)
        {
            Bitmap bmp = new Bitmap(image.Width, image.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                ColorMatrix matrix = new ColorMatrix();
                matrix.Matrix33 = opacity;
                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default,
                                                  ColorAdjustType.Bitmap);
                g.DrawImage(image, new Rectangle(0, 0, bmp.Width, bmp.Height),
                                   0, 0, image.Width, image.Height,
                                   GraphicsUnit.Pixel, attributes);
            }
            return bmp;
        }

        public void OpenDish()
        {
            RefreshLocalData();

            if (user == null)
            {
                addBookmarkBtn.Visible = false;
                removeBookmarkBtn.Visible = false;
                editDishBtn.Visible = false;
                removeDishBtn.Visible = false;
            }
            else
            {
                if (db.GetAllDishIdFromUserBookmarks(user.id).IndexOf(dish.id) == -1)
                {
                    addBookmarkBtn.Visible = true;
                    removeBookmarkBtn.Visible = false;
                }
                else
                {
                    addBookmarkBtn.Visible = false;
                    removeBookmarkBtn.Visible = true;
                }
                if (user.trusted)
                {
                    editDishBtn.Visible = true;
                    removeDishBtn.Visible = true;
                }
                else
                {
                    editDishBtn.Visible = false;
                    removeDishBtn.Visible = false;
                }
                
            }




            // очищаем елементы от данных, что были до этого
            showNameLbl.Text = dish.name;
            showIngFLP.Controls.Clear();
            foreach (IngredientClass ic in dish.ingredients)
            {
                SmartLabelUC iuc = new SmartLabelUC(ic.product.name, false, ic.product.id, ic.value);
                showIngFLP.Controls.Add(iuc);
            }
            showSubclassFLP.Controls.Clear();
            foreach (SubcategoryClass ic in dish.classes)
            {
                SmartLabelUC iuc = new SmartLabelUC(ic.name, false);
                showSubclassFLP.Controls.Add(iuc);
            }
            if (dish.image != null)
            {
                MemoryStream ms = new MemoryStream(dish.image);
                showDishImgPB.Image = Image.FromStream(ms);
                ms.Close();
            }
            else
            {
                showDishImgPB.Image = showDishImgPB.InitialImage;
            }
            showDiscriptionUC.setText(dish.description);

            
            //  открываем панель блюда
            mainTC.SelectedTab = dishTP;

        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                PanelMouseDownLocation = e.Location;

        }
        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X + - PanelMouseDownLocation.X;
                this.Top += e.Y - PanelMouseDownLocation.Y;
            }

        }
        private void exitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void editAddIngBtn_Click(object sender, EventArgs e)
        {
            SimpleTableClass prod = new SimpleTableClass();
            prod.name = editProductCB.Text;
            prod.id = -1;

            foreach (SimpleTableClass item in products)
            {
                if (item.name == prod.name) prod.id = item.id;
            }


            if (prod.id != -1)
            {
                string value = editValueTB.Text;
                editIngFLP.Controls.Add(new SmartLabelUC(prod.name, true, prod.id, value));
            }
            else
            {
                if (user != null && user.trusted)
                {
                    DialogResult dialogResult = MessageBox.Show("В базе нет такого продукта. Добавить?", "Внимание!", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        db.AddProduct(prod.name);
                        RefreshLocalData();
                        editProductCB.Items.Add(prod.name);
                    }

                }
                else
                {
                    MessageBox.Show("В базе нет такого продукта.", "Внимание!");
                }
            }
            
        }

        private void editAddPhotoBtn_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "All files|*.*|PNG|*.png|JPEGs|*.jpg|Bitmaps|*.bmp|GIFs|*.gif";
            f.FilterIndex = 1;
            if (f.ShowDialog() == DialogResult.OK)
            {
                editResultPhotoPB.Image = Image.FromFile(f.FileName);
            }
        }

        private void fastSearchBtn_Click(object sender, EventArgs e)
        {
            OpenFastSearch();
        }

        private void OpenFastSearch()
        {
            RefreshLocalData();

            fastSearchTP.Controls.Clear();
            foreach (DishCategoryClass dishClass in classes)
            {
                DishClassLBUC DishClassUC = new DishClassLBUC(dishClass,true);
                DishClassUC.Dock = DockStyle.Top;
                fastSearchTP.Controls.Add(DishClassUC);
            }

            searchTC.SelectedTab = fastSearchTP;
        }

        private void defaultSearchBtn_Click(object sender, EventArgs e)
        {
            OpenDefaultSerach();
        }
        private void OpenDefaultSerach()
        {
            RefreshLocalData();

            productDSCB.Items.Clear();
            productDSCB.AutoCompleteMode = AutoCompleteMode.Append;
            productDSCB.AutoCompleteSource = AutoCompleteSource.ListItems;
            foreach (SimpleTableClass item in products)
            {
                productDSCB.Items.Add(item.name);
            }

            classDSCB.Items.Clear();
            foreach (DishCategoryClass item in classes)
            {
                classDSCB.Items.Add(item.name);
            }

            searchTC.SelectedTab = defaultSearchTP;
        }


        // обновляем юзера и списки продуктов и величн
        private void RefreshLocalData()
        {
           // загружаем с базы всеееееее
           if (user != null)
            {
                user = db.GetUserByLoginPassword(user.login, user.password);
            }
           if (dish != null)
            {
                dish = db.GetDishById(dish.id);
            }
            classes = db.GetAllDishClasses();
            products = db.GetAllProducts();
            minDishList = db.GetAllMinDishs();
        }

        private void FillPanel(List<DishClass> list)
        {
            ItemsFLP.Controls.Clear();
            foreach (DishClass dc in list)
            {
                ItemsFLP.Controls.Add(new MinDishForm(this,dc));
            }
        }


        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void addIngToDSBtn_Click(object sender, EventArgs e)
        {
            SimpleTableClass prod = new SimpleTableClass();
            prod.name = productDSCB.Text;
            prod.id = -1;

            foreach (SimpleTableClass item in products)
            {
                if (item.name == prod.name) prod.id = item.id;
            }


            if (prod.id!=-1)
            {
                ingredientsDSFLP.Controls.Add(new SmartLabelUC(prod.name, true,prod.id));
            }
            else
            {
                if (user != null && user.trusted )
                {
                    DialogResult dialogResult = MessageBox.Show("В базе нет такого продукта. Добавить?", "Внимание!", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        db.AddProduct(prod.name);
                    }

                }
                else
                {
                    MessageBox.Show("В базе нет такого продукта.", "Внимание!");
                }
            }

        }

        private void backToAllDishes_Click(object sender, EventArgs e)
        {
            OpenAllDishes();
        }
        private void OpenAllDishes()
        {
            mainTC.SelectedTab = dishesTP;
        }
        private void addBookmarkBtn_Click(object sender, EventArgs e)
        {
            if (db.AddBookmark(user.id, dish.id))
            {
                addBookmarkBtn.Visible = false;
                removeBookmarkBtn.Visible = true;
            }
            
        }
        private void removeBookmarkBtn_Click(object sender, EventArgs e)
        {
            if (db.DeleteBookmark(user.id, dish.id))
            {
                {
                    addBookmarkBtn.Visible = true;
                    removeBookmarkBtn.Visible = false;
                }
            }
        }

        private void removeDishBtn_Click(object sender, EventArgs e)
        {
            db.DeleteAllDishIngredientsByDishId(dish.id);
            db.DeleteAllDishSubclassesByDihId(dish.id);
            db.DeleteBookmark(user.id, dish.id);
            db.DeleteTableById("Dish", dish.id);
            dish = null;
            RefreshLocalData();
            
            OpenHelpPage();
        }

        private void addDishBtn_Click(object sender, EventArgs e)
        {
            dish = null;

            EditDish();
        }

        private void EditDish()
        {
            RefreshLocalData();

            // очищаем елементы от данных, что были до этого
            editDishNameTB.Text = "Название блюда";
            editIngFLP.Controls.Clear();
            
            editSelectClassCB.Items.Clear();
            foreach (DishCategoryClass item in classes)
            {
                editSelectClassCB.Items.Add(item.name);
            }
            editProductCB.Items.Clear();
            foreach (SimpleTableClass item in products)
            {
                editProductCB.Items.Add(item.name);
            }
            editAddSubclassLBUC.SetList(null);
            editSubclassFLP.Controls.Clear();
            editIngFLP.Controls.Clear();
            editResultPhotoPB.Image = editResultPhotoPB.InitialImage;
            editValueTB.Text = "";
            editDescriptionUC.setText("");

            // если мы изменяем какое-то блюдо, то следует загрузить его данные
            // для удобного редактирования
            if (dish != null)
            {
                editDishNameTB.Text =dish.name;
                foreach (IngredientClass ic in dish.ingredients)
                {
                    SmartLabelUC iuc = new SmartLabelUC(ic.product.name,true,ic.product.id,ic.value);
                    editIngFLP.Controls.Add(iuc);
                }
                foreach (SubcategoryClass ic in dish.classes)
                {
                    SmartLabelUC iuc = new SmartLabelUC(ic.name,true,ic.id);
                    editSubclassFLP.Controls.Add(iuc);
                }

                if (dish.image != null)
                {
                    MemoryStream ms = new MemoryStream(dish.image);
                    editResultPhotoPB.Image = Image.FromStream(ms);
                    ms.Close();
                }
                  
                editDescriptionUC.setText(dish.description);
            }
            //  открываем панель редактирования
            mainTC.SelectedTab = editDishTP;
        }

        private void helpBtn_Click(object sender, EventArgs e)
        {
            OpenHelpPage();
        }

        private void OpenHelpPage()
        {
            mainTC.SelectedTab = helpTP;
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            LoginForm lf = new LoginForm(this);
            lf.ShowDialog(this);
            RefreshMainWindowUIElements();
        }

        private void startSearchBtn_Click(object sender, EventArgs e)
        {
            RefreshLocalData();
            List<DishClass> result = new List<DishClass>();
            SearchData sd = new SearchData();


            // заполнение класса поиска
            if (searchTC.SelectedTab == fastSearchTP)
            {
                // если выбран быстрый поиск, то проходим по всем элементам с
                // панели быстрого поиска и считываем значения их переключатлей
                foreach (Control item in fastSearchTP.Controls) 
                {
                    sd.reqSubclasses = sd.reqSubclasses.Concat(((DishClassLBUC)item).GetSelectedList()).ToList< SubcategoryClass>();
                }
                // больше нет критериев поиска
            }
            else
            {
                // заполняем подклассы
                // начинаем со 2го элемента, тк 1й - это просто надпись, а не элемент SmartLabel
                for (int i = 1; i < subclassDSFLP.Controls.Count; ++i)
                {
                    SubcategoryClass b = new SubcategoryClass();
                    b.name = subclassDSFLP.Controls[i].Text;
                    b.id = ((SmartLabelUC)subclassDSFLP.Controls[i]).itemId;
                    sd.reqSubclasses.Add(b);
                }
                // заполняем продукты
                for (int i = 1; i < ingredientsDSFLP.Controls.Count; ++i)
                {
                    SimpleTableClass b = new SimpleTableClass();
                    b.name = ingredientsDSFLP.Controls[i].Text;
                    b.id = ((SmartLabelUC)ingredientsDSFLP.Controls[i]).itemId;
                    sd.reqProducts.Add(b);
                }

                sd.reqWord = wordDSTB.Text;


            }

            // производим отбор подходящих блюд
            foreach (DishClass item in minDishList)
            {
                if (sd.DishIsValid(item))
                    result.Add(item);
            }
            OpenAllDishes();
            FillPanel(result);

        }

        private void addSubclassToDSBtn_Click(object sender, EventArgs e)
        {
            foreach (SubcategoryClass item in subclassDSUC.GetSelectedList())
            {
                subclassDSFLP.Controls.Add(new SmartLabelUC(item.name, true,item.id));
            }
        }

        private void classDSCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            string className = classDSCB.Text;
            DishCategoryClass dcc = new DishCategoryClass();
            foreach (DishCategoryClass item in classes)
            {
                if (className == item.name)
                    subclassDSUC.SetList(item);
            }

        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            user = null;
            RefreshMainWindowUIElements();
        }

        private void bookmarkBtn_Click(object sender, EventArgs e)
        {
            List<DishClass> result = new List<DishClass>();
            List<int> dishesFromBookmaek = db.GetAllDishIdFromUserBookmarks(user.id);
            foreach (DishClass item in minDishList)  
            {
                if (dishesFromBookmaek.IndexOf(item.id) != -1)
                    result.Add(item);
            }
            FillPanel(result);
            OpenAllDishes();

        }

        private void settingsBtn_Click(object sender, EventArgs e)
        {

            SettingsForm sf = new SettingsForm();
            sf.ShowDialog();
            ReloadSettings();
        }

        private void editValueTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void editSelectClassCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            string className = editSelectClassCB.Text;
            DishCategoryClass dcc = new DishCategoryClass();
            foreach (DishCategoryClass item in classes)
            {
                if (className == item.name)
                    editAddSubclassLBUC.SetList(item);
            }
        }

        private void productDSCB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void saveDishBtn_Click(object sender, EventArgs e)
        {
            // добавляем блюдо в базу
            DishClass newDish = new DishClass();
            newDish.name = editDishNameTB.Text;
            newDish.description = editDescriptionUC.getText();
            newDish.user_id = user.id;
            if (editResultPhotoPB.Image != null)
            {
                MemoryStream ms = new MemoryStream();
                editResultPhotoPB.Image.Save(ms, editResultPhotoPB.Image.RawFormat);
                newDish.image = ms.GetBuffer();
                ms.Close();
            }
            
            if (dish==null)
                newDish.id = db.AddDish(newDish);
            else
            {
                newDish.id = dish.id;
                db.UpdateDish(newDish);
            }


            if (newDish.id != -1)
            {
                // стираем старые подклассы 
                db.DeleteAllDishSubclassesByDihId(newDish.id);
                // привязываем подклассы к блюду 
                foreach (SmartLabelUC item in editSubclassFLP.Controls)
                {
                    db.AddLink(newDish.id, item.itemId);
                }

                // очищаем старые ингредиенты
                db.DeleteAllDishIngredientsByDishId(newDish.id);
                // создаем и привязываем ингридиенты к блюду
                foreach (SmartLabelUC item in editIngFLP.Controls)
                {
                    IngredientClass b = new IngredientClass();
                    b.dish_id = newDish.id;
                    b.product.id = item.itemId;
                    b.value = item.secondWord;
                    db.AddIngredient(b);
                }
            }

            // считываем послностью с ингридиентами и подклассами
            dish = db.GetDishById(newDish.id);

            OpenDish();

        }

        private void addSubclassesBtn_Click(object sender, EventArgs e)
        {
            foreach(SubcategoryClass item in editAddSubclassLBUC.GetSelectedList())
            {
                editSubclassFLP.Controls.Add(new SmartLabelUC(item.name, true, item.id));
            }
        }

        private void editDishBtn_Click(object sender, EventArgs e)
        {

            EditDish();
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void fastSearchTP_Click(object sender, EventArgs e)
        {

        }
    }
}
