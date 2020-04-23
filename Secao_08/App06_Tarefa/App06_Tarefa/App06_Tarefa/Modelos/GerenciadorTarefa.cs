using System;
using System.Collections.Generic;
using System.Text;

namespace App06_Tarefa.Modelos
{
    public class GerenciadorTarefa
    {
        private List<Tarefa> Lista { get; set; }
        public void Salvar(Tarefa tarefa)
        {
            Lista.Add(tarefa);

            SalvarProperties(Lista);
        }

        public void Finalizar(Tarefa tarefa, int index)
        {
            Lista.RemoveAt(index);

            Lista.Add(tarefa);
            SalvarProperties(Lista);
        }

        public void Deletar(Tarefa tarefa)
        {
            Lista.Remove(tarefa);

            SalvarProperties(Lista);
        }

        public List<Tarefa> Listagem()
        {
            return ListagemProperties();
        }

        public void SalvarProperties(List<Tarefa> lista)
        {
            if (App.Current.Properties.ContainsKey("Tarefas"))
            {
                App.Current.Properties.Remove("Tarefas");
            }

            App.Current.Properties.Add("Tarefas", lista);
        }

        public List<Tarefa> ListagemProperties()
        {
            if (App.Current.Properties.ContainsKey("Tarefas"))
            {
                return (List<Tarefa>)App.Current.Properties["Tarefas"];
            }
            else
            {
                return new List<Tarefa>();
            }
        }
    }
}
