using System;
using pkgServices.pkgCollections.pkgLineal.pkgInterfaces;
using pkgServices.pkgCollections.pkgLineal.pkgVector.pkgADT;

namespace pkgServices.pkgCollections.pkgLineal.pkgVector
{
    public class clsVectorQueue<T> : clsADTVector<T>, iQueue<T> where T : IComparable<T>
    {
        #region Attributes
        #region Builders
        public clsVectorQueue(): base()
        {

        }
        public clsVectorQueue(int prmCapacity): base(prmCapacity)
        {
        }
        #endregion
        #endregion
        #region CRUDs
        public bool opPeek(ref T prmItem)
        {
            return true;
        }
        public bool opPop(ref T prmItem)
        {
            return true;
        }
        public bool opPush(T prmItem)
        {
            return true;
        } 
        #endregion
    }
}
