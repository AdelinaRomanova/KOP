using PluginsConventionLibrary;
using System.Reflection;

namespace WinFormsAppByPlugins
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
            PluginsManager manager = new PluginsManager();
            var plugins = manager.plugins_dictionary;

            ToolStripItem[] toolStripItems = new ToolStripItem[plugins.Count];
            int i = 0;
            if (plugins.Count > 0)
            {
                foreach (var plugin in plugins)
                {
                    ToolStripMenuItem itemMenu = new ToolStripMenuItem();
                    itemMenu.Text = plugin.Value.PluginName;
                    itemMenu.Click += (sender, e) =>
                    {
                        _selectedPlugin = plugin.Value.PluginName;
                        panelControl.Controls.Clear();
                        panelControl.Controls.Add(_plugins[_selectedPlugin].GetControl);
                        panelControl.Controls[0].Dock = DockStyle.Fill;
                    };
                    toolStripItems[i] = itemMenu;
                    i++;
                }
                ControlsStripMenuItem.DropDownItems.AddRange(toolStripItems);
            }
            return plugins;
        }
        //private Dictionary<string, IPluginsConvention> LoadPlugins()
        //{
        //    var plugins = new Dictionary<string, IPluginsConvention>();

        //    string pathFrom = "D:\\Study\\3 course\\коп\\git\\KOP\\RomanovaPlugin\\bin\\Debug\\net6.0-windows\\RomanovaPlugin.dll";
        //    string pathTo = "D:\\Study\\3 course\\коп\\git\\KOP\\WinFormsAppByPlugins\\bin\\Debug\\net6.0-windows\\Plugins\\RomanovaPlugin.dll";
        //    File.Copy(pathFrom, pathTo, true);

        //    if (File.Exists(pathTo))
        //    {
        //        var assemblyLoadFile = Assembly.LoadFile(pathTo); 
        //        var types = assemblyLoadFile.GetTypes(); 
        //        foreach (var type in types) 
        //        {
        //            if (type.GetInterface("IPluginsConvention") != null) 
        //            {
        //                var plug = (IPluginsConvention)Activator.CreateInstance(type); 
        //                plugins.Add(plug.PluginName, plug);
        //            }
        //        }
        //    }

        //    if (plugins.Count > 0)
        //    {
        //        foreach (var plugin in plugins)
        //        {
        //            ToolStripMenuItem menuItem = new ToolStripMenuItem();
        //            menuItem.Text = plugin.Value.PluginName;
        //            menuItem.Click += (sender, e) =>
        //            {
        //                panelControl.Controls.Clear();
        //                _selectedPlugin = plugin.Value.PluginName;
        //                var control = plugins[_selectedPlugin].GetControl;
        //                panelControl.Controls.Add(control);
        //                panelControl.Controls[0].Dock = DockStyle.Fill;
        //            };
        //            ControlsStripMenuItem.DropDownItems.Add(menuItem);
        //        }
        //    }
        //    return plugins;
        //}

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

