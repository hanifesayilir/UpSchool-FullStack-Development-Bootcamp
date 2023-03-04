using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpSchool.Domain.Utilities
{
    public class PasswordMemento
    {

        private string Password { get; set; } = string.Empty;

        public PasswordMemento(string password)
        {
            this.Password = Password;
        }
    }
}
