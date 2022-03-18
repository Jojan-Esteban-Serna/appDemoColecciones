using Servicios.Colecciones.Interfaces;
using Servicios.Colecciones.Nodos;
using Servicios.Colecciones.Tads;

using System;

namespace Servicios.Colecciones.Enlazadas
{
    public class clsListaEnlazada<Tipo> : clsTADEnlazado<Tipo>, iLista<Tipo> where Tipo : IComparable
    {
        #region Metodos

        #region Constructores

        public clsListaEnlazada() : base()
        {
        }

        #endregion Constructores

        #region CRUDs

        public bool agregar(Tipo prmItem)
        {
            return insertar(prmItem, atrLongitud);
        }

        public bool extraerEn(int prmIndice, ref Tipo prmItem)
        {
            return extraer(ref prmItem, prmIndice);
        }

        public bool insertarEn(int prmIndice, Tipo prmItem)
        {
            return insertar(prmItem, prmIndice);
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
            return recuperar(ref prmItem, prmIndice);
        }

        #endregion CRUDs

        #endregion Metodos
    }
}
