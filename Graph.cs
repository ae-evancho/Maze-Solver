using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Graph
    {
        List<Edge> v;
        Vertex[] n; 
        int[][] matAdj;
        int source, puits;
        int size;

        public void createGraph(int a, int b, List<Edge> v, Vertex [] n)
        {
            this.source = a;
            this.puits = b;
            this.v = v;
            this.n = n;
            this.size = n.GetLength(0);
        }
        
        public List<Edge> findSolution()
        {
            bool b=true;
            while (b)
            {
                b = false;
                for (int i = 0; i < this.puits + 1; i++)
                {
                    if (this.n[i].getctr() == 1 & i != this.source & i != this.puits) 
                    {
                        this.n[i].decCount(); b = true;
                        for (int j = 0; j < this.v.Count; j++)
                        {
                            if (this.v[j].a == i) { this.n[this.v[j].b].decCount(); this.v.Remove(this.v[j]); break; }
                            if (this.v[j].b == i) { this.n[this.v[j].a].decCount(); this.v.Remove(this.v[j]); break; }
                        }
                    }
                    
                   
                }
                
            }

            return this.v;

        }


        public List<Edge> findSolutionDJIK()
        {
            for (int i = 0; i < this.puits + 1; i++)
            {
                
                for (int j = 0; j < this.v.Count; j++)
                {
                    if (this.v[j].a == i & this.v[j].b != this.source)
                    {
                        if (this.n[this.v[j].b].getpre() == -1) {this.n[this.v[j].b].setpre(i); this.n[this.v[j].b].setpreDIM(v[j].getdim());}
                    }
                    if (this.v[j].b == i & this.v[j].a != this.source)
                    {
                        if (this.n[this.v[j].a].getpre() == -1) {this.n[this.v[j].a].setpre(i); this.n[this.v[j].a].setpreDIM(v[j].getdim());}
                    }
                }
            }

            List<Edge> temp = new List<Edge>();
            for (int i = 0; i < this.puits + 1; i++)
            {
                Edge e = new Edge();
                e.createEdge(n[i].getpre(), i, n[i].getpreDIM());
                temp.Add(e);
            }

            return temp;
        }






    }
}
