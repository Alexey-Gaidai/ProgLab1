namespace MatrixApp
{
    public partial class Form1 : Form
    {
        Matrix matrix;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            initMatrix(dataGridView1);
        }

        private void initMatrix(DataGridView dgv)
        {
            var rows = Convert.ToInt32(textBox1.Text);
            var cols = Convert.ToInt32(textBox2.Text);
            matrix = new Matrix(rows, cols);
            dgv.RowCount = rows;
            dgv.ColumnCount = cols;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    dgv.Rows[i].Cells[j].Value = matrix.matrix[i, j];
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            matrix.reverseElements();
            dataGridView2.RowCount = matrix.matrix.GetLength(0);
            dataGridView2.ColumnCount = matrix.matrix.GetLength(1);
            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                for (int j = 0; j < dataGridView2.ColumnCount; j++)
                {
                    dataGridView2.Rows[i].Cells[j].Value = matrix.matrix[i, j];
                }
            }
        }
    }
}