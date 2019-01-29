using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EmployeeLib
{
    // admin
    public sealed class Admin
    {
        static PayrollGenerator pGen = new PayrollGenerator();

        static public void AddEmployee(ref List<Employee> empl)
        {
            char ch;
            int count, id, hr;
            double rate, salary;
            string name, prop;
            Console.WriteLine(":::::Payroll System:::::\n\n");
            Console.WriteLine("Input count of employees: ");
            count = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < count;)
            {
                Console.Clear();
                Console.WriteLine(":::::Payroll System:::::\n\n");
                Console.WriteLine("1.Programmer\n2.Guard\n3.TeamLead");
                switch (ch = Convert.ToChar(Console.ReadLine()))
                {
                    case '1': // Programmer
                        Console.Write("Name: ");
                        name = Console.ReadLine();
                        Console.Write("SSN [##-#-##]: ");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Salary: ");
                        salary = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Project: ");
                        prop = Console.ReadLine();
                        empl.Add(new Programmer(name, id, salary, prop));
                        i++;
                        break;

                    case '2': // Guard
                        Console.WriteLine("Name: ");
                        name = Console.ReadLine();
                        Console.Write("SSN [##-#-##]: ");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Work hours: ");
                        hr = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Rate: ");
                        rate = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Weapoon: ");
                        prop = Console.ReadLine();
                        empl.Add(new Guard(name, id, hr, rate, prop));
                        i++;
                        break;

                    case '3': // TeamLead
                        Console.Write("Name: ");
                        name = Console.ReadLine();
                        Console.Write("SSN [##-#-##]: ");
                        id = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Salary: ");
                        salary = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Project: ");
                        prop = Console.ReadLine();
                        empl.Add(new TeamLead(name, id, salary, prop));
                        i++;
                        break;

                    default:
                        Console.WriteLine("error key");
                        break;
                }
            }
        }
        static public void DeleteEmployee(ref List<Employee> empl)
        {
            int num, i = 1;
            while (true)
            {
                Console.WriteLine(":::::Payroll System:::::\n\n");
                foreach (Employee e in empl)
                {
                    Console.WriteLine($"==========[{i}]==========");
                    Console.WriteLine(String.Format($"{e}Pay{null,-10}{e.Pay():c2}"));
                    i++;
                }
                Console.WriteLine("\n~~~~~~~~~~~~~~~~\nInput sequence number of employee: ");
                num = Convert.ToInt32(Console.ReadLine());
                if ((num <= empl.Count) || (num > 0))
                {
                    empl.Remove(empl.ElementAt(num - 1));
                    return;
                }
                Console.WriteLine("error key");
                Console.ReadLine();
                Console.Clear();
            }
        }
        static public void OutputOnConsole(string path_txt, ref List<Employee> empl)
        {
            // local
            int i = 1;
            Console.WriteLine(":::::Payroll System:::::\n\n");
            Console.WriteLine("~~~~~Local~~~~~\n");
            foreach (Employee e in empl)
            {
                Console.WriteLine($"==========[{i}]==========");
                Console.WriteLine(String.Format($"{e}Pay{null,-10}{e.Pay():c2}"));
                i++;
            }

            // in file
            Console.WriteLine("~~~~~In file~~~~~\n");
            pGen.ShowData(path_txt);
        }
        static public void OutputFilesOnConsole()
        {
            string fileData = @"D:\Employees\employeesData.txt";
            string filePayCheck = @"D:\Employees\employeesPayCheck.txt";
            // in file
            Console.WriteLine("~~~~~In file <employeesData.txt>~~~~~\n");
            pGen.ShowData(fileData);
            Console.WriteLine("/n~~~~~In file <employeesPayCheck.txt>~~~~~\n");
            pGen.ShowData(filePayCheck);
        }

        static public void SaveInFiles(string path_txt, string path_dat, ref List<Employee> empl)
        {
            char ch;


            while (true)
            {
                Console.WriteLine(":::::Payroll System:::::\n\n");
                Console.WriteLine("1.Append data\n2.Rewrite data\n3.Exit\n");
                ch = Convert.ToChar(Console.ReadLine());
                Console.Clear();
                switch (ch)
                {
                    case '1':
                        pGen.SerializeEmpl(path_dat, true, ref empl);
                        pGen.OutDataInFile(path_txt, false, ref empl);
                        break;
                    case '2':
                        pGen.SerializeEmpl(path_dat, false, ref empl);
                        pGen.OutDataInFile(path_txt, false, ref empl);
                        break;
                    case '3':
                        return;
                    default:
                        Console.WriteLine("error key");
                        break;
                }
            }
        }
        static public void ClearFile(string path_txt, string path_dat, string path_payCheck)
        {
            StreamWriter wrtr;
            FileStream fs;
            char ch;
            while (true)
            {
                Console.WriteLine(":::::Payroll System:::::\n\n");
                Console.WriteLine("1.Clear all files\n2.Clear data file\n3.Clear pay check\n4.Exit\n");
                ch = Convert.ToChar(Console.ReadLine());

                Console.Clear();
                switch (ch)
                {
                    case '1':
                        fs = new FileStream(path_dat, FileMode.Truncate);
                        fs.Close();
                        fs = new FileStream(path_payCheck, FileMode.Truncate);
                        fs.Close();

                        wrtr = new StreamWriter(path_txt, false);
                        wrtr.WriteLine($"|    Last modified    |\r\n| {DateTime.Now:dd.MM.yyyy} | {DateTime.Now:HH:mm}  |\r\n.......................\r\n.......................\r\n");
                        wrtr.WriteLine($"======================[{0}]");
                        wrtr.Close();
                        break;
                    case '2':
                        fs = new FileStream(path_dat, FileMode.Truncate);
                        fs.Close();

                        wrtr = new StreamWriter(path_txt, false);
                        wrtr.WriteLine($"|    Last modified    |\r\n| {DateTime.Now:dd.MM.yyyy} | {DateTime.Now:HH:mm}  |\r\n.......................\r\n.......................\r\n");
                        wrtr.WriteLine($"======================[{0}]");
                        wrtr.Close();
                        break;
                    case '3':
                        fs = new FileStream(path_payCheck, FileMode.Truncate);
                        fs.Close();
                        break;
                    case '4':
                        return;
                    default:
                        Console.WriteLine("error key");
                        break;
                }
            }
        }
        static public void PrintPayCheck(string path, ref List<Employee> empl)
        {

            pGen.OutPayCheckInFile(path, ref empl);
            pGen.ShowData(path);
        }

        static public void Config(ref List<Employee> empl)
        {
            int i = 1, choise, indx;
            foreach (Employee e in empl)
            {
                Console.WriteLine($"==========[{i}]==========");
                Console.WriteLine(String.Format($"{e}Pay{null,-10}{e.Pay():c2}"));
                i++;
            }
            Console.WriteLine("\n");
            indx = Convert.ToInt32(Console.ReadLine());
            Employee loc_ob = empl.ElementAt(indx - 1);
            Console.Clear();

            if (loc_ob is Programmer)
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine(((Programmer)loc_ob).ToString());
                    Console.WriteLine($"1.Name\n2.SSN\n3.Salary\n4.Project\n5.Apply");
                    choise = Convert.ToInt32(Console.ReadLine());
                    switch (choise)
                    {
                        case 1:
                            Console.Write("Name: ");
                            ((Programmer)loc_ob).Name = Console.ReadLine();
                            break;
                        case 2:
                            Console.Write("SSN [##-#-##]: ");
                            ((Programmer)loc_ob).ID = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 3:
                            Console.Write("Salary: ");
                            ((Programmer)loc_ob).Salary = Convert.ToDouble(Console.ReadLine());
                            break;
                        case 4:
                            Console.Write("Project: ");
                            ((Programmer)loc_ob).Project = Console.ReadLine();
                            break;
                        case 5:
                            empl.Remove(empl.ElementAt(indx - 1));
                            empl.Insert(indx - 1, loc_ob);
                            return;
                        default:
                            break;
                    }
                }
            }
            else if (loc_ob is Guard)
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine(((Guard)loc_ob).ToString());
                    Console.WriteLine($"1.Name\n2.SSN\n3.Hours\n4.Rate\n5.Weapoon\n6.Apply");
                    choise = Convert.ToInt32(Console.ReadLine());
                    switch (choise)
                    {
                        case 1:
                            Console.Write("Name: ");
                            ((Guard)loc_ob).Name = Console.ReadLine();
                            break;
                        case 2:
                            Console.Write("SSN [##-#-##]: ");
                            ((Guard)loc_ob).ID = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 3:
                            Console.Write("Hours: ");
                            ((Guard)loc_ob).Hours = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 4:
                            Console.Write("Rate: ");
                            ((Guard)loc_ob).Rate = Convert.ToDouble(Console.ReadLine());
                            break;
                        case 5:
                            Console.Write("Weapon: ");
                            ((Guard)loc_ob).Weapon = Console.ReadLine();
                            break;
                        case 6:
                            empl.Remove(empl.ElementAt(indx - 1));
                            empl.Insert(indx - 1, loc_ob);
                            return;
                        default:
                            break;
                    }
                }
            }
            else
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine(((TeamLead)loc_ob).ToString());
                    Console.WriteLine($"1.Name\n2.SSN\n3.Salary\n4.Division\n5.Apply");
                    choise = Convert.ToInt32(Console.ReadLine());
                    switch (choise)
                    {
                        case 1:
                            Console.Write("Name: ");
                            ((TeamLead)loc_ob).Name = Console.ReadLine();
                            break;
                        case 2:
                            Console.Write("SSN [##-#-##]: ");
                            ((TeamLead)loc_ob).ID = Convert.ToInt32(Console.ReadLine());
                            break;
                        case 3:
                            Console.Write("Salary: ");
                            ((TeamLead)loc_ob).Salary = Convert.ToDouble(Console.ReadLine());
                            break;
                        case 4:
                            Console.Write("Division: ");
                            ((TeamLead)loc_ob).Division = Console.ReadLine();
                            break;
                        case 5:
                            empl.Remove(empl.ElementAt(indx - 1));
                            empl.Insert(indx - 1, loc_ob);
                            return;
                        default:
                            break;
                    }
                }
            } // TeamLead
        }

        static public void Load(string path_dat, ref List<Employee> empl)
        {
            if (new FileInfo(path_dat).Length != 0)
            {
                empl = new PayrollGenerator().DeSerializeEmpl(path_dat, ref empl);
            }
        }
    }

}
