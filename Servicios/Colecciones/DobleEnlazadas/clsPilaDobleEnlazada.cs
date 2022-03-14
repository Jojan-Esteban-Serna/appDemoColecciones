using Servicios.Colecciones.Interfaces;
using Servicios.Colecciones.Tads;
using System;

namespace Servicios.Colecciones.DobleEnlazadas
{
    public class clsPilaDobleEnlazada<Tipo> : clsTADDobleEnlazado<Tipo>, iPila<Tipo> where Tipo : IComparable
    {
        #region Metodos

        #region Constructores

        public clsPilaDobleEnlazada() : base()
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