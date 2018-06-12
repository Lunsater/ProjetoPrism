using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ProjetoPrism.Custom
{
    public class CustomCheckBox : View
    {
        public static readonly BindableProperty IsCheckedProperty =
            BindableProperty.Create<CustomCheckBox, bool>(
                p => p.IsChecked, 
                true, 
                propertyChanged: (s, o, n) =>
                {
                    (s as CustomCheckBox).OnChecked(new EventArgs());
                });

        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }

        public event EventHandler Checked;
        protected virtual void OnChecked(EventArgs e)
        {
            try
            {
                if (Checked != null)
                    Checked(this, e);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro", ex);
            }
        }
    }
}
