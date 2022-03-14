using System;

namespace Servicios.Colecciones.Nodos
{
    public class clsNodoDobleEnlazado<Tipo> : clsNodo<Tipo> where Tipo : IComparable
    {
        #region Atributos

        private clsNodoDobleEnlazado<Tipo> atrRefAnterior;
        private clsNodoDobleEnlazado<Tipo> atrRefSiguiente;

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

        public void invertirEnlaces()
        {
            clsNodoDobleEnlazado<Tipo> varTemporal = atrRefAnterior;
            atrRefAnterior = atrRefSiguiente;
            atrRefSiguiente = varTemporal;
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

        #endregion Metodos
    }
}