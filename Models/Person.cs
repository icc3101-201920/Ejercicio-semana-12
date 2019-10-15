using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Person
    {
        string name;
        string lastName;
        DateTime birthDate;
        string bio;
        string ocupation;

        public Person(string name, string lastName, DateTime birthDate, string bio, string ocupation)
        {
            this.name = name;
            this.lastName = lastName;
            this.birthDate = birthDate;
            this.bio = bio;
            this.ocupation = ocupation;
        }

        public string Name { get => name; set => name = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public DateTime BirthDate { get => birthDate; set => birthDate = value; }
        public string Bio { get => bio; set => bio = value; }
        public string Ocupation { get => ocupation; set => ocupation = value; }

        int maxLength()
        {
            if (Bio.Length > 20)
                return 20;
            else
                return Bio.Length;
        }
        public override string ToString()
        {
            return Name + " " + LastName+ ", DATA | Birthdate: " + BirthDate.ToShortDateString() + " | Ocupation: " + Ocupation + " | Bio: " + Bio.Substring(0, maxLength()) + "... |";
        }
    }
}
