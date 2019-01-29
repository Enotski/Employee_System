using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLib
{
    [Serializable]
    public sealed class Programmer : SalariedEmployee
    {
        private string project;
        public string Project
        {
            get => project;
            set => project = value ?? "N/A";
        }
        public Programmer(string _name, int _id, double _salary, string _project) : base(_name, _id, _salary)
        {
            Project = _project;
        }

        public override double Pay()
        {
            return base.Pay();
        }
        public override string ToString()
        {
            return string.Format($"{base.ToString()}Project{null,-6}{Project}\r\n");
        }
    }
}
