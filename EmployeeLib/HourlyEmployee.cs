using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLib
{
    [Serializable]
    public class HourlyEmployee : Employee
    {
        public const int OVERTIME_THREESHOLD = 40;
        public const double OVERTIME_FACTOR = 1.5;
        private double rate; // ставка
        private int hours;
        public int Hours
        {
            get => hours;
            set => hours = value > 0 ? value : 0;
        }
        public double Rate
        {
            get => rate;
            set => rate = value > 0.0 ? value : 0.0;
        }
        public HourlyEmployee(string _name, int _id, int _hours, double _rate) : base(_id, _name)
        {
            Hours = _hours;
            Rate = _rate;
        }

        public override double Pay()
        {
            if (Hours < OVERTIME_THREESHOLD)
            {
                return Rate * Hours;
            }
            return OVERTIME_THREESHOLD * Rate + (Hours - OVERTIME_THREESHOLD) *
                Rate * OVERTIME_FACTOR;
        }
        public override string ToString()
        {
            return string.Format($"{base.ToString()}Rate{null,-9}{Rate}\r\nHours{null,-8}{Hours}\r\n");
        }
    }
}
