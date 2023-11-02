using System;
using Task3.DoNotChange;

namespace Task3
{
    public class UserTaskController
    {
        private readonly UserTaskService _taskService;

        public UserTaskController(UserTaskService taskService)
        {
            _taskService = taskService;
        }

        public bool AddTaskForUser(int userId, string description, IResponseModel model)
        {
            try
            {
                string message = GetMessageForModel(userId, description);
                if (message != null)
                {
                    model.AddAttribute("action_result", message);
                    return false;
                }

                return true;
            }
            catch (ArgumentException ex)
            {
                model.AddAttribute("action_result", ex.Message);
                return false;
            }
            catch (InvalidOperationException ex)
            {
                model.AddAttribute("action_result", ex.Message);
                return false;
            }
        }

        private string GetMessageForModel(int userId, string description)
        {
            var task = new UserTask(description);
            int result = _taskService.AddTaskForUser(userId, task);

            if (result == -1)
                throw new ArgumentException("Invalid userId");

            if (result == -2)
                throw new InvalidOperationException("User not found");

            if (result == -3)
                throw new InvalidOperationException("The task already exists");

            return null;
        }
    }
}