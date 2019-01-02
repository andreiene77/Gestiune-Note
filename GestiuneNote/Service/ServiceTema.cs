using System;
using System.Collections.Generic;
using System.Linq;

namespace GestiuneNote
{
    public class ServiceTema
    {
        private Repo<Tema, string> Repository;
        public int SaptamanaCurenta { get; set; }

        public ServiceTema(Repo<Tema, string> repo) => Repository = repo;

        public void Add(string id, string description, string deadline)
        {
            Tema t = new Tema(id, description, int.Parse(deadline), SaptamanaCurenta);
            Repository.Save(t);
        }

        public void Postpone(string id, string nrSapt)
        {
            Tema t = Repository.FindOne(id);
            if (t.Deadline > SaptamanaCurenta)
            {
                t.Deadline += int.Parse(nrSapt);
            }
            else
            {
                throw new Exception("Dedline-ul a fost depasit! Tema nu mai poate fi prelungita.");
            }
        }

        public List<Tema> GetTeme() => Repository.Entities.Values.ToList();
    }
}
