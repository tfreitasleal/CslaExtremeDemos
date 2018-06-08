//http://codereview.stackexchange.com/questions/39163/loading-a-combobox-with-an-enum-and-binding-to-it

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Csla;

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

        public static string[] EnumToArray(Type enumType)
        {
            return (from object item in Enum.GetValues(enumType)
                select
                    (Attribute.GetCustomAttribute(item.GetType().GetField(item.ToString()),
                            typeof(DescriptionAttribute)) as
                        DescriptionAttribute).Description).ToArray();
        }

        public static string[] NvlToArray(NameValueListBase<short, string> nameValueList)
        {
            return nameValueList.Select(nameValuePair => nameValuePair.Value).ToArray();
        }

        #region Suspend Bindings And Set DataSource by @michaelcsikos

        public static void SuspendBindingsAndSetDataSource(this ComboBox comboBox, object dataSource)
        {
            comboBox.SuspendBindingsAndSetDataSource(null, dataSource);
        }

        public static void SuspendBindingsAndSetDataSource(this ComboBox comboBox, BindingSource bindingSource,
            object dataSource)
        {
            var bindText = comboBox.DataBindings["Text"];
            var bindSelectedValue = comboBox.DataBindings["SelectedValue"];

            var oldTextUpdateMode = DataSourceUpdateMode.Never;
            var oldSelectedValueUpdateMode = DataSourceUpdateMode.Never;

            if (bindText != null)
            {
                oldTextUpdateMode = bindText.DataSourceUpdateMode;

                bindText.DataSourceUpdateMode = DataSourceUpdateMode.Never;
            }

            if (bindSelectedValue != null)
            {
                oldSelectedValueUpdateMode = bindSelectedValue.DataSourceUpdateMode;

                bindSelectedValue.DataSourceUpdateMode = DataSourceUpdateMode.Never;
            }

            if (bindingSource != null)
            {
                bindingSource.RaiseListChangedEvents = false;
                bindingSource.DataSource = dataSource;
                bindingSource.RaiseListChangedEvents = true;

                if (comboBox.DataSource != bindingSource)
                    comboBox.DataSource = bindingSource;
                else
                    bindingSource.ResetBindings(false);
            }
            else
            {
                comboBox.DataSource = dataSource;
                comboBox.SelectedIndex = -1;
            }

            if (bindText != null)
            {
                bindText.DataSourceUpdateMode = oldTextUpdateMode;

                bindText.ReadValue();
            }

            if (bindSelectedValue != null)
            {
                bindSelectedValue.DataSourceUpdateMode = oldSelectedValueUpdateMode;

                bindSelectedValue.ReadValue();
            }
        }

        #endregion
    }
}