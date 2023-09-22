using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSINEP
{
    public class Functions
    {
        public double s1, s2, c1, c2, kb;
        public double Bz = 0.00391;
        public double A1 = -1.974556;
        public double A2 = 0.975181;
        public double A3 =-0.975182;
        public List<double[]> orto = new List<double[]>();
        public double[] xx;
        public int M;
        public int nep, nd2;
        public string er0 = "не хватает памяти";

        public double[] Sine(int n)
        {
            const int FS = 1000; // частота дискретизации

            return MathNet.Numerics.Generate.Sinusoidal(n, FS, 1.0, 10.0);
        }

        public void ini_Gram(int m_)
        {
            int i, j, k;
            double r;
            double[] coeff = new double[gv.N21];
            double[] rv;
            double rr;

            M = m_;
            //* созАаАим массив аргументов */
            nep = gv.LAST_EP - gv.FIRST_EP + 1;
            nd2 = gv.NPOINTS - gv.LAST_EP - 1;
            xx = new double[gv.NPOINTS];
            rr = 2.0 / gv.NPOINTS;
            r = -1.0;
            for (i = 0; i < gv.NPOINTS; i++)
            {
                xx[i] = r;
                r += rr;
            }
            for (i = 0; i <= M; i++)
            {
                orto.Add(new double[gv.NPOINTS]);
            }
            //* многочлен нулевой степени */
            r= Math.Sqrt(1.0 / (nd2 + gv.FIRST_EP));
            for (i = 0; i < gv.NPOINTS; i++)
            {
                orto[0][i] = r;
            }
            //* вычисление многочленов старших поряАков */
            rv = new double[gv.NPOINTS];
            for (k = 1; k <= M; k++)
            {
                for (i = 0; i < gv.NPOINTS; i++)
                {
                    rv[i] = Math.Pow(xx[i], k);
                }
                for (j = 0; j < k; j++)
                {
                    rr = 0;
                    for (i = 0; i < gv.FIRST_EP; i++)
                        rr += rv[i] * orto[j][i];

                    for (i = gv.LAST_EP + 1; i < gv.NPOINTS; i++)
                        rr += rv[i] * orto[j][i];

                    coeff[j] = rr;
                }
                for (j = 0; j < k; j++)
                {
                    for (i = 0; i < gv.NPOINTS; i++)
                    {
                        rv[i] -= coeff[j] * orto[j][i];
                    }
                }
                rr = 0;
                for (i = 0; i < gv.FIRST_EP; i++)
                    rr += rv[i] * rv[i];

                for (i = gv.LAST_EP + 1; i < gv.NPOINTS; i++)
                    rr += rv[i] * rv[i];

                rr = Math.Sqrt(rr);
                for (i = 0; i < gv.NPOINTS; i++)
                {
                    orto[k][i] = rv[i] / rr;
                }
            }
        }
        public double SIN_()
        {
            double s0 = s1 * kb - s2;
            s2 = s1;
            s1 = s0;
            return s0;
        }
        public double COS_()
        {
            double c0 = c1 * kb - c2;
            c2 = c1;
            c1 = c0;
            return c0;
        }
        public void ini_oscillator(double betta)
        {
            s1 = -Math.Sin(betta);
            s2 = -Math.Sin(betta * 2);
            c1 = Math.Cos(betta);
            c2 = Math.Cos(betta * 2);
            kb = c1 * 2;
        }
        public void modulation(double betta, ref double[] mas, double[] mas_cos, double[] mas_sin)
        {
            int ind = 0;
            double sn, cn;
            ini_oscillator(betta);
            for (int i = 0; i < gv.NPOINTS; i++)
            {
                sn = SIN_(); cn = COS_();
                for (int j = 0; j < gv.NCAN; j++)
                {
                    mas_cos[ind] = mas[ind] * cn; //mas[ind] * cn; //сумма - это отсебятинка. Аналог интерференции, вместо модуляции из радио, когда нужна доп.постоянка
                    mas_sin[ind] = mas[ind] * sn;//mas[ind] * sn;
                    ind++;
                }
            }
        }
        public void demodulation(double betta, double[] mas, double[] mas_cos, double[] mas_sin)
        {
            int i, j, ind = 0;
            double sn, cn;
            ini_oscillator(betta);
            for (i = 0; i < gv.NPOINTS; i++)
            {
                sn = SIN_(); cn = COS_();
                for (j = 0; j < gv.NCAN; j++)
                {
                    //странная какая-то демодуляция. 
                    mas[ind] = mas_cos[ind] * cn + mas_sin[ind] * sn;
                    ind++;
                }
            }
        }
        public void filtr(ref double[] mas)
        {
            //* "зануление" концов */
            //сделано для линейного массива, поэтому надо будет переделывать, если использовать 2d массив
            int ind = gv.NPOINTS * gv.NCAN - 1;
            int i,j,k = 0;
            double r;
            for (i = 0; i < 20; i++)
            {
                r = 1.0 - Math.Cos(i * gv.M_PI / 40.0);
                for (j = 0; j < gv.NCAN; j++)
                {
                    mas[k] = r;
                    mas[ind] = r;
                    k++;
                    ind--;
                }
            }
            //* фильтрация в прямом направлении */
            ind = gv.NCAN * 2;
            for (i = 2; i < gv.NPOINTS; i++)
            {
                for (j = 0; j < gv.NCAN; j++)
                {
                    mas[ind] = Bz * mas[ind] - A1 * mas[ind - gv.NCAN] - A2 * mas[ind - gv.NCAN - gv.NCAN];
                    ind++;
                }
            }
            //* фильтрация в обратном направлении */
            ind = gv.NPOINTS * gv.NCAN - 1 - gv.NCAN * 2;
            for (i = 2; i < gv.NPOINTS; i++)
            {
                for (j = 0; j < gv.NCAN; j++)
                {
                    mas[ind] = Bz * mas[ind] - A1 * mas[ind + gv.NCAN] - A2 * mas[ind + gv.NCAN + gv.NCAN];
                    ind--;
                }
            }

            ind = gv.NPOINTS * gv.NCAN - 1 - gv.NCAN * 2;
            for (i = 2; i < gv.NPOINTS; i++)
            {
                for (j = 0; j < gv.NCAN; j++)
                {
                    mas[ind] = Bz * mas[ind] - A3 * mas[ind + gv.NCAN];
                    ind--;
                }
            }
        }
        public void Gram(double[] inp, double[] Out_)
        {
            int i, k = 0;
            double r, rr;
            double[] coeff = new double[gv.N21];

            for (k = 0; k <= M; k++)
            {
                r = 0;
                for (i = 0; i < gv.FIRST_EP; i++)
                {
                    r += inp[i] * orto[k][i];
                }
                for (i = gv.LAST_EP+1; i < gv.NPOINTS; i++)
                {
                    r += inp[i] * orto[k][i];
                }
                coeff[k] = r;
            }
            for (i = 0; i < gv.NPOINTS; i++)
            {
                Out_[i] = 0;
                for (k = 0; k <= M; k++)
                {
                    Out_[i] = Out_[i] + coeff[k] * orto[k][i];
                }
            }
            rr = 1.0 / (double)gv.FIRST_EP;
            r = 1.0;
            for (i = 0; i < gv.FIRST_EP; i++)
            {
                Out_[i] = inp[i] * r + Out_[i] * (1.0 - r);
                r -= rr;
            }
            k = gv.NPOINTS - gv.LAST_EP - 1;
            if (k <= 0)
                rr = 1.0;
            else
                rr = 1.0 / k;
            r = 0;
            for (i = gv.LAST_EP + 1; i < gv.NPOINTS; i++)
            {
                Out_[i] = inp[i] * r + Out_[i] * (1.0 - r);
                r += rr;
            }
        }
        public void subtracking(double[] sum, double[] mas1, double[] mas2)
        {
            int i, j, ind = 0;
            for (i = 0; i < gv.NPOINTS; i++)
            {
                for (j = 0; j < gv.NCAN; j++)
                {
                    sum[ind] = mas1[ind] - mas2[ind];
                    ind++;
                }
            }
        }
        public void summing(double[] sum, double[] mas1, double[] mas2)
        {
            int i, j, ind = 0;
            for (i = 0; i < gv.NPOINTS; i++)
            {
                for (j = 0; j < gv.NCAN; j++)
                {
                    sum[ind] = mas1[ind] + mas2[ind];
                    ind++;
                }
            }
        }
    }
}
