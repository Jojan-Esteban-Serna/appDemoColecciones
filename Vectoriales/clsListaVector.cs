using Servicios.Colecciones.Interfaces;
using System;

namespace Servicios.Colecciones.Vectoriales
{
    public class clsListaVector<Tipo> : iLista<Tipo> where Tipo : IComparable
    {
        #region Atributos

        private Tipo[] atrItems;
        private int atrLongitud = 0;
        private int atrCapacidad = 0;
        private bool atrDinamica = true;
        private int atrFactorCrecimiento = 1000;
        private int atrBorde = int.MaxValue / 16;

        #endregion Atributos

        #region Metodos

        #region Constructores

        public clsListaVector()
        {
            atrItems = new Tipo[atrCapacidad];
        }

        public clsListaVector(int prmCapacidad)
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

        public clsListaVector(int prmCapacidad, bool prmFlexible)
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

        public clsListaVector(int prmCapacidad, int prmFactorCrecimiento)
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

        #endregion Constructores

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

        public int darFactorCrecimiento()
        {
            return atrFactorCrecimiento;
        }

        #endregion Accesores

        #region Consultores

        public bool esDinamica()
        {
            return atrDinamica;
        }

        #endregion Consultores

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

        public bool ajustarFactorCrecimiento(int prmValor)
        {
            if (prmValor >= atrBorde)
            {
                return false;
            }
            atrFactorCrecimiento = prmValor;
            return true;
        }

        #endregion Mutadores

        #region CRUDs

        public bool agregar(Tipo prmItem)
        {
            if (atrLongitud == atrCapacidad)
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

        public bool insertarEn(int prmIndice, Tipo prmItem)
        {
            if (prmIndice < 0 || prmIndice > atrLongitud)
            {
                return false;
            }

            if (atrLongitud == atrCapacidad)
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

            if (atrLongitud - prmIndice < 0)
            {
                return false;
            }

            Array.Copy(atrItems, prmIndice, atrItems, prmIndice + 1, atrLongitud - prmIndice);
            atrItems[prmIndice] = prmItem;
            atrLongitud++;
            return true;
        }

        public bool extraerEn(int prmIndice, ref Tipo prmItem)
        {
            if (prmIndice < 0 || atrLongitud == 0 || prmIndice >= atrLongitud)
            {
                prmItem = default(Tipo);
                return false;
            }

            prmItem = atrItems[prmIndice];
            Array.Copy(atrItems, prmIndice + 1, atrItems, prmIndice, atrLongitud - prmIndice - 1);
            atrLongitud--;
            return true;
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
            if (prmIndice < 0 || atrLongitud == 0 || prmIndice >= atrLongitud)
            {
                prmItem = default(Tipo);
                return false;
            }
            prmItem = atrItems[prmIndice];
            return true;
        }

        public bool contieneA(Tipo prmItem)
        {
            foreach (Tipo varItem in atrItems)
            {
                if (varItem.CompareTo(prmItem) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        public int encontrarA(Tipo prmItem)
        {
            for (int varIndice = 0; varIndice < atrLongitud; varIndice++)
            {
                if (atrItems[varIndice].CompareTo(prmItem) == 0)
                {
                    return varIndice;
                }
            }

            return -1;
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

        #endregion CRUDs

        #endregion Metodos
    }
}