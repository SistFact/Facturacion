using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRNC
{

    public static class carro
    {

        public static int _num;


        public static int Numero
        {
            get { _num = 8 + 5;
                 return _num;
            }
            set { _num = value; }
        }
        
       

    }

}
