using System;
using pkgServices.pkgCollections.pkgLineal.pkgInterfaces;

namespace pkgServices.pkgCollections.pkgLineal.pkgVector
{
    public class clsVectorStack<T> : pkgADT.clsADTVector<T>, iStack<T> where T : IComparable<T>
    {
        #region Builders
        public clsVectorStack(int prmCapacity) : base(prmCapacity)
        {
            
        }
        public clsVectorStack(): base()
        {

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
            // Verificar si la pila está vacía antes de intentar sacar un elemento
            if (attLength > 0)
            {
                prmItem = attItems[0]; // Obtener el elemento superior

                // Desplazar los elementos restantes para que el elemento superior esté en el índice 0
                for (int i = 1; i < attItems.Length; i++)
                {
                    attItems[i - 1] = attItems[i];
                }


                attLength--; // Reducir la longitud de la pila
                return true; // Indicar que se pudo hacer el pop correctamente
            }
            else
            {
                prmItem = default; // No hay elementos para sacar, asignar el valor por defecto de T a prmItem
                return false; // Indicar que no se pudo hacer el pop porque la pila está vacía
            }
        }


        public bool opPush(T prmItem)
        {
            // Verificar si la pila está llena y no es flexible
            if (attLength >= attTotalCapacity && !attItsFlexible)
            {
                // No se puede agregar el elemento y se debe retornar false
                return false;
            }
            else
            {
                try
                {
                    // Crear un nuevo arreglo temporal solo si no hay suficiente espacio y la pila es flexible
                    if (attLength >= attTotalCapacity && attItsFlexible)
                    {
                        
                        if(attLength == attMaxCapacity - 1)
                        {
                            T[] tempArray = new T[attMaxCapacity];
                            tempArray[0] = prmItem;
                            attItems = tempArray;
                            attItsFlexible = false; // ya no soporta otro item mas
                            attGrowingFactor = 0;
                        }
                        else
                        {
                            T[] tempArray = new T[attLength + 100];

                            // Copiar los elementos existentes al nuevo arreglo temporal
                            for (int i = 0; i < attLength; i++)
                            {
                                tempArray[i + 1] = attItems[i]; // Desplazar los elementos hacia abajo
                            }

                            // Agregar el nuevo elemento en la posición superior (posición 0) del nuevo arreglo
                            tempArray[0] = prmItem;

                            // Asignar el nuevo arreglo temporal al arreglo original
                            attItems = tempArray;
                        }
                        // Actualizar la capacidad total
                        attTotalCapacity = attItems.Length;
                    }
                    else
                    {
                        // Agregar el nuevo elemento en la posición superior (posición 0) del arreglo original
                        for (int i = attLength - 1; i >= 0; i--)
                        {
                            attItems[i + 1] = attItems[i]; // Desplazar los elementos hacia abajo
                        }
                        attItems[0] = prmItem; // Agregar el nuevo elemento en la posición superior
                                          
                    }
                    // Incrementar la longitud de la pila
                    attLength++;

                    return true;
                }
                catch (Exception ex)
                {
                    // Manejar cualquier excepción y retornar false indicando que no se pudo agregar el elemento
                    return false;
                }
            }
        }



        #endregion
    }
}
