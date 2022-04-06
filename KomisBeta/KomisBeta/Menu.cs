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
            if(!(searchForm is null))
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
                addForm.FormClosed += delegate { this.addForm = null; };
            }
            addForm.Show();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
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
                searchForm.FormClosed += delegate { this.searchForm = null; };

            }
            searchForm.Show();
        }

        private void CalendarButton_Click(object sender, EventArgs e)
        {
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


    }
}
