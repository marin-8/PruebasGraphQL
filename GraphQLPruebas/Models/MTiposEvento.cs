using System;
using System.Collections.Generic;

namespace GraphQLPruebas.Models;

public partial class MTiposEvento
{
    public short PK { get; set; }

    public string Abreviatura { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public virtual ICollection<DEvento> DEventos { get; set; } = new List<DEvento>();
}
