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
        private int atrFactorCrecimiento;//Tendria que ser tenido en cuenta por los constructores

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


        public clsPilaVector()
        {
            atrLongitud = 0;
            atrCapacidad = 1000;
            atrItems = new Tipo[atrCapacidad];
            atrFlexible = true;

        }
        
        public clsPilaVector(int prmCapacidad)
        {
            atrLongitud = 0;
            atrCapacidad = prmCapacidad;
            atrItems = new Tipo[atrCapacidad];
            atrFlexible = true;
        }

        public clsPilaVector(int prmCapacidad, bool prmFlexible)
        {
            atrCapacidad = prmCapacidad;
            atrFlexible = prmFlexible;
            atrItems = new Tipo[atrCapacidad];

        }

        public bool apilar(Tipo prmItem)
        {
            try
            {

                if (atrLongitud == atrCapacidad)
                {
                    prmItem = default;
                    return false;
                    //atrCapacidad += 1000;
                    //Array.Resize(ref atrItems, atrCapacidad);
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

        
    }
}
