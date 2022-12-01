using PluginsConventionLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;

namespace LibraryView
{
    public class PluginManager
    {
        //Тег, указывающий, что plugins должны быть заполнены CompositionContainer
        [ImportMany(typeof(IPluginsConvention))]
        IEnumerable<IPluginsConvention> plugins { get; set; }

        public readonly Dictionary<string, IPluginsConvention> plugins_dictionary = new Dictionary<string, IPluginsConvention>();

        public PluginManager()
        {
            string pathFrom = "D:\\Study\\3 course\\коп\\git\\KOP\\RomanovaPlugin\\bin\\Debug\\net6.0-windows\\RomanovaPlugin.dll";
            string pathTo = "D:\\Study\\3 course\\коп\\git\\KOP\\LibraryView\\bin\\Debug\\net6.0-windows\\Plugins\\RomanovaPlugin.dll";
            File.Copy(pathFrom, pathTo, true);
            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(AppDomain.CurrentDomain.BaseDirectory));
            catalog.Catalogs.Add(new DirectoryCatalog(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins")));

            //Контейнер композиции
            CompositionContainer container = new CompositionContainer(catalog);
            container.ComposeParts(this);
            if (plugins.Any())
            {
                plugins
                    .ToList()
                    .ForEach(p =>
                    {
                        if (!plugins_dictionary.Keys.Contains(p.PluginName))
                            plugins_dictionary.Add(p.PluginName, p);
                    });
            }
        }
    }
}
