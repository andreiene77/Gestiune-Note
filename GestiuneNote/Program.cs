using System.Collections.Generic;
using GestiuneNote.Domain;

namespace GestiuneNote
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlRepo<Student, string> repoStuds = new XmlRepo<Student, string>("studenti.xml");
            //AddStuds(repoStuds);

            XmlRepo<Tema, string> repoTeme = new XmlRepo<Tema, string>("teme.xml");
            XmlRepo<Nota, KeyValuePair<string, string>> repoNote = new XmlRepo<Nota, KeyValuePair<string, string>>("note.xml");

            ServiceTema temeBus = new ServiceTema(repoTeme);
            ServiceNote noteBus = new ServiceNote(repoNote, repoStuds, repoTeme);

            ConsoleUI console = new ConsoleUI(noteBus, temeBus);
            console.Start();
        }

        private static void AddStuds(XmlRepo<Student, string> repoStuds)
        {
            Student s1 = new Student("1", "Student 1", 221, "student1@facultate.ro", "Prof");
            Student s2 = new Student("2", "Student 2", 221, "student2@facultate.ro", "Prof");
            Student s3 = new Student("3", "Student 3", 221, "student3@facultate.ro", "Prof");
            repoStuds.Save(s1);
            repoStuds.Save(s2);
            repoStuds.Save(s3);
        }
    }
}
