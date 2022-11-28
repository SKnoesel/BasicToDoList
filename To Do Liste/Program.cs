using System;
using System.Collections.Generic;
using System.Linq;
using To_Do_Liste.Repoistory;

namespace To_Do_Liste
{
    class Program
    {
        static void Main(string[] args)
        {
            string Eingabe;

            ToDoRepoistory toDoRepoistory = new ToDoRepoistory();

            ToDo ersteToDo = new ToDo();
            ToDo zweiteToDo = new ToDo();

            
            ersteToDo.Id = 1;
            ersteToDo.Inhalt = "Eis essen gehen";
            ersteToDo.ErstellDatum = new DateTime(2022, 11, 01);
            ersteToDo.Enddatum = new DateTime(2022, 11, 02);
            ersteToDo.Abgehakt = "Nein";

            zweiteToDo.Id = 2;
            zweiteToDo.Inhalt = "Eis essen gehen";
            zweiteToDo.ErstellDatum = new DateTime(2022, 11, 01);
            zweiteToDo.Enddatum = new DateTime(2022, 11, 02);
            zweiteToDo.Abgehakt = "Nein";

            toDoRepoistory.Add(ersteToDo);
            toDoRepoistory.Add(zweiteToDo);
            String BenutzerName = "Simon";
            String Passwort = "1234";
       
            
            Console.WriteLine("Benutzername eingeben: ");
            Eingabe = Console.ReadLine();
            while (Eingabe != Passwort)
                if (Eingabe == BenutzerName)
            {
                Console.WriteLine("Passwort eingeben: ");
                Eingabe = Console.ReadLine();
                if (Eingabe == Passwort)
                {
                    Console.Clear();
                    while (true)
                    {
                        Console.WriteLine("1 drücken um die Tablle an To Do`s anzugucken");
                        Console.WriteLine("2 drücken um eine neue To Do hinzuzufügen");
                        Console.WriteLine("3 drücken um To Do`s zu löschen");
                        Console.WriteLine("4 drücken um To do`s abzuhaken");
                        Console.WriteLine("5 drücken um To Do`s zu bearbeiten");
                        Eingabe = Console.ReadLine();

                        if (Eingabe == "1")
                        {
                            Console.Clear();
                            foreach (var loopToDo in toDoRepoistory.GetToDos())
                            {
                                Console.WriteLine(loopToDo.ToString());
                            }
                        }
                        else if (Eingabe == "2")
                        {
                            Console.Clear();
                            string InhaltneueToDo = HoleToDoStringStuff("Gib den Inhalt der To do an:");
                            string EnddatumneueToDo = HoleToDoStringStuff("Gib das Enddatum der To Do an:");
                            string AbgehaktneueToDo = HoleToDoStringStuff("Ist die To Do Abgehakt (Nur Ja/Nein):");
                            static string HoleToDoStringStuff(string ausgabeText)
                            {
                                Console.Write(ausgabeText);
                                return Console.ReadLine();
                            }
                            ToDo neueToDo = new ToDo();
                            neueToDo.Inhalt = InhaltneueToDo;
                            neueToDo.ErstellDatum = DateTime.Now;
                            neueToDo.Enddatum = DateTime.Parse(EnddatumneueToDo);
                            neueToDo.Abgehakt = AbgehaktneueToDo;

                            toDoRepoistory.Add(neueToDo);

                            Console.Clear();
                            Console.WriteLine("Eine Neue To Do wurde Hinzugefügt! ");
                        }
                        else if (Eingabe == "3")
                        {
                            Console.Clear();
                            foreach (var loopToDo in toDoRepoistory.GetToDos())
                            {
                                Console.WriteLine(loopToDo.ToString());
                            }
                            Console.WriteLine("Welche ToDo willst du löschen?");
                            int idZumLoschen = Convert.ToInt32(Console.ReadLine());
                            toDoRepoistory.Remove(idZumLoschen);
                            Console.Clear();
                            Console.WriteLine("Die To Do mit der ID " + idZumLoschen + " wurde gelöscht!");
                        }
                        else if (Eingabe == "4")
                        {
                            Console.Clear();
                            foreach (var loopToDo in toDoRepoistory.GetToDos())
                            {
                                Console.WriteLine(loopToDo.ToString());
                            }
                            Console.WriteLine("Welche To Do willst du abhaken?");
                            int idzumAbhaken = Convert.ToInt32(Console.ReadLine());
                            ToDo todo = toDoRepoistory.GetById(idzumAbhaken);

                            if (todo.Abgehakt == "Ja")
                            {
                                todo.Abgehakt = "Nein";
                            }
                            else
                            {
                                todo.Abgehakt = "Ja";
                            }
                            Console.Clear();
                            Console.WriteLine("Die To Do mit der ID " + idzumAbhaken + " wurde abgehakt!");
                        }
                        else if (Eingabe == "5")
                        {
                            Console.Clear();
                            foreach (var loopToDo in toDoRepoistory.GetToDos())
                            {
                                Console.WriteLine(loopToDo.ToString());
                            }
                            Console.WriteLine("Gib die ID der To Do, welche du ändern willst");
                            int idzumÄndern = Convert.ToInt32(Console.ReadLine());
                            ToDo todo = toDoRepoistory.GetById(idzumÄndern);
                            Console.WriteLine("1 Drücken um den Inhalt zu ändern, 2 drücken um das Enddatum zu ändern:");
                            Eingabe = Console.ReadLine();
                            if (Eingabe == "1")
                            {
                                Console.WriteLine("Neuen Inhalt der To do eingeben:");
                                Eingabe = Console.ReadLine();
                                todo.Inhalt = Eingabe;
                            }
                            else if (Eingabe == "2")
                            {
                                Console.WriteLine("Neues Enddatum der To do eingeben:");
                                DateTime EingabeDate = Convert.ToDateTime(Console.ReadLine());
                                todo.Enddatum = EingabeDate;
                            }
                            Console.Clear();
                            Console.WriteLine("Die To Do mit der ID " + idzumÄndern + (" wurde bearbeitet!"));
                        }
                        else
                        {
                            Console.WriteLine("Falsche eingabe, Leertaste drücken und bitte eine Zahlt von 1-5 eingeben!");
                            Console.ReadLine();
                            Console.Clear();
                        }
                    }
                }
               
            }
            else
            {
                Console.WriteLine("Falscher Benutzername oder falsches Passwort! Bitte erneut Eingeben");
                Console.ReadLine();
            }
        }      
        
                
                

            




            
        public class ToDo
        {
            public int Id;
            public string Inhalt;
            public DateTime ErstellDatum;
            public DateTime Enddatum;
            public string Abgehakt;
            public string ToString()
            {
                return $"{Id}: {Inhalt}, {ErstellDatum}, {Enddatum}, {Abgehakt}";
            }
        }
    }   
}




    






