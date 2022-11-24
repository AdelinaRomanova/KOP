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

namespace LibraryView
{
    public partial class FormManual : Form
    {
        private readonly IGenreLogic _genreLogic;
        public FormManual(IGenreLogic genreLogic)
        {
            _genreLogic = genreLogic;
            InitializeComponent();
        }

        private void FormManual_Load(object sender, EventArgs e)
        {
            LoadData();
            dataGridView.CellEndEdit += CellEndEdit;
        }

        private void LoadData()
        {
            var genries = _genreLogic.Read(null);
            if (genries != null)
            {
                dataGridView.Rows.Clear();
                foreach (var genre in genries)
                {
                    dataGridView.Rows.Add(genre.Id, genre.Name);
                }
            }
        }

        private void CellEndEdit(object sender, EventArgs e)
        {
            if (dataGridView.CurrentCell.Value != null)
            {
                if (dataGridView.CurrentRow.Cells[0].Value == null)
                {
                    _genreLogic.CreateOrUpdate(new GenreBindingModel
                    {
                        Name = dataGridView.CurrentCell.Value.ToString()
                    });
                }
                else
                {
                    _genreLogic.CreateOrUpdate(new GenreBindingModel
                    {
                        Id = (int)dataGridView.CurrentRow.Cells[0].Value,
                        Name = dataGridView.CurrentCell.Value.ToString()
                    });
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            DataGridViewRow row = new DataGridViewRow();
            if (keyData == (Keys.Insert))
            {
                DataGridViewCell cell = dataGridView.Rows[dataGridView.NewRowIndex].Cells[1];
                dataGridView.CurrentCell = cell;
                dataGridView.BeginEdit(true);
                return true;
            }

            if (keyData == (Keys.Enter))
            {
                dataGridView.EndEdit();
                LoadData();
            }

            if (keyData == (Keys.Delete))
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int? id = null;
                    try
                    {
                        id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                    }
                    catch
                    {
                        MessageBox.Show("Чтобы удалить запись, нажмите на пустую ячейку слева от удаляемой записи", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (id != null)
                    {
                        try
                        {
                            _genreLogic.Delete(new GenreBindingModel { Id = id });
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    LoadData();
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
