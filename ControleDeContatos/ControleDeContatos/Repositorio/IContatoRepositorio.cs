﻿using ControleDeContatos.Models;
using System.Collections.Generic;

namespace ControleDeContatos.Repositorio
{
    public interface IContatoRepositorio
    {
        List<ContatoModel> BuscarTodos();
        ContatoModel ListarPorId(int id);
        ContatoModel Adicionar(ContatoModel contato);
		ContatoModel Atualizar(ContatoModel contato);
        bool Apagar(int id);
    }
}
