using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Week5Lab.BL;
using System.IO;
using System.Threading.Tasks;

namespace Week5Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            int option;
            float merit = 0;
            bool scholarshipcheck = false;
            List<Student> students = new List<Student>();
            ReadUserData( students);
            option = Menu();
            if(option == 1)
            {
                AddStudentData(students);
            }
            else if ( option == 2)
            {
                merit = students[0].CalculateMerit();
                Console.WriteLine(" merit = " + merit + "%");
            }
            else if (option == 3)
            {
              scholarshipcheck = students[0].IsEligbleForScholarship(merit);
                if(scholarshipcheck == true)
                {
                    Console.WriteLine("You are eligible for scholarship");
                }
                else
                {
                    Console.WriteLine("You Are Not eligible");
                }
            }
            else if (option == 4)
            {
                DisplayUserData( students);
            }
            else if (option == 5)
            {

            }
            else if (option == 6)
            {

            }
            else if (option == 7)
            {

            }
            Console.ReadKey();



        }

        static int Menu()
        {
            int option;
            Console.WriteLine("1.  Add a Student");
            Console.WriteLine("2.  Add Degree Program");
            Console.WriteLine("3.  Generate Merit");
            Console.WriteLine("4.  View Registered Students");
            Console.WriteLine("5.  View Student of a Specific Program");
            Console.WriteLine("6.  Register Subjects for a specified Student");
            Console.WriteLine("7.  Calculate Fees for All Registered Students");
            Console.WriteLine("");
            option = int.Parse(Console.ReadLine());
            return option;
        }
        static void ReadUserData( List<Student> students)
        {
            string studentPath = @"E:\SecondSemester\Week5Lab\StudentFile.txt";
            if (File.Exists(studentPath))
            {
                using (StreamReader file = new StreamReader(studentPath))
                {
                    string record;
                    while ((record = file.ReadLine()) != null)
                    {
                        string[] fields = record.Split(',');
                        if (fields.Length >= 9)
                        {
                            string Name = fields[0];
                            int rollNumber = int.Parse(fields[1]);
                            float cGPA = float.Parse(fields[2]);
                            int matricMarks = int.Parse(fields[3]);
                            int fscMarks = int.Parse(fields[4]);
                            int ecatMarks = int.Parse(fields[5]);
                            string homeTown = fields[6];
                            bool isHotellite = bool.Parse(fields[7]);
                            bool isTakingScholarship = bool.Parse(fields[8]);
                            Student student = new Student(Name, rollNumber, cGPA, matricMarks, fscMarks, ecatMarks, homeTown, isHotellite, isTakingScholarship);
                            students.Add(student);
                        }
                        else
                        {
                            Console.WriteLine($"Invalid record: {record}");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine($"File does not exist: {studentPath}");
            }
        }
        static void DisplayUserData(List<Student> students)
        {
            Console.Clear();           
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"{i + 1}:    {students[i].Name}, {students[i].rollNumber}, {students[i].cGPA}, {students[i].matricMarks}, {students[i].fscMarks}, {students[i].ecatMarks}, {students[i].homeTown}, {students[i].isHostellite}, {students[i].isTakingScholarship}");
            }
        }
       
        static void AddStudentData(List<Student> students)
        {
            Console.WriteLine("Enter Your Full Name");
            string Name = Console.ReadLine();
            Console.WriteLine("Enter Your Roll Number");
            int rollNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Your CGPA");
            float cGPA = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Your Matric Marks");
            int matricMarks = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Your FSC Marks");
            int fscMarks = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Your Ecat Marks");
            int ecatMarks = int.Parse(Console.ReadLine());
            Console.WriteLine("Ente Your Home Town (City)");
            string homeTown = Console.ReadLine();
            Console.WriteLine("Are You an Hostellite (True or False) ?");
            bool isHotellite = bool.Parse(Console.ReadLine());
            Console.WriteLine("Are You Taking Any Scholarship (True or False) ?");
            bool isTakingScholarship = bool.Parse(Console.ReadLine());

            Student student = new Student(Name, rollNumber, cGPA, matricMarks,fscMarks,ecatMarks,homeTown,isHotellite,isTakingScholarship);
            students.Add(student);
            using (StreamWriter file = new StreamWriter(@"E:\SecondSemester\Week5Lab\StudentFile.txt", true))
            {
                file.WriteLine($"{Name},{rollNumber},{cGPA},{matricMarks},{fscMarks},{ecatMarks},{homeTown},{isHotellite},{isTakingScholarship}");
            }
        }
    }
}
