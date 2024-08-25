namespace PROYECTO_FLK.Models
{
    public class GestionarVehiculoViewModel
    {
        public Vehiculo Vehiculo { get; set; }
        public TipoDeVehiculo TipoDeVehiculo { get; set; }
        public List<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
        public List<TipoDeVehiculo> TipoDeVehiculos { get; set; } = new List<TipoDeVehiculo>();
       


    }
}
