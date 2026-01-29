using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMICalculatorApp
{
    class Person
    {
        public string Gender { get; set; }
        public double BMI { get; set; }
        public string HealthStatus { get; set; }

        public Person(string gender,  double BMI, string healthStatus)
        {
            this.Gender = gender;
            this.BMI = BMI;
            this.HealthStatus = healthStatus;
        }

    }
}
