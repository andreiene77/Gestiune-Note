using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;

namespace GestiuneNote.Domain
{
    public class Nota : IHasID<KeyValuePair<string, string>>
    {
        public KeyValuePair<string, string> Id { get; set; }
        public double Valoare { get; set; }
        public int Data { get; set; }
        public string Feedback { get; set; }

        public Nota(KeyValuePair<string, string> id, double valoare, int data, string feedback)
        {
            Id = id;
            Valoare = valoare;
            Data = data;
            Feedback = feedback;
        }

        public Nota() { }

        public override int GetHashCode() => HashCode.Combine(Id, Valoare, Data, Feedback);

        public override string ToString() => Id + ", " + Valoare + ", " + Data + ", " + Feedback;

        public override bool Equals(object obj)
        {
            double EPSILON = 0.1;
            return obj is Nota nota &&
                   EqualityComparer<KeyValuePair<string, string>>.Default.Equals(Id, nota.Id) &&
                   Math.Abs(Valoare - nota.Valoare) < EPSILON &&
                   Data == nota.Data &&
                   Feedback == nota.Feedback;
        }

        public void CreateEntityFromElement(XElement elem)
        {
            string[] idPair = elem.Attribute("id").Value.Split('(', ')')[0].Split(',');
            Id = new KeyValuePair<string, string>(idPair[0], idPair[1]);
            Valoare = Double.Parse(elem.Descendants("valoare").First().Value);
            Data = Int32.Parse(elem.Descendants("date").First().Value);
            Feedback = elem.Descendants("feedback").First().Value;
        }

        public XElement CreateElementFromEntity()
        {
            var nota = new XElement("nota");
            var idString = "(" + Id.Key + ", " + Id.Value + ")";
            nota.Add(new XAttribute("id", idString));
            nota.Add(new XElement("valoare", Valoare));
            nota.Add(new XElement("date", Data));
            nota.Add(new XElement("feedback", Feedback));
            return nota;
        }
    }
}
