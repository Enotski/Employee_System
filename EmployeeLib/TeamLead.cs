using System;

namespace EmployeeLib
{
    [Serializable]
    public sealed class TeamLead : SalariedEmployee
    {
        private string division;
        public string Division
        {
            get => division;
            set => division = value ?? "N/A";
        }
        public TeamLead(string _name, int _id, double _salary, string _division) : base(_name, _id, _salary)
        {
            Division = _division;
        }

        public override string ToString()
        {
            return string.Format($"{base.ToString()}Division{null,-5}{Division}\r\n");
        }
        public override double Pay()
        {
            return base.Pay();
        }
    }
}
