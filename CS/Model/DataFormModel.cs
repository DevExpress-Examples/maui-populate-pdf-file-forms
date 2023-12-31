using DevExpress.Maui.DataForm;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillPDFFile.Model
{
    public class PdfData
    {
        public Types Type { get; set; }
        public object Value { get; set; }
        public List<Object> Items { get; set; }

        public PdfData(Types type, object value, List<Object> items = null)
        {
            Type = type;
            Value = value;
            Items = items;
        }
    }
    public enum Types { Text, RadioGroup, ComboBox }


}