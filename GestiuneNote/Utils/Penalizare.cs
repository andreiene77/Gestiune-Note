using System;
using GestiuneNote.Domain;

namespace GestiuneNote
{
    public class Penalizare
    {
        private readonly double valoare;
        private readonly int saptamanaCurenta;
        private readonly int deadline;

        public Penalizare(int valoare, int saptamanaCurenta, int deadline)
        {
            this.valoare = valoare;
            this.saptamanaCurenta = saptamanaCurenta;
            this.deadline = deadline;
        }

        public double CalculatePenalizare => (saptamanaCurenta - deadline) > 2 ? 10 : (saptamanaCurenta - deadline) > 0 ? (saptamanaCurenta - deadline) * 2.5 : 0;

        public double CalculateNotaMax => 10 - CalculatePenalizare;

        public double CalculateNota => valoare - CalculatePenalizare;
    }
}
