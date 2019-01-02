using System;
using System.Collections.Generic;
using System.Linq;
using GestiuneNote.Domain;

namespace GestiuneNote
{
    public class ServiceNote
    {
        private Repo<Nota, KeyValuePair<string, string>> repositoryNote;
        private Repo<Student, string> repositoryStudent;
        private Repo<Tema, string> repositoryTema;
        public int SaptamanaCurenta { get; set; }

        public ServiceNote(Repo<Nota, KeyValuePair<string, string>> repoNote, Repo<Student, string> repoStud, Repo<Tema, string> repoTema)
        {
            repositoryNote = repoNote;
            repositoryStudent = repoStud;
            repositoryTema = repoTema;
        }

        public Penalizare Add(string idStud, string idTema, string valoare, string feedback)
        {
            KeyValuePair<string, string> id = new KeyValuePair<string, string>(idStud, idTema);
            if (repositoryStudent.FindOne(idStud).Equals(null)) { throw new Exception("Student inexistent!"); }
            Tema tema = repositoryTema.FindOne(idTema);
            if (tema.Equals(null)) { throw new Exception("Tema inexistenta!"); }
            //try
            //{
                if(!(repositoryNote.FindOne(id) == default(Nota)))
                    throw new Exception("Studentul are deja o nota la aceasta tema!");
            //}
            //catch (Exception)
            //{
                Penalizare pen = new Penalizare(int.Parse(valoare), SaptamanaCurenta, tema.Deadline);
                Nota n = new Nota(id, pen.CalculateNota, SaptamanaCurenta, feedback);
                repositoryNote.Save(n);
                return pen;
            //}
        }

        public List<Nota> GetNote() => repositoryNote.Entities.Values.ToList();
        public List<Student> GetStuds() => repositoryStudent.Entities.Values.ToList();
    }
}
