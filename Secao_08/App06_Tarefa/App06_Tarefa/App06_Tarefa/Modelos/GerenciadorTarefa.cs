using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace App06_Tarefa.Modelos
{
    public class GerenciadorTarefa
    {
        private List<Tarefa> Lista { get; set; }
        public void Salvar(Tarefa tarefa)
        {
            Lista = Listagem();
            Lista.Add(tarefa);

            SalvarProperties(Lista);
        }

        public void Finalizar(Tarefa tarefa, int index)
        {
            Lista = Listagem();
            Lista.RemoveAt(index);

            tarefa.DataFinalizacao = DateTime.Now;
            Lista.Add(tarefa);
            SalvarProperties(Lista);
        }

        public void Deletar(int index)
        {
            Lista = Listagem();
            Lista.RemoveAt(index);

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

            string json = JsonConvert.SerializeObject(lista);

            App.Current.Properties.Add("Tarefas", json);
        }

        public List<Tarefa> ListagemProperties()
        {
            if (App.Current.Properties.ContainsKey("Tarefas"))
            {
                List<Tarefa> tarefas = JsonConvert.DeserializeObject<List<Tarefa>>((string)App.Current.Properties["Tarefas"]);
                return tarefas;
            }
            else
            {
                return new List<Tarefa>();
            }
        }
    }
}
