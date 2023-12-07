using PNumerico.PNumerico.Math;
using System;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
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
                DataTable outResult = new DataTable();
                outResult.Columns.Add("Identificador", typeof(string));
                outResult.Columns.Add("Valor", typeof(double));

                DataRow row = outResult.NewRow();
                int index = 1;
                foreach (var r in results)
                {
                    row["Identificador"] = $"X{index++}";
                    row["Valor"] = Math.Round(r, 8);
                    outResult.Rows.Add(row);

                    row = outResult.NewRow();
                }

                DetermineSystemType(outResult);

                LoadGrid(outResult);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao executar operações lógicas", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                InnerError = ex;
                return;
            }
        }

        private void DetermineSystemType(DataTable resultsTable)
        {
            

            bool isSystemImpossible = resultsTable.AsEnumerable().Any(row => double.IsInfinity(row.Field<double>("Valor")));

            if (isSystemImpossible)
            {
                ElipsedProcessTime.Text = $"{_elipsed}ms\r\nSISTEMA IMPOSSÍVEL";
                return;
            }

            bool isSystemLinearSimple = resultsTable.AsEnumerable().All(row => IsInt(row.Field<double>("Valor")));

            if (isSystemLinearSimple)
            {
                ElipsedProcessTime.Text = $"{_elipsed}ms\r\nSISTEMA LINEAR SIMPLES";
            }
            else
            {
                bool isSystemPossibleIndeterminate = resultsTable.AsEnumerable().Any(row => IsFloat(row.Field<double>("Valor")));

                ElipsedProcessTime.Text = $"{_elipsed}ms" +
                    (isSystemPossibleIndeterminate ? "\r\nSISTEMA POSSÍVEL INDETERMINADO" : "\r\nSISTEMA LINEAR SIMPLES");
            }
        }

        private bool IsInt(double value)
        {
            return Math.Floor(value) == value;
        }

        private bool IsFloat(double value)
        {
            return !IsInt(value) && !double.IsInfinity(value);
        }

        private void LoadGrid(DataTable table)
        {
            ResultsGrid.DataSource = table;
            int ptr = (ResultsGrid.Width - 50) / 2;

            ResultsGrid.Columns[0].Width = ptr;
            ResultsGrid.Columns[1].Width = ptr;
            

            //ElipsedProcessTime.Text += $"{_elipsed}ms";
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
                DialogResult res = MessageBox.Show($"Arquivo salvo como: {fileName}.\nAbrir arquivo?", "Salvar", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
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
