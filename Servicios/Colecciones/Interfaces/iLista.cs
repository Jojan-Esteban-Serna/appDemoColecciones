using System;

namespace Servicios.Colecciones.Interfaces
{
    public interface iLista<Tipo> where Tipo : IComparable
    {
        bool agregar(Tipo prmItem);

        bool insertarEn(int prmIndice, Tipo prmItem);

        bool extraerEn(int prmIndice, ref Tipo prmItem);

        bool modificarEn(int prmIndice, Tipo prmItem);

        bool recuperarEn(int prmIndice, ref Tipo prmItem);
    }
}