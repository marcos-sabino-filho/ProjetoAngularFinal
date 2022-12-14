using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Data.Dto;

namespace Projeto.Data.Interfaces
{
    public interface ITarefaRepositorio
    {
        public List<TarefaDto> TodasTarefas();
        public TarefaDto ListarPorId(int id);

        public int CriarTarefa(TarefaDto model);

        public int ApagarTarefa(TarefaDto model);

        public int AtualizarTarefa(TarefaAtualizarDto model);
    }
}
