using Servicios.Colecciones.Interfaces;
using System;

namespace Servicios.Colecciones.Vectoriales
{
    public class clsPilaVector<Tipo> : iPila<Tipo> where Tipo : IComparable
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

        public clsPilaVector()
        {
            atrItems = new Tipo[atrCapacidad];
        }

        public clsPilaVector(int prmCapacidad)
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

        public clsPilaVector(int prmCapacidad, bool prmFlexible)
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

        public clsPilaVector(int prmCapacidad, int prmFactorCrecimiento)
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

            #region Antigua implementación

            /*if(prmCapacidad == 0 && prmFactorCrecimiento > 0 && prmFactorCrecimiento <atrBorde)
            {
                atrItems = new Tipo[atrCapacidad];
                atrFactorCrecimiento = prmFactorCrecimiento;
                return;
            }

            if (validarCapacidad(prmCapacidad) && validarFactorCrecimiento(prmFactorCrecimiento))
            {
                atrDinamica = prmFactorCrecimiento == 0 ? false : true;
                atrCapacidad = prmCapacidad;
                atrFactorCrecimiento = prmFactorCrecimiento;
                if (prmCapacidad == atrBorde)
                {
                    if (prmFactorCrecimiento != 0)
                    {
                        atrCapacidad = 0;
                        atrFactorCrecimiento = 1000;
                        atrDinamica = true;
                    }
                    else { atrDinamica = false; }
                }
            }
            atrItems = new Tipo[atrCapacidad];*/

            #endregion Antigua implementación
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

        public bool ponerLongitud(int prmValor)
        {
            atrLongitud = prmValor;
            return true;
        }

        public bool ponerCapacidad(int prmValor)
        {
            atrCapacidad = prmValor;
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

        public bool apilar(Tipo prmItem)
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
            Array.Copy(atrItems, 0, atrItems, 1, atrLongitud);
            /*
             for (int i = atrLongitud - 1; i >= 0; i--)
            {
                atrItems[i + 1] = atrItems[i];
            }
             */
            atrItems[0] = prmItem;
            atrLongitud++;
            return true;
        }

        public bool desapilar(ref Tipo prmItem)
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
                }*/
                //atrItems[atrLongitud -1] = default;
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

        #endregion CRUDs

        #endregion Metodos

        //el basico para los espacios
    }
}