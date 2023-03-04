using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpSchool.Domain.Utilities
{
    public class CareTaker
    {
        private List<PasswordMemento> passwordMementoList = new List<PasswordMemento>();

        public void Add(PasswordMemento state)
        {
            passwordMementoList.Add(state);
        }

        public PasswordMemento Get(int index)
        {
            return passwordMementoList[index];
        }

    }
}
