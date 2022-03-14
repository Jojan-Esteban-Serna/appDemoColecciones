using Servicios.Colecciones.Interfaces;
using Servicios.Colecciones.Tads;
using System;

namespace Servicios.Colecciones.Vectoriales
{
    public class clsColaVector<Tipo> : clsTADVectorial<Tipo>, iCola<Tipo> where Tipo : IComparable
    {
        #region Metodos

        #region Constructores

        public clsColaVector() : base()
        {
        }

        public clsColaVector(int prmCapacidad) : base(prmCapacidad)
        {
        }

        public clsColaVector(int prmCapacidad, bool prmFlexible) : base(prmCapacidad, prmFlexible)
        {
        }

        public clsColaVector(int prmCapacidad, int prmFactorCrecimiento) : base(prmCapacidad, prmFactorCrecimiento)
        {
        }

        #endregion Constructores

        #region CRUDS

        public bool encolar(Tipo prmItem)
        {
            return insertar(prmItem, atrLongitud);
        }

        public bool desencolar(ref Tipo prmItem)
        {
            return extraer(ref prmItem, 0);
        }

        public bool revisar(ref Tipo prmItem)
        {
            return recuperar(ref prmItem, 0);
        }

        #endregion CRUDS

        #endregion Metodos
    }
}