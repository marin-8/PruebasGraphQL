using System;
using System.Collections.Generic;

namespace GraphQLPruebas.Models;

public partial class MProvincia
{
    public short PK { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<MMunicipio> MMunicipios { get; set; } = new List<MMunicipio>();
}
