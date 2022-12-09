using System;
using System.Collections.Generic;

namespace GraphQLPruebas.Models;

public partial class MMunicipio
{
    public short PK { get; set; }

    public string Nombre { get; set; } = null!;

    public short FkProvincia { get; set; }

    public virtual ICollection<DEvento> DEventos { get; set; } = new List<DEvento>();

    public virtual MProvincia FkProvinciaNavigation { get; set; } = null!;
}
