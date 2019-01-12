using System;
using System.Linq;
using System.Xml.Linq;
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

        public Tema() { }

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

        public void CreateEntityFromElement(XElement elem)
        {
            Id = elem.Attribute("id").Value;
            Description = elem.Descendants("description").First().Value;
            Deadline = Int32.Parse(elem.Descendants("deadline").First().Value);
            StartDate = Int32.Parse(elem.Descendants("startdate").First().Value);
        }

        public XElement CreateElementFromEntity()
        {
            var tema = new XElement("tema");
            tema.Add(new XAttribute("id", Id));
            tema.Add(new XElement("description", Description));
            tema.Add(new XElement("deadline", Deadline));
            tema.Add(new XElement("startdate", StartDate));
            return tema;
        }
    }
}
