using AppMinhasCompras.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMinhasCompras.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Formulario : ContentPage
    {
        public Formulario()
        {
            InitializeComponent();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                Produto p = new Produto
                {
                    Nome = txt_nome.Text,
                    Preco = Convert.ToDouble(txt_preco.Text),
                    Qnt = Convert.ToDouble(txt_qnt.Text),
                };

                App.Db.Insert(p);

                DisplayAlert("Deu Certo!", "Produto Inserido", "OK");

                Navigation.PopAsync();

            } catch (Exception ex)
            {
                DisplayAlert("Ops", ex.Message, "OK");
            }
        }
    }
}