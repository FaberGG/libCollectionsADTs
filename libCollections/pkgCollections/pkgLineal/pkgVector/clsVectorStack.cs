using System;
using pkgServices.pkgCollections.pkgLineal.pkgInterfaces;

namespace pkgServices.pkgCollections.pkgLineal.pkgVector
{
    public class clsVectorStack<T> : pkgADT.clsADTVector<T>, iStack<T> where T : IComparable<T>
    {
        #region Builders
        public clsVectorStack(int prmCapacity) : base(prmCapacity)
        {
            
            try
            {
                if (attLength < 0) attLength = 0;
                attItems = new T[prmCapacity];
            }
            catch
            {
                attTotalCapacity = 100;
                attMaxCapacity = int.MaxValue / 16;
                attItems = new T[100];
                attItsFlexible = false;
                attGrowingFactor = 100;
            }
        }
        public clsVectorStack()
        {
            attTotalCapacity = 100; // Capacidad total predeterminada
            attMaxCapacity = int.MaxValue / 16; // Capacidad máxima predeterminada
            attItems = new T[attTotalCapacity]; // Inicializar la matriz de elementos con la capacidad total
            attLength = 0; // La longitud inicial debe ser 0 ya que la pila está vacía
            attItsFlexible = false; // La pila no es flexible por defecto
            attGrowingFactor = 100; // Factor de crecimiento predeterminado
        }

        #endregion
        #region CRUDs
        public bool opPeek(ref T prmItem)
        {
            if (attLength > 0)
            {
                prmItem = attItems[0]; // Obtener el elemento superior sin eliminarlo
                return true; // Indicar que se pudo hacer el peek correctamente
            }
            else
            {
                // La pila está vacía, no se puede hacer peek
                return false;
            }
        }


        public bool opPop(ref T prmItem)
        {
            throw new NotImplementedException();
        }

        public bool opPush(T prmItem)
        {
            // Verificar si la pila está llena antes de intentar agregar un nuevo elemento
            if (attLength >= attTotalCapacity)
            {
                // Si la pila está llena y no es flexible, no se debe agregar el elemento y se debe retornar false
                return false;
            }
            else
            {
                // Si la pila no está llena, agregar el elemento y aumentar attLength
                attItems[attLength] = prmItem;
                attLength++;
                return true;
            }
        }

        #endregion
    }
}
