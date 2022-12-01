using LibraryContracts.BindingModels;
using LibraryContracts.BusinessLogicsContracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RomanovaPlugin
{
    public partial class FormBook : Form
    {
        private readonly IBookLogic _bookLogic;
        private readonly IGenreLogic _genreLogic;
        public int Id { set { id = value; } }
        private int? id;
        public FormBook(IBookLogic bookLogic, IGenreLogic genreLogic)
        {
            _bookLogic = bookLogic;
            _genreLogic = genreLogic;
            InitializeComponent();
            LoadGenries();
        }

        private void LoadGenries()
        {
            var genries = _genreLogic.Read(null);
            foreach (var genre in genries)
            {
                romanovaComboBoxGenre.FillList(genre.Name);
            }
        }

        private void FormBook_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var view = _bookLogic.Read(new BookBindingModel { Id = id })?[0];
                    if (view != null)
                    {
                        if (view.CostStr == "Не указано")
                        {
                            textBoxTitle.Text = view.Title;
                            textBoxDescription.Text = view.Description;
                            romanovaComboBoxGenre.SelectElement = view.Genre;
                            textBoxCost.Value = null;
                        }
                        else
                        {
                            textBoxTitle.Text = view.Title;
                            textBoxDescription.Text = view.Description;
                            romanovaComboBoxGenre.SelectElement = view.Genre;
                            textBoxCost.Value = view.Cost;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxTitle.Text))
            {
                MessageBox.Show("Заполните название книга", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(textBoxDescription.Text))
            {
                MessageBox.Show("Заполните описание книги", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(romanovaComboBoxGenre.SelectElement.ToString()))
            {
                MessageBox.Show("Выберите жанр книги", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int? cost = null;
            if (textBoxCost.Value != null)
            {
                try
                {
                    cost = Convert.ToInt32(textBoxCost.Value);
                }
                catch
                {
                    MessageBox.Show("Стоимость должна быть целым числом", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            try
            {
                _bookLogic.CreateOrUpdate(new BookBindingModel
                {
                    Id = id,
                    Title = textBoxTitle.Text,
                    Description = textBoxDescription.Text,
                    Genre = romanovaComboBoxGenre.SelectElement.ToString(),
                    Cost = cost
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
