using System;
using System.Collections.Generic;
using System.Linq;
using TaskManager.Model;

namespace TaskManager.DAL
{
    public class TaskManagerRepository : ITaskManagerRepository<UserTaskModel>, IDisposable
    {
        TaskManagerDbContext context;
        public TaskManagerRepository()
        {
            context = new TaskManagerDbContext();
        }
        public bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public bool Insert(UserTaskModel userTaskModel)
        {
            try
            {
                var UT = new UserTask()
                {
                    ParentTask_ID = userTaskModel.ParentTask_ID,
                    TaskDetail = userTaskModel.TaskDetail,
                    StartDate = userTaskModel.StartDate,
                    EndDate = userTaskModel.EndDate,
                    Priority = userTaskModel.Priority,
                    Status = userTaskModel.Status
                };
                context.UserTasks.Add(UT);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }
        }

        public List<UserTaskModel> GetTaskDetails()
        {
            try
            {
                List<UserTaskModel> taskModelList = new List<UserTaskModel>();
                var taskList = context.UserTasks.ToList();
                foreach(var taskItem  in taskList)
                {
                    var UTM = new UserTaskModel()
                    {
                        ParentTask_ID = taskItem.ParentTask_ID,
                        TaskDetail = taskItem.TaskDetail,
                        StartDate = taskItem.StartDate,
                        EndDate = taskItem.EndDate,
                        Priority = taskItem.Priority,
                        Status = taskItem.Status
                    };
                    taskModelList.Add(UTM);
                   
                }
                return taskModelList;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public UserTaskModel GetTaskDetailsById(int id)
        {
            var taskModel = (from c in context.UserTasks
                            where c.Task_ID == id
                            select c).FirstOrDefault();

            var UTM = new UserTaskModel()
            {
                ParentTask_ID = taskModel.ParentTask_ID,
                TaskDetail = taskModel.TaskDetail,
                StartDate = taskModel.StartDate,
                EndDate = taskModel.EndDate,
                Priority = taskModel.Priority,
                Status = taskModel.Status
            };
            return UTM;
        }

        public bool Update(UserTaskModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
