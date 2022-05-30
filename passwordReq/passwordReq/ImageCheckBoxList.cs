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
    public partial class ImageCheckBoxList : UserControl
    {
        private PasswordCheck checker;

        public ImageCheckBoxList()
        {
            InitializeComponent();
            checker = new PasswordCheck();
        }

        public void UpdateCheckboxes(string text)
        {
            checker.Password = text;
            imageCheckBox1.IsChecked = checker.CorrectLength();
            imageCheckBox2.IsChecked = checker.ContainSpecialCharacter();
            imageCheckBox3.IsChecked = checker.ContainUpperCase();
            imageCheckBox4.IsChecked = checker.ContainDigit();
        }

        private void Refreshboxes()
        {
            imageCheckBox1.IsChecked = checker.CorrectLength();
            imageCheckBox2.IsChecked = checker.ContainSpecialCharacter();
            imageCheckBox3.IsChecked = checker.ContainUpperCase();
            imageCheckBox4.IsChecked = checker.ContainDigit();

        }

        public bool IsPasswordValid()
        {
            return checker.IsValid();
        }

        [Description("Minimum length"), Category("Data")]
        public int MinLength
        {
            get => checker.MinimumLenght;
            set {
                checker.MinimumLenght = value;
                imageCheckBox1.LabelText = "at least " + checker.MinimumLenght + " characters";
                Refreshboxes();
                }
        }

        [Description("Set of special characters"), Category("Data")]
        public string SpecialCharacters
        {
            get => checker.SpecialCharacters;
            set { checker.SpecialCharacters = value;
                Refreshboxes();
            }
        }
    }
}
