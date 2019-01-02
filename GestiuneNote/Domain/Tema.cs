using System;
using GestiuneNote.Domain;

namespace GestiuneNote
{
    public class Tema : IHasID<string>
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public int Deadline { get; set; }
        public int StartDate { get; set; }

        public Tema(string id, string description, int deadline, int startDate)
        {
            Id = id;
            Description = description;
            Deadline = deadline;
            StartDate = startDate;
        }

        public override bool Equals(object obj)
        {
            return obj is Tema tema &&
                   Id == tema.Id &&
                   Description == tema.Description &&
                   Deadline == tema.Deadline &&
                   StartDate == tema.StartDate;
        }

        public override int GetHashCode() => HashCode.Combine(Id, Description, Deadline, StartDate);

        public override string ToString() => Id + ", " + Description + ", " + Deadline + ", " + StartDate;
    }
}
