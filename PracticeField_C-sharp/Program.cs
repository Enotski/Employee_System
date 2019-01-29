using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using EmployeeLib;


namespace PracticeField_C_sharp
{
    class Programm
    {
        static void Main(string[] args)
        {
            //string directory = @"D:\Employees";
            string fileData = @"employeesData.txt";
            string fileData_Dat = @"employeesData.dat";
            string filePayCheck = @"employeesPayCheck.txt";         

            int choise;

            List<Employee> employes = new List<Employee>();
            char[] ch = { '=', '[', ']', ' ', '\r', '\n'};
            
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-Us");
            while (true)
            {
                Console.Clear();
                Console.WriteLine(":::::Payroll System:::::\n\n");
                Console.WriteLine("1.Add employee\n2.Delete employee\n3.Output all employes\n4.Save data in file\n5.Clear file\n6.Print paycheck for mounth\n7.Config\n8.Load\n9.Exit\n");
                choise = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (choise)
                {
                    case 1: 
                        Admin.AddEmployee(ref employes);
                        break;
                    case 2:
                        if (employes.Count == 0)
                        {
                            Console.WriteLine("*No data*");
                            break;
                        }
                        Admin.DeleteEmployee(ref employes);
                        break;
                    case 3:
                        Admin.OutputOnConsole(fileData, ref employes);
                        break;
                    case 4:
                        if (employes.Count == 0)
                        {
                            Console.WriteLine("*No data*");
                            break;
                        }
                        Admin.SaveInFiles(fileData, fileData_Dat, ref employes);
                        break;
                    case 5:
                        Admin.ClearFile(fileData, fileData_Dat, filePayCheck);
                        break;
                    case 6:
                        if (employes.Count == 0)
                        {
                            Console.WriteLine("*No data*");
                            break;
                        }
                        Admin.PrintPayCheck(filePayCheck, ref employes);
                        break;
                    case 7:
                        if (employes.Count == 0)
                        {
                            Console.WriteLine("*No data*");
                            break;
                        }
                        Admin.Config(ref employes);
                        break;
                    case 8:
                        Admin.Load(fileData_Dat, ref employes);
                        break;
                    case 9:
                        Console.WriteLine("\n\n\t\tShutting down...\n\n");
                        Console.ReadLine();
                        return;
                    default:
                        Console.WriteLine("error key");
                        break;
                }

                Console.ReadLine();
            }
        }
    }
}
