using Servicios.Colecciones.Interfaces;
using System;

namespace Servicios.Colecciones.DobleEnlazadas
{
    public class clsColaDobleEnlazada<Tipo> : iCola<Tipo> where Tipo : IComparable
    {
        #region Atributos

        private clsNodoDobleEnlazado<Tipo> atrPrimero;
        private clsNodoDobleEnlazado<Tipo> atrUltimo;
        private int atrLongitud = 0;
        private int atrBorde = int.MaxValue / 64;

        #endregion Atributos

        #region Metodos

        #region Costructores

        public clsColaDobleEnlazada()
        {
            atrPrimero = new clsNodoDobleEnlazado<Tipo>();
            atrUltimo = new clsNodoDobleEnlazado<Tipo>();
            atrPrimero.enlazarSiguiente(atrUltimo);
        }

        #endregion Costructores

        #region Accesores

        public Tipo[] darItems()
        {
            if (atrLongitud == 0)
            {
                return null;
            }
            Tipo[] varItems = new Tipo[atrLongitud];
            int varContador = 0;
            for (clsNodoDobleEnlazado<Tipo> varIterador = atrPrimero.darSiguiente(); varContador != atrLongitud; varIterador = varIterador.darSiguiente())
            {
                varItems[varContador] = varIterador.darItem();
                varContador++;
            }
            return varItems;
        }

        public int darLongitud()
        {
            return atrLongitud;
        }

        public clsNodoDobleEnlazado<Tipo> darPrimero()
        {
            if (atrLongitud == 0)
            {
                return null;
            }
            return atrPrimero.darSiguiente();
        }

        public clsNodoDobleEnlazado<Tipo> darUltimo()
        {
            if (atrLongitud == 0)
            {
                return null;
            }
            return atrUltimo.darAnterior();
        }

        #endregion Accesores

        #region Mutadores

        public bool ponerItems(Tipo[] prmItems)
        {
            if (prmItems.Length == 0 || prmItems.Length > atrBorde)
            {
                return false;
            }
            atrPrimero.enlazarSiguiente(atrUltimo);

            foreach (Tipo varItem in prmItems)
            {
                clsNodoDobleEnlazado<Tipo> nuevoNodo = new clsNodoDobleEnlazado<Tipo>(atrUltimo.darAnterior(), varItem, atrUltimo);
                atrLongitud++;
            }
            return true;
        }

        #endregion Mutadores

        #region CRUDs

        public bool desencolar(ref Tipo prmItem)
        {
            if (atrLongitud == 0)
            {
                return false;
            }

            prmItem = atrPrimero.darSiguiente().darItem();
            atrPrimero.enlazarSiguiente(atrPrimero.darSiguiente().darSiguiente());
            atrLongitud--;

            return true;
        }

        public bool encolar(Tipo prmItem)
        {
            if (atrLongitud == atrBorde)
            {
                return false;
            }

            clsNodoDobleEnlazado<Tipo> nuevoNodo = new clsNodoDobleEnlazado<Tipo>(atrUltimo.darAnterior(), prmItem, atrUltimo);
            atrLongitud++;

            return true;
        }

        public bool reversar()
        {
            if (atrLongitud == 0)
            {
                return false;
            }

            int varContador = 0;
            for (clsNodoDobleEnlazado<Tipo> varIterador = atrPrimero; varContador != atrLongitud + 2; varIterador = varIterador.darAnterior())
            {
                varIterador.invertirEnlaces();
                varContador++;
            }

            clsNodoDobleEnlazado<Tipo> varTemporal = atrPrimero;
            atrPrimero = atrUltimo;
            atrUltimo = varTemporal;

            return true;
        }

        public bool revisar(ref Tipo prmItem)
        {
            if (atrLongitud == 0)
            {
                return false;
            }
            prmItem = atrPrimero.darSiguiente().darItem();
            return true;
        }

        #endregion CRUDs

        #endregion Metodos
    }
}