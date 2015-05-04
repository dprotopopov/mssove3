using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Elliptic2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LockForm();

            // Параметры элиптической кривой
            double a1 = GetA1();
            double a2 = GetA2();
            double a3 = GetA3();
            double a4 = GetA4();
            double a6 = GetA6();

            // Диапазон изменения переменноу X и количество интервалов
            double xmin = GetXmin();
            double xmax = GetXmax();
            ulong n = GetN();

            // http://stackoverflow.com/questions/10622674/chart-creating-dynamically-in-net-c-sharp
            var series1 = new Series
            {
                Name = "Series1",
                Color = Color.Black,
                IsVisibleInLegend = false,
                IsXValueIndexed = true,
                ChartType = SeriesChartType.Line
            };

            var series2 = new Series
            {
                Name = "Series2",
                Color = Color.Black,
                IsVisibleInLegend = false,
                IsXValueIndexed = true,
                ChartType = SeriesChartType.Line
            };

            var sb = new StringBuilder();
            var sb1 = new StringBuilder();
            sb.AppendLine("y^2+a1*x*y+a3*y = x^3+a2*x^2+a4*x+a6");
            sb.AppendLine("a1=" + a1);
            sb.AppendLine("a2=" + a2);
            sb.AppendLine("a3=" + a3);
            sb.AppendLine("a4=" + a4);
            sb.AppendLine("a6=" + a6);
            sb.AppendLine();
            sb.AppendLine("# X Y1 Y2");
            sb1.AppendLine("# X Y1 Y2");
            for (ulong i = 0; i <= n; i++)
            {
                double x = (xmin*(n - i) + xmax*i)/n;

                // Расчитываем параметры квадратичного уравнения для данного X
                const double a = 1;
                double b = a1*x + a3;
                double c = -(x*x*x + a2*x*x + a4*x + a6);

                // По формуле за шестой класс средней школы вычисляем решение квадратичного уравнения
                double d = b*b - 4*a*c;
                if (d < 0) continue;

                double y1 = (-b - Math.Sqrt(d))/(2*a);
                double y2 = (-b + Math.Sqrt(d))/(2*a);

                series1.Points.AddXY(x, y1);
                series2.Points.AddXY(x, y2);

                sb.AppendLine(x + " " + y1 + " " + y2);
                sb1.AppendLine(x + " " + y1 + " " + y2);
            }

            // Выдаём отчёт о проделанной работе
            SetChart(series1, series2);
            SetReport(sb.ToString());
            SetReport1(sb1.ToString());

            UnlockForm();
            ActivatePage(2);

            // Start the asynchronous operation.
            if (backgroundWorker1.IsBusy) return;
            backgroundWorker1.RunWorkerAsync();
        }

        private void SetChart(Series series1, Series series2)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (chart1.InvokeRequired)
            {
                SetChartCallback d = SetChart;
                Invoke(d, new object[] {series1, series2});
            }
            else
            {
                chart1.Series.Clear();
                chart1.Series.Add(series1);
                chart1.Series.Add(series2);
                chart1.Invalidate();
            }
        }

        private void SetReport(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (textBox2.InvokeRequired)
            {
                SetReportCallback d = SetReport;
                Invoke(d, new object[] {text});
            }
            else
            {
                textBox2.Text = text;
            }
        }

        private void SetReport1(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (textBox3.InvokeRequired)
            {
                SetReportCallback d = SetReport1;
                Invoke(d, new object[] {text});
            }
            else
            {
                textBox3.Text = text;
            }
        }

        private void ActivatePage(int i)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (wizardPages1.InvokeRequired)
            {
                ActivatePageCallback d = ActivatePage;
                Invoke(d, new object[] {i});
            }
            else
            {
                try
                {
                    wizardPages1.SelectedIndex = i;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(@"ActivatePage" + ex.Message + i);
                }
            }
        }

        private void LockForm()
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (InvokeRequired)
            {
                LockUnlockFormCallback d = LockForm;
                Invoke(d, new object[] {});
            }
            else
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(@"LockForm" + ex.Message);
                }
            }
        }

        private void UnlockForm()
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (InvokeRequired)
            {
                LockUnlockFormCallback d = UnlockForm;
                Invoke(d, new object[] {});
            }
            else
            {
                try
                {
                    Enabled = true;
                    Cursor = Cursors.Default;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(@"UnlockForm" + ex.Message);
                }
            }
        }

        private ulong GetN()
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (!numericUpDownN.InvokeRequired) return (ulong) numericUpDownN.Value;
            GetNumberCallback d = GetN;
            return (ulong) Invoke(d, new object[] {});
        }

        private double GetXmin()
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (!numericUpDownA1.InvokeRequired) return (double) numericUpDownXmin.Value;
            GetDoubleCallback d = GetXmin;
            return (double) Invoke(d, new object[] {});
        }

        private double GetXmax()
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (!numericUpDownA1.InvokeRequired) return (double) numericUpDownXmax.Value;
            GetDoubleCallback d = GetXmax;
            return (double) Invoke(d, new object[] {});
        }

        private double GetA1()
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (!numericUpDownA1.InvokeRequired) return (double) numericUpDownA1.Value;
            GetDoubleCallback d = GetA1;
            return (double) Invoke(d, new object[] {});
        }

        private double GetA2()
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (!numericUpDownA2.InvokeRequired) return (double) numericUpDownA2.Value;
            GetDoubleCallback d = GetA2;
            return (double) Invoke(d, new object[] {});
        }

        private double GetA3()
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (!numericUpDownA3.InvokeRequired) return (double) numericUpDownA3.Value;
            GetDoubleCallback d = GetA3;
            return (double) Invoke(d, new object[] {});
        }

        private double GetA4()
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (!numericUpDownA4.InvokeRequired) return (double) numericUpDownA4.Value;
            GetDoubleCallback d = GetA4;
            return (double) Invoke(d, new object[] {});
        }

        private double GetA6()
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (!numericUpDownA6.InvokeRequired) return (double) numericUpDownA6.Value;
            GetDoubleCallback d = GetA6;
            return (double) Invoke(d, new object[] {});
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }

        private void textBox3_DoubleClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox3.Text)) MessageBox.Show(@"Нет данных");
            else if (saveFileDialog2.ShowDialog() == DialogResult.OK)
                File.WriteAllText(saveFileDialog2.FileName, textBox3.Text);
        }

        private delegate void ActivatePageCallback(int i);

        private delegate double GetDoubleCallback();

        private delegate ulong GetNumberCallback();

        private delegate void LockUnlockFormCallback();

        private delegate void SetChartCallback(Series series1, Series series2);

        private delegate void SetReportCallback(string text);

        private void chart1_Click(object sender, EventArgs e)
        {
            // http://www.dotnetperls.com/chart
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                chart1.SaveImage(saveFileDialog1.FileName, ChartImageFormat.Png);
        }
    }
}