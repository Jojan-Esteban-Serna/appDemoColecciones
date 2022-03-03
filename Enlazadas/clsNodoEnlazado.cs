using System;

namespace Servicios.Colecciones.Enlazadas
{
    public class clsNodoEnlazado<Tipo> where Tipo : IComparable
    {
        #region Atributos

        private Tipo atrItem;
        private clsNodoEnlazado<Tipo> atrRefSiguiente;

        #endregion Atributos

        #region Metodos

        #region Constructores

        public clsNodoEnlazado()
        {
        }

        public clsNodoEnlazado(Tipo prmItem)
        {
            atrItem = prmItem;
        }

        public clsNodoEnlazado(Tipo prmItem, clsNodoEnlazado<Tipo> prmSiguiente)
        {
            atrItem = prmItem;
            atrRefSiguiente = prmSiguiente;
        }

        public clsNodoEnlazado(clsNodoEnlazado<Tipo> prmAnterior, Tipo prmItem, clsNodoEnlazado<Tipo> prmSiguiente)
        {
            atrItem = prmItem;
            atrRefSiguiente = prmSiguiente;
            prmAnterior.ponerSiguiente(this);
        }

        #endregion Constructores

        #region Accesores

        public clsNodoEnlazado<Tipo> darSiguiente()
        {
            return atrRefSiguiente;
        }

        public Tipo darItem()
        {
            return atrItem;
        }

        #endregion Accesores

        #region Mutadores

        public bool ponerItem(Tipo prmItem)
        {
            atrItem = prmItem;
            return true;
        }

        public bool ponerSiguiente(clsNodoEnlazado<Tipo> prmSiguiente)
        {
            atrRefSiguiente = prmSiguiente;
            return true;
        }

        #endregion Mutadores

        #endregion Metodos
    }
}