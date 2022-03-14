using Servicios.Colecciones.Interfaces;
using Servicios.Colecciones.Tads;
using System;

namespace Servicios.Colecciones.Vectoriales
{
    public class clsListaVector<Tipo> : clsTADVectorial<Tipo>, iLista<Tipo> where Tipo : IComparable
    {
        #region Metodos

        #region Constructores

        public clsListaVector() : base()
        {
        }

        public clsListaVector(int prmCapacidad) : base(prmCapacidad)
        {
        }

        public clsListaVector(int prmCapacidad, bool prmFlexible) : base(prmCapacidad, prmFlexible)
        {
        }

        public clsListaVector(int prmCapacidad, int prmFactorCrecimiento) : base(prmCapacidad, prmFactorCrecimiento)
        {
        }

        #endregion Constructores

        #region CRUDs

        public bool agregar(Tipo prmItem)
        {
            return insertar(prmItem, atrLongitud);
        }

        public bool insertarEn(int prmIndice, Tipo prmItem)
        {
            return insertar(prmItem, prmIndice);
        }

        public bool extraerEn(int prmIndice, ref Tipo prmItem)
        {
            return extraer(ref prmItem, prmIndice);
        }

        public bool modificarEn(int prmIndice, Tipo prmItem)
        {
            if (prmIndice < 0 || atrLongitud == 0 || prmIndice >= atrLongitud)
            {
                return false;
            }

            atrItems[prmIndice] = prmItem;
            return true;
        }

        public bool recuperarEn(int prmIndice, ref Tipo prmItem)
        {
            return recuperar(ref prmItem, prmIndice);
        }

        #endregion CRUDs

        #endregion Metodos
    }
}