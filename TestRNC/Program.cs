using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRNC
{
    class Program
    {
        static void Main(string[] args)
        {



            Console.WriteLine(Program.Numero);
            
            // char[] rnc = Console.ReadLine().ToCharArray();
            // ValidarRNC(rnc);
            Console.ReadKey();
        }

        public static int _num;

        public static int Numero
        {
            get
            {
                _num = 8 + 5;
                return _num;
            }
            set { _num = value; }
        }



        public static bool ValidarRNC(char[] rnc)
        {
            char[] peso = { '7', '9', '8', '6', '5', '4', '3', '2' };
            int suma = 0;
            int division = 0;
            if (rnc.Length != 9)
            {
                Console.WriteLine("Son 9 digitos");
                return false;
            }
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    if (Char.IsDigit(rnc[i]) != true)
                    {
                        Console.WriteLine("Algunos de esto no es un digito");
                        return false;
                    }
                    suma = suma + ((int)Char.GetNumericValue(rnc[i]) * (int)Char.GetNumericValue(peso[i]));

                }
                division = suma / 11;
                int resto = suma - (division * 11);
                int digito = 0;

                if (resto == 0)
                    digito = 2;
                else if (resto == 1)
                    digito = 1;
                else
                    digito = 11 - resto;
                if (digito != (int)Char.GetNumericValue(rnc[8]))
                {
                    Console.WriteLine("No es Valido");
                    return false;
                }
            }
            Console.WriteLine("Valido");
            return true;
        }

    }
}
