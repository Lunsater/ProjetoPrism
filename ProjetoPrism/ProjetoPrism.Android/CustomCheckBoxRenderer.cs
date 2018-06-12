using System;
using System.ComponentModel;

using Android.Widget;
using ProjetoPrism.Custom;
using ProjetoPrism.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomCheckBox),
    typeof(CustomCheckBoxRenderer))]
namespace ProjetoPrism.Droid
{

    [System.Obsolete]
    public class CustomCheckBoxRenderer :
        Xamarin.Forms.Platform.Android.AppCompat.ViewRenderer<CustomCheckBox, CheckBox>
    {


        private CheckBox checkBox;

        protected override void OnElementChanged(ElementChangedEventArgs<CustomCheckBox> e)
        {
            base.OnElementChanged(e);
            var model = e.NewElement;
            checkBox = new CheckBox(Context);
            checkBox.Tag = this;
            CheckboxPropertyChanged(model, null);
            checkBox.SetOnClickListener(new ClickListener(model));

            SetNativeControl(checkBox);
        }
        private void CheckboxPropertyChanged(CustomCheckBox model, String propertyName)
        {
            if (propertyName == null || CustomCheckBox.IsCheckedProperty.PropertyName == propertyName)
            {
                checkBox.Checked = model.IsChecked;

            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (checkBox != null)
            {
                base.OnElementPropertyChanged(sender, e);

                CheckboxPropertyChanged((CustomCheckBox)sender, e.PropertyName);
            }
        }

        public class ClickListener : Java.Lang.Object, IOnClickListener
        {
            private CustomCheckBox _myCheckbox;
            public ClickListener(CustomCheckBox myCheckbox)
            {
                this._myCheckbox = myCheckbox;
            }

            public void OnClick(global::Android.Views.View v)
            {
                _myCheckbox.IsChecked = !_myCheckbox.IsChecked;
            }
        }


    }
}