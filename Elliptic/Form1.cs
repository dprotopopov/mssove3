using System;
using System.ComponentModel;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace Elliptic
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
            ulong n = GetN();
            ulong a1 = GetA1();
            ulong a2 = GetA2();
            ulong a3 = GetA3();
            ulong a4 = GetA4();
            ulong a6 = GetA6();

            // http://stackoverflow.com/questions/9173485/how-can-i-create-an-in-memory-sqlite-database
            var connection = new SQLiteConnection("Data Source=:memory:");
            connection.Open();

            string[] sqls1 =
            {
                "CREATE TABLE t1 (x INTEGER , key1 INTEGER )",
                "CREATE TABLE t2 (y INTEGER , key2 INTEGER )",
                "CREATE TABLE t3 (x INTEGER , y INTEGER , key3 INTEGER )"
            };

            foreach (string sql in sqls1)
                new SQLiteCommand(sql, connection).ExecuteNonQuery();

            for (ulong x = 0; x < n; x++)
            {
                ulong x2 = (x*x)%n;
                ulong x3 = (x2*x)%n;
                ulong a2X2 = (a2*x2)%n;
                ulong a4X = (a4*x)%n;
                ulong key1 = (x3 + a2X2 + a4X + a6)%n;
                string sql = "INSERT INTO t1 (x, key1) VALUES (" + x + "," + key1 + ")";
                new SQLiteCommand(sql, connection).ExecuteNonQuery();
            }

            for (ulong y = 0; y < n; y++)
            {
                ulong y2 = y*y%n;
                ulong a3Y = (a3*y)%n;
                ulong key2 = (y2 + a3Y)%n;
                string sql = "INSERT INTO t2 (y, key2) VALUES (" + y + "," + key2 + ")";
                new SQLiteCommand(sql, connection).ExecuteNonQuery();
            }

            if ((a1%n) != 0)
                for (ulong x = 0; x < n; x++)
                {
                    ulong a1X = (a1*x)%n;
                    for (ulong y = 0; y < n; y++)
                    {
                        ulong key3 = (a1X*y)%n;
                        string sql = "INSERT INTO t3 (x, y, key3) VALUES (" + x + "," + y + "," + key3 + ")";
                        new SQLiteCommand(sql, connection).ExecuteNonQuery();
                    }
                }

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

            foreach (string sql in sqls2)
                new SQLiteCommand(sql, connection).ExecuteNonQuery();

            var bitmap = new Bitmap((int) n, (int) n);
            Graphics.FromImage(bitmap).Clear(Color.White);
            string select = ((a1%n) == 0)
                ? "SELECT t1.x,t2.y FROM t1, t2 WHERE key1=key2"
                : "SELECT t1.x,t2.y FROM t1, t2, t3 WHERE (key1=key2+key3 or key1+" + n +
                  "=key2+key3) AND t1.x=t3.x AND t2.y=t3.y";
            SQLiteDataReader reader = new SQLiteCommand(select, connection).ExecuteReader();
            while (reader.Read())
            {
                int x = Convert.ToInt32(reader[0]);
                int y = Convert.ToInt32(reader[1]);
                bitmap.SetPixel(x, y, Color.Black);
            }
            SetBitmap(bitmap);
            connection.Close();
            UnlockForm();
            ActivatePage(2);

            // Start the asynchronous operation.
            if (backgroundWorker1.IsBusy) return;
            backgroundWorker1.RunWorkerAsync();
        }

        private void SetBitmap(Bitmap bitmap)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (pictureBox1.InvokeRequired)
            {
                SetBitmapCallback d = SetBitmap;
                Invoke(d, new object[] {bitmap});
            }
            else
            {
                pictureBox1.Image = bitmap;
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

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null) MessageBox.Show(@"Нет картинки");
            else if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                pictureBox1.Image.Save(saveFileDialog1.FileName);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }

        private delegate void ActivatePageCallback(int i);

        private delegate ulong GetNumberCallback();

        private delegate void LockUnlockFormCallback();

        private delegate void SetBitmapCallback(Bitmap bitmap);
    }
}