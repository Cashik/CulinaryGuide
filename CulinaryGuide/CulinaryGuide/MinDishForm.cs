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
    public partial class MinDishForm : UserControl
    {
        MainForm mainForm;
        DishClass dc;
        public MinDishForm()
        {
            InitializeComponent();
        }
        public MinDishForm(MainForm _mainForm,DishClass _dc)
        {
            InitializeComponent();
            mainForm = _mainForm;
            dc = _dc;   
            nameLinkBtn.Text = _dc.name;

            int ingCount = 0;
            foreach(IngredientClass ic in _dc.ingredients)
            {
                ++ingCount;
                //выходим, тк элементы все-равно не вместяться на панели
                if (ingCount>=7 )
                {
                    moreThanSixIngLbl.Visible = true;
                    break;
                }
                else
                {
                    SmartLabelUC iuc = new SmartLabelUC(ic.product.name,false,ic.product.id,ic.value);
                    iuc.Size = new Size(95, 20);
                    ingredientsFLP.Controls.Add(iuc);
                }
            }

            descriptionLbl.Text = _dc.description;

            // TODO:backgrownd image
        }

        private void nameLinkBtn_Click(object sender, EventArgs e)
        {
            mainForm.dish = dc;
            mainForm.OpenDish();
        }
    }
}
