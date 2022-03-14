using Servicios.Colecciones.Interfaces;
using System;

namespace Servicios.Colecciones.Tads
{
    //public abstract class clsTAD<Tipo> : iTAD<Tipo> where Tipo : IComparable
    public class clsTAD<Tipo> : iTAD<Tipo> where Tipo : IComparable
    {
        #region Atributos

        protected int atrLongitud = 0;
        protected int atrBorde = int.MaxValue / 16;

        #endregion Atributos

        #region Metodos

        #region CRUDs

        #region Propios

        // protected abstract bool insertar(Tipo prmItem, int prmIndice);
        protected virtual bool insertar(Tipo prmItem, int prmIndice)
        {
            throw new NotImplementedException();
        }

        // protected abstract bool extraer(ref Tipo prmItem, int prmIndice);
        protected virtual bool extraer(ref Tipo prmItem, int prmIndice)
        {
            throw new NotImplementedException();
        }

        //protected abstract bool recuperar(ref Tipo prmItem, int prmIndice);
        protected virtual bool recuperar(ref Tipo prmItem, int prmIndice)
        {
            throw new NotImplementedException();
        }

        #endregion Propios

        //Interface

        #region Polimorficos

        //public abstract bool contieneA(Tipo ptmItem);

        public virtual bool contieneA(Tipo prmItem)
        {
            throw new NotImplementedException();
        }

        //public abstract Tipo[] darItems();

        public virtual Tipo[] darItems()
        {
            throw new NotImplementedException();
        }

        public int darLongitud()
        {
            return atrLongitud;
        }

        //public abstract int encontrarA(Tipo prmItem);

        public virtual int encontrarA(Tipo prmItem)
        {
            throw new NotImplementedException();
        }

        //public abstract bool ponerItems(Tipo[] prmItems);

        public virtual bool ponerItems(Tipo[] prmItems)
        {
            throw new NotImplementedException();
        }

        //public abstract bool reversar();
        public virtual bool reversar()
        {
            throw new NotImplementedException();
        }

        #endregion Polimorficos

        #endregion CRUDs

        #endregion Metodos
    }
}