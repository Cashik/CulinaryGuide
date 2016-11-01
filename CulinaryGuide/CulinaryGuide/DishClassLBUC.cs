using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CulinaryGuide
{
    public partial class DishClassLBUC : UserControl
    {
        //List<SimpleTableClass> items;
        DishCategoryClass dish_class;
        public DishClassLBUC()
        {
            InitializeComponent();
            panel1.Visible = false;
        }
        public DishClassLBUC(DishCategoryClass _dish_class,bool visible_class_name=false)
        {
            InitializeComponent();
            panel1.Visible = visible_class_name;
            
            SetList(_dish_class);

        }

        public void SetList(DishCategoryClass _dish_class)
        {
            panel2.Controls.Clear();
            if (_dish_class != null)
            {
                dish_class = _dish_class;
                label1.Text = dish_class.name;
                foreach (SimpleTableClass sub_class in dish_class.subCategoryElements)
                {
                    CheckBox cb = new CheckBox();
                    cb.Appearance = Appearance.Button;
                    cb.FlatStyle = FlatStyle.Flat;
                    cb.FlatAppearance.BorderSize = 0;
                    cb.BackColor = Color.SeaGreen;
                    cb.FlatStyle = FlatStyle.Flat;
                    cb.FlatAppearance.MouseDownBackColor = Color.PaleGreen;
                    cb.FlatAppearance.CheckedBackColor = Color.LightGreen;

                    cb.Dock = DockStyle.Top;

                    cb.Text = sub_class.name;
                    panel2.Controls.Add(cb);
                }
            }
            else
            {
                label1.Text = "";
            }
        }
        public List<SubcategoryClass> GetSelectedList()
        {
            List<SubcategoryClass> result = new List<SubcategoryClass>();

            for (int i = 0; i < panel2.Controls.Count; i++)
            {
                if (((CheckBox)panel2.Controls[i]).Checked)
                {
                    result.Add(new SubcategoryClass((dish_class.subCategoryElements[i].id), panel2.Controls[i].Text,dish_class.id));
                }
            }

            return result;
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }
    }
}
