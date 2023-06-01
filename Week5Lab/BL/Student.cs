using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5Lab.BL
{
    class Student
    {
        public string Name, homeTown;
        public int rollNumber, matricMarks, fscMarks, ecatMarks;
        public float cGPA;
        public bool isHostellite, isTakingScholarship;

        public Student(string Name,int rollNumber,float cGPA,int matricMarks,int fscMarks,int ecatMarks,string homeTown,bool isHostellite,bool isTakingScholarship)
        {
            this.Name = Name;
            this.rollNumber = rollNumber;
            this.cGPA = cGPA;
            this.matricMarks = matricMarks;
            this.fscMarks = fscMarks;
            this.ecatMarks = ecatMarks;
            this.homeTown = homeTown;
            this.isHostellite = isHostellite;
            this.isTakingScholarship = isTakingScholarship;  
        }
        public float CalculateMerit()
        {
            float merit;
            merit = ((fscMarks * 60) / 1100) + ((ecatMarks * 40) / 400);
            return merit;
        }
        public bool IsEligbleForScholarship(float merit)
        {
            if(merit >= 80 && isHostellite == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
