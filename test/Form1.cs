using NotVisualComponents;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Linq;


namespace test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadData();
            romanovaTextBox.Tip("11.11.2012");

        }

        private void LoadData()
        {
            romanovaComboBox.FillList("hello");
            romanovaComboBox.FillList("my love!");

        }

        private void clear_Click(object sender, EventArgs e)
        {
            romanovaComboBox.ClearList();
        }

        private void save_Click(object sender, EventArgs e)
        {
            romanovaTextBox.template = @"^\d{2}.\d{2}.\d{4}$";

            string res = romanovaTextBox.ChekDate;
            if (res != null)
            {
                MessageBox.Show("������������!", "��� �� :)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("����...", "��� ����� :(", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FillList obj = new FillList("������� ����������","��������");
            romanovaListBox1.Fill(obj);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                romanovaListBox1.LayoutString(textBox1.Text, '{', '}');
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            romanovaListBox1.GetSelectedItem<FillList>();
        }

        private void createExcel_Click(object sender, EventArgs e)
        {
            string[] text = { "������� 14 �������", "�� ���� ����������", "�� ����� ��� �����" };

            RomanovaExcelDocument document = new RomanovaExcelDocument();
            document.CreateExcel("D:\\Study\\3 course\\KOP\\file\\Excel.xls", "� ������", text);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            RomanovaExcelTable romanovaExcelTable = new RomanovaExcelTable();
            var dict = new List<MergeCells>();
            romanovaExcelTable.columnsName = new List<string>() { "ID", "Status", "Name", "Surname", "Age", "Kid", "Division", "Post", "Prize" };
            int[]arrayHeight ={30, 30, 20, 20, 30, 40, 20, 20, 20 };
            string[] arrayHeader3 = { "�������������", "������", "���", "�������", "�������", "����", "�������������", "���������", "������" };
            var listCars = new List<Client>() { new Client(1, "�����", "�������", "������", 26, 2, "One", "One", 24000),
                                                new Client(2, "������", "ϸ��", "�������", 20, 2, "One", "One", 24000),
                                                new Client(3, "�������", "��������", "�������������", 20, 2, "One", "One", 24000),
                                                new Client(4, "������", "�����", "����������", 20, 2, "One", "One", 24000) };
            
            dict.Add(new MergeCells("������ ������", new int[] { 2, 3, 4 }));
            dict.Add(new MergeCells("������", new int[] { 6, 7 }));
            romanovaExcelTable.CreateTableExcel("D:\\Study\\3 course\\KOP\\file\\Client.xls", "�������", dict, arrayHeight, arrayHeader3, listCars);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LineChartConfig data = new LineChartConfig();
            data.FilePath = "D:\\Study\\3 course\\KOP\\file\\Diagram.xls";
            data.Header = "MyDiagram";
            data.ChartTitle = "Diagram";
            string[] Names = { "������", "������" };

            var list2D = new Dictionary<string, List<int>>();

            for (var i = 0; i < 2; i++)
            {
                var row = new List<int>();
                for (var j = 0; j < 5; j++)
                    row.Add(5 * i + j + 1);

                list2D.Add(Names[i],row);
            }
            
            data.Values = list2D;
            
            RomanovaExcelDiagram diagram = new RomanovaExcelDiagram();
            diagram.CreateExcel(data);
        }
    }
}