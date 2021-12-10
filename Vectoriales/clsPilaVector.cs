using Servicios.Colecciones.Interfaces;
using System;

namespace Servicios.Colecciones.Vectoriales
{
    public class clsPilaVector<Tipo> : iPila<Tipo> where Tipo : IComparable
    {
        #region Atributos
        private Tipo[] atrItems;
        private int atrLongitud = 0;
        private int atrCapacidad= 0;
        private bool atrDinamica = true; //Resizing por defecto activado, crece en factor de crecimiento, este factor es 
        private int atrFactorCrecimiento = 1000;//Tendria que ser tenido en cuenta por los constructores, se coloca en todos sin distincion

        #endregion
        #region Metodos
        #region Constructores

        public clsPilaVector()
        {
            atrItems = new Tipo[atrCapacidad];
        }
        public clsPilaVector(int prmCapacidad)
        {
            if(prmCapacidad>0 && prmCapacidad <= int.MaxValue/16)
            {
                atrCapacidad = prmCapacidad;
                if (prmCapacidad == int.MaxValue / 16)
                {
                    atrFactorCrecimiento = 0;
                    atrDinamica = false;
                }
            }
            atrItems = new Tipo[atrCapacidad];
        }
        
        public clsPilaVector(int prmCapacidad, bool prmFlexible)
        {
            if (prmCapacidad > 0 && prmCapacidad <= int.MaxValue / 16)
            {
                atrCapacidad = prmCapacidad;
                atrFactorCrecimiento = prmFlexible ? 1000 : 0;
                atrDinamica = prmFlexible;
                if (prmCapacidad == int.MaxValue / 16)
                {
                    atrFactorCrecimiento = 0;
                    atrDinamica = false;
                }
            }
            atrItems = new Tipo[atrCapacidad];
        }
        public clsPilaVector(int prmCapacidad, int prmFactorCrecimiento)
        {
            if (prmCapacidad > 0 && prmCapacidad <= int.MaxValue / 16)
            {
                if(prmFactorCrecimiento>= 0 && prmFactorCrecimiento < int.MaxValue / 16)
                {
                    if(prmFactorCrecimiento == 0) { atrDinamica = false; }
                    atrCapacidad = prmCapacidad;
                    atrFactorCrecimiento = prmFactorCrecimiento;
                    if(prmCapacidad == int.MaxValue / 16)
                    {
                        atrCapacidad = int.MaxValue / 16;
                        atrFactorCrecimiento = 0;
                        atrDinamica = false;
                    }
                    if(prmCapacidad == int.MaxValue/16 && prmFactorCrecimiento != 0)
                    {
                        atrCapacidad = 0;
                        atrFactorCrecimiento = 1000;
                        atrDinamica = true;
                    }
                    
                }

            }

            atrItems = new Tipo[atrCapacidad];
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
        public int darFactorCrecimiento()
        {
            return atrFactorCrecimiento;
        }

        #endregion
        #region Consultores
        public bool esDinamica()
        {
            return atrDinamica;
        }
        #endregion
        #region Mutadores
        public bool ponerItems(Tipo[] prmVector)
        {
            try
            {
                if(prmVector.Length >= 0 && prmVector.Length <= int.MaxValue/16)
                {
                    atrItems = prmVector;
                    atrLongitud = prmVector.Length;
                    atrCapacidad = prmVector.Length;
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
            if(atrCapacidad == int.MaxValue / 16 || atrCapacidad == 0)
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
            if(prmValor>= int.MaxValue / 16)
            {
                return false;
            }
            atrFactorCrecimiento = prmValor;
            return true;
        }
        #endregion
         #region CRUDs

        public bool apilar(Tipo prmItem)
        {
            try
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
                for (int i = atrLongitud - 1; i >= 0; i--)
                {
                    atrItems[i + 1] = atrItems[i];
                }
                atrItems[0] = prmItem;
                atrLongitud++;
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool desapilar(ref Tipo prmItem)
        {
            try
            {
                if (atrLongitud == 0)
                {
                    prmItem = default(Tipo);
                    return false;
                }
                prmItem = atrItems[0];

                for (int i = 0; i < atrLongitud - 1; i++)
                {
                    atrItems[i] = atrItems[i + 1];
                }
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
                    prmItem = default(Tipo);
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

        #endregion 
        #endregion
        //el basico para los espacios
    }
}
