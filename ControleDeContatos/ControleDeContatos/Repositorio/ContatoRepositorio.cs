﻿using ControleDeContatos.Data;
using ControleDeContatos.Models;
using System.Collections.Generic;
using System.Linq;

namespace ControleDeContatos.Repositorio
{
	public class ContatoRepositorio : IContatoRepositorio
	{
		private readonly BancoContent _context;

		public ContatoRepositorio(BancoContent bancoContent) //Injetar
		{
			_context = bancoContent;
		}

		public ContatoModel ListarPorId(int id)
		{
			return _context.Contatos.FirstOrDefault(x => x.Id == id);
		}

		public List<ContatoModel> BuscarTodos()
		{
			return _context.Contatos.ToList();  //Carrega tudo que esta no banco de dados
		}

		public ContatoModel Adicionar(ContatoModel contato)
		{
			//gravar no banco de dados
			_context.Contatos.Add(contato);
			_context.SaveChanges();
			return contato;
		}

		public ContatoModel Atualizar(ContatoModel contato)
		{
			ContatoModel contatoDB = ListarPorId(contato.Id);

			if (contatoDB == null) throw new System.Exception("Houve um erro na atualização do contato!");

			contatoDB.Nome = contato.Nome;
			contatoDB.Email = contato.Email;
			contatoDB.Celular = contato.Celular;

			_context.Contatos.Update(contatoDB);
			_context.SaveChanges();

			return contatoDB;
		}

		public bool Apagar(int id)
		{
			ContatoModel contatoDB = ListarPorId(id);

			if (contatoDB == null) throw new System.Exception("Houve um erro na deleção do contato!");

			_context.Contatos.Remove(contatoDB);
			_context.SaveChanges();

			return true;

		}
	}
}
