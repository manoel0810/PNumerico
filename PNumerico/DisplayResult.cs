using PNumerico.PNumerico.Math;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace PNumerico
{
    public partial class DisplayResult : Form
    {
        private readonly double[,] _values;
        private double[] _results;

        public Exception InnerError { get; private set; }
        private long _elipsed;

        public long ElipsedTime => _elipsed;

        public DisplayResult(double[,] values)
        {
            InitializeComponent();
            _values = values;
        }

        private void DisplayResult_Load(object sender, EventArgs e)
        {
            try
            {
                Stopwatch elipsedTime = Stopwatch.StartNew();

                elipsedTime.Start();
                var results = Calculate.Gauss(_values);
                _results = results;
                elipsedTime.Stop();

                _elipsed = elipsedTime.ElapsedMilliseconds;
                DataTable outRestult = new DataTable();
                outRestult.Columns.Add("Identificador", typeof(string));
                outRestult.Columns.Add("Valor", typeof(double));

                DataRow row = outRestult.NewRow();
                int indexe = 1;
                foreach (var r in results)
                {
                    row["Identificador"] = $"X{indexe++}";
                    row["Valor"] = Math.Round(r, 8);
                    outRestult.Rows.Add(row);

                    row = outRestult.NewRow();
                }

                LoadGrid(outRestult);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao executar operações logicas", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                InnerError = ex;
                return;
            }
        }

        private void LoadGrid(DataTable table)
        {
            ResultsGrid.DataSource = table;
            int ptr = (ResultsGrid.Width - 50) / 2;

            ResultsGrid.Columns[0].Width = ptr;
            ResultsGrid.Columns[1].Width = ptr;

            ElipsedProcessTime.Text += $"{_elipsed}ms";
        }

        private void Sava_Click(object sender, EventArgs e)
        {
            string txt = "";
            int i = 1;
            foreach (double b in _results)
                txt += $"\r\nX{i++} = {b}";

            try
            {
                string fileName = $"{Guid.NewGuid().ToString().Substring(0, 8)}.txt";
                File.WriteAllText(fileName, txt);
                DialogResult res = MessageBox.Show($"Arquivo salco como: {fileName}.\nAbrir arquivo?", "Salvar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (res == DialogResult.Yes)
                    Process.Start(fileName);
                
                return;
            }
            catch
            {
                MessageBox.Show("Não foi possível salvar a saída", "Salvar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
    }
}
