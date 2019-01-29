using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLib
{
    //guard
    [Serializable]
    public sealed class Guard : HourlyEmployee
    {
        private string weapon;

        public string Weapon
        {
            get => weapon;
            set => weapon = value ?? "N/A";
        }
        public Guard(string _name, int _id, int _hours, double _rate, string _weapon) : base(_name, _id, _hours, _rate)
        {
            Weapon = _weapon;
        }
        public override double Pay()
        {
            return base.Pay();
        }
        public override string ToString()
        {
            return string.Format($"{base.ToString()}Weapon{null,-7}{Weapon}\r\n");
        }
    }
}
