using Todo.Api.Domian.Models;

namespace Todo.Api.Domian.Services.Communication
{
    public class SaveTodoItemResponse : BaseResponse
    {
        public TodoItem TodoItem { get; private set; }

        private SaveTodoItemResponse(bool success, string message, TodoItem todoItem)
            : base(success, message)
        {
            TodoItem = todoItem;
        }

        public SaveTodoItemResponse(TodoItem todoItem)
            : this(true, string.Empty, todoItem)
        {

        }

        public SaveTodoItemResponse(string message)
            : this(false, message, null)
        {

        }
    }
}
