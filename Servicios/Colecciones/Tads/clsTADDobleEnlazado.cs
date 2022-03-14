using Servicios.Colecciones.Nodos;
using System;

namespace Servicios.Colecciones.Tads
{
    public class clsTADDobleEnlazado<Tipo> : clsTAD<Tipo> where Tipo : IComparable
    {
        #region Atributos

        protected new int atrBorde = int.MaxValue / 64;
        protected clsNodoDobleEnlazado<Tipo> atrPrimero;
        protected clsNodoDobleEnlazado<Tipo> atrUltimo;

        #endregion Atributos

        #region Metodos

        #region Constructores

        public clsTADDobleEnlazado()
        {
            atrPrimero = new clsNodoDobleEnlazado<Tipo>();
            atrUltimo = new clsNodoDobleEnlazado<Tipo>();
            atrPrimero.enlazarSiguiente(atrUltimo);
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
            for (clsNodoDobleEnlazado<Tipo> varIterador = atrPrimero.darSiguiente(); varContador != atrLongitud; varIterador = varIterador.darSiguiente())
            {
                varItems[varContador] = varIterador.darItem();
                varContador++;
            }
            return varItems;
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

        public override bool ponerItems(Tipo[] prmItems)
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

        protected bool buscarIndice(Tipo prmItem, ref int prmIndice)
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

        protected bool buscarNodo(int prmIndice, ref clsNodoDobleEnlazado<Tipo> prmNodo)
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
                clsNodoDobleEnlazado<Tipo> nuevoNodo = new clsNodoDobleEnlazado<Tipo>(atrUltimo.darAnterior(), prmItem, atrUltimo);
                atrLongitud++;
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

        protected override bool extraer(ref Tipo prmItem, int prmIndice)
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

        protected override bool recuperar(ref Tipo prmItem, int prmIndice)
        {
            clsNodoDobleEnlazado<Tipo> varNodo = null;
            if (buscarNodo(prmIndice, ref varNodo))
            {
                prmItem = varNodo.darItem();

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