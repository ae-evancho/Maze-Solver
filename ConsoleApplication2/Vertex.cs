using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Vertex
    {
        int adr,ctr,pre;
        bool preDIM;

        public void createNode(int col, int line, int inu, int wid)
        {
            this.adr = col + ((inu+wid) * line);
            this.pre = -1;
        }
        public int getadr()
        {
            return this.adr;
        }
        public void incCount() 
        {
            this.ctr++;
        }
        public void decCount()
        {
            this.ctr--;
        }
        public int getctr()
        {
            return this.ctr;
        }
        public int getpre()
        {
            return this.pre;
        }
        public void setpre(int pre)
        {
            this.pre = pre;
        }
        public bool getpreDIM()
        {
            return this.preDIM;
        }
        public void setpreDIM(bool preDIM)
        {
            this.preDIM = preDIM;
        }
    }
}
