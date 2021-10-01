using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoAPI.Models;

namespace TodoAPI.Repository.Impl
{
    public interface TodoItemRepository
    {
        public Task<List<TodoItem>> Listar();
        public Task Salvar(TodoItem todo);
        public Task Atualizar(TodoItem todo);
        public Task Excluir(int id);
        public Task<TodoItem> GetById(int id);
    }
}
