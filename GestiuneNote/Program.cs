using System.Collections.Generic;
using GestiuneNote.Domain;

namespace GestiuneNote
{
    class Program
    {
        static void Main(string[] args)
        {
            Repo<Student, string> repoStuds = new Repo<Student, string>();
            Student s1 = new Student("1", "Student 1", 221, "student1@facultate.ro", "Prof");
            Student s2 = new Student("2", "Student 2", 221, "student2@facultate.ro", "Prof");
            Student s3 = new Student("3", "Student 3", 221, "student3@facultate.ro", "Prof");
            repoStuds.Save(s1);
            repoStuds.Save(s2);
            repoStuds.Save(s3);

            Repo<Tema, string> repoTeme = new Repo<Tema, string>();
            Repo<Nota, KeyValuePair<string, string>> repoNote = new Repo<Nota, KeyValuePair<string, string>>();

            ServiceTema temeBus = new ServiceTema(repoTeme);
            ServiceNote noteBus = new ServiceNote(repoNote, repoStuds, repoTeme);

            ConsoleUI console = new ConsoleUI(noteBus, temeBus);
            console.Start(); 
        }
    }
}
