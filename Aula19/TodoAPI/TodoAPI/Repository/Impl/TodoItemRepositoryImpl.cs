using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoAPI.Models;

namespace TodoAPI.Repository.Impl
{
    public class TodoItemRepositoryImpl : TodoItemRepository
    {
        private TodoAPIDBContext _context;

        public TodoItemRepositoryImpl(TodoAPIDBContext context)
        {
            _context = context;
        }

        public async Task Atualizar(TodoItem todo)
        {
            _context.Entry(todo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Excluir(int id)
        {
            var query = _context.todoItem.Where(e => e.Id == id);
            _context.RemoveRange(query);
            await _context.SaveChangesAsync();
        }

        public async Task<TodoItem> GetById(int id)
        {
            return await _context.todoItem.FindAsync(id);
        }

        public async Task<List<TodoItem>> Listar()
        {
            return await _context.todoItem.ToListAsync();
        }

        public async Task Salvar(TodoItem todo)
        {
            _context.Add(todo);
            await _context.SaveChangesAsync();
        }
    }
}
