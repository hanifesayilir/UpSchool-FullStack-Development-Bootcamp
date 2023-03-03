
using Rollback.Console;
using System.Runtime.CompilerServices;

public class Deneme
{
    public static Originator originator;

    public static Memento memento;
    public static void Main(string[] args)
    {
        originator = new Originator("State 2");
        memento = originator.GetMemento();
        CareTaker careTaker = new CareTaker(memento);
        careTaker.SetDeneme(true);
        careTaker.run();
       
    }
}






   /*Originator originator = new Originator("STATE 1");
   Memento memento = originator.GetMemento();
    memento.Save();

Originator originator2 = new Originator("STATE 2");
Memento memento2 = originator2.GetMemento();
memento2.Save();

Originator originator3 = new Originator("STATE 3");
Memento memento3 = originator3.GetMemento();
memento3.Save();*/














