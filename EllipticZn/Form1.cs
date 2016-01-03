using System;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace EllipticZn
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LockForm();

            // Параметры кольца вычетов Z|n
            var n = GetN();

            // Параметры эллиптической кривой
            var a1 = GetA1();
            var a2 = GetA2();
            var a3 = GetA3();
            var a4 = GetA4();
            var a6 = GetA6();

            // http://stackoverflow.com/questions/9173485/how-can-i-create-an-in-memory-sqlite-database
            var connection = new SQLiteConnection("Data Source=:memory:");
            connection.Open();

            // Создаём таблицы
            string[] sqls1 =
            {
                "CREATE TABLE t1 (x INTEGER , key1 INTEGER )",
                "CREATE TABLE t2 (y INTEGER , key2 INTEGER )",
                "CREATE TABLE t3 (x INTEGER , y INTEGER , key3 INTEGER )"
            };

            foreach (var sql in sqls1)
                new SQLiteCommand(sql, connection).ExecuteNonQuery();

            // Заполняем таблицы начальными значениями
            for (ulong x = 0; x < n; x++)
            {
                var x2 = (x*x)%n;
                var x3 = (x2*x)%n;
                var a2X2 = (a2*x2)%n;
                var a4X = (a4*x)%n;
                var key1 = (x3 + a2X2 + a4X + a6)%n;
                var sql = string.Format("INSERT INTO t1 (x, key1) VALUES ({0},{1})", x, key1);
                new SQLiteCommand(sql, connection).ExecuteNonQuery();
            }

            for (ulong y = 0; y < n; y++)
            {
                var y2 = y*y%n;
                var a3Y = (a3*y)%n;
                var key2 = (y2 + a3Y)%n;
                var sql = string.Format("INSERT INTO t2 (y, key2) VALUES ({0},{1})", y, key2);
                new SQLiteCommand(sql, connection).ExecuteNonQuery();
            }

            if ((a1%n) != 0)
                for (ulong x = 0; x < n; x++)
                {
                    var a1X = (a1*x)%n;
                    for (ulong y = 0; y < n; y++)
                    {
                        var key3 = (a1X*y)%n;
                        var sql = string.Format("INSERT INTO t3 (x, y, key3) VALUES ({0},{1},{2})", x, y, key3);
                        new SQLiteCommand(sql, connection).ExecuteNonQuery();
                    }
                }

            // Создаём индексы для таблиц
            string[] sqls2 =
            {
                "CREATE INDEX t1key1 ON t1 (key1)",
                "CREATE INDEX t2key2 ON t2 (key2)",
                "CREATE INDEX t3key3 ON t3 (key3)",
                "CREATE UNIQUE INDEX t1x ON t1 (x)",
                "CREATE UNIQUE INDEX t2y ON t2 (y)",
                "CREATE INDEX t3x ON t3 (x)",
                "CREATE INDEX t3y ON t3 (y)"
            };

            foreach (var sql in sqls2)
                new SQLiteCommand(sql, connection).ExecuteNonQuery();

            // http://stackoverflow.com/questions/10622674/chart-creating-dynamically-in-net-c-sharp
            var series1 = new Series
            {
                Name = "Series1",
                Color = Color.Black,
                IsVisibleInLegend = false,
                IsXValueIndexed = true,
                ChartType = SeriesChartType.Point
            };

            // Выполняем JOIN запрос и получаем результаты
            // Чем дороже DBMS тем лучше алгоритмы она использует для оптимизации запросов
            var select = ((a1%n) == 0)
                ? "SELECT t1.x,t2.y FROM t1, t2 WHERE key1=key2"
                : "SELECT t1.x,t2.y FROM t1, t2, t3 WHERE (key1=key2+key3 or key1+" + n +
                  "=key2+key3) AND t1.x=t3.x AND t2.y=t3.y";
            var reader = new SQLiteCommand(select, connection).ExecuteReader();
            var sb = new StringBuilder();
            var sb1 = new StringBuilder();
            sb.AppendLine("y^2+a1*x*y+a3*y = x^3+a2*x^2+a4*x+a6 mod n");
            sb.AppendLine("n=" + n);
            sb.AppendLine("a1=" + a1);
            sb.AppendLine("a2=" + a2);
            sb.AppendLine("a3=" + a3);
            sb.AppendLine("a4=" + a4);
            sb.AppendLine("a6=" + a6);
            sb.AppendLine();
            sb.AppendLine("# X Y");
            sb1.AppendLine("# X Y");
            while (reader.Read())
            {
                var x = Convert.ToInt32(reader[0]);
                var y = Convert.ToInt32(reader[1]);
                series1.Points.AddXY(x, y);
                sb.AppendLine(x + " " + y);
                sb1.AppendLine(x + " " + y);
            }

            // Выдаём отчёт о проделанной работе
            SetChart(series1);
            SetReport(sb.ToString());
            SetReport1(sb1.ToString());
            connection.Close();

            UnlockForm();
            ActivatePage(2);
        }

        private void SetReport(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (textBox2.InvokeRequired)
            {
                SetReportCallback d = SetReport;
                Invoke(d, text);
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
                Invoke(d, text);
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
                Invoke(d, i);
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

        private ulong GetA1()
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (!numericUpDownA1.InvokeRequired) return (ulong) numericUpDownA1.Value;
            GetNumberCallback d = GetA1;
            return (ulong) Invoke(d, new object[] {});
        }

        private ulong GetA2()
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (!numericUpDownA2.InvokeRequired) return (ulong) numericUpDownA2.Value;
            GetNumberCallback d = GetA2;
            return (ulong) Invoke(d, new object[] {});
        }

        private ulong GetA3()
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (!numericUpDownA3.InvokeRequired) return (ulong) numericUpDownA3.Value;
            GetNumberCallback d = GetA3;
            return (ulong) Invoke(d, new object[] {});
        }

        private ulong GetA4()
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (!numericUpDownA4.InvokeRequired) return (ulong) numericUpDownA4.Value;
            GetNumberCallback d = GetA4;
            return (ulong) Invoke(d, new object[] {});
        }

        private ulong GetA6()
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (!numericUpDownA6.InvokeRequired) return (ulong) numericUpDownA6.Value;
            GetNumberCallback d = GetA6;
            return (ulong) Invoke(d, new object[] {});
        }

        private void textBox3_DoubleClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox3.Text)) MessageBox.Show(@"Нет данных");
            else if (saveFileDialog2.ShowDialog() == DialogResult.OK)
                File.WriteAllText(saveFileDialog2.FileName, textBox3.Text);
        }

        private void SetChart(Series series1)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (chart1.InvokeRequired)
            {
                SetChartCallback d = SetChart;
                Invoke(d, series1);
            }
            else
            {
                chart1.Series.Clear();
                chart1.Series.Add(series1);
                chart1.Invalidate();
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            // http://www.dotnetperls.com/chart
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                chart1.SaveImage(saveFileDialog1.FileName, ChartImageFormat.Png);
        }

        private delegate void SetChartCallback(Series series1);

        private delegate void ActivatePageCallback(int i);

        private delegate ulong GetNumberCallback();

        private delegate void LockUnlockFormCallback();

        private delegate void SetReportCallback(string text);
    }
}