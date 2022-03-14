using System;

namespace Servicios.Colecciones.Interfaces
{
    public interface iTAD<Tipo> where Tipo : IComparable
    {
        int darLongitud();

        Tipo[] darItems();

        bool ponerItems(Tipo[] prmItems);

        bool reversar();

        bool contieneA(Tipo ptmItem);

        int encontrarA(Tipo prmItem);
    }
}