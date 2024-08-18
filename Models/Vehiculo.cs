using System;
using System.Collections.Generic;

namespace PROYECTO_FLK.Models;

public partial class Vehiculo
{
    public int PkVehiculo { get; set; }

    public string? Fabricante { get; set; }

    public string? Modelo { get; set; }

    public string? NumeroSerie { get; set; }

    public string? Marca { get; set; }

    public int? FkTipoDeVehiculos { get; set; }

    public int? FkEmpresas { get; set; }

    public virtual Empresa? FkEmpresasNavigation { get; set; }

    public virtual TipoDeVehiculo? FkTipoDeVehiculosNavigation { get; set; }
}
