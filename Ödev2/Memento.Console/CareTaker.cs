using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rollback.Console
{
    public class CareTaker
    {
        private readonly Memento memento;

        private bool deneme  = false;

        public void SetDeneme(bool yen)
        {
            this.deneme = yen;
        }

      

      public CareTaker(Memento memento) { this.memento = memento; }

        public void run()
        {
            if (deneme) memento.Undo();
            else memento.Save();
        }
    }
}
