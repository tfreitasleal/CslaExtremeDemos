//http://codereview.stackexchange.com/questions/39163/loading-a-combobox-with-an-enum-and-binding-to-it

using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace CslaExtremeDemos.WindowsForms
{
    internal static class EnumExtension
    {
        // ReSharper disable once InconsistentNaming

        public static void EnumToComboBox(this ComboBox comboBox, Type enumType)
        {
            comboBox.DataSource = Enum.GetValues(enumType).Cast<Enum>().Select(Key => new
            {
                (Attribute.GetCustomAttribute(Key.GetType().GetField(Key.ToString()),
                    typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                Key
            }).OrderBy(item => item.Key).ToList();

            comboBox.DisplayMember = "Description";
            comboBox.ValueMember = "Key";
        }

        public static void EnumToDataSource(this BindingSource bindingSource, Type enumType)
        {
            bindingSource.DataSource = Enum.GetValues(enumType).Cast<Enum>().Select(Key => new
            {
                (Attribute.GetCustomAttribute(Key.GetType().GetField(Key.ToString()),
                    typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                Key
            }).OrderBy(item => item.Key).ToList();
        }
    }
}