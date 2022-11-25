using ComponentsLibrary.IstyukovNotVisualComponents;
using ComponentsLibrary.MyUnvisualComponents;
using ComponentsLibrary.MyUnvisualComponents.HelperModels;
using ComponentsLibraryNet60.DocumentWithTable;
using ComponentsLibraryNet60.Models;
using LibraryContracts.BindingModels;
using LibraryContracts.BusinessLogicsContracts;
using LibraryDatabaseImplement.Models;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace LibraryView
{
    public partial class FormMain : Form
    {
        private ContextMenuStrip contextMenu = new ContextMenuStrip();
        private readonly IBookLogic _bookLogic;
        private readonly IGenreLogic _genreLogic;
        public FormMain(IBookLogic bookLogic, IGenreLogic genreLogic)
        {

            InitializeComponent();

            _bookLogic = bookLogic;
            _genreLogic = genreLogic;

            List<string> hierarhy = new List<string>();
            hierarhy.Add("Genre");
            hierarhy.Add("CostStr");
            hierarhy.Add("Id");
            hierarhy.Add("Title");

            sevaTreeView.SetHierarhy(hierarhy);

            // создаем элементы меню
            ToolStripMenuItem addMenuGenre = new ToolStripMenuItem("Справочник");
            ToolStripMenuItem addMenuItem = new ToolStripMenuItem("Добавить книгу");
            ToolStripMenuItem updateMenuItem = new ToolStripMenuItem("Изменить книгу");
            ToolStripMenuItem deleteMenuItem = new ToolStripMenuItem("Удалить книгу");
            ToolStripMenuItem simpleDocMenuItem = new ToolStripMenuItem("Простой документ");
            ToolStripMenuItem tableMenuItem = new ToolStripMenuItem("Таблица");
            ToolStripMenuItem diagramMenuItem = new ToolStripMenuItem("Диаграмма");

            // добавляем элементы в меню
            contextMenu.Items.AddRange(new[] { addMenuGenre, addMenuItem, updateMenuItem, deleteMenuItem, simpleDocMenuItem, tableMenuItem, diagramMenuItem });

            // ассоциируем контекстное меню с узлом дерева
            sevaTreeView.ContextMenuStrip = contextMenu;

            // устанавливаем обработчики событий для меню
            addMenuGenre.Click += addGenreItem_Click;
            addMenuItem.Click += addMenuItem_Click;
            updateMenuItem.Click += updateMenuItem_Click;
            deleteMenuItem.Click += deleteMenuItem_Click;
            simpleDocMenuItem.Click += simpleDocMenuItem_Click;
            tableMenuItem.Click += tableMenuItem_Click;
            diagramMenuItem.Click += diagramDocMenuItem_Click;
        }

        private void treeViewControl_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            sevaTreeView.Clear();
            var books = _bookLogic.Read(null);
            if (books != null)
            {
                foreach (var book in books)
                {
                    if (book != null)
                    {
                        sevaTreeView.Add(book);
                    }
                }
            }
        }

        void addMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormBook>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        void addGenreItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormManual>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void updateMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormBook>();
            form.Id = Convert.ToInt32(sevaTreeView.GetSelectedValue<Book>().Id);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void deleteMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(sevaTreeView.GetSelectedValue<Book>().Id);
                try
                {
                    _bookLogic.Delete(new BookBindingModel { Id = id });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                LoadData();
            }
        }

        private void simpleDocMenuItem_Click(object sender, EventArgs e)
        {
            CreateExcelSimpleDoc();
        }

        private void tableMenuItem_Click(object sender, EventArgs e)
        {
            CreateWordTable();
        }

        private void diagramDocMenuItem_Click(object sender, EventArgs e)
        {
            CreatePdfDiagram();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.A))
            {
                addMenuItem_Click(null, null);
                return true;
            }

            if (keyData == (Keys.Control | Keys.U))
            {
                updateMenuItem_Click(null, null);
                return true;
            }

            if (keyData == (Keys.Control | Keys.D))
            {
                deleteMenuItem_Click(null, null);
                return true;
            }

            if (keyData == (Keys.Control | Keys.S))
            {
                CreateExcelSimpleDoc();
                return true;
            }

            if (keyData == (Keys.Control | Keys.T))
            {
                CreateWordTable();
                return true;
            }

            if (keyData == (Keys.Control | Keys.C))
            {
                CreatePdfDiagram();
                return true;
            }

            if (keyData == (Keys.Control | Keys.G))
            {
                addGenreItem_Click(null, null);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void CreateExcelSimpleDoc()
        {
            string dataSet = "";
            var products = _bookLogic.Read(null);
            if (products != null)
            {
                foreach (var product in products)
                {
                    if (product.Cost == 0)
                    {
                        dataSet += product.Title + " " + product.Description + ";";
                    }
                }

                string[] data = dataSet.Split(';');
                var sfd = new SaveFileDialog();
                sfd.FileName = "D:\\Study\\3 course\\KOP\\file\\simpleDocProducts.xls";
                sfd.Filter = "Excel files (*.xlsx)|*.xlsx";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (data != null)
                    {
                        romanovaExcelDocument.CreateExcel(sfd.FileName, "Книги", data);
                        MessageBox.Show("Файл был создан успешно", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Файл не был создан", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void CreatePdfDiagram()
        {
            Dictionary<string, double> data = new Dictionary<string, double>();
            var books = _bookLogic.Read(null);
            var genries = _genreLogic.Read(null);
            if (books != null && genries != null)
            {
                foreach (var genre in genries)
                {
                    int count = 0;
                    foreach (var book in books)
                    {
                        if (book.Cost == 0 && book.Genre.Equals(genre.Name))
                        {
                            count++;
                        }
                    }
                    data.Add(genre.Name, count);
                }
                var sfd = new SaveFileDialog();
                sfd.FileName = "DiagramBook.pdf";
                sfd.Filter = "Pdf files (*.pdf)|*.pdf";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    diagramTopdf1.CreateDocument(sfd.FileName, "Бесплатные книги",
                        "Сколько бесплатных книг какого жанра", ComponentsLibrary.BasharinNotVisualComponents.Area.TOP, data);
                    MessageBox.Show("Файл был создан успешно", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void CreateWordTable()
        {
            var sfd = new SaveFileDialog();
            sfd.FileName = "WordBooks.docx";
            sfd.Filter = "Word files (*.docx)|*.docx";
            var booksDB = _bookLogic.Read(null);
            List<Book> books = new List<Book>();
            foreach (var book in booksDB)
            {
                Book prod = new Book
                {
                    Id = (int)book.Id,
                    Title = book.Title,
                    Description = book.Description,
                    Genre = book.Genre,
                    Cost = book.Cost
                };
                books.Add(prod);
            }
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                componentDocumentWithTableMultiHeaderWord.CreateDoc(new ComponentDocumentWithTableHeaderDataConfig<Book>
                {
                    FilePath = sfd.FileName,
                    Header = "Информация по всем книгам",
                    ColumnsRowsWidth = new List<(int, int)> { (5, 5), (10, 5), (10, 0), (5, 0), (7, 0) },
                    Headers = new List<(int ColumnIndex, int RowIndex, string Header, string PropertyName)>
                        {
                        (0, 0, "Id", "Id"),
                        (1, 0, "Название", "Title"),
                        (2, 0, "Описание", "Description"),
                        (3, 0, "Категория", "Genre"),
                        (4, 0, "Стоимость книг", "CostStr")
                    },
                    Data = books
                });
                MessageBox.Show("Файл был создан успешно", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public List<int> getColumnsWidth(int count, int width)
        {
            List<int> list = new List<int>();

            for (int i = 0; i < count; i++)
            {
                list.Add(width);
            }
            return list;
        }
    }
}

