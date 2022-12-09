using System;
using System.Collections.Generic;

namespace GraphQLPruebas.Models;

public partial class DLinksPorEvento
{
    public int FkEvento { get; set; }

    public byte Orden { get; set; }

    public string Titulo { get; set; } = null!;

    public string Url { get; set; } = null!;

    public virtual DEvento FkEventoNavigation { get; set; } = null!;
}
