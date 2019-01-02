using System;
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
    }
}
