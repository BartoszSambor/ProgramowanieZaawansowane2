using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace passwordReq
{
    public partial class UserControl1 : UserControl
    {

        string specialCharacters = string.Empty;
        List<(string, Func<string, bool>)> actions = new List<(string, Func<string, bool>)>();
        public UserControl1()
        {
            InitializeComponent();
            checkedListBox1.Items.Clear();
            this.RequireCharacters(10);
            this.RequireNumeric(2);
            this.RequireSpecialCharacters(2);
            this.RequireUppercase(2);
            foreach (var action in actions)
            {
                checkedListBox1.Items.Add(action.Item1);
            }
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void ValidatePassword()
        {
            string text = textBox1.Text;

            bool result = true;
            int i = 0;
            foreach (var f in actions)
            {
                if (f.Item2(textBox1.Text) == false)
                {
                    result = false;
                    checkedListBox1.SetItemChecked(i, false);
                }
                else
                {
                    checkedListBox1.SetItemChecked(i, true);
                }
                i++;
            }
        }



        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            ValidatePassword();
        }

        public void Add(string description, Func<string, bool> func)
        {
            actions.Add((description, func));
            checkedListBox1.Items.Add(description);
        }

        public void RequireCharacters(int count)
        {
            Add($"at least {count} characters", new Func<string, bool>(t =>
            {
                return t.Length >= count;
            }));
        }

        public void RequireUppercase(int count)
        {
            Add($"at least {count} uppercase characters", new Func<string, bool>(t =>
            {
                return t.Count(char.IsUpper) >= count;
            }));
        }

        public void RequireNumeric(int count)
        {
            Add($"at least {count} numeric characters", new Func<string, bool>(t =>
            {
                return t.Count(char.IsNumber) >= count;
            }));
        }

        public void RequireSpecialCharacters(int count)
        {
            Add($"at least {count} special characters", new Func<string, bool>(t =>
            {
                return t.Count(char.IsPunctuation) >= count;
            }));
        }
        public void SetSpecialCharacters(string characters)
        {
            specialCharacters = characters;
        }

        
    }
}
