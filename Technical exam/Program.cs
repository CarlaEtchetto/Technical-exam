using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technical_exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] marsh = { 0, 0, 1, 0, 0, 1, 0 };
            int jumps = jumpOnMarsh(marsh);
            Console.WriteLine("Mínimo de saltos requeridos: " + jumps);
           
        }
        /* Funciones */
        /* Valida si es piedra */
        public static bool isAStone(int i)
        {
            if (i == 0)
                return true;

            return false;
        }
        /* Valida si hay posibles pasos delante */
        public static bool isRoomLeft(int i, int n)
        {
            if (i >= n)
                return false;

            return true;
        }
        /* Valida tamaño del array ingresado */
        public static bool isSizeOk(int[] n)
        {
            if (n.Length > 100 || n.Length < 2)
            {
                Console.WriteLine("Parámetro incorrecto");
                return false;
            }

            return true;

        }
        /* Valida si el array ingresado esta compuesto por números binarios y llama a la función isSizeOk para chequear el tamaño del array */
        public static bool isBinary(int[] n)
        {
           
            bool sizeOk = isSizeOk(n);
            if (sizeOk)
            {
                for (int i = 0; i < n.Length; i++)
                {
                    if (n[i] < 0 || n[i] > 1)
                    {
                        Console.WriteLine("Parámetro  incorrecto");
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        /* Valida si el array ingresado comienza y termina en 0, y llama a la función isBinary para chequear si el arreglo esta compuesto por números binarios*/
        public static bool startsAndEndsInZero(int[] n)
        {
            bool binaryOk = isBinary(n);
            if (binaryOk)
            {
                if (n[0] == 0 && n[n.Length - 1] == 0)
                {
                    return true;
                }
                return false;
            }

            return false;
        }
        /* Función de salto  */
        public static int jumpOnMarsh(int[] n)
        {
            int jumps = 0;
            bool dataOk;
            /* Chequea las restricciones */
            dataOk = startsAndEndsInZero(n);

            if (dataOk)
            {
                for (int i = 0; i < n.Length;)
                {
                    /*Chequea si es piedra y si hay posibles pasos futuros, incrementando el índice y los saltos según hay piedra o no y según la cantidad de saltos posibles */
                    if (isAStone(n[i]))
                    {
                        if (isRoomLeft(i + 1, n.Length))
                        {
                            if (isAStone(n[i + 1]))
                            {
                                if (isRoomLeft(i + 2, n.Length))
                                {
                                    if (isAStone(n[i + 2]))
                                    {
                                        jumps++;
                                        i= i+2;

                                    }
                                    else
                                    {
                                        jumps++;
                                        i++;
                                    }
                                }
                                else
                                {
                                    i++;
                                }
                            }
                            else
                            {
                                jumps++;
                                i++;
                            }
                        }
                        else
                        {
                            i++;
                        }

                    }

                    else
                    {
                        i++;
                    }

                }

            }
            return jumps;

        }


    }
}


