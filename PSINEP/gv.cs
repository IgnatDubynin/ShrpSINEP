using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINEP
{
    public static class gv
    {
        public static double[] mas, buf, buf1;

        public static double M_PI = Math.PI;
        public static int NPOINTS;
        public static int NCAN;
        public static int MIN_FRQ;
        public static int MAX_FRQ;
        public static int FIRST_EP;
        public static int LAST_EP;
        public static int ORDER;
        public static int NMS = 1;//
        public static int N21 = 21;//

        public static double[] mas_sin, mas_cos, sum_, lsum;
        public static double[] mas_sini, mas_cosi, mas1, mas2;
        public static double minr, maxr;
        public static int iam, npr, nsum;
        public static int ind;
    }
}
