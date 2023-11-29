using PNumerico.PNumerico.Math;
using System.Drawing;
using System.Windows.Forms;

namespace Control
{
    public partial class MatrixControl : UserControl
    {
        private const int XOffset = 50;
        private const int YOffset = 30;
        private const int PaddingObjects = 10;

        private int _xSize = 0;
        private int _ySize = 0;
        private readonly Size _basePoint = new Size(40, 20);

        public MatrixControl()
        {
            InitializeComponent();
        }

        private int _matrixSize;

        public int MatrixSize
        {
            get { return _matrixSize; }
            set
            {
                _matrixSize = value;
                GenerateMatrix();
            }
        }

        private void GenerateMatrix()
        {
            Controls.Clear();

            for (int i = 0; i < MatrixSize; i++)
            {
                for (int j = 0; j < MatrixSize + 1; j++)
                {
                    TextBox txtBox = new TextBox
                    {
                        Location = new Point((PaddingObjects + j * XOffset), (PaddingObjects + i * YOffset)),
                        Name = "textBox" + i.ToString() + j.ToString(),
                        Size = _basePoint,
                        TabIndex = j + i * (MatrixSize + 1),
                        Text = "0",
                        TextAlign = HorizontalAlignment.Center
                    };

                    txtBox.KeyPress += (obj, arg) =>
                    {
                        new FormatNumericInputs().ValitedNumInput(ref arg, true, true);
                    };

                    Controls.Add(txtBox);

                    if (i == MatrixSize - 1 && j == MatrixSize)
                    {
                        _xSize = (PaddingObjects + j * XOffset) + 40;
                        _ySize = (PaddingObjects + i * YOffset) + 20;

                        Width = _xSize;
                        Height = _ySize;
                    }
                }
            }
        }

        public Size GetObjectRealSize() => new Size(_xSize - PaddingObjects, _ySize - PaddingObjects);
    }
}
