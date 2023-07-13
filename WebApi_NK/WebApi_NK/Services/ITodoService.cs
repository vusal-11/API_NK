using WebApi_NK.DTOs;
using WebApi_NK.Models;

namespace WebApi_NK.Services
{
    public interface ITodoService
    {

        Task<IEnumerable<TodoItem>> GetTodoItems(); 

        Task<TodoItem?> GetTodoItem(int id);
        Task<TodoItem?> ChangeTodoItem(int id,bool isCompleted);

        Task<TodoItemDto> CreateTodoItem(CreateTodoItemRequest request);



    }

    
}
