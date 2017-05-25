using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace MvcBootstrap.Models
{
	public class Pessoa
	{
		[Key]
		public long id { get; set;}
		public String nome { get; set;}
		public Pessoa()
		{
		}
	}

	public class PessoaContexto : DbContext
	{
		public PessoaContexto() : base()
		{
		}

		public DbSet<Pessoa> Pessoas { get; set; }
	}
}
