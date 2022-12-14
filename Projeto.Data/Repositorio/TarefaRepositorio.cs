using Projeto.Data.Interfaces;
using Projeto.Data.Dto;
using Projeto.Data.Contexto;

namespace Projeto.Data.Repositorio
{
    public class TarefaRepositorio : ITarefaRepositorio
    {
        private readonly TreinamentoContext _treinamentoContext;

        public TarefaRepositorio(TreinamentoContext treinamentoContext)
        {
            _treinamentoContext = treinamentoContext;
        }

        public int ApagarTarefa(TarefaDto model)
        {
            Entidades.Tarefa tarefa;

            if (model.Id > 0)
            {
                tarefa = _treinamentoContext.Tarefas.Where(w => w.Id == model.Id)?.FirstOrDefault() ?? new Entidades.Tarefa();
            }
            else
            {
                tarefa = _treinamentoContext.Tarefas.Where(w => w.Nome == model.Nome)?.FirstOrDefault() ?? new Entidades.Tarefa();
            }

            if (tarefa != null)
            {
                _treinamentoContext.ChangeTracker.Clear();
                _treinamentoContext.Tarefas.Remove(tarefa);
                return _treinamentoContext.SaveChanges();
            }

            return 0;
        }

        public int AtualizarTarefa(TarefaAtualizarDto model)
        {
            Entidades.Tarefa tarefa = _treinamentoContext.Tarefas.Where(w => w.Id == model.Id).FirstOrDefault();

            if (tarefa != null)
            {
                tarefa.Nome = model.Nome;
                tarefa.Descricao = model.Descricao;

                _treinamentoContext.ChangeTracker.Clear();
                _treinamentoContext.Tarefas.Update(tarefa);
                return _treinamentoContext.SaveChanges();
            }

            return 0;
        }

        public int CriarTarefa(TarefaDto model)
        {
            Entidades.Tarefa tarefa = new Entidades.Tarefa()
            {
                Nome = model.Nome,
            };

            _treinamentoContext.ChangeTracker.Clear();
            _treinamentoContext.Add(tarefa);

            int linhasExecutadas = _treinamentoContext.SaveChanges();

            if (linhasExecutadas > 0)
            {
                return tarefa.Id;
            }
            else
            {
                return 0;
            }
        }

        public TarefaDto ListarPorId(int id)
        {
            return (from t in _treinamentoContext.Tarefas
                    where t.Id == id
                    select new TarefaDto()
                    {
                        Id = t.Id,
                        Nome = t.Nome
                    })?.FirstOrDefault()
                    ?? new TarefaDto();
        }

        public List<TarefaDto> TodasTarefas()
        {
            return (from t in _treinamentoContext.Tarefas
                    select new TarefaDto()
                    {
                        Id = t.Id,
                        Nome = t.Nome
                    }).ToList();
        }
    }
}
