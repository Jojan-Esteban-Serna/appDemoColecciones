using Servicios.Colecciones.Interfaces;
using Servicios.Colecciones.Tads;

using System;

namespace Servicios.Colecciones.Enlazadas
{
    public class clsColaEnlazada<Tipo> : clsTADEnlazado<Tipo>, iCola<Tipo> where Tipo : IComparable
    {
        #region Metodos

        #region Constructores

        public clsColaEnlazada() : base()
        {
        }

        #endregion Constructores

        #region CRUDs

        public bool desencolar(ref Tipo prmItem)
        {
            return extraer(ref prmItem, 0);
        }

        public bool encolar(Tipo prmItem)
        {
            return insertar(prmItem, atrLongitud);
        }

        public bool revisar(ref Tipo prmItem)
        {
            return recuperar(ref prmItem, 0);
        }

        #endregion CRUDs

        #endregion Metodos
    }
}