using System;
using System.Collections.Generic;

namespace Projeto.Data.Entidades;

public partial class Curso
{
    public int Id { get; set; }

    public string NomeCurso { get; set; } = null!;

    public DateTime? Criacao { get; set; }
}
