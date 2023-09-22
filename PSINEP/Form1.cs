using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PSINEP
{
    public partial class fmMain : Form
    {

        Functions fc = new Functions();

        public fmMain()
        {
            InitializeComponent();
        }

        private void DrawOrigData()
        {
            chart1.Series.Clear();
            Series srs1 = new Series();
            setSeriesCfg(srs1, Color.Red);
            chart1.Series.Add(srs1);

            chart1.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.DashDot;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.DashDot;
            chart1.ChartAreas[0].AxisY.Maximum = gv.mas.Max() + 1;
            chart1.ChartAreas[0].AxisY.Minimum = gv.mas.Min() - 1;
            chart1.ChartAreas[0].AxisY.Interval = 2;


            for (int i = 0; i < gv.mas.Length; i++)
                srs1.Points.AddXY(i, gv.mas[i]);
        }

        private void DrawModulationResult()
        {
            chart2.Series.Clear();
            Series srs2 = new Series();
            setSeriesCfg(srs2, Color.Red);
            chart2.Series.Add(srs2);

            chart2.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.DashDot;
            chart2.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.DashDot;
            chart2.ChartAreas[0].AxisY.Maximum = gv.mas_cos.Max() + 1;
            chart2.ChartAreas[0].AxisY.Minimum = gv.mas_cos.Min() - 1;

            for (int i = 0; i < gv.mas_cos.Length; i++)
                srs2.Points.AddXY(i, gv.mas_cos[i]);
            //
            chart3.Series.Clear();
            Series srs3 = new Series();
            setSeriesCfg(srs3, Color.Red);
            chart3.Series.Add(srs3);

            chart3.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.DashDot;
            chart3.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.DashDot;
            chart3.ChartAreas[0].AxisY.Maximum = gv.mas_sin.Max() + 1;
            chart3.ChartAreas[0].AxisY.Minimum = gv.mas_sin.Min() - 1;

            for (int i = 0; i < gv.mas_sin.Length; i++)
                srs3.Points.AddXY(i, gv.mas_sin[i]);
        }

        private void DrawResult()
        {
            Series srs2 = new Series();
            setSeriesCfg(srs2, Color.Green);
            srs2.BorderWidth = 2;
            chart1.Series.Add(srs2);

            chart1.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.DashDot;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.DashDot;
            chart1.ChartAreas[0].AxisY.Maximum = gv.sum_.Max() + 1;
            chart1.ChartAreas[0].AxisY.Minimum = gv.sum_.Min() - 1;
            chart1.ChartAreas[0].AxisY.Interval = 2;

            for (int i = 0; i < gv.sum_.Length; i++)
                srs2.Points.AddXY(i, gv.sum_[i]);
        }

        private void DrawDemodulationResult()
        {
            chart10.Series.Clear();
            Series srs2 = new Series();
            setSeriesCfg(srs2, Color.Red);
            chart10.Series.Add(srs2);

            chart10.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.DashDot;
            chart10.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.DashDot;

            for (int i = 0; i < gv.mas2.Length; i++)
                srs2.Points.AddXY(i, gv.mas2[i]);
            //
            chart11.Series.Clear();
            Series srs3 = new Series();
            setSeriesCfg(srs3, Color.Red);
            chart11.Series.Add(srs3);

            chart11.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.DashDot;
            chart11.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.DashDot;

            for (int i = 0; i < gv.mas2.Length; i++)
                srs3.Points.AddXY(i, gv.mas2[i]);
        }

        void DrawFiltrationResult()
        {
            chart4.Series.Clear();
            Series srs2 = new Series();
            setSeriesCfg(srs2, Color.Red);
            chart4.Series.Add(srs2);

            chart4.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.DashDot;
            chart4.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.DashDot;

            for (int i = 0; i < gv.mas_cos.Length; i++)
                srs2.Points.AddXY(i, gv.mas_cos[i]);
            //
            chart5.Series.Clear();
            Series srs3 = new Series();
            setSeriesCfg(srs3, Color.Red);
            chart5.Series.Add(srs3);

            chart5.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.DashDot;
            chart5.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.DashDot;

            for (int i = 0; i < gv.mas_sin.Length; i++)
                srs3.Points.AddXY(i, gv.mas_sin[i]);
        }

        void DrawGram()
        {
           // chart4.Series.Clear();
            Series srs2 = new Series();
            setSeriesCfg(srs2, Color.Blue);
            chart4.Series.Add(srs2);

            chart4.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.DashDot;
            chart4.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.DashDot;

            for (int i = 0; i < gv.mas_cosi.Length; i++)
                srs2.Points.AddXY(i, gv.mas_cosi[i]);
            //
           // chart5.Series.Clear();
            Series srs3 = new Series();
            setSeriesCfg(srs3, Color.Blue);
            chart5.Series.Add(srs3);

            chart5.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.DashDot;
            chart5.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.DashDot;

            for (int i = 0; i < gv.mas_sini.Length; i++)
                srs3.Points.AddXY(i, gv.mas_sini[i]);
        }

        void DrawSubtracking()
        {
            chart8.Series.Clear();
            Series srs2 = new Series();
            setSeriesCfg(srs2, Color.Red);
            chart8.Series.Add(srs2);

            chart8.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.DashDot;
            chart8.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.DashDot;

            for (int i = 0; i < gv.mas_cosi.Length; i++)
                srs2.Points.AddXY(i, gv.mas_cosi[i]);
            //
            chart9.Series.Clear();
            Series srs3 = new Series();
            setSeriesCfg(srs3, Color.Red);
            chart9.Series.Add(srs3);

            chart9.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.DashDot;
            chart9.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.DashDot;

            for (int i = 0; i < gv.mas_sini.Length; i++)
                srs3.Points.AddXY(i, gv.mas_sini[i]);
        }

        private void fmMain_Load(object sender, EventArgs e)
        {
            gv.M_PI= Math.PI;
            gv.NPOINTS= 1000;
            gv.NCAN= 1;
            gv.MIN_FRQ= 2;
            gv.MAX_FRQ= 40;
            gv.ORDER= 5;

            gv.FIRST_EP= 400;
            gv.LAST_EP= 600;

            gv.mas = new double[gv.NPOINTS * gv.NCAN]; 
            gv.buf = new double[gv.NPOINTS];
            gv.buf1 = new double[gv.NPOINTS];
            gv.mas_cos = new double[gv.NPOINTS * gv.NCAN];
            gv.mas_sin = new double[gv.NPOINTS * gv.NCAN];
            gv.sum_ = new double[gv.NPOINTS * gv.NCAN];
            gv.mas_sini = new double[gv.NPOINTS * gv.NCAN];
            gv.mas_cosi = new double[gv.NPOINTS * gv.NCAN];
            gv.mas1 = new double[gv.NPOINTS * gv.NCAN];
            gv.mas2 = new double[gv.NPOINTS * gv.NCAN];

            int dCnt = rTxtBxIn.Lines.Count();
            gv.mas = new double[dCnt];
            for (int i=0; i<dCnt; i++)
            {
                double.TryParse(rTxtBxIn.Lines[i], out gv.mas[i]);
            }

            tabControl1.SelectedTab = tabPage6;
        }
        public Series setSeriesCfg(Series srs, Color clr)
        {
            srs.ChartType = SeriesChartType.Line;
            srs.YValueType = ChartValueType.Double;
            srs.BorderWidth = 1;
            srs.Color = clr;
            return srs;
        }
        private void btnCalc_Click(object sender, EventArgs e)
        {
            gv.FIRST_EP = (int)UpDwnFirstERP.Value;
            gv.LAST_EP = (int)UpDwnLastERP.Value;

            DrawOrigData();
            //

            double pace_freq = 1000.0 / (gv.NPOINTS * gv.NMS);
            int k = 1;
            double freq = k * pace_freq;
            freq = (double)sedParam.Value;
            double min_freq, max_freq;
            //freq = sedParam.Value;

            fc.ini_Gram(gv.ORDER);

            min_freq = Math.Truncate(gv.MIN_FRQ / pace_freq) + 1;
            max_freq = Math.Truncate(gv.MAX_FRQ / pace_freq + 0.9);
            if (max_freq > gv.NPOINTS / 2.0) 
                max_freq = (int)(gv.NPOINTS / 2.0);

            //тут неясная шляпа: если +- сигнал модулировать классически умножением на некий синус сигнал +-, то получим модуляцию по модулю. Отрицательные значения будут
            //отображены в +. Поэтому надо добавлять постоянную составлющую в синус сигнал
            fc.modulation(freq * gv.M_PI * 2 * gv.NMS / 1000.0, ref gv.mas, gv.mas_cos, gv.mas_sin);

            DrawModulationResult();

            ///* фильтрация (туАа-обратно) */
            //надо понять какой это фильтр
            //фильтр НЧ, но странный. Когда подаёшь син/кос ниже 10Гц, начинает пропускать, но выходная амплитуда растёт с понижением частоты, превышая исходную
            //не уверен что это корректно. Скорее всего, надо нормировать и подбирать более годный фильтр (их гребёнку по частотам)
            //в статье речь про узкополосный НЧ фильтр, а тут явно обычный БИХ ФНЧ
            //Автор писал: наиболее подходящий - фильтр Чебышева 2-го рода. Результат существенно лучше, чем старый вариант с фильтром Баттерворта
            //В описании проги есть также demodulation - использовать или для выделения ВП метод комплексной демодуляции. Возможные значения параметра Yes или No;
            // fourie - использовать или для выделения ВП метод Фурье фильтрации.Возможные значения параметра Yes или No;
            //С фурье фильтрацией более-менее понятно, т.к. я пока в упор не понимаю как в м-де комплексной демодуляции выделяется нужная низкая частота на фоне других, 
            //также низких.
            /*            fc.filtr(ref gv.mas_cos);
                        fc.filtr(ref gv.mas_sin);*/

            DrawFiltrationResult();

            int ind = 0;
            for (int i = 0; i < gv.NPOINTS; i++)
            {
                gv.buf[i] = gv.mas_cos[ind];
                ind++;
            }
            //что делает эта хрень, пока совершенно неясно
            //вроде, нужно для интерполяции значений на испытуемый интервал значениями вне данного интервала
            //интерполирует очень плохо, в смысле правдоподобности
            fc.Gram(gv.buf, gv.buf1);//

            ind = 0;
            for (int i = 0; i < gv.NPOINTS; i++)
            {
                gv.mas_cosi[ind] = gv.buf1[i];
                ind++;
            }

            ind = 0;
            for (int i = 0; i < gv.NPOINTS; i++)
            {
                gv.buf[i] = gv.mas_sin[ind];
                ind++;
            }

            fc.Gram(gv.buf, gv.buf1);//

            ind = 0;
            for (int i = 0; i < gv.NPOINTS; i++)
            {
                gv.mas_sini[ind] = gv.buf1[i];
                ind++;
            }

            DrawGram();

            fc.subtracking(gv.mas_cosi, gv.mas_cos, gv.mas_cosi);//результат; от чего вычитаем; что вычитаем
            fc.subtracking(gv.mas_sini, gv.mas_sin, gv.mas_sini);

            DrawSubtracking();

            //тут вообще происходит странное: результат есть сумма повторной модуляции входных сигналов по косинусу и синусу
            fc.demodulation(freq * gv.M_PI * 2 * gv.NMS / 1000.0, gv.mas2, gv.mas_cosi, gv.mas_sini);

            DrawDemodulationResult();

            fc.summing(gv.sum_, gv.sum_, gv.mas2);//результат; слагаемое1; слагаемое2
            //fc.summing(gv.sum_, gv.sum_, gv.mas2);//зачем два раза? Пока убрал

            DrawResult();
         
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Open Text File";
            openFileDialog1.Filter = "TXT files|*.txt";
            openFileDialog1.InitialDirectory = @"d:\SINEP\ShrpSINEP\PSINEP\Data\";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //MessageBox.Show(openFileDialog1.FileName.ToString());
                using (StreamReader sReader = new StreamReader(openFileDialog1.FileName))
                {
                    string sLine = "";
                    double[] data_ = new double[10000000];
                    sLine = sReader.ReadLine();
                    string[] bits = sLine.Split(' ');
                    int indx = 0;
                        
                    for (int i=0; i<bits.Length; i++)
                    {
                        if (bits[i] != "")
                        {
                            double.TryParse(bits[i], out data_[indx]);
                            indx++;
                        }                                
                    }
                    gv.mas = new double[indx];
                    Array.Copy(data_, gv.mas, gv.mas.Length);

                    rTxtBxIn.Clear();
                    for (int i = 0; i < gv.mas.Length; i++)
                    {
                        rTxtBxIn.AppendText(gv.mas[i].ToString() + Environment.NewLine);

                    }

                }
            }
        }

        private void btnGenSignal_Click(object sender, EventArgs e)
        {
            double[] sinSignal = fc.Sine(10000);

            chart1.Series.Clear();
            Series srs1 = new Series();
            setSeriesCfg(srs1, Color.Red);
            chart1.Series.Add(srs1);

            chart1.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.DashDot;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.DashDot;
            chart1.ChartAreas[0].AxisY.Maximum = sinSignal.Max() + 1;
            chart1.ChartAreas[0].AxisY.Minimum = sinSignal.Min() - 1;
            chart1.ChartAreas[0].AxisY.Interval = 2;


            for (int i = 0; i < sinSignal.Length; i++)
                srs1.Points.AddXY(i, sinSignal[i]);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            chart1.Series[0].Enabled = (sender as CheckBox).Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            chart1.Series[1].Enabled = (sender as CheckBox).Checked;
        }
    }
}
