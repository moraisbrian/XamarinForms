using System;
using System.Collections.Generic;
using System.Text;
using App10_Vagas.Modelos;
using SQLite;
using Xamarin.Forms.Xaml.Diagnostics;
using Xamarin.Forms;

namespace App10_Vagas.Banco
{
    public class Database
    {
        private SQLiteConnection _conexao;

        public Database()
        {
            var dep = DependencyService.Get<ICaminho>();
            string caminho = dep.ObterCaminho("database.sqlite");
            _conexao = new SQLiteConnection(caminho);
            _conexao.CreateTable<Vaga>();
        }

        public List<Vaga> Consultar()
        {
            return _conexao.Table<Vaga>().ToList();
        }

        public Vaga ObterVagaPorId(int id)
        {
            return _conexao.Table<Vaga>()
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public Vaga Pesquisa(string palavra)
        {
            return _conexao.Table<Vaga>()
                .Where(x => x.NomeVaga
                .Contains(palavra))
                .FirstOrDefault();
        }

        public void Cadastro(Vaga vaga)
        {
            _conexao.Insert(vaga);
        }

        public void Atualizar(Vaga vaga)
        {
            _conexao.Update(vaga);
        }

        public void Deletar(Vaga vaga)
        {
            _conexao.Delete(vaga);
        }
    }
}
