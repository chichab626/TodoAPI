using Microsoft.EntityFrameworkCore;
using TodoAPI.Models;

namespace TodoAPI.Services
{
    public interface ITodoItemService
    {
        Task<IEnumerable<TodoItem>> GetTodoItemsAsync();
        Task<TodoItem> GetTodoItemByIdAsync(int id);
        Task<TodoItem> AddTodoItemAsync(TodoItem todoItem);
        Task<bool> UpdateTodoItemAsync(int id, TodoItem todoItem);
        Task<bool> DeleteTodoItemAsync(int id);
    }

    public class TodoItemService : ITodoItemService
    {
        private readonly TodoDbContext _context;

        public TodoItemService(TodoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TodoItem>> GetTodoItemsAsync()
        {
            return await _context.TodoItems
                .Include(t => t.Category) // Eagerly load the related Category data
                .ToListAsync();
        }

        public async Task<TodoItem> GetTodoItemByIdAsync(int id)
        {
            return await _context.TodoItems
                .Include(t => t.Category) // Include related Category
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<TodoItem> AddTodoItemAsync(TodoItem todoItem)
        {
            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();
            return todoItem;
        }

        public async Task<bool> UpdateTodoItemAsync(int id, TodoItem todoItem)
        {
            if (id != todoItem.Id)
            {
                return false;
            }

            _context.Entry(todoItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.TodoItems.AnyAsync(t => t.Id == id))
                {
                    return false;
                }
                throw;
            }
        }

        public async Task<bool> DeleteTodoItemAsync(int id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);
            if (todoItem == null)
            {
                return false;
            }

            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
