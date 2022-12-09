using System;
using System.Collections.Generic;

namespace GraphQLPruebas.Models;

public partial class DRutasImagenesPorEvento
{
    public int FkEvento { get; set; }

    public byte Orden { get; set; }

    public string Ruta { get; set; } = null!;

    public virtual DEvento FkEventoNavigation { get; set; } = null!;
}
