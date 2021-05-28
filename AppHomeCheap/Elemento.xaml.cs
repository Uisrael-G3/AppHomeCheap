using AppHomeCheap.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppHomeCheap
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Elemento : ContentPage
	{


		public int IdSeleccionado;
		public string NomSeleccionado, ApeSeleccionado, ContraSeleccioado, CorreoSeleccionado, CeluSeleccionado;
		private SQLiteAsyncConnection _con;
		IEnumerable<Usuario> ResultadoDelete;
		IEnumerable<Usuario> ResultadoUpdate;

		public Elemento(int id, string nom, string ape, string contra, string correo, string celu)
		{
			InitializeComponent();
			_con = DependencyService.Get<Database>().GetConnection();

			IdSeleccionado = id;
			NomSeleccionado = nom;
			ApeSeleccionado = ape;
			ContraSeleccioado = contra;
			CorreoSeleccionado = correo;
			CeluSeleccionado = celu;


		}


		protected override void OnAppearing()
		{
			base.OnAppearing();
			txtNombre.Text = NomSeleccionado;
			txtApellido.Text = ApeSeleccionado;
			txtContrasena.Text = ContraSeleccioado;
			txtCorreo.Text = CorreoSeleccionado;
			txtCelular.Text = CeluSeleccionado;
		}

		public static IEnumerable<Usuario> Delete(SQLiteConnection db, int id) 
		{

			return db.Query<Usuario>("DELETE FROM Usuario where Id = ?", id);

		}


		public static IEnumerable<Usuario> Update(SQLiteConnection db, string nombre, string apellido, string contrasena, string correo, string celular , int id)
		{

			return db.Query<Usuario>("UPDATE Usuario SET Nombre = ?, Apellido = ?," +
				"Contrasena = ?, Correo = ?, Celular = ? WHERE Id = ?", nombre, apellido , contrasena, correo , celular , id);
		}



		private void btnActualizar_Clicked(object sender, EventArgs e)
		{

			try
			{
				var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "homecheap.db3");
				var db = new SQLiteConnection(databasePath);

				ResultadoUpdate = Update(db, txtNombre.Text, txtApellido.Text, txtContrasena.Text, txtCorreo.Text , txtCelular.Text, IdSeleccionado);

				DisplayAlert("Mensaje", "Dato actualizado", "OK");


				txtNombre.Text = "";
				txtApellido.Text = "";
				txtContrasena.Text = "";
				txtCorreo.Text = "";
				txtCelular.Text = "";
			}
			catch (Exception ex)
			{

				DisplayAlert("Alerta", "Error" + ex.Message, "OK");
			}

		}

		private void btnEliminar_Clicked(object sender, EventArgs e)
		{

			try
			{
				var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "homecheap.db3");
				var db = new SQLiteConnection(databasePath);

				ResultadoDelete = Delete(db, IdSeleccionado);
				DisplayAlert("Mensaje", "Usuario eliminado correctamente", "OK");

				
				txtNombre.Text = "";
				txtApellido.Text = "";
				txtContrasena.Text = "";
				txtCorreo.Text = "";
				txtCelular.Text = "";
			}
			catch (Exception ex)
			{

				DisplayAlert("Alerta", "Error" + ex.Message, "OK");
			}

		}
	}
}