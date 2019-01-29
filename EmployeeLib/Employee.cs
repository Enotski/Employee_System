using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLib
{
    [Serializable]
    public abstract class Employee
    {
        private int id;
        private string name;
        public int ID
        {
            get => id;
            set => id = (value > 9999) && (value < 100000) ? value : 10000;
        }
        public string Name
        {
            get => name;
            set => name = value ?? "N/A";
        }
        public Employee(int _id, string _name)
        {
            ID = _id;
            Name = _name;
        }
        abstract public double Pay();

        public override string ToString()
        {
            return string.Format($"Position{null,-5}{GetType().Name}\r\nName{null,-9}{Name}\r\nSSN{null,-10}{ID:##-#-##}\r\n");
        }
    }
}
