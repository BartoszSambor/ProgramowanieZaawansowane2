using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KomisBeta
{
    public partial class Menu : Form
    {
        AddForm addForm = null;
        SearchForm searchForm = null;
        ReservationList reservationList = null;
        Car selectedCar = null;
        public Menu()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            this.Size = new Size(800, 460);

            if (!(searchForm is null))
            {
                searchForm.Hide();
            }
            if (!(reservationList is null))
            {
                reservationList.Hide();
            }
            if (addForm is null)
            {
                addForm = new AddForm();
                LoadChild(addForm);
                addForm.FormClosed += delegate { this.addForm = null; };
            }
            addForm.Show();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            this.Size = new Size(1120, 800);
            if(!(addForm is null))
            {
                addForm.Hide();
            }
            if (!(reservationList is null))
            {
                reservationList.Hide();
            }
            if (searchForm is null)
            {
                searchForm = new SearchForm(this);
                LoadChild(searchForm);
                searchForm.FormClosed += delegate { this.searchForm = null; };

            }
            searchForm.Show();
        }

        private void CalendarButton_Click(object sender, EventArgs e)
        {
            this.Size = new Size(600, 480);

            if (!(addForm is null))
            {
                addForm.Hide();
            }
            if (!(searchForm is null))
            {
                searchForm.Hide();
            }
            if (reservationList is null)
            {
                reservationList = new ReservationList();
                LoadChild(reservationList);
                reservationList.FormClosed += delegate { this.reservationList = null; };

            }
            reservationList.SelectCar(selectedCar);
            reservationList.Show();
        }

        public void SelectCar(Car car)
        {
            this.selectedCar = car;
            CalendarButton_Click(this, new EventArgs());
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        // fill panel with borderless form provided
        private void LoadChild(Form child)
        {
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Dock = DockStyle.Fill;
            panel2.Controls.Add(child);
            panel2.Tag = child;
            child.BringToFront();
            child.Show();
        }
    }
}
