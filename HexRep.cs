using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class HexRep
    {
       private int a, b;

       public int geta() 
       {
           return this.a;
       }

       public int getb()
       {
           return this.b;
       }
       public void seta(int a)
       {
           this.a = a;
       }
       public void setb(int b)
       {
           this.b = b;
       }

       public void transformH(Byte b)
       {
           int k=b % 16;
           int div = b / 16;
           div = div % 16;
           this.a = div;
           this.b = k;
       }
       public byte transformD()
       {
           return (byte)(this.a * 16 + this.b);
       }
       public void afficher()
       {
           Console.Write(this.a + "" + this.b+" ");
       }






    }
}
