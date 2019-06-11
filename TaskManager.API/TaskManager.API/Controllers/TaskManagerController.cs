using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
//using System.Web.Http.Cors;
using TaskManager.Business;
using TaskManager.Model;

namespace TaskManager.API.Controllers
{
    [RoutePrefix("api/TaskManager")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TaskManagerController : ApiController, IDisposable
    {
        // GET api/values
        public List<UserTaskModel> GetTaskDetails()
        {
            try
            {
                using (var task = new TaskManagerOperations())
                {

                    return task.GetTaskDetails();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //[Route("GetTaskDetailsById/{id}")]
        public UserTaskModel GetTaskDetailsById(int id)
        {
            try
            {
                using (var task = new TaskManagerOperations())
                {

                    return task.GetTaskDetailsById(id);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //// GET api/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

       // POST api/values
        public void Post([FromBody]UserTaskModel record)
        {
            try
            {
                using (var task = new TaskManagerOperations())
                {
                    var entity = new UserTaskModel();
                    entity.TaskDetail = record.TaskDetail;
                    entity.StartDate = record.StartDate;
                    entity.EndDate = record.EndDate;
                    entity.Priority = record.Priority;
                    entity.Status = record.Status;
                    entity.ParentTask_ID = record.ParentTask_ID;
                    var opSuccess = task.InsertTask(entity);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

            }
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}