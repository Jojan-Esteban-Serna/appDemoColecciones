using Servicios.Colecciones.Interfaces;
using System;

namespace Servicios.Colecciones.Enlazadas
{
    public class clsColaEnlazada<Tipo> : iCola<Tipo> where Tipo : IComparable
    {
        #region Atributos

        private clsNodoEnlazado<Tipo> atrPrimero;
        private clsNodoEnlazado<Tipo> atrUltimo;
        private clsNodoEnlazado<Tipo> atrPenultimo;
        private int atrLongitud = 0;
        private int atrBorde = int.MaxValue / 64;

        #endregion Atributos

        #region Metodos

        #region Constructores

        public clsColaEnlazada()
        {
            atrPrimero = new clsNodoEnlazado<Tipo>();
            atrUltimo = new clsNodoEnlazado<Tipo>();
            atrPrimero.ponerSiguiente(atrUltimo);
            atrPenultimo = atrPrimero;
        }

        #endregion Constructores

        #region Accesores

        public Tipo[] darItems()
        {
            if (atrLongitud == 0)
            {
                return null;
            }
            Tipo[] varItems = new Tipo[atrLongitud];
            int varContador = 0;
            for (clsNodoEnlazado<Tipo> varIterador = atrPrimero.darSiguiente(); varContador != atrLongitud; varIterador = varIterador.darSiguiente())
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

        public clsNodoEnlazado<Tipo> darPrimero()
        {
            if (atrLongitud == 0)
            {
                return null;
            }
            return atrPrimero.darSiguiente();
        }

        public clsNodoEnlazado<Tipo> darUltimo()
        {
            if (atrLongitud == 0)
            {
                return null;
            }
            return atrPenultimo;
        }

        #endregion Accesores

        #region Mutadores

        public bool ponerItems(Tipo[] prmItems)
        {
            if (prmItems.Length == 0 || prmItems.Length > atrBorde)
            {
                return false;
            }
            atrPrimero.ponerSiguiente(atrUltimo);
            atrPenultimo.ponerSiguiente(null);
            atrPenultimo = atrPrimero;

            foreach (Tipo varItem in prmItems)
            {
                clsNodoEnlazado<Tipo> nuevoNodo = new clsNodoEnlazado<Tipo>(atrPenultimo, varItem, atrUltimo);
                atrPenultimo = nuevoNodo;
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

            prmItem = darPrimero().darItem();
            atrPrimero.ponerSiguiente(atrPrimero.darSiguiente().darSiguiente());
            atrLongitud--;
            return true;
        }

        public bool encolar(Tipo prmItem)
        {
            if (atrLongitud == atrBorde)
            {
                return false;
            }

            clsNodoEnlazado<Tipo> nuevoNodo = new clsNodoEnlazado<Tipo>(atrPenultimo, prmItem, atrUltimo);
            atrPenultimo = nuevoNodo;
            atrLongitud++;
            return true;
        }

        public bool reversar()
        {
            if (atrLongitud == 0)
            {
                return false;
            }
            clsNodoEnlazado<Tipo> varAnterior = null;
            clsNodoEnlazado<Tipo> varActual = atrPrimero;
            clsNodoEnlazado<Tipo> varSiguiente = null;
            atrPenultimo = darPrimero();
            while (varActual != null)
            {
                varSiguiente = varActual.darSiguiente(); // Guarda el siguiente nodo
                varActual.ponerSiguiente(varAnterior); // Invierte el nodo
                varAnterior = varActual; // Avanza el nodo anterior hacia el actual
                varActual = varSiguiente; // Avanza el nodo actual con el siguiente guardado
            }

            clsNodoEnlazado<Tipo> varTemporal = atrPrimero;
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
            prmItem = darPrimero().darItem();
            return true;
        }

        #endregion CRUDs

        #endregion Metodos
    }
}