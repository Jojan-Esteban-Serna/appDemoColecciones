using System;

namespace Servicios.Colecciones.DobleEnlazadas
{
    public class clsNodoDobleEnlazado<Tipo> where Tipo : IComparable
    {
        #region Atributos

        private clsNodoDobleEnlazado<Tipo> atrRefAnterior;
        private clsNodoDobleEnlazado<Tipo> atrRefSiguiente;
        private Tipo atrItem;

        #endregion Atributos

        #region Metodos

        #region Constructores

        public clsNodoDobleEnlazado()
        {
        }

        public clsNodoDobleEnlazado(clsNodoDobleEnlazado<Tipo> prmAnterior, Tipo prmItem, clsNodoDobleEnlazado<Tipo> prmSiguiente)
        {
            enlazar(prmAnterior, prmSiguiente);
            atrItem = prmItem;
        }

        public clsNodoDobleEnlazado(Tipo prmItem)
        {
            atrItem = prmItem;
            atrRefAnterior = null;
            atrRefSiguiente = null;
        }

        #endregion Constructores

        #region Accesores

        public clsNodoDobleEnlazado<Tipo> darAnterior()
        {
            return atrRefAnterior;
        }

        public clsNodoDobleEnlazado<Tipo> darSiguiente()
        {
            return atrRefSiguiente;
        }

        public Tipo darItem()
        {
            return atrItem;
        }

        #endregion Accesores

        #region Mutadores

        public bool ponerAnterior(clsNodoDobleEnlazado<Tipo> prmNuevoNodo)
        {
            atrRefAnterior = prmNuevoNodo;
            return true;
        }

        public bool ponerSiguiente(clsNodoDobleEnlazado<Tipo> prmNuevoNodo)
        {
            atrRefSiguiente = prmNuevoNodo;
            return true;
        }

        public bool ponerItem(Tipo prmItem)
        {
            atrItem = prmItem;
            return true;
        }

        #endregion Mutadores

        #region Enlazadores

        public void enlazarSiguiente(clsNodoDobleEnlazado<Tipo> prmSiguiente)
        {
            atrRefSiguiente = prmSiguiente;
            prmSiguiente.ponerAnterior(this);
        }

        public void enlazarAnterior(clsNodoDobleEnlazado<Tipo> prmAnterior)
        {
            atrRefAnterior = prmAnterior;
            prmAnterior.ponerSiguiente(this);
        }

        public void enlazar(clsNodoDobleEnlazado<Tipo> prmAnterior, clsNodoDobleEnlazado<Tipo> prmSiguiente)
        {
            enlazarAnterior(prmAnterior);
            enlazarSiguiente(prmSiguiente);
        }

        #endregion Enlazadores

        #region Desenlazadores

        public void quitarEnlaces()
        {
            quitarAnterior();
            quitarSiguiente();
        }

        public void quitarAnterior()
        {
            atrRefAnterior.ponerSiguiente(null);
            atrRefAnterior = null;
        }

        public void quitarSiguiente()
        {
            atrRefSiguiente.ponerAnterior(null);
            atrRefSiguiente = null;
        }

        #endregion Desenlazadores

        #region Intercambiadores

        public void invertirEnlaces()
        {
            clsNodoDobleEnlazado<Tipo> varTemporal = atrRefAnterior;
            atrRefAnterior = atrRefSiguiente;
            atrRefSiguiente = varTemporal;
        }

        public void intercambiarItems(clsNodoDobleEnlazado<Tipo> prmNodoIntercambio)
        {
            Tipo varItemTemporal = atrItem;
            atrItem = prmNodoIntercambio.darItem();
            prmNodoIntercambio.ponerItem(varItemTemporal);
        }

        #endregion Intercambiadores

        #endregion Metodos
    }
}