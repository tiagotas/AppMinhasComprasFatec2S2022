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

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                Produto produto_selecionado = new Produto();

                if (BindingContext != null)
                    produto_selecionado = BindingContext as Produto;                    

                Produto p = new Produto
                {
                    Id = produto_selecionado.Id,
                    Nome = txt_nome.Text,
                    Preco = Convert.ToDouble(txt_preco.Text),
                    Qnt = Convert.ToDouble(txt_qnt.Text),
                };

                if(p.Id == 0)
                {
                    await App.Db.Insert(p);
                    await DisplayAlert("Deu Certo!", "Produto Inserido", "OK");
                }                    
                else
                {                    
                    await App.Db.Update(p);
                    await DisplayAlert("Deu Certo!", "Produto Atualizado", "OK");
                }               

                await Navigation.PopAsync();

            } catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }
        }
    }
}