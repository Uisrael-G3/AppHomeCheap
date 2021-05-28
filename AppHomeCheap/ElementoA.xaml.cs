using AppHomeCheap.Model;
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
	public partial class ElementoA : ContentPage
	{
		public int IdSeleccionadoA;
		public string TitSeleccionado, DirSeleccionado, PreSeleccionado, TelSeleccionado, DetSeleccionado;
		private SQLiteAsyncConnection _conn;
		IEnumerable<Arriendos> ResultadoDelete;
		IEnumerable<Arriendos> ResultadoUpdate;



		public ElementoA(int id, string tit, string dir, string pre, string tel, string det)
		{
			InitializeComponent();

			_conn = DependencyService.Get<Database>().GetConnection();

			IdSeleccionadoA = id;
			TitSeleccionado = tit;
			DirSeleccionado = dir;
			PreSeleccionado = pre;
			TelSeleccionado = tel;
			DetSeleccionado = det;

		
		}


		protected override void OnAppearing()
		{
			base.OnAppearing();
			txtTitulo.Text = TitSeleccionado;
			txtDireccion.Text = DirSeleccionado;
			txtPrecio.Text = PreSeleccionado;
			txtTelefonos.Text = TelSeleccionado;
			txtDetalle.Text = DetSeleccionado;
		}

		private void btnActualizado_Clicked(object sender, EventArgs e)
		{
			try
			{
				var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "homecheap.db3");
				var db = new SQLiteConnection(databasePath);

				ResultadoUpdate = Update(db, txtTitulo.Text, txtDireccion.Text, txtPrecio.Text, txtTelefonos.Text, txtDetalle.Text, IdSeleccionadoA);

				DisplayAlert("Mensaje", "Publicación Actualizada", "OK");


				txtTitulo.Text = "";
				txtDireccion.Text = "";
				txtPrecio.Text = "";
				txtTelefonos.Text = "";
				txtDetalle.Text = "";
			}
			catch (Exception ex)
			{

				DisplayAlert("Alerta", "Error" + ex.Message, "OK");
			}

		}

		private void btnEliminado_Clicked(object sender, EventArgs e)
		{
			try
			{
				var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "homecheap.db3");
				var db = new SQLiteConnection(databasePath);

				ResultadoDelete = Delete(db, IdSeleccionadoA);
				DisplayAlert("Mensaje", "Su publicación a sido eliminada", "OK");


				txtTitulo.Text = "";
				txtDireccion.Text = "";
				txtPrecio.Text = "";
				txtTelefonos.Text = "";
				txtDetalle.Text = "";
			}
			catch (Exception ex)
			{

				DisplayAlert("Alerta", "Error" + ex.Message, "OK");
			}

		}

		public static IEnumerable<Arriendos> Delete(SQLiteConnection db, int id)
		{

			return db.Query<Arriendos>("DELETE FROM Arriendos where Id = ?", id);

		}



		public static IEnumerable<Arriendos> Update(SQLiteConnection db, string titulo, string direccion, string precio, string telefonos, string detallle, int id)
		{

			return db.Query<Arriendos>("UPDATE Arriendos SET Titulo = ?, Direccion = ?," +
				"Precio = ?, Telefonos = ?, Detallle = ? WHERE Id = ?", titulo, direccion, precio, telefonos, detallle, id);
		}


		
	}
}