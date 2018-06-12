using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ProjetoPrism.Behaviors
{
    public class LimiteTamanhoBehavior : Behavior<Entry>
    {
        public int TamanhoMax { get; set; }

        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += MudancaDeTexto;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= MudancaDeTexto;
        }

        private void MudancaDeTexto(object sender, TextChangedEventArgs e)
        {
            var entry = (Entry)sender;
            if (entry != null && entry.Text != "" && entry.Text.Length > TamanhoMax)
            {
                entry.TextChanged -= MudancaDeTexto;
                entry.Text = e.OldTextValue;
                entry.TextChanged += MudancaDeTexto;
            }
        }

    }
}
