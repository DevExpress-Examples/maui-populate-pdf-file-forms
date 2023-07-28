using DevExpress.Maui.DataForm;
using System.Collections;

namespace FillPDFFile {
    public class DataFormPropertySourceBehavior : Behavior<DataFormView> {
        //public static readonly BindableProperty DataObjectProperty = BindableProperty.Create("DataObject", typeof(object), typeof(DataFormPropertySourceBehavior));
        public static readonly BindableProperty ItemTemplateProperty = BindableProperty.Create("ItemTemplate", typeof(DataTemplate), typeof(DataFormPropertySourceBehavior));
        public static readonly BindableProperty PropertiesSourceProperty = BindableProperty.Create("PropertiesSource", typeof(IList), typeof(DataFormPropertySourceBehavior), propertyChanged: (b, o, n) => ((DataFormPropertySourceBehavior)b).OnPropertiesSourceChanged(b, o, n));
        //public object DataObject {
        //    get { return (object)GetValue(DataObjectProperty); }
        //    set { SetValue(DataObjectProperty, value); }
        //}
        public DataTemplate ItemTemplate {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }
        public IList PropertiesSource {
            get { return (IList)GetValue(PropertiesSourceProperty); }
            set { SetValue(PropertiesSourceProperty, value); }
        }
        void OnPropertiesSourceChanged(BindableObject bindable, object oldValue, object newValue) {
            GenerateFormItems();
        }
        DataFormView AssociatedObject;
        protected override void OnAttachedTo(DataFormView bindable) {
            base.OnAttachedTo(bindable);
            AssociatedObject = bindable;
            AssociatedObject.BindingContextChanged += AssociatedObject_BindingContextChanged;
        }

        private void AssociatedObject_BindingContextChanged(object sender, EventArgs e) {
            this.BindingContext = AssociatedObject.BindingContext;
        }

        void GenerateFormItems() {
            foreach (var sourceItem in PropertiesSource) {
                DataTemplate actualtemplate = null;
                if(ItemTemplate is DataTemplateSelector selector) {
                    actualtemplate = selector.SelectTemplate(sourceItem, this);
                }
                DataFormItem generatedItem = (DataFormItem)actualtemplate.LoadTemplate();
                generatedItem.BindingContext = sourceItem;
                AssociatedObject.Items.Add(generatedItem);
            }
        }
    }
}
