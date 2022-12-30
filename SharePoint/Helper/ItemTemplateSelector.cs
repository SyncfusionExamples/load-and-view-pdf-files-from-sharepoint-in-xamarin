using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Syncfusion.TreeView.Engine;

namespace SharePoint
{
    public class ItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate Template1 { get; set; }
        public DataTemplate Template2 { get; set; }
        public ItemTemplateSelector()
        {
            this.Template1 = new DataTemplate(typeof(Template1));
            this.Template2 = new DataTemplate(typeof(Template2));
        }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var treeviewNode = item as TreeViewNode;
            if (treeviewNode == null)
                return null;
            if (treeviewNode.Level == 0)
                return Template1;
            else
                return Template2;
        }
    }
}
