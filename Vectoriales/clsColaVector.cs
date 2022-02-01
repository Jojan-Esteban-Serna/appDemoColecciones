using System;
using Servicios.Colecciones.Interfaces;

namespace Servicios.Colecciones.Vectoriales
{
    public class clsColaVector<Tipo> : iCola<Tipo> where Tipo:IComparable
    {
        #region Atributos 
        private Tipo[] atrItems;
        private int atrLongitud = 0;
        private int atrCapacidad = 0;
        private bool atrDinamica = true;
        private int atrFactorCrecimiento = 1000;
        private int atrBorde = int.MaxValue / 16;

        #endregion

        #region Metodos
        #region Constructores
        public clsColaVector()
        {
            atrItems = new Tipo[atrCapacidad];
        }
        public clsColaVector(int prmCapacidad)
        {
            if (validarCapacidad(prmCapacidad))
            {
                atrCapacidad = prmCapacidad;
                if (prmCapacidad == atrBorde)
                {
                    atrFactorCrecimiento = 0;
                    atrDinamica = false;
                }
            }
            atrItems = new Tipo[atrCapacidad];
        }
        public clsColaVector(int prmCapacidad, bool prmFlexible)
        {
            if (validarCapacidad(prmCapacidad))
            {
                atrCapacidad = prmCapacidad;
                atrFactorCrecimiento = prmFlexible ? 1000 : 0;
                atrDinamica = prmFlexible;
                if (prmCapacidad == atrBorde)
                {
                    atrFactorCrecimiento = 0;
                    atrDinamica = false;
                }
            }
            atrItems = new Tipo[atrCapacidad];
        }
        public clsColaVector(int prmCapacidad, int prmFactorCrecimiento)
        {
            if (prmCapacidad < 0 || prmCapacidad > atrBorde || prmFactorCrecimiento < 0 || prmFactorCrecimiento > atrBorde)
            {
                atrItems = new Tipo[atrCapacidad];
                return;
            }
            else if (prmCapacidad == 0 && prmFactorCrecimiento == 0 || prmCapacidad == atrBorde && prmFactorCrecimiento > 0)
            {
                atrItems = new Tipo[atrCapacidad];
                return;
            }
            else
            {
                atrCapacidad = prmCapacidad;
                atrFactorCrecimiento = prmFactorCrecimiento;
                atrDinamica = atrFactorCrecimiento == 0 || prmCapacidad == atrBorde ? false : true;
                atrItems = new Tipo[atrCapacidad];

            }
        }
        public bool validarCapacidad(int prmCapacidad)
        {
            return prmCapacidad > 0 && prmCapacidad <= atrBorde;
        }
        #endregion
        #region Accesores
        public Tipo[] darItems()
        {
            return atrItems;
        }

        public int darLongitud()
        {
            return atrLongitud;
        }

        public int darCapacidad()
        {
            return atrCapacidad;
        }

        public bool esDinamica()
        {
            return atrDinamica;
        }

        public int darFactorCrecimiento()
        {
            return atrFactorCrecimiento;
        }
        #endregion

        #region Mutadores
        public bool ponerItems(Tipo[] prmVector)
        {
            try
            {
                if (prmVector.Length >= 0 && prmVector.Length <= atrBorde)
                {
                    atrItems = prmVector;
                    atrLongitud = prmVector.Length;
                    atrCapacidad = prmVector.Length;
                    atrFactorCrecimiento = atrItems.Length == atrBorde ? 0 : 1000;
                    atrDinamica = atrFactorCrecimiento == 0 ? false : true;
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool ajustarFactorCrecimiento(int prmValor)
        {
            if (prmValor >= atrBorde)
            {
                return false;
            }
            atrFactorCrecimiento = prmValor;
            return true;
        }
        public bool ajustarFlexibilidad(bool prmValor)
        {
            if (atrCapacidad == atrBorde || atrCapacidad == 0)
            {
                return false;
            }
            else
            {
                atrDinamica = prmValor;
                if (!atrDinamica)
                    atrFactorCrecimiento = 0;

            }

            return true;
        }
        #endregion

        #region CRUDS
        public bool encolar(Tipo prmItem)
        {
            try
            {
                if(atrLongitud == atrCapacidad)
                {
                    if (atrDinamica)
                    {
                        atrCapacidad += atrFactorCrecimiento;
                        Array.Resize(ref atrItems, atrCapacidad);
                    }
                    else
                    {
                        return false;
                    }
                }
                atrItems[atrLongitud] = prmItem;
                atrLongitud++;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool desencolar(ref Tipo prmItem)
        {
            try
            {
                if (atrLongitud == 0)
                {
                    return false;
                }
                prmItem = atrItems[0];
                Array.Copy(atrItems, 1, atrItems, 0, atrLongitud - 1);
                /*
                for (int i = 0; i < atrLongitud - 1; i++)
                {
                    atrItems[i] = atrItems[i + 1];
                }
                //atrItems[atrLongitud -1] = default;
                */
                atrLongitud--;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool revisar(ref Tipo prmItem)
        {
            try
            {
                if (atrLongitud == 0)
                {
                    return false;
                }
                prmItem = atrItems[0];
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool reversar()
        {
            if (atrLongitud == 0)
            {
                return false;
            }
            int varMitad = (int)atrLongitud / 2;
            for (int varIndice = 0; varIndice < varMitad; varIndice++)
            {
                Tipo varItemActual = atrItems[varIndice];
                atrItems[varIndice] = atrItems[atrLongitud - 1 - varIndice];
                atrItems[atrLongitud - 1 - varIndice] = varItemActual;
            }
            return true;

        }
        #endregion
        #endregion


    }
}
