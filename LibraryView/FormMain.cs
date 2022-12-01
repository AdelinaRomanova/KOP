﻿using PluginsConventionLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;


namespace LibraryView
{
    public partial class FormMain : Form
    {
        private readonly Dictionary<string, IPluginsConvention> _plugins;
        private string _selectedPlugin;
        public FormMain()
        {
            InitializeComponent();
            _plugins = LoadPlugins();
            _selectedPlugin = string.Empty;
        }
        private Dictionary<string, IPluginsConvention> LoadPlugins()
        {
            PluginManager manager = new PluginManager();
            var plugins = manager.plugins_dictionary;
            if (plugins.Count > 0)
            {
                foreach (var plugin in plugins)
                {
                    ToolStripMenuItem menuItem = new ToolStripMenuItem();
                    menuItem.Text = plugin.Value.PluginName;
                    menuItem.Click += (sender, e) =>
                    {
                        panelControl.Controls.Clear();
                        _selectedPlugin = plugin.Value.PluginName;
                        var control = _plugins[_selectedPlugin].GetControl;
                        panelControl.Controls.Add(control);
                        panelControl.Controls[0].Dock = DockStyle.Fill;
                    };
                    ControlsStripMenuItem.DropDownItems.Add(menuItem);
                }
            }
            return plugins;
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedPlugin) || !_plugins.ContainsKey(_selectedPlugin))
            {
                return;
            }
            if (!e.Control)
            {
                return;
            }
            switch (e.KeyCode)
            {
                case Keys.A:
                    AddNewElement();
                    break;
                case Keys.U:
                    UpdateElement();
                    break;
                case Keys.D:
                    DeleteElement();
                    break;
                case Keys.S:
                    CreateSimpleDoc();
                    break;
                case Keys.T:
                    CreateTableDoc();
                    break;
                case Keys.C:
                    CreateChartDoc();
                    break;
            }
        }
        private void AddNewElement()
        {
            var form = _plugins[_selectedPlugin].GetForm(null);
            if (form != null && form.ShowDialog() == DialogResult.OK)
            {
                _plugins[_selectedPlugin].ReloadData();
            }
        }
        private void UpdateElement()
        {
            var element = _plugins[_selectedPlugin].GetElement;
            if (element == null)
            {
                MessageBox.Show("Нет выбранного элемента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var form = _plugins[_selectedPlugin].GetForm(element);
            if (form != null && form.ShowDialog() == DialogResult.OK)
            {
                _plugins[_selectedPlugin].ReloadData();
            }
        }
        private void DeleteElement()
        {
            if (MessageBox.Show("Удалить выбранный элемент", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }
            var element = _plugins[_selectedPlugin].GetElement;
            if (element == null)
            {
                MessageBox.Show("Нет выбранного элемента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_plugins[_selectedPlugin].DeleteElement(element))
            {
                _plugins[_selectedPlugin].ReloadData();
            }
        }
        private void CreateSimpleDoc()
        {
            var sfd = new SaveFileDialog();
            sfd.FileName = "simpleDocProducts.xls";
            sfd.Filter = "Excel files (*.xlsx)|*.xlsx";
            if (_plugins[_selectedPlugin].CreateSimpleDocument(new PluginsConventionSaveDocument
            {
                FileName = sfd.FileName
            }))
            {
                MessageBox.Show("Документ сохранен", "Создание документа", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ошибка при создании документа", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CreateTableDoc()
        {
            var sfd = new SaveFileDialog();
            sfd.FileName = "WordProducts.docx";
            sfd.Filter = "Word files (*.docx)|*.docx";
            if (_plugins[_selectedPlugin].CreateTableDocument(new PluginsConventionSaveDocument
            {
                FileName = sfd.FileName
            }))
            {
                MessageBox.Show("Документ сохранен", "Создание документа", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ошибка при создании документа", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CreateChartDoc()
        {
            var sfd = new SaveFileDialog();
            sfd.FileName = "DiagramProducts.pdf";
            sfd.Filter = "Pdf files (*.pdf)|*.pdf";
            if (_plugins[_selectedPlugin].CreateChartDocument(new PluginsConventionSaveDocument
            {
                FileName = sfd.FileName
            }))
            {
                MessageBox.Show("Документ сохранен", "Создание документа", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ошибка при создании документа", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AddElementToolStripMenuItem_Click(object sender, EventArgs e) => AddNewElement();
        private void UpdElementToolStripMenuItem_Click(object sender, EventArgs e) => UpdateElement();
        private void DelElementToolStripMenuItem_Click(object sender, EventArgs e) => DeleteElement();
        private void SimpleDocToolStripMenuItem_Click(object sender, EventArgs e) => CreateSimpleDoc();
        private void TableDocToolStripMenuItem_Click(object sender, EventArgs e) => CreateTableDoc();
        private void ChartDocToolStripMenuItem_Click(object sender, EventArgs e) => CreateChartDoc();
    }
}

