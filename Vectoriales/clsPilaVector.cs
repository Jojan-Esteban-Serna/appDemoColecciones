using Servicios.Colecciones.Interfaces;
using System;
namespace Servicios.Colecciones.Vectoriales
{
    public class clsPilaVector<Tipo> : iPila<Tipo> where Tipo : IComparable
    {
        
        private Tipo[] atrItems;
        private int atrLongitud;
        private int atrCapacidad;
        private bool atrFlexible; //Resizin por defecto activado, crece en factor de crecimiento, este factor es 
        private int atrFactorCrecimiento;//Tendria que ser tenido en cuenta por los constructores, se coloca en todos sin distincion

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
        public bool esFlexible()
        {
            return atrFlexible;
        }
        #endregion
        #region Mutadores
        public void ponerItems(Tipo[] prmItems)
        {
            try
            {
                atrItems = prmItems;
                atrLongitud = prmItems.Length;
                atrCapacidad = prmItems.Length;
            }
            catch (Exception)
            {

                return;
            }
        }

        public void ponerLongitud(int prmValor)
        {
            atrLongitud = prmValor;
        }

        public void ponerCapacidad(int prmValor)
        {
            atrCapacidad = prmValor;
        } 
        #endregion

        #region Constructores

        public clsPilaVector()
        {
            atrLongitud = 0;
            atrCapacidad = 1000;
            atrItems = new Tipo[atrCapacidad];
            atrFlexible = true;
            atrFactorCrecimiento = 1000;

        }

        public clsPilaVector(int prmCapacidad)
        {
            atrLongitud = 0;
            if (prmCapacidad <= 0 || prmCapacidad >= int.MaxValue/14 + 1000)
            {
                atrCapacidad = 0;
            }
            else
            {
                atrCapacidad = prmCapacidad;
               
            }
            atrItems = new Tipo[atrCapacidad];
            atrFlexible = true;
            atrFactorCrecimiento = 1000;

        }
        //si es -100 y false, tomar el valor absoluto con la capacidad igual al valor absoluto
        //si la capacidad es cero, retornar con valor de 100 la capacidad
        public clsPilaVector(int prmCapacidad, bool prmFlexible)//hacer flexible y no flexible para los casos de prueba, si queda en cero y es no flexible, el factor de crecimiento quedaria en cero
        {

            //Si el tamaño no es valido debe ser de capacidad 1000
            if (prmCapacidad >= int.MaxValue / 14 + 1000 || prmCapacidad <= 0)
            {
                atrFlexible = prmFlexible; 
                if (prmFlexible)
                {
                    atrCapacidad = 0;
                    atrFactorCrecimiento = 1000;
                }
                else// no es flexible, el factor de crecimiento debe ser cero, //Si no paso el if anterior quiere decir que es falso, enotnces se asigna
                {
                    atrCapacidad = 1000;
                    atrFactorCrecimiento = 0;
                }
                atrItems = new Tipo[atrCapacidad];
            }
            else // la capacidad es valido, puede tener cualquier capacidad
            {
                atrCapacidad = prmCapacidad;
                atrFlexible = prmFlexible;
                atrItems = new Tipo[atrCapacidad];
                if (prmFlexible)
                {
                    atrFactorCrecimiento = 1000;
                }
                else
                {
                    atrFactorCrecimiento = 0;
                }
            }
        }
        public clsPilaVector(int prmCapacidad,int prmFactorCrecimiento, bool prmFlexible)
        {
            atrFactorCrecimiento = prmFactorCrecimiento;
            atrCapacidad = prmCapacidad;
            atrFlexible = prmFlexible;
            atrItems = new Tipo[atrCapacidad];

        }
        #endregion
        #region CRUDs

        public bool apilar(Tipo prmItem)
        {
            try
            {

                if (atrLongitud == atrCapacidad)
                {
                    if (atrFlexible)
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
    }
}
