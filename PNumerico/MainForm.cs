#define TEST_MODE

using PNumerico.Notifications;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PNumerico
{
    public partial class MainForm : Form
    {
        private readonly List<Notification> _notifications;

        public MainForm()
        {
            SplashScreen spl = new SplashScreen();
            spl.ShowDialog();
            spl?.Dispose();

            InitializeComponent();
            _notifications = new List<Notification>();
        }

        private void DispayGrid()
        {
            matrix1.MatrixSize = (int)VarCount.Value;
            int xPoint = (MathGrid.Width - matrix1.GetObjectRealSize().Width) / 2;
            int yPoint = (MathGrid.Height - matrix1.GetObjectRealSize().Height) / 2;

            matrix1.Location = new Point(xPoint, yPoint);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DispayGrid();
        }

        private void VarCount_ValueChanged(object sender, EventArgs e)
        {
            DispayGrid();
        }

        private void ExecProc_Click(object sender, EventArgs e)
        {

            ExecProc.Text = "Calculando...";
            Cursor = Cursors.WaitCursor;

            
            double[,] values = new double[matrix1.MatrixSize, matrix1.MatrixSize + 1];
            foreach (System.Windows.Forms.Control c in matrix1.Controls)
            {
                if (c is TextBox t)
                {
                    int i = int.Parse(t.Name.Substring(t.Name.Length - 2)[0].ToString());
                    int j = int.Parse(t.Name.Substring(t.Name.Length - 1));

                    if (IsValidInputValue(c.Text))
                        values[i, j] = double.Parse(c.Text);
                    else
                        AddNotification(new Notification(nameof(ExecProc_Click), $"Erro ao processar posição [{i}, {j}]. O valor era: {(string.IsNullOrWhiteSpace(c.Text) ? "NULL" : c.Text)}"));

                }
            }


            if (SuccessInitialization())
            {
                DisplayResult show = new DisplayResult(values);
                show.ShowDialog();
                show?.Dispose();
            }
            else
            {
                string msg = "";
                foreach (var notify in _notifications)
                {
                    msg += $"\n\r{notify.Message}";
                }

                MessageBox.Show($"Erro ao processar dados. Saída do depurador interno:\n\r{msg}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _notifications.Clear();
                return;
            }


            _notifications.Clear();
            ExecProc.Text = "Calcular";
            Cursor = Cursors.Default;
        }


        /// <summary>
        /// Método de controle interno para testes
        /// </summary>
        /// <returns>Vetor de dimensão n x n + 1, que representa um sistema possível determinado para testes</returns>

        private double[,] Test()
        {
            double[,] values = new double[3, 4];
            int[] nvalues = { 1, -2, 3, 6, 2, -1, -1, -3, 1, -3, 2, 1 };

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    values[i, j] = (double)nvalues[4 * i + j];
                }
            }

            return values;
        }

        private bool IsValidInputValue(string value) => double.TryParse(value, out _);

        /// <summary>
        /// Adiciona à auditoria da classe uma notificação de ocorrência
        /// </summary>
        /// <param name="notify">Detalhes da ocorrência</param>

        private void AddNotification(Notification notify)
        {
            if (notify != null)
                _notifications.Add(notify);
        }

        /// <summary>
        /// Verifica se houve ocorrências de avisos na inicialização do objeto <see cref="MainForm" />
        /// </summary>
        /// <returns><b>true</b> quando não há ocorrências</returns>

        private bool SuccessInitialization() => _notifications.Count == 0;
    }
}
