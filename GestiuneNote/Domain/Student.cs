using System;
using System.Linq;
using System.Xml.Linq;

namespace GestiuneNote.Domain
{
    public class Student : IHasID<string>
    {
        public string Id { get; set; }
        public string Nume { get; set; }
        public int Grupa { get; set; }
        public string Email { get; set; }
        public string Prof { get; set; }

        public Student(string id, string nume, int grupa, string email, string prof)
        {
            Id = id;
            Nume = nume;
            Grupa = grupa;
            Email = email;
            Prof = prof;
        }
        public Student() { }

        public override bool Equals(object obj)
        {
            return obj is Student student &&
                   Id == student.Id &&
                   Nume == student.Nume &&
                   Grupa == student.Grupa &&
                   Email == student.Email &&
                   Prof == student.Prof;
        }

        public override int GetHashCode() => HashCode.Combine(Id, Nume, Grupa, Email, Prof);

        public override string ToString() => Id + ", " + Nume + ", " + Grupa + ", " + Email + ", " + Prof;

        public void CreateEntityFromElement(XElement elem)
        {
            Id = elem.Attribute("id").Value;
            Nume = elem.Descendants("nume").First().Value;
            Grupa = Int32.Parse(elem.Descendants("grupa").First().Value);
            Email = elem.Descendants("email").First().Value;
            Prof = elem.Descendants("prof").First().Value;
        }

        public XElement CreateElementFromEntity()
        {
            var student = new XElement("student");
            student.Add(new XAttribute("id", Id));
            student.Add(new XElement("nume", Nume));
            student.Add(new XElement("grupa", Grupa));
            student.Add(new XElement("email", Email));
            student.Add(new XElement("prof", Prof));
            return student;
        }
    }
}
