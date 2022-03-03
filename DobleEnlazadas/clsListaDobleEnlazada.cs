using Servicios.Colecciones.Interfaces;
using System;

namespace Servicios.Colecciones.DobleEnlazadas
{
    public class clsListaDobleEnlazada<Tipo> : iLista<Tipo> where Tipo : IComparable
    {
        #region Atributos

        private clsNodoDobleEnlazado<Tipo> atrPrimero;
        private clsNodoDobleEnlazado<Tipo> atrUltimo;
        private int atrLongitud = 0;
        private int atrBorde = int.MaxValue / 64;

        #endregion Atributos

        #region Metodos

        #region Constructores

        public clsListaDobleEnlazada()
        {
            atrPrimero = new clsNodoDobleEnlazado<Tipo>();
            atrUltimo = new clsNodoDobleEnlazado<Tipo>();
            atrPrimero.enlazarSiguiente(atrUltimo);
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

        #region Consultores

        private bool buscarIndice(Tipo prmItem, ref int prmIndice)
        {
            if (atrLongitud == 0)
            {
                return false;
            }
            int varContador = 0;
            for (clsNodoDobleEnlazado<Tipo> varIterador = atrPrimero.darSiguiente(); varContador != atrLongitud; varIterador = varIterador.darSiguiente())
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

        private bool buscarNodo(int prmIndice, ref clsNodoDobleEnlazado<Tipo> prmNodo)
        {
            if (atrLongitud == 0 || prmIndice < 0 || prmIndice >= atrLongitud)
            {
                return false;
            }
            int varContador = 0;
            for (clsNodoDobleEnlazado<Tipo> varIterador = atrPrimero.darSiguiente(); varContador != atrLongitud; varIterador = varIterador.darSiguiente())
            {
                if (varContador == prmIndice)
                {
                    prmNodo = varIterador;
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

            clsNodoDobleEnlazado<Tipo> nuevoNodo = new clsNodoDobleEnlazado<Tipo>(atrUltimo.darAnterior(), prmItem, atrUltimo);
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
            clsNodoDobleEnlazado<Tipo> varNodo = null;
            if (buscarNodo(prmIndice, ref varNodo))
            {
                clsNodoDobleEnlazado<Tipo> varAnterior = varNodo.darAnterior();
                clsNodoDobleEnlazado<Tipo> varSiguiente = varNodo.darSiguiente();
                prmItem = varNodo.darItem();
                varAnterior.enlazarSiguiente(varSiguiente);
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
            clsNodoDobleEnlazado<Tipo> varNodo = null;
            if (buscarNodo(prmIndice, ref varNodo))
            {
                clsNodoDobleEnlazado<Tipo> varAnterior = varNodo.darAnterior();
                clsNodoDobleEnlazado<Tipo> varNuevoNodo = new clsNodoDobleEnlazado<Tipo>(varAnterior, prmItem, varNodo);
                atrLongitud++;

                return true;
            }
            return false;
        }

        public bool modificarEn(int prmIndice, Tipo prmItem)
        {
            clsNodoDobleEnlazado<Tipo> varNodo = null;
            if (buscarNodo(prmIndice, ref varNodo))
            {
                varNodo.ponerItem(prmItem);

                return true;
            }
            return false;
        }

        public bool recuperarEn(int prmIndice, ref Tipo prmItem)
        {
            clsNodoDobleEnlazado<Tipo> varNodo = null;
            if (buscarNodo(prmIndice, ref varNodo))
            {
                prmItem = varNodo.darItem();

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

        #endregion CRUDs

        #endregion Metodos
    }
}