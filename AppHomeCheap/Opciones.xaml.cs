using System;
using System.Collections.Generic;
using SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.OpenWhatsApp;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppHomeCheap
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Opciones : ContentPage
	{
		public Opciones()
		{
			InitializeComponent();
			
		}

		private async void btnEditar_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new ConsultaRegistro());
		}

		private  async void btnEditarPubli_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new ConsultaRegistroA());
		}

		private async void btnCrearPubli_Clicked(object sender, EventArgs e)
		{
			 await DisplayAlert("Terminos y Condiciones", "HomeCheap tiene como política que todas las publicaciones de arriendo tengan un valor máximo de $150 dólares americanos, todos los lugares en arriendo deberán contar con los servicios básicos y un ambiente adecuado para vivir, en caso de existir incumplimiento con las políticas de HomeCheap se procederá al respectivo cierre de la cuenta y procedimientos legales en caso de ser necesario.", "Aceptar");
			 await Navigation.PushAsync(new Arriendo());
		}

		private  async void btnSalir_Clicked(object sender, EventArgs e)
		{
	
			await Navigation.PushAsync(new Login());

		}

		private async void OpenWhatsApp(object sender, EventArgs e)
		{
			try
			{			
				Chat.Open("+593987287864", "Somos Home Cheap, un gusto en saludarte, cuentanos tienes alguna denuncia o preguntas sobre nuestros servicios");
			
			}
			catch (Exception ex)
			{
				await DisplayAlert("Error", ex.Message, "OK");
			}
		}

	}
}