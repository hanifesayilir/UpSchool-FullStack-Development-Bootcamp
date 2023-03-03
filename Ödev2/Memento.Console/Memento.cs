using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rollback.Console
{
    public class Memento
    {
        private Originator originator;
        private List<string> States;
        private int Position = 0;


        public Memento()
        {
        States = new List<string>();
        }

        public void SetOriginator(Originator originator) { this.originator = originator; }

        public void Save()
        {
            string State = originator.GetState();
            System.Console.WriteLine("Memento: saving state: " + State);
            States.Add(State);
            Position++;
        }

        public void Undo()
        {
            int CurrentPosition = Position;
            CurrentPosition -= 2;
            string PreviousState = States[CurrentPosition];
            originator.SetState(PreviousState);
            System.Console.WriteLine("Memento: undoing to: " + PreviousState);
        }
    }
}
