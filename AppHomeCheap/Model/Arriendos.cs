using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppHomeCheap.Model
{
	public class Arriendos
	{
		[PrimaryKey, AutoIncrement]
		public int Id { set; get; }


		[MaxLength(255)]
		public string Titulo { set; get; }


		[MaxLength(255)]
		public string Direccion { set; get; }


		[MaxLength(255)]
		public string Precio { set; get; }


		[MaxLength(255)]
		public string Telefonos { set; get; }


		[MaxLength(255)]
		public string Detallle { set; get; }


	}
}
