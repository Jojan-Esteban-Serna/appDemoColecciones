using System;


namespace Servicios.Colecciones.Interfaces  //Capas
{
    public interface iPila<Tipo> where Tipo : IComparable //Comparación
    {
        bool apilar(Tipo prmItem);
        bool desapilar(ref Tipo prmItem);
        bool revisar(ref Tipo prmItem);
        bool reversar();
    }
}
