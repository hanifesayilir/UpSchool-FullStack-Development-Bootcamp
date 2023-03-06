using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpSchool.Domain.Utilities
{
    public class PasswordMemento
    {

        private string Password { get;  } = string.Empty;

        public PasswordMemento(string password)
        {
            this.Password = password;
        }

        public string GetState()
        {
            return Password;
        }

        public override string ToString()
        {
            return this.Password;
        }
    
    }
}
