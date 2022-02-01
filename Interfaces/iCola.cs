using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Colecciones.Interfaces
{
    public interface iCola<Tipo> where Tipo: IComparable
    {
        bool encolar(Tipo prmItem);
        bool desencolar(ref Tipo prmItem);
        bool revisar(ref Tipo prmItem);
        bool reversar();
    }
}
