using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UpSchool.Domain.Utilities
{
    public class CareTaker
    {
        private List<PasswordMemento> PasswordMementoList = new List<PasswordMemento>();


        public void Add(PasswordMemento state)
        {
            PasswordMementoList.Add(state);
            Console.WriteLine(PasswordMementoList.Count);
         
          for(int i=0;i<PasswordMementoList.Count;i++)
            {
                Console.WriteLine("add: "+i+" "+PasswordMementoList[i]);
            }
        }

        public PasswordMemento? Get()
        {


            if (PasswordMementoList.Count > 1)
            {
                PasswordMementoList.RemoveAt(PasswordMementoList.Count - 1);
               // Console.WriteLine("Sonra" + PasswordMementoList.Count);
                return PasswordMementoList.Last();
            }
            else if (PasswordMementoList.Count == 1)
            {
               var  last = PasswordMementoList.Last();
                PasswordMementoList.RemoveAt(PasswordMementoList.Count - 1);
                return last;
            } 
            else 
            {
                Console.WriteLine("Index dışı");
                return null;
            }
            
        }

        public int GetLength() 
        { 
            return PasswordMementoList.Count;
        }


    }
}

