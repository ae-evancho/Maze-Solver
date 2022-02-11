using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Donner le nom de fichier image(.bmp)\n");
            string st = Console.ReadLine();
            string path = @"C:\\Users\\Assil\\Desktop\\" + st + ".bmp";
            byte[] b = File.ReadAllBytes(path);
            int len = b.GetLength(0);
            HexRep[] H = new HexRep[len];
            double Start = (double)DateTime.Now.Ticks / TimeSpan.TicksPerSecond;
            for (int i = 0; i < len; i++)
            {
                H[i] = new HexRep();
                H[i].transformH(b[i]);

            }

            int[] sh = new int[len * 2];

            for (int i = 0; i < len; i++)
            {
                sh[i * 2] = H[i].geta();
                sh[i * 2 + 1] = H[i].getb();
            }


            int off = b[10] * 2;
            int width = b[18] + b[19] + b[20] + b[21];
            int height = b[22] + b[23] + b[24] + b[25];
            int inu = (8 - (width % 8)) % 8;
            Vertex[] n = new Vertex[height * width];
            List<Edge> v = new List<Edge>(); ;
            int k = 1;
            int j = 0;


            for (int i = 0; i < width - 1; i++) { if (sh[off + i] != 0) { n[0] = new Vertex(); n[0].createNode(i, 0, inu, width); } }


            int l = 1;
            bool foundX = false;
            bool foundY = false;
            bool solution = true;
            int col = 1;


            while (l <= height - 2)
            {
                if (sh[off + col + ((inu + width) * l)] != 0)
                {
                    if (((sh[off + col + ((inu + width) * (l - 1))] != 0) || (sh[off + col + ((inu + width) * (l + 1))] != 0)) & ((sh[off + col + ((inu + width) * l) - 1] != 0) || (sh[off + col + ((inu + width) * l) + 1] != 0)))
                    {
                        n[k] = new Vertex();
                        n[k].createNode(col, l, inu, width); k++;



                        foundX = false;
                        int vcol = col - 1;
                        while (vcol != 0)
                        {
                            if (sh[off + vcol + ((inu + width) * l)] != 0)
                            {
                                for (int i = 0; i < k; i++)
                                {
                                    if (off + vcol + ((inu + width) * l) == off + n[i].getadr())
                                    {
                                        Edge e = new Edge();
                                        e.createEdge(i, k - 1, false);
                                        v.Add(e);
                                        n[i].incCount(); n[k - 1].incCount();
                                        j++; foundX = true; break;
                                    }
                                }
                                if (foundX) break;
                            }
                            else break;
                            vcol--;
                        }




                        foundY = false;
                        int vline = l - 1;
                        while (vline != -1)
                        {
                            if (sh[off + col + ((inu + width) * vline)] != 0)
                            {
                                for (int i = 0; i < k; i++)
                                {
                                    if (off + col + ((inu + width) * vline) == off + n[i].getadr())
                                    {
                                        Edge e = new Edge();
                                        e.createEdge(i, k - 1, true);
                                        v.Add(e);
                                        n[i].incCount(); n[k - 1].incCount();
                                        j++; foundY = true; break;
                                    }
                                }
                                if (foundY) break;
                            }
                            else break;
                            vline--;
                        }





                    }
                    col++; if (col == width) { col = 1; l++; }
                }
                else { col++; if (col == width) { col = 1; l++; } }
            }




            for (int i = 0; i < width - 1; i++)
            {
                if (sh[off + i + ((inu + width) * (height - 1))] != 0)
                {
                    n[k] = new Vertex(); n[k].createNode(i, height - 1, inu, width); k++;
                    if (sh[off + i + ((inu + width) * (height - 2))] != 0)
                    {
                        for (int ii = 0; ii < k; ii++)
                        {
                            if (off + i + ((inu + width) * (height - 2)) == off + n[ii].getadr())
                            {
                                Edge e = new Edge();
                                e.createEdge(ii, k - 1, true);
                                v.Add(e);
                                j++; n[ii].incCount(); n[k - 1].incCount();
                            }

                        }
                    }
                    else solution = false;
                }
            }



            Graph g = new Graph();
            g.createGraph(0, k - 1, v, n);
            v = g.findSolution();

             for (int i = 0; i < v.Count; i++)
             {
                 v[i].Afficher(); 
             }
             Console.Write(v.Count);
             Console.ReadKey();

             /* for (int i = 0; i < k; i++)
              {
              sh[off + n[i].getadr()] = 10;
              }*/

            
            if (v.Count == 0) solution = false;

            for (int i = 0; i < v.Count; i++)
            {
                if (v[i].getdim()) sh = v[i].remplirPY(sh, n, off, inu, width); else sh = v[i].remplirPX(sh, n, off);
            }


            for (int i = 0; i < len; i++)
            {
                H[i].seta(sh[i * 2]);
                H[i].setb(sh[i * 2 + 1]);
                b[i] = H[i].transformD();
            }

            double end = (double)DateTime.Now.Ticks / TimeSpan.TicksPerSecond;
            Console.Write((double)end - Start +"\n");

            if (!solution) Console.Write("maze cannot be solved\n");
            else {
                path = @"C:\\Users\\Assil\\Desktop\\" + st + "Solved.bmp";
                FileStream F = File.Create(path);
                F.Write(b, 0, len);
                F.Close();
                Console.Write("Solution created in : " + st + "Solved.bmp\n");
            }










            Console.ReadKey();

        }
    }
}
