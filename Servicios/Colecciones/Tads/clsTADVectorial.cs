using System;

namespace Servicios.Colecciones.Tads
{
    public class clsTADVectorial<Tipo> : clsTAD<Tipo> where Tipo : IComparable
    {
        #region Atributos

        protected Tipo[] atrItems;
        protected int atrCapacidad = 0;
        protected bool atrDinamica = true;
        protected int atrFactorCrecimiento = 1000;

        #endregion Atributos

        #region Metodos

        #region Contructores

        protected clsTADVectorial()
        {
            atrItems = new Tipo[atrCapacidad];
        }

        protected clsTADVectorial(int prmCapacidad)
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

        protected clsTADVectorial(int prmCapacidad, bool prmFlexible)
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

        protected clsTADVectorial(int prmCapacidad, int prmFactorCrecimiento)
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

        protected bool validarCapacidad(int prmCapacidad)
        {
            return prmCapacidad > 0 && prmCapacidad <= atrBorde;
        }

        #endregion Contructores

        #region Accesores

        public override Tipo[] darItems()
        {
            return atrItems;
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

        public override bool ponerItems(Tipo[] prmVector)
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

        public bool ponerCapacidad(int prmValor)
        {
            if (atrCapacidad <= 0 || atrCapacidad > atrBorde)
            {
                return false;
            }
            atrCapacidad = prmValor;
            return true;
        }

        #endregion Mutadores

        #region CRUDs

        protected override bool extraer(ref Tipo prmItem, int prmIndice)
        {
            if (prmIndice < 0 || atrLongitud == 0 || prmIndice >= atrLongitud)
            {
                //prmItem = default(Tipo);
                return false;
            }

            prmItem = atrItems[prmIndice];
            Array.Copy(atrItems, prmIndice + 1, atrItems, prmIndice, atrLongitud - prmIndice - 1);
            atrLongitud--;
            return true;
        }

        protected override bool insertar(Tipo prmItem, int prmIndice)
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

        protected override bool recuperar(ref Tipo prmItem, int prmIndice)
        {
            if (prmIndice < 0 || atrLongitud == 0 || prmIndice >= atrLongitud)
            {
                //prmItem = default(Tipo);
                return false;
            }
            prmItem = atrItems[prmIndice];
            return true;
        }

        public override bool contieneA(Tipo prmItem)
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

        public override int encontrarA(Tipo prmItem)
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

        public override bool reversar()
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