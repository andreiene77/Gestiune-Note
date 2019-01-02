using System;
using System.Collections.Generic;

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


    }
}
