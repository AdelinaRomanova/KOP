using ComponentsLibrary.BasharinNotVisualComponents;
using ComponentsLibrary.MyNotVisualComponents;
using ComponentsLibraryNet60.Models;
using LibraryBusinessLogic.BusinessLogics;
using LibraryContracts.BindingModels;
using LibraryContracts.BusinessLogicsContracts;
using LibraryDatabaseImplement.Models;

namespace RomanovaPlugin
{
    public partial class MainControl : UserControl
    {
        private ContextMenuStrip contextMenu = new ContextMenuStrip();
        private readonly IBookLogic _bookLogic;
        private readonly IGenreLogic _genreLogic;
        public MainControl()
        {
            InitializeComponent();
            _bookLogic = new BookLogic();
            _genreLogic = new GenreLogic();

            List<string> hierarhy = new List<string>();
            hierarhy.Add("Genre");
            hierarhy.Add("CostStr");
            hierarhy.Add("Id");
            hierarhy.Add("Title");
            sevaTreeView.SetHierarhy(hierarhy);

            // создаем элементы меню
            ToolStripMenuItem addMenuItem = new ToolStripMenuItem("Добавить");
            ToolStripMenuItem updateMenuItem = new ToolStripMenuItem("Изменить");
            ToolStripMenuItem deleteMenuItem = new ToolStripMenuItem("Удалить");

            // добавляем элементы в меню
            contextMenu.Items.AddRange(new[] { addMenuItem, updateMenuItem, deleteMenuItem });

            // ассоциируем контекстное меню с узлом дерева
            sevaTreeView.ContextMenuStrip = contextMenu;

            // устанавливаем обработчики событий для меню
            addMenuItem.Click += addMenuItem_Click;
            updateMenuItem.Click += updateMenuItem_Click;
            deleteMenuItem.Click += deleteMenuItem_Click;
        }

        private void treeViewControl_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
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
            var form = new FormBook(_bookLogic, _genreLogic);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void updateMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormBook(_bookLogic, _genreLogic);
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

            return base.ProcessCmdKey(ref msg, keyData);
        }

        public bool CreateExcelSimpleDoc()
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
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Файл не был создан", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else return false;
            }
            else return false;
        }

        public bool CreatePdfDiagram()
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
                    diagramTopdf.CreateDocument(sfd.FileName, "Бесплатные книги",
                        "Сколько бесплатных книг какого жанра", ComponentsLibrary.BasharinNotVisualComponents.Area.TOP, data);
                    MessageBox.Show("Файл был создан успешно", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else return false;
            }
            else return false;
        }

        public bool CreateWordTable()
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
                return true;
            }
            else return false;
        }

        private void справочникToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormManual(_genreLogic);
            form.ShowDialog();
        }

        public Book GetSelectedValue()
        {
            var book = sevaTreeView.GetSelectedValue<Book>();
            return book;
        }
    }
}
