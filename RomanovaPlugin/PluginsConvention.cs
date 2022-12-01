using LibraryBusinessLogic.BusinessLogics;
using LibraryContracts.BindingModels;
using LibraryContracts.BusinessLogicsContracts;
using LibraryDatabaseImplement.Implements;
using PluginsConventionLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanovaPlugin
{
    [Export(typeof(IPluginsConvention))]
    public class PluginsConvention : IPluginsConvention
    {
        private readonly MainControl _mainControl;
        private readonly IBookLogic _bookLogic;
        private readonly IGenreLogic _genreLogic;
        public PluginsConvention()
        {
            _bookLogic = new BookLogic();
            _genreLogic = new GenreLogic();
            _mainControl = new MainControl();
        }

        /// Название плагина
        string IPluginsConvention.PluginName => PluginName();
        public string PluginName()
        {
            return "RomanovaPlugin";
        }

        /// Получение контрола для вывода набора данных
        public UserControl GetControl()
        {
            return _mainControl;
        }
        UserControl IPluginsConvention.GetControl => GetControl();

        /// Получение элемента, выбранного в контроле
        public PluginsConventionElement GetElement()
        {
            var book = _mainControl.GetSelectedValue();
            PluginsConventionElementMy element = null;
            //TODO if
            if (_mainControl != null)
            {
                element = new PluginsConventionElementMy
                {
                    Id = book.Id,
                    Title = book.Title,
                    Description = book.Description,
                    Genre = book.Genre,
                    Cost = book.Cost,
                    CostStr = book.CostStr
                };
            }
            return element;
        }
        PluginsConventionElement IPluginsConvention.GetElement => GetElement();

        /// Получение формы для создания/редактирования объекта
        public Form GetForm(PluginsConventionElement element)
        {
            var form = new FormBook(_bookLogic, _genreLogic);
            if (element != null)
            {
                form.Id = element.Id;
            }
            return form;
        }

        /// Удаление элемента
        public bool DeleteElement(PluginsConventionElement element)
        {
            if (element != null)
            {
                _bookLogic.Delete(new BookBindingModel { Id = element.Id });
                return true;
            }
            else return false;
        }

        /// Обновление набора данных в контроле
        public void ReloadData()
        {
            _mainControl.LoadData();
        }

        /// Создание простого документа
        public bool CreateSimpleDocument(PluginsConventionSaveDocument saveDocument)
        {
            if (_mainControl.CreateExcelSimpleDoc())
            {
                return true;
            }
            else return false;
        }

        /// Создание документа с настраиваемой таблицей
        public bool CreateTableDocument(PluginsConventionSaveDocument saveDocument)
        {
            if (_mainControl.CreateWordTable())
            {
                return true;
            }
            else return false;
        }

        /// Создание документа с диаграммой
        public bool CreateChartDocument(PluginsConventionSaveDocument saveDocument)
        {
            if (_mainControl.CreatePdfDiagram())
            {
                return true;
            }
            else return false;
        }
    }
}
