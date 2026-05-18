using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExoApi.Contexts;
using ExoApi.Models;

namespace ExoApi.Repositories
{
    public class ProjetoRepository
    {
        private readonly ExoContext _context;

        public ProjetoRepository(ExoContext context)
        {
            _context = context;
        }

        public IEnumerable<Projeto> Listar()
        {
            return _context.Projetos;
        }
        public void Cadastrar(Projeto projeto)
        {
            _context.Projetos.Add(projeto); //O Add está preparando uma gavetinha dentro desse armário para receber a informação para o banco
            _context.SaveChanges(); //Salvar Alterações
        }
        public Projeto BuscarPorId(int id)
        {
            return _context.Projetos.Find(id);
        }
        public void Atualizar(int id, Projeto projeto)
        {
            Projeto projetoBuscado = _context.Projetos.Find(id);
            if(projetoBuscado != null) //!= é "diferente de"
            {
                projetoBuscado.NomeDoProjeto = projeto.NomeDoProjeto;
                projetoBuscado.Area = projeto.Area;
                projetoBuscado.Status = projeto.Status;
            }
            _context.Projetos.Update(projetoBuscado);
            _context.SaveChanges();
        }
        public void Deletar(int id)
        {
            projetoBuscado = _context.Projetos.Find(id);
            _context.Projetos.Remove(projetoBuscado);
            _context.SaveChanges();
        }
    }
}
