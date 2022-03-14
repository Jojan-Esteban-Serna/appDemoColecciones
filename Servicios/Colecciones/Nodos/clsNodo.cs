using System;

namespace Servicios.Colecciones.Nodos
{
    public class clsNodo<Tipo> where Tipo : IComparable
    {
        #region Atributos

        protected Tipo atrItem;

        #endregion Atributos

        #region Metodos

        #region Accesores

        public Tipo darItem()
        {
            return atrItem;
        }

        #endregion Accesores

        #region Mutadores

        public void ponerItem(Tipo prmItem)
        {
            atrItem = prmItem;
        }

        #endregion Mutadores

        #endregion Metodos
    }
}