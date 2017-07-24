using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ToDoList.Infrastructure.DbContexts;
using ToDoList.Services.ViewModels;

namespace ToDoList.Web.Controllers
{
    public class ToDoListController : Controller
    {
        ToDoListDbContext toDoListDbContext = new ToDoListDbContext();  
        // GET: ToDoList
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult TaskList()
        {
            string currentUserId = User.Identity.GetUserId();
            List<TaskItemViewModel> taskItemViewModel = new List<TaskItemViewModel>();
            taskItemViewModel = toDoListDbContext.TaskItems.Where(lmb => lmb.UserId == currentUserId).Select(lmb => new TaskItemViewModel { Id = lmb.Id, TaskDescription = lmb.TaskDescription, TaskTitle = lmb.TaskTitle, TaskDueDate = lmb.TaskDueDate, UserId = lmb.UserId }).ToList();
            return View(taskItemViewModel);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(TaskItemViewModel taskItemViewModel)
        {
            toDoListDbContext.TaskItems.Add(new Domain.Entities.TaskItem { TaskDescription = taskItemViewModel.TaskDescription, TaskTitle = taskItemViewModel.TaskTitle, TaskDueDate = taskItemViewModel.TaskDueDate, UserId = User.Identity.GetUserId() });
            toDoListDbContext.SaveChanges();
            return RedirectToAction("TaskList");
        }

        [Authorize]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            TaskItemViewModel taskItemViewModel = new TaskItemViewModel();
            taskItemViewModel = toDoListDbContext.TaskItems.Where(lmb => lmb.Id == id).Select(lmb => new TaskItemViewModel { Id = lmb.Id, TaskDescription = lmb.TaskDescription, TaskDueDate = lmb.TaskDueDate, TaskTitle = lmb.TaskTitle, UserId = lmb.UserId }).FirstOrDefault();
            return View(taskItemViewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(TaskItemViewModel taskItemViewModel)
        {
            var taskItem = toDoListDbContext.TaskItems.Where(lmb => lmb.Id == taskItemViewModel.Id).FirstOrDefault();
            taskItem.TaskTitle = taskItemViewModel.TaskTitle;
            taskItem.TaskDescription = taskItemViewModel.TaskDescription;
            taskItem.TaskDueDate = taskItemViewModel.TaskDueDate;
            toDoListDbContext.SaveChanges();
            return RedirectToAction("TaskList");
        }

        [Authorize]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            TaskItemViewModel taskItemViewModel = new TaskItemViewModel();
            taskItemViewModel = toDoListDbContext.TaskItems.Where(lmb => lmb.Id == id).Select(lmb => new TaskItemViewModel { Id = lmb.Id, TaskDescription = lmb.TaskDescription, TaskDueDate = lmb.TaskDueDate, TaskTitle = lmb.TaskTitle, UserId = lmb.UserId }).FirstOrDefault();
            return View(taskItemViewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Delete(TaskItemViewModel taskItemViewModel)
        {
            var taskItem = toDoListDbContext.TaskItems.Where(lmb => lmb.Id == taskItemViewModel.Id).FirstOrDefault();
            toDoListDbContext.Entry(taskItem).State = System.Data.Entity.EntityState.Deleted;
            toDoListDbContext.SaveChanges();
            return RedirectToAction("TaskList");
        }

        [Authorize]
        [HttpGet]
        public ActionResult Details(int id)
        {
            TaskItemViewModel taskItemViewModel = new TaskItemViewModel();
            taskItemViewModel = toDoListDbContext.TaskItems.Where(lmb => lmb.Id == id).Select(lmb => new TaskItemViewModel { Id = lmb.Id, TaskDescription = lmb.TaskDescription, TaskDueDate = lmb.TaskDueDate, TaskTitle = lmb.TaskTitle, UserId = lmb.UserId }).FirstOrDefault();
            return View(taskItemViewModel);
        }

    }
}