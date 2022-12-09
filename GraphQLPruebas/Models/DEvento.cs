using System;
using System.Collections.Generic;

using HotChocolate.Data;

namespace GraphQLPruebas.Models;

public partial class DEvento
{
    public int PK { get; set; }

    public string Titulo { get; set; } = null!;

    public string Entidad { get; set; } = null!;

    public short? FkTipoEvento { get; set; }

    public string? OtroTipoEvento { get; set; }

    public string Genero { get; set; } = null!;

    public decimal? PrecioMinimo { get; set; }

    public decimal? PrecioMaximo { get; set; }

    public DateTime FechaHora { get; set; }

    public string Lugar { get; set; } = null!;

    public short FkMunicipio { get; set; }

    public short Duracion { get; set; }

    public string? Sinopsis { get; set; }

    public string? InformacionImportante { get; set; }

    public string? Elenco { get; set; }

    public string? InformacionAdicional { get; set; }

    public virtual ICollection<DLinksPorEvento> DLinksPorEventos { get; set; } = new List<DLinksPorEvento>();

    [UseFiltering] public virtual ICollection<DRutasImagenesPorEvento> DRutasImagenesPorEventos { get; set; } = new List<DRutasImagenesPorEvento>();

    public virtual MMunicipio FkMunicipioNavigation { get; set; } = null!;

    public virtual MTiposEvento? FkTipoEventoNavigation { get; set; }
}
