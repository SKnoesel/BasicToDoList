using System.Collections.Generic;
using System.Linq;
using static To_Do_Liste.Program;

namespace To_Do_Liste.Repoistory
{
    class ToDoRepoistory
    { 
        List<ToDo> ToDoListe = new List<ToDo>();
        public void Add(ToDo todo)
        {
            todo.Id = ToDoListe.Any()
                ? ToDoListe.Max(todo => todo.Id) + 1
                : 0;
            ToDoListe.Add(todo);
        }
        public void Remove(int id)
        {
            ToDo todoZumLoschen = ToDoListe.Single(x => x.Id == id);
            ToDoListe.Remove(todoZumLoschen);
        }
        public ToDo GetById(int id)
        {
            return ToDoListe.Single(x => x.Id == id);
        }
        public List<ToDo> GetToDos()
        {
            return ToDoListe;
        }
    }
}
