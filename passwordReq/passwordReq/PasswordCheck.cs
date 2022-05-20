using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace passwordReq
{
    internal class PasswordCheck
    {
        private string password;
        private int minLength;
        private string specialCharacters;
        public string Password { get { return password; } set { password = value; } }
        public int MinimumLenght { 
            get { return minLength; } 
            set {
                if (value < 0)
                {
                    throw new ArgumentException("Minimum length can't be negative");
                }
                else
                {
                    minLength = value;
                }
            } 
        }

        public PasswordCheck()
        {
            minLength = 8;
            specialCharacters = "!@#$%^&*()_+";
            password = String.Empty;
        }
        
        public string SpecialCharacters { get { return specialCharacters; } set { specialCharacters = value; } }

        public bool CorrectLength()
        {
            return this.password.Length >= this.minLength;
        }

        public bool ContainSpecialCharacter()
        {
            return this.password.Any(c => specialCharacters.Contains(c));
        }

        public bool ContainDigit()
        {
            return this.password.Any(char.IsDigit);
        }

        public bool ContainUpperCase()
        {
            return this.password.Any(char.IsUpper);
        }

        public bool IsValid() {
            return this.ContainDigit() && this.ContainSpecialCharacter() && this.ContainUpperCase() && this.CorrectLength();
        }
        
        
        
    }
}
