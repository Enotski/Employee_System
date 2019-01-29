using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeLib
{
    [Serializable]
    public class SalariedEmployee : Employee
    {

        private double salary;
        public double Salary
        {
            get => salary;
            set => salary = value > 0 ? value : 0;
        }

        public SalariedEmployee(string _name, int _id, double _salary) : base(_id, _name)
        {
            Salary = _salary;
        }
        public override double Pay()
        {
            return Salary;
        }

        public override string ToString()
        {
            return string.Format($"{base.ToString()}Salary{null,-7}{Salary:C2}\r\n");
        }

    }
}
