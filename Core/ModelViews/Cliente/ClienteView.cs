﻿using Core.ModelViews.Endereco;
using Core.ModelViews.Telefone;

namespace Core.ModelViews.Cliente;
public class ClienteView : ICloneable
{
		public int Id { get; set; }
		public string Nome { get; set; }
		public DateTime DataNascimento { get; set; }

		public SexoView Sexo { get; set; }
		public ICollection<TelefoneView> Telefones { get; set; }

		public string Documento { get; set; }
		public DateTime Criacao { get; set; }
		public DateTime? UltimaAtualizacao { get; set; }

		public EnderecoView Endereco { get; set; }

		public object Clone()
		{
				var cliente = (ClienteView)MemberwiseClone();
				cliente.Endereco = (EnderecoView)cliente.Endereco.Clone();
				var telefones = new List<TelefoneView>();

				cliente.Telefones.ToList().ForEach(p => telefones.Add((TelefoneView)p.Clone()));
				cliente.Telefones = telefones;
				return cliente;
		}

		public ClienteView CloneClienteView()
		{
				return (ClienteView)Clone();
		}
}
