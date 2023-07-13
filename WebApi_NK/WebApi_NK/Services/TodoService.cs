using WebApi_NK.DTOs;
using WebApi_NK.Models;

namespace WebApi_NK.Services
{
    public class TodoService : ITodoService
    {

        private readonly Dictionary<int,TodoItem> _items=new Dictionary<int,TodoItem>();

        private int _nextid = 1;


        public Task<TodoItem?> ChangeTodoItem(int id, bool isCompleted)
        {
            throw new NotImplementedException();
        }

        public Task<TodoItemDto> CreateTodoItem(CreateTodoItemRequest request)
        {
            var now = DateTimeOffset.UtcNow;

            var item = new TodoItem()
            {
                Title = request.Title,
                Id = _nextid++,
                CreatedDate = now,
                UpdatedDate = now,
                IsComplete = false,
                Description = request.Description
            };

            _items.Add(item.Id, item);
            return Task.FromResult(new TodoItemDto
            {
                Id= item.Id,
                Title=item.Title,
                Description=item.Description,
                Created=item.CreatedDate,
                IsCompleted=item.IsComplete
            });


        }

        public Task<TodoItem?> GetTodoItem(int id)
        {
            return Task.FromResult(_items.GetValueOrDefault(id));
        }

        public Task<IEnumerable<TodoItem>> GetTodoItems()
        {
            return Task.FromResult<IEnumerable<TodoItem>>(_items.Values);
        }
    }

    


}
