using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace EmployeeLib
{
    public sealed class PayrollGenerator
    {

        //output file on console
        public void ShowData(string path)
        {
            using (StreamReader rdr = new StreamReader(path))
            {
                while (!rdr.EndOfStream)
                {
                    Console.WriteLine(rdr.ReadLine());
                }
                rdr.Close();
            }

        }
        // output data in file fileData
        public void OutDataInFile(string path, bool key, ref List<Employee> empl)
        {
            int i = 1;
            using (StreamWriter wrtr = new StreamWriter(path, key))
            {
                wrtr.WriteLine($"|    Last modified    |\r\n| {DateTime.Now:dd.MM.yyyy} | {DateTime.Now:HH:mm}  |\r\n.......................\r\n.......................\r\n");
                foreach (Employee e in empl)
                {
                    wrtr.WriteLine(String.Format($"{e}Pay{null,-10}{e.Pay():c2}"));
                    wrtr.WriteLine($"======================[{i}]");
                    i++;
                }
                wrtr.Close();
            }
        }
        // output check in file filePayCheck
        public void OutPayCheckInFile(string path, ref List<Employee> empl)
        {
            using (StreamWriter wrtr = new StreamWriter(path, false))
            {
                wrtr.WriteLine($"|Paycheck|\r\n|{DateTime.Now:MM.yyyy} |\r\n.......................\r\n=======================\r\n.......................\r\n");
                foreach (Employee e in empl)
                {
                    wrtr.WriteLine(String.Format($"Name{null,9}{e.Name}{null,3}\r\nSSN{null,10}{e.ID:#-##-#}\r\n\nPay{null,10}{e.Pay():C2}"));
                    wrtr.WriteLine("......................." + Environment.NewLine);
                }
                wrtr.Close();
            }
        }
        // serealisation in file fileData.dat
        public void SerializeEmpl(string path, bool key, ref List<Employee> empl)
        {
            BinaryFormatter bf = new BinaryFormatter();
            if (key == true && new FileInfo(path).Length != 0)
            {
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {

                    empl.AddRange((List<Employee>)bf.Deserialize(fs));
                    fs.Close();
                }
                using (FileStream fs = new FileStream(path, FileMode.Truncate, FileAccess.ReadWrite))
                {
                    bf.Serialize(fs, empl);
                    fs.Close();
                }
            }
            else
            {
                using (FileStream fs = new FileStream(path, FileMode.Truncate, FileAccess.ReadWrite))
                {
                    bf.Serialize(fs, empl);
                    fs.Close();
                }
            }
        }
        // deserealisation from file fileData.dat
        public List<Employee> DeSerializeEmpl(string path, ref List<Employee> empl)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite))
            {
                empl = (List<Employee>)bf.Deserialize(fs);
                fs.Close();
            }

            return empl;
        }
    }
}
