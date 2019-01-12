using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace GestiuneNote
{
    public class ConsoleUI
    {
        private ServiceNote noteBus;
        private ServiceTema temeBus;
        private Dictionary<string, Action> menu;

        public ConsoleUI(ServiceNote noteBus, ServiceTema temeBus)
        {
            this.noteBus = noteBus;
            this.temeBus = temeBus;
            menu = new Dictionary<string, Action>
            {
                { "1", ShowStuds },
                { "2", ShowTeme },
                { "3", ShowNote },
                { "4", AddTema },
                { "5", PostponeTema },
                { "6", AddNota },
                { "0", Exit }
            };
        }

        public void Start()
        {
            WriteLine("Introduceti saptamana curenta: ");
            string saptCurenta = ReadLine();
            noteBus.SaptamanaCurenta = int.Parse(saptCurenta);
            temeBus.SaptamanaCurenta = int.Parse(saptCurenta);

            while (true)
            {
                ShowMenu();
                menu[ReadLine()].Invoke();
            }
        }

        private void ShowMenu()
        {
            WriteLine("Menu: ");
            WriteLine(" 1. Toti studentii");
            WriteLine(" 2. Toate temele");
            WriteLine(" 3. Toate notele");
            WriteLine(" 4. Adauga tema");
            WriteLine(" 5. Amana tema");
            WriteLine(" 6. Adauga nota");
            WriteLine("0. Iesi");

        }

        private void Exit() => Environment.Exit(0);
        private void ShowStuds() => noteBus.GetStuds().ForEach(obj => WriteLine(obj));
        private void ShowTeme() => temeBus.GetTeme().ForEach(obj => WriteLine(obj));
        private void ShowNote() => noteBus.GetNote().ForEach(obj => WriteLine(obj));

        private void AddTema()
        {
            WriteLine("Introduceti datele temei (nr, enunt, deadline):");
            string line = ReadLine();
            List<string> attrs = line.Split(", ").ToList();

            try
            {
                temeBus.Add(attrs[0], attrs[1], attrs[2]);
                WriteLine("Tema adaugata cu succes.");
            }
            catch (Exception e)
            {
                WriteLine(e);
            }
        }

        private void PostponeTema()
        {
            WriteLine("Numarul temei: ");
            string id = ReadLine();
            WriteLine("Numarul de saptamani cu care se amana tema: ");
            string nrSapt = ReadLine();

            try
            {
                temeBus.Postpone(id, nrSapt);
                WriteLine("Tema amanata cu succes.");
            }
            catch (Exception e)
            {
                WriteLine(e);
            }
        }

        private void AddNota()
        {
            WriteLine("Id student:");
            string idS = ReadLine();

            WriteLine("Id tema:");
            string idT = ReadLine();

            WriteLine("Nota:");
            string val = ReadLine();

            WriteLine("Feedback:");
            string fedbck = ReadLine();

            try
            {
                Penalizare pen = noteBus.Add(idS, idT, val, fedbck);
                WriteLine("Nota adaugata cu succes.");
                WriteLine("Nota maxima: " + pen.CalculateNotaMax);
                WriteLine("Penalizare: " + pen.CalculatePenalizare);
                WriteLine("Nota finala: " + pen.CalculateNota);
            }
            catch (Exception e)
            {
                WriteLine(e);
            }
        }
        // TODO: Rapoarte
    }
}
