using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ComponentsLibrary.BasharinVisualComponents
{
    public partial class SevaTreeView : UserControl
    {
        private List<string> _hierarhy;
        public void SetHierarhy(List<string> hierarhy)
        {
            _hierarhy = hierarhy;
        }

        public SevaTreeView()
        {
            InitializeComponent();
        }
        private int _selectedNodeIndex = 0;
        public int SelectedNodeIndex
        {
            get { return _selectedNodeIndex; }
            set { if (treeView.SelectedNode != null) _selectedNodeIndex = treeView.SelectedNode.Index; }
        }
        public T GetSelectedValue<T>()
        {
            if (treeView.SelectedNode.Nodes.Count == 0)
            {
                T val = Activator.CreateInstance<T>();
                foreach (string item in Enumerable.Reverse(_hierarhy))
                {
                    string text = treeView.SelectedNode.Text;
                    PropertyInfo property = val.GetType().GetProperty(item);
                    PropertyInfo propertyInfo = property;
                    Type conversionType = property?.PropertyType;
                    propertyInfo.SetValue(val, Convert.ChangeType(text, conversionType));
                    if (treeView.SelectedNode.Parent != null)
                    {
                        treeView.SelectedNode = treeView.SelectedNode.Parent;
                    }
                }

                return val;
            }

            return default(T);

        }

        public void Add<T>(T obj)
        {
            TreeNodeCollection nodes = treeView.Nodes;
            foreach (string item in _hierarhy)
            {
                PropertyInfo property = obj.GetType().GetProperty(item);
                string text = property.GetValue(obj, null).ToString();
                if (nodes.ContainsKey(text + _hierarhy.IndexOf(item)))
                {
                    TreeNode treeNode = nodes.Find(text + _hierarhy.IndexOf(item), searchAllChildren: true)[0];
                    nodes = treeNode.Nodes;
                    continue;
                }

                if (_hierarhy.IndexOf(item) == _hierarhy.Count - 1)
                {
                    nodes.Add(text);
                    continue;
                }

                TreeNode treeNode2 = new TreeNode
                {
                    Name = text + _hierarhy.IndexOf(item),
                    Text = text
                };
                nodes.Add(treeNode2);
                nodes = treeNode2.Nodes;
            }
        }
        public void CreateTree<T>(T obj) where T : class, new()
        {
            if (_hierarhy == null)
                throw new NullReferenceException("Add not null config");
            if (obj == null)
                throw new NullReferenceException("Add not null list of objects");

            var elementType = obj.GetType();

            var currentLevelNodes = treeView.Nodes;
            int curlvl = 1;
            foreach (var nodeName in _hierarhy)
            {
                var propertyInfo = elementType.GetProperty(nodeName);
                if (propertyInfo != null)
                {
                    var propertyValue = propertyInfo.GetValue(obj).ToString();
                    if (!currentLevelNodes.ContainsKey(propertyValue))
                    {
                        if (curlvl == _hierarhy.Count)
                        {
                            currentLevelNodes.Add(propertyValue);
                        }
                        else
                            currentLevelNodes.Add(propertyValue, propertyValue);
                    }
                    if (curlvl != _hierarhy.Count)
                        currentLevelNodes = currentLevelNodes.Find(propertyValue, false)[0].Nodes;
                }
                else
                {
                    var fieldInfo = elementType.GetField(nodeName);
                    if (fieldInfo != null)
                    {
                        var fieldValue = fieldInfo.GetValue(obj).ToString();
                        if (!currentLevelNodes.ContainsKey(fieldValue))
                        {
                            if (curlvl == _hierarhy.Count)
                            {
                                currentLevelNodes.Add(fieldValue);
                            }
                            else
                                currentLevelNodes.Add(fieldValue, fieldValue);
                        }
                        if (curlvl != _hierarhy.Count)
                            currentLevelNodes = currentLevelNodes.Find(fieldValue, false)[0].Nodes;
                    }
                }
                curlvl++;
            }


        }
        public void Clear()
        {
            treeView.Nodes.Clear();
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
