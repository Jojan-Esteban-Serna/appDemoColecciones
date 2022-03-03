using Servicios.Colecciones.Interfaces;
using System;

namespace Servicios.Colecciones.Enlazadas
{
    public class clsListaEnlazada<Tipo> : iLista<Tipo> where Tipo : IComparable
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

        public clsListaEnlazada()
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

        #region Consultores

        private bool buscarIndice(Tipo prmItem, ref int prmIndice)
        {
            if (atrLongitud == 0)
            {
                return false;
            }
            int varContador = 0;
            for (clsNodoEnlazado<Tipo> varIterador = atrPrimero.darSiguiente(); varContador != atrLongitud; varIterador = varIterador.darSiguiente())
            {
                if (varIterador.darItem().CompareTo(prmItem) == 0)
                {
                    prmIndice = varContador;
                    return true;
                }
                varContador++;
            }
            return false;
        }

        private bool buscarNodo(int prmIndice, ref clsNodoEnlazado<Tipo> prmAnterior)
        {
            if (atrLongitud == 0 || prmIndice < 0 || prmIndice >= atrLongitud)
            {
                return false;
            }
            if (prmIndice == 0)
            {
                prmAnterior = atrPrimero;
                return true;
            }
            int varMaximoIndice = prmIndice - 1;
            int varContador = 0;
            for (clsNodoEnlazado<Tipo> varIterador = atrPrimero.darSiguiente(); varContador != atrLongitud; varIterador = varIterador.darSiguiente())
            {
                if (varContador == varMaximoIndice)
                {
                    prmAnterior = varIterador;
                    return true;
                }
                varContador++;
            }
            return false;
        }

        #endregion Consultores

        #region CRUDs

        public bool agregar(Tipo prmItem)
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

        public bool contieneA(Tipo prmItem)
        {
            int varIndice = 0;
            if (buscarIndice(prmItem, ref varIndice))
            {
                return true;
            }
            return false;
        }

        public int encontrarA(Tipo prmItem)
        {
            int varIndice = 0;
            if (buscarIndice(prmItem, ref varIndice))
            {
                return varIndice;
            }
            return -1;
        }

        public bool extraerEn(int prmIndice, ref Tipo prmItem)
        {
            clsNodoEnlazado<Tipo> varNodoAnterior = null;
            if (buscarNodo(prmIndice, ref varNodoAnterior))
            {
                clsNodoEnlazado<Tipo> varNodoActual = varNodoAnterior.darSiguiente();
                prmItem = varNodoActual.darItem();
                if (prmIndice == atrLongitud - 1)
                {
                    atrPenultimo = varNodoAnterior;
                }
                varNodoAnterior.ponerSiguiente(varNodoActual.darSiguiente());
                atrLongitud--;

                return true;
            }
            return false;
        }

        public bool insertarEn(int prmIndice, Tipo prmItem)
        {
            if (prmIndice == atrLongitud)
            {
                agregar(prmItem);
                return true;
            }
            clsNodoEnlazado<Tipo> varNodoAnterior = null;
            if (buscarNodo(prmIndice, ref varNodoAnterior))
            {
                clsNodoEnlazado<Tipo> varNuevoNodo = new clsNodoEnlazado<Tipo>(varNodoAnterior, prmItem, varNodoAnterior.darSiguiente());
                atrLongitud++;

                return true;
            }
            return false;
        }

        public bool modificarEn(int prmIndice, Tipo prmItem)
        {
            clsNodoEnlazado<Tipo> varNodoAnterior = null;
            if (buscarNodo(prmIndice, ref varNodoAnterior))
            {
                clsNodoEnlazado<Tipo> varNodoActual = varNodoAnterior.darSiguiente();
                varNodoActual.ponerItem(prmItem);

                return true;
            }
            return false;
        }

        public bool recuperarEn(int prmIndice, ref Tipo prmItem)
        {
            clsNodoEnlazado<Tipo> varNodoAnterior = null;
            if (buscarNodo(prmIndice, ref varNodoAnterior))
            {
                clsNodoEnlazado<Tipo> varNodoActual = varNodoAnterior.darSiguiente();
                prmItem = varNodoActual.darItem();

                return true;
            }
            prmItem = default(Tipo);
            return false;
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

        #endregion CRUDs

        #endregion Metodos
    }
}