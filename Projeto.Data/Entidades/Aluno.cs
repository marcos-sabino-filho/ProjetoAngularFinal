using System;
using System.Collections.Generic;

namespace Projeto.Data.Entidades;

public partial class Aluno
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string? Documento { get; set; }

    public DateTime? Aniversario { get; set; }
}
