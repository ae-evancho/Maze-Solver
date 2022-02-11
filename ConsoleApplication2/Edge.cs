using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Edge
    {
        public int a, b;
        bool dim; // 0 vertex in x dim (line) 1 vertex in y dim (column)

        public void createEdge(int node1, int node2, bool dimension)
        {
            this.a = node1;
            this.b = node2;
            this.dim =dimension;
        }

        public void Afficher()
        {
            Console.Write("(" + this.a + "," + this.b + ":" + this.dim + "\n");
        }

        public int [] remplirPX(int[] sh, Vertex[] n, int off )
        {
           int adr1= n[this.a].getadr();
           int adr2= n[this.b].getadr();
           
            while(adr1 <= adr2)
            {
                sh[off + adr1] = 13; adr1++;
            }
            return sh;   
        }

        public int[] remplirPY(int[] sh, Vertex[] n, int off, int inu , int w)
        {
            int adr1 = n[this.a].getadr();
            int adr2 = n[this.b].getadr();
            while (adr1 <= adr2)
            {
                sh[off + adr1] = 13; adr1 = adr1 + (inu + w); 
            }
            return sh;
        }

        public bool getdim()
        {
            return this.dim;
        }
    
    
    
    
    }
}
