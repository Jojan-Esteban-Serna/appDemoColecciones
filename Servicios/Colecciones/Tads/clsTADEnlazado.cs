using Servicios.Colecciones.Nodos;
using System;

namespace Servicios.Colecciones.Tads
{
    public class clsTADEnlazado<Tipo> : clsTAD<Tipo> where Tipo : IComparable
    {
        #region Atributos

        protected new int atrBorde = int.MaxValue / 64;
        protected clsNodoEnlazado<Tipo> atrPrimero;
        protected clsNodoEnlazado<Tipo> atrUltimo;
        protected clsNodoEnlazado<Tipo> atrPenultimo;

        #endregion Atributos

        #region Metodos

        #region Constructores

        public clsTADEnlazado()
        {
            atrPrimero = new clsNodoEnlazado<Tipo>();
            atrUltimo = new clsNodoEnlazado<Tipo>();
            atrPrimero.ponerSiguiente(atrUltimo);
            atrPenultimo = atrPrimero;
        }

        #endregion Constructores

        #region Accesores

        public override Tipo[] darItems()
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

        public override bool ponerItems(Tipo[] prmItems)
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

        protected bool buscarIndice(Tipo prmItem, ref int prmIndice)
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

        protected bool buscarNodo(int prmIndice, ref clsNodoEnlazado<Tipo> prmAnterior)
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

        public override bool contieneA(Tipo prmItem)
        {
            int varIndice = 0;
            if (buscarIndice(prmItem, ref varIndice))
            {
                return true;
            }
            return false;
        }

        public override int encontrarA(Tipo prmItem)
        {
            int varIndice = 0;
            if (buscarIndice(prmItem, ref varIndice))
            {
                return varIndice;
            }
            return -1;
        }

        protected override bool insertar(Tipo prmItem, int prmIndice)
        {
            if (atrLongitud == atrBorde)
            {
                return false;
            }
            if (prmIndice == atrLongitud)
            {
                clsNodoEnlazado<Tipo> nuevoNodo = new clsNodoEnlazado<Tipo>(atrPenultimo, prmItem, atrUltimo);
                atrPenultimo = nuevoNodo;
                atrLongitud++;
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

        protected override bool extraer(ref Tipo prmItem, int prmIndice)
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

        protected override bool recuperar(ref Tipo prmItem, int prmIndice)
        {
            clsNodoEnlazado<Tipo> varNodoAnterior = null;
            if (buscarNodo(prmIndice, ref varNodoAnterior))
            {
                clsNodoEnlazado<Tipo> varNodoActual = varNodoAnterior.darSiguiente();
                prmItem = varNodoActual.darItem();

                return true;
            }
            //prmItem = default(Tipo);
            return false;
        }

        public override bool reversar()
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