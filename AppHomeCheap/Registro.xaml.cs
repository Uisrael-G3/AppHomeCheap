using AppHomeCheap.Models;
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
	public partial class Registro : ContentPage
	{
		private SQLiteAsyncConnection _con;

		public Registro()
		{
			InitializeComponent();
			_con = DependencyService.Get<Database>().GetConnection();
		}

		private void btnRegistro_Clicked(object sender, EventArgs e)
		{

			try
			{
				var Datos = new Usuario { Nombre = txtNombre.Text, Apellido = txtApellido.Text, Contrasena = txtContrasena.Text, Correo = txtCorreo.Text, Celular= txtCelular.Text };
				_con.InsertAsync(Datos);

				txtNombre.Text = "";
				txtApellido.Text = "";
				txtContrasena.Text = "";
				txtCorreo.Text = "";
				txtCelular.Text = "";



				DisplayAlert("Mensaje", "Usuario Registrado", "OK");


			}
			catch (Exception)
			{

				throw;
			}

		}
	}
}