﻿using System;
using pkgServices.pkgCollections.pkgLineal.pkgADT;
using pkgServices.pkgCollections.pkgLineal.pkgInterfaces;

namespace pkgServices.pkgCollections.pkgLineal.pkgDoubleLinked
{
    public class clsDoubleLinkedStack<T> : clsADTDoubleLinked<T>, iStack<T> where T : IComparable<T>
    {
        #region CRUDs
        public bool opPeek(ref T prmItem)
        {
            throw new NotImplementedException();
        }
        public bool opPop(ref T prmItem)
        {
            throw new NotImplementedException();
        }
        public bool opPush(T prmItem)
        {
            throw new NotImplementedException();
        } 
        #endregion
    }
}
