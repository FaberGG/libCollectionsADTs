﻿using pkgServices.pkgCollections.pkgLineal.pkgInterfaces;
using System;
using System.Linq;

namespace pkgServices.pkgCollections.pkgLineal.pkgADT
{
    public class clsADTLineal<T>: iADTLineal<T> where T : IComparable<T>
    {
        #region Attributes
        protected int attLength = 0;
        protected bool attItsOrderedAscending = false;
        protected bool attItsOrderedDescending = false;
        private int prmItemsCount = 0;
        protected T[] prmArray = new T[100];
        public clsADTLineal()
        {
            
        }
        public clsADTLineal(int attLength)
        {
            prmArray = new T[attLength];
            attLength = 0;
            attItsOrderedAscending = false;
            attItsOrderedDescending = false;
            prmItemsCount = 0;
        }
        #endregion
        #region Operations
        #region Getters
        public int opGetLength()
        {
            return attLength;
        }
        #endregion
        #region Serialize/Deserialize
        public virtual T[] opToArray()
        {
            throw new NotImplementedException();
        }
        public String opToString()
        {
            throw new NotImplementedException();
        }
        public virtual bool opToItems(T[] prmArray)
        {
            throw new NotImplementedException();
        }
        public virtual bool opToItems(T[] prmArray, int prmItemsCount)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region CRUDs
        public bool opModify(int prmIdx, T prmItem)
        {
            if (prmIdx >= 0 && prmIdx < prmItemsCount)
            {
                prmArray[prmIdx] = prmItem;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool opRetrieve(int prmIdx, ref T prmItem)
        {
            if (prmIdx >= 0 && prmIdx < prmItemsCount)
            {
                prmItem = prmArray[prmIdx];
                return true;
            }
            else
            {
                prmItem = default(T);
                return false;
            }
        }
        public bool opReverse()
        {
            prmArray.Reverse();
            return true;
        }
        public int opGetLength(T prmItem)
        {
            throw new NotImplementedException();
        }
        public int opFind(T prmItem)
        {
            throw new NotImplementedException();
        }
        public bool opExists(T prmItem)
        {
            throw new NotImplementedException();
        }
        public bool opItsEmpty()
        {
            throw new NotImplementedException();
        }
        public bool opItsValid(int prmIndex)
        {
            throw new NotImplementedException();
        }
        public bool opItsOrderedAscending()
        {
            attLength = prmArray.Length;
            for (int i = 1; i < attLength; i++)
            {
                if (prmArray[i].CompareTo(prmArray[i - 1]) <= 0)
                {
                    attItsOrderedDescending = false;
                    return attItsOrderedDescending;
                }
            }
            attItsOrderedDescending = true;
            return attItsOrderedDescending;
        }
        public bool opItsOrderedDescending()
        {
            attLength = prmArray.Length;
            for (int i = 1; i < attLength; i++)
            {
                if (prmArray[i].CompareTo(prmArray[i - 1]) >= 0)
                {
                    attItsOrderedDescending = false;
                    return attItsOrderedDescending;
                }
            }
            attItsOrderedDescending = true;
            return attItsOrderedDescending;
        }
        public bool opItsValid()
        {
            throw new NotImplementedException();
        }
        //public bool opSetCapacity(int prmValue)
        //{
        //    attTotalCapacity = prmValue;
        //    return true;
        //}
        #endregion 
        #endregion
    }
}