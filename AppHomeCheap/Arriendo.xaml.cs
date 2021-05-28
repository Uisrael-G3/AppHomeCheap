
using AppHomeCheap.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppHomeCheap
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Arriendo : ContentPage
	{
		private SQLiteAsyncConnection _conn;

		public Arriendo()
		{
			InitializeComponent();
			_conn = DependencyService.Get<Database>().GetConnection();
		}

		private void btnRegistroA_Clicked(object sender, EventArgs e)
		{
			try
			{
				var Datos = new Arriendos { Titulo = txtTitulo.Text, Direccion = txtDireccion.Text, Precio = txtPrecio.Text, Telefonos = txtTelefonos.Text, Detallle = txtDetallle.Text };
				_conn.InsertAsync(Datos);

				txtTitulo.Text = "";
				txtDireccion.Text = "";
				txtPrecio.Text = "";
				txtTelefonos.Text = "";
				txtDetallle.Text = "";



				DisplayAlert("Mensaje", "Publicación Registrada Correctamente", "OK");


			}
			catch (Exception)
			{

				throw;
			}


		}
	}
}