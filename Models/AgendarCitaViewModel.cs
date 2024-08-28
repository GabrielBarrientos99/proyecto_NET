using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace PROYECTO_FLK.Models
{
    public class AgendarCitaViewModel
    {
        public List<TipoInspeccion> TipoInspeccions { get; set; } = new List<TipoInspeccion>();
        public List<TiposServicio> TiposServicios { get; set; } = new List<TiposServicio>();
        public List<Empresa> Empresas { get; set; } = new List<Empresa>();

        public List<Inspeccione> Inspecciones { get; set; } = new List<Inspeccione>();
        public Empresa NuevaEmpresa { get; set; } = new Empresa();
        public Inspeccione InspeccionCompleta { get; set; } = new Inspeccione(); // Modelo para completar la inspección

        // Propiedades para almacenar los datos seleccionados
        public int SelectedTipoServicioId { get; set; }
        public int SelectedTipoInspeccionId { get; set; }
        public int SelectedEmpresaId { get; set; }
    }
}
