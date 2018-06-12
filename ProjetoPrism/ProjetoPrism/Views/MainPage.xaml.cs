using Xamarin.Forms;

namespace ProjetoPrism.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ListViewUsuario_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListViewUsuario.SelectedItem = null;
        }
    }
}
