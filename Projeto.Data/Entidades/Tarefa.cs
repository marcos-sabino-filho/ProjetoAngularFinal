using System;
using System.Collections.Generic;

namespace Projeto.Data.Entidades;

public partial class Tarefa
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string? Descricao { get; set; }
}
