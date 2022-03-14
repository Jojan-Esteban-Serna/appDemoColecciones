using Servicios.Colecciones.Interfaces;
using Servicios.Colecciones.Tads;
using System;

namespace Servicios.Colecciones.DobleEnlazadas
{
    public class clsColaDobleEnlazada<Tipo> : clsTADDobleEnlazado<Tipo>, iCola<Tipo> where Tipo : IComparable
    {
        #region Metodos

        #region Costructores

        public clsColaDobleEnlazada() : base()
        {
        }

        #endregion Costructores

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