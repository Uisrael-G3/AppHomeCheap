using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppHomeCheap.Models
{
	public class Usuario
	{
		[PrimaryKey, AutoIncrement]
		public int Id { set; get; }


		[MaxLength(255)]
		public string Nombre { set; get; }


		[MaxLength(255)]
		public string Apellido { set; get; }


		[MaxLength(255)]
		public string Contrasena { set; get; }


		[MaxLength(255)]
		public string Correo { set; get; }


		[MaxLength(255)]
		public string Celular { set; get; }


	}
}
