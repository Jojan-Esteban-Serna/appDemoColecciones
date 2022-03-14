using Servicios.Colecciones.Interfaces;
using Servicios.Colecciones.Tads;
using System;

namespace Servicios.Colecciones.Vectoriales
{
    public class clsPilaVector<Tipo> : clsTADVectorial<Tipo>, iPila<Tipo> where Tipo : IComparable
    {
        #region Metodos

        #region Constructores

        public clsPilaVector() : base()
        {
        }

        public clsPilaVector(int prmCapacidad) : base(prmCapacidad)
        {
        }

        public clsPilaVector(int prmCapacidad, bool prmFlexible) : base(prmCapacidad, prmFlexible)
        {
        }

        public clsPilaVector(int prmCapacidad, int prmFactorCrecimiento) : base(prmCapacidad, prmFactorCrecimiento)
        {
        }

        #endregion Constructores

        #region CRUDs

        public bool apilar(Tipo prmItem)
        {
            return insertar(prmItem, 0);
        }

        public bool desapilar(ref Tipo prmItem)
        {
            return extraer(ref prmItem, 0);
        }

        public bool revisar(ref Tipo prmItem)
        {
            return recuperar(ref prmItem, 0);
        }

        #endregion CRUDs

        #endregion Metodos

        //el basico para los espacios
    }
}