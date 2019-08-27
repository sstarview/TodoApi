using Microsoft.AspNetCore.Mvc;
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
    }
}
