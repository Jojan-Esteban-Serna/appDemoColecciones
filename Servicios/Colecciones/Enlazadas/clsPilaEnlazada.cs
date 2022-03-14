using Servicios.Colecciones.Interfaces;
using Servicios.Colecciones.Tads;

using System;

namespace Servicios.Colecciones.Enlazadas
{
    public class clsPilaEnlazada<Tipo> : clsTADEnlazado<Tipo>, iPila<Tipo> where Tipo : IComparable
    {
        #region Metodos

        #region Constructores

        public clsPilaEnlazada() : base()
        {
        }

        #endregion Constructores

        #region CRUDs

        public bool apilar(Tipo prmItem)
        {
            return insertar(prmItem, 0);
        }

        public bool desapilar(ref Tipo prmItem)
        {
            return extraer(ref prmItem, 0);
        }

        public bool revisar(ref Tipo prmItem)
        {
            return recuperar(ref prmItem, 0);
        }

        #endregion CRUDs

        #endregion Metodos
    }
}