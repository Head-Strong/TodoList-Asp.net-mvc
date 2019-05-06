using AutoMapper;
using Sample.ToDoList.Infrastructure;
using Sample.ToDoList.Models;
using Sample.ToDoList.Service;
using Sample.ToDoList.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Sample.ToDoList.Controllers
{
    [Authorize]
    public class ToDoController : Controller
    {
        private readonly IToDoService _todoService;

        public ToDoController(IToDoService todoService)
        {
            _todoService = todoService;
        }

        public ActionResult Index()
        {
            var user = CustomContext.GetUser();
            var todoList = _todoService.GetUserToDoList(user.Id).ToList();
            var todoListViewModel = Mapper.Map<List<ToDo>, List<ToDoViewModel>>(todoList);
            return View(todoListViewModel);
        }

        public ActionResult Create()
        {
            var todoViewModel = new ToDoViewModel();
            return View(todoViewModel);
        }

        [HttpPost]
        public ActionResult Create(ToDoViewModel todoViewModel)
        {
            if (ModelState.IsValid)
            {
                todoViewModel.DateModified = DateTime.Now;
                var todo = Mapper.Map<ToDoViewModel, ToDo>(todoViewModel);
                var user = CustomContext.GetUser();
                todo.CreatedBy = user;               
                _todoService.Add(todo);
                return RedirectToAction("Index");
            }

            return View(todoViewModel);
        }

        public ActionResult Edit(string id)
        {
            var todo = _todoService.Get(id);
            var todoViewModel = Mapper.Map<ToDo, ToDoViewModel>(todo);
            return View(todoViewModel);
        }

        public ActionResult Delete(string id)
        {
            _todoService.Delete(id);
            return RedirectToAction("Index");
        }

        public JsonResult UpdateStatus(string id, bool status)
        {
            try
            {
                var todo = _todoService.Get(id);
                todo.DateModified = DateTime.Now;
                todo.IsComplete = status;
                _todoService.Update(todo);
                return Json("success",JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                // Log in database
                return Json("fail", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Edit(string id, ToDoViewModel todoViewModel)
        {
            if (ModelState.IsValid)
            {
                var todo = _todoService.Get(id);
                todo.Description = todoViewModel.Description;
                todo.DateModified = DateTime.Now;
                _todoService.Update(todo);
                return RedirectToAction("Index");
            }

            return View(todoViewModel);
        }        
    }
}