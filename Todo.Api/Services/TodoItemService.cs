using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Todo.Api.Domian.Models;
using Todo.Api.Domian.Repositories;
using Todo.Api.Domian.Services;
using Todo.Api.Domian.Services.Communication;

namespace Todo.Api.Services
{
    public class TodoItemService : ITodoItemService
    {
        private readonly ITodoItemRespository _todoItemRespository;
        private readonly IUnitOfWork _unitOfWork;

        public TodoItemService(ITodoItemRespository todoItemRespository, IUnitOfWork unitOfWork)
        {
            _todoItemRespository = todoItemRespository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<TodoItem>> ListAsync()
        {
            return await _todoItemRespository.ListAsync();
        }

        public async Task<SaveTodoItemResponse> SaveAsync(TodoItem todoItem)
        {
            try
            {
                await _todoItemRespository.AddAsync(todoItem);
                await _unitOfWork.CompleteAsync();

                return new SaveTodoItemResponse(todoItem);
            }
            catch (Exception ex)
            {

                return new SaveTodoItemResponse($"An error occurred when saving the todo: {ex.Message}");
            }
        }

        public async Task<SaveTodoItemResponse> UpdateAsync(int id, TodoItem todoItem)
        {
            var existingTodo = await _todoItemRespository.FindByIdAsync(id);

            if (existingTodo == null)
            {
                return new SaveTodoItemResponse("Todo not found");
            }

            existingTodo.Name = todoItem.Name;

            try
            {
                _todoItemRespository.Update(existingTodo);
                await _unitOfWork.CompleteAsync();

                return new SaveTodoItemResponse(existingTodo);
            }
            catch (Exception ex)
            {

                return new SaveTodoItemResponse($"An error occurred when updating the category: {ex.Message}");
            }
        }

        public async Task<SaveTodoItemResponse> DeleteAsync(int id)
        {
            var existingTodo = await _todoItemRespository.FindByIdAsync(id);

            if (existingTodo == null)
            {
                return new SaveTodoItemResponse("Todo not found");
            }

            try
            {
                _todoItemRespository.Remove(existingTodo);
                await _unitOfWork.CompleteAsync();

                return new SaveTodoItemResponse(existingTodo);
            }
            catch (Exception ex)
            {

                return new SaveTodoItemResponse($"An error occurred when deleting the todo: {ex.Message}");
                ;
            }
        }
    }
}
