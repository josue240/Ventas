using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Rentas
{
    public class VehiculoBL
    {
        Contexto _contexto;
        

        public BindingList<Vehiculo> ListaVehiculo { get; set; }

        public VehiculoBL()
        {

            _contexto = new Contexto();
            ListaVehiculo = new BindingList<Vehiculo>();
        }

        public IEnumerable<Vehiculo> ObtenerVehiculos()
        {
            _contexto.Vehiculo.Load();
            ListaVehiculo = _contexto.Vehiculo.Local.ToBindingList();

            return ListaVehiculo.OrderBy(r => r.Descripcion);
        }
        public IEnumerable<Vehiculo> ObtenerVehiculos(string buscar)
        {
            var descripcion = buscar.ToLower().Trim();
            var resultado = _contexto.Vehiculo.Where(r => r.Descripcion.ToLower().Contains(descripcion)).ToList();

            return resultado;
        }

        public object ObtenerProductos()
        {
            throw new NotImplementedException();
        }

        public void CancelarCambios()
        {
            foreach (var item in _contexto.ChangeTracker.Entries())
            {
                item.State = EntityState.Unchanged;
                item.Reload();
            }
        }
        public Resultado GuardarVehiculo(Vehiculo vehiculo)
        {
            var resultado = Validar(vehiculo);
            if (resultado.Exitoso == false)
            {
                return resultado;
            }

            _contexto.SaveChanges();

            resultado.Exitoso = true;
            return resultado;
        }

        public void AgregarVehiculo()
        {
            var nuevoVehiculo = new Vehiculo();
            _contexto.Vehiculo.Add(nuevoVehiculo);
        }

        public bool EliminarVehiculo ( int id)
        {
            foreach (var vehiculo in ListaVehiculo.ToList())
            {
                if (vehiculo.Id == id)
                {
                    ListaVehiculo.Remove(vehiculo);
                    _contexto.SaveChanges();
                    return true;
                }

            }


            return false;
        }

        private Resultado Validar(Vehiculo vehiculo)
        {
            var resultado = new Resultado();
            resultado.Exitoso = true;

            if (vehiculo.Descripcion == "")
            {
                resultado.Mensaje = "Ingrese una Descripcion";
                resultado.Exitoso = false;
            }

            if (vehiculo.Tipoid == 0)
            {
                resultado.Mensaje = "Ingrese un tipo";
                resultado.Exitoso = false;
            }

            
            if (vehiculo.Precio < 0)
            {
                resultado.Mensaje = "El Precio tiene que ser mayor que 0";
                resultado.Exitoso = false;
            }
            if (vehiculo == null)
            {
                resultado.Mensaje = "Espacios vacios";
                resultado.Exitoso = false;
            }
            return resultado;
        }

    }

    public class Vehiculo
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Placa { get; set; }
        public int Existencia { get; set; }
        public bool Activo { get; set; }
        public int Tipoid { get; set; }
        public Tipo Tipo { get; set; }
        public byte[] Foto { get; set; }
        public double Precio { get; set; }
    }

    public class Resultado
    {
        public bool Exitoso { get; set; }
        public string Mensaje { get; set; }
}
}
