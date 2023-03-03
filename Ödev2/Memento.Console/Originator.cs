using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rollback.Console
{
    public class Originator
    {

        private string State = String.Empty;
        private Memento memento = new Memento();

        public Originator(string state)
        {
            this.State = state;
            memento.SetOriginator(this);
        }

        public string GetState()
        {
            return State;
        }

        public Memento GetMemento() { return memento; }

        public override string ToString() { return "Originator [tate= " + State + "]"; }

        public void SetState(string previousState)
        {
            this.State = previousState;
        }


    }
}
