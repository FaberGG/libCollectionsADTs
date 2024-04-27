using pkgServices.pkgCollections.pkgLineal.pkgInterfaces;
using System;
using System.Collections.Generic;

namespace pkgServices.pkgCollections.pkgLineal.pkgVector.pkgADT
{
    public class clsADTVector<T> : pkgLineal.pkgADT.clsADTLinked<T>, iADTVector<T> where T : IComparable<T>
    {
        #region Attributes
        protected int attTotalCapacity = 100;
        protected static int attMaxCapacity = int.MaxValue / 16;
        protected T[] attItems = new T[100];
        protected bool attItsFlexible = false;
        protected int attGrowingFactor = 1;
        #endregion
        #region Operations
        #region Builders
        protected clsADTVector()
        {
            attTotalCapacity = 100; // Capacidad total predeterminada
            attMaxCapacity = int.MaxValue / 16; // Capacidad máxima predeterminada
            attItems = new T[attTotalCapacity]; // Inicializar la matriz de elementos con la capacidad total
            attLength = 0; // La longitud inicial debe ser 0 ya que la pila está vacía
            attItsFlexible = false; // La pila no es flexible por defecto
            attGrowingFactor = 100; // Factor de crecimiento predeterminado
        }
        protected clsADTVector(int prmCapacity)
        {
            try
            {
                if (attLength < 0) attLength = 0; 

                if (prmCapacity <= 0 || prmCapacity > opGetMaxCapacity())
                {
                    throw new ArgumentException("La capacidad proporcionada no es válida.");
                }

                if (prmCapacity == attMaxCapacity)
                {
                    attGrowingFactor = 0;
                }
                else if( prmCapacity == attMaxCapacity -1)
                {
                    attGrowingFactor = 1; // Establecer el valor predeterminado si no hay excepción
                }

                attTotalCapacity = prmCapacity;
                attItems = new T[prmCapacity];
                attGrowingFactor = 100;
            }
            catch (Exception e)
            {
                base.attLength = 0;
                attItsOrderedAscending = false;
                attItsOrderedDescending = false;
                attTotalCapacity = 100;
                attItems = new T[100];
                attItsFlexible = false;
                attGrowingFactor = 100; // Establecer el factor de crecimiento en caso de excepción
            }
        }

        #endregion
        #region Getters
        public int opGetTotalCapacity()
        {
            return attTotalCapacity;
        }
        public int opGetGrowingFactor()
        {
            
            return attGrowingFactor;
            
        }
        public int opGetAvailableCapacity()
        {
            return attTotalCapacity - attLength;
        }
        public static int opGetMaxCapacity()
        {
            return attMaxCapacity;
        }
        #endregion
        #region Setters
        public bool opSetGrowingFactor(int prmValue)
        {
            attGrowingFactor = prmValue;
            return true;
        }
        public bool opSetCapacity(int prmValue)
        {
            attTotalCapacity = prmValue;
            return true;
        }
        public bool opSetFlexible()
        {
            attItsFlexible = true;
            return true;
        }
        public bool opSetInflexible()
        {
            attItsFlexible = false;
            return false;
        }
        #endregion
        #region Query
        public bool opItsFull()
        {
            throw new NotImplementedException();
        }
        public bool opItsFlexible()
        {
            return attItsFlexible;
        }
        #endregion
        #region Serialize/Deserialize
        public override T[] opToArray()
        {
            return attItems;
        }
        public override bool opToItems(T[] prmArray)
        {
            try
            {
                attItems = prmArray;
                attTotalCapacity = prmArray.Length;
                base.attLength = attItems.Length;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public override bool opToItems(T[] prmArray, int prmItemsCount)
        {
            attItems = prmArray;
            attTotalCapacity = prmArray.Length;
            base.attLength = prmItemsCount;
            return true;
        }
        #endregion
        #endregion
    }
}
