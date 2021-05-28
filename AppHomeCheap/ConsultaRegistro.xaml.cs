using AppHomeCheap.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppHomeCheap
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ConsultaRegistro : ContentPage
	{
		private SQLiteAsyncConnection _con;
		private ObservableCollection<Usuario> tablaUsuario;

		public ConsultaRegistro()
		{
			InitializeComponent();

			_con = DependencyService.Get<Database>().GetConnection();

		}


		protected async override void OnAppearing()
		{
			var resultado = await _con.Table<Usuario>().ToListAsync();
			tablaUsuario = new ObservableCollection<Usuario>(resultado);

			ListaUsuarios.ItemsSource = tablaUsuario;
			base.OnAppearing();

		}


		public void OnSelection(object sender, SelectedItemChangedEventArgs e)
		{

			var Obj = (Usuario)e.SelectedItem;
			var item = Obj.Id.ToString();
			int ID = Convert.ToInt32(item);

			var nom = Obj.Nombre;
			var ape = Obj.Apellido;
			var contra = Obj.Contrasena;
			var correo = Obj.Correo;
			var celu = Obj.Celular;

			try
			{
				Navigation.PushAsync(new Elemento(ID, nom, ape, contra, correo, celu));
			}
			catch (Exception)
			{

				throw;
			}

		}


	}
}