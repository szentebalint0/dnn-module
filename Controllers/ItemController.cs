/*
' Copyright (c) 2026 ClosedAI
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using DotNetNuke.Entities.Users;
using DotNetNuke.Framework.JavaScriptLibraries;
using DotNetNuke.Web.Mvc.Framework.ActionFilters;
using DotNetNuke.Web.Mvc.Framework.Controllers;
using HelloWorld.Dnn.Dnn.ClosedAI.HelloWorld.Components;
using HelloWorld.Dnn.Dnn.ClosedAI.HelloWorld.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using HelloWorld.Dnn.Dnn.ClosedAI.HelloWorld.Providers;
using DotNetNuke.Entities.Portals;

namespace HelloWorld.Dnn.Dnn.ClosedAI.HelloWorld.Controllers
{
    [DnnHandleError]
    public class ItemController : DnnController
    {

        private readonly ChatbotConfigRepository _configRepository = new ChatbotConfigRepository();

        public ActionResult Delete(int itemId)
        {
            ItemManager.Instance.DeleteItem(itemId, ModuleContext.ModuleId);
            return RedirectToDefaultRoute();
        }

        public ActionResult Edit(int itemId = -1)
        {
            DotNetNuke.Framework.JavaScriptLibraries.JavaScript.RequestRegistration(CommonJs.DnnPlugins);

            var userlist = UserController.GetUsers(PortalSettings.PortalId);
            var users = from user in userlist.Cast<UserInfo>().ToList()
                        select new SelectListItem { Text = user.DisplayName, Value = user.UserID.ToString() };

            ViewBag.Users = users;

            var item = (itemId == -1)
                 ? new Item { ModuleId = ModuleContext.ModuleId }
                 : ItemManager.Instance.GetItem(itemId, ModuleContext.ModuleId);

            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(Item item)
        {
            if (item.ItemId == -1)
            {
                item.CreatedByUserId = User.UserID;
                item.CreatedOnDate = DateTime.UtcNow;
                item.LastModifiedByUserId = User.UserID;
                item.LastModifiedOnDate = DateTime.UtcNow;

                ItemManager.Instance.CreateItem(item);
            }
            else
            {
                var existingItem = ItemManager.Instance.GetItem(item.ItemId, item.ModuleId);
                existingItem.LastModifiedByUserId = User.UserID;
                existingItem.LastModifiedOnDate = DateTime.UtcNow;
                existingItem.ItemName = item.ItemName;
                existingItem.ItemDescription = item.ItemDescription;
                existingItem.AssignedUserId = item.AssignedUserId;

                ItemManager.Instance.UpdateItem(existingItem);
            }

            return RedirectToDefaultRoute();
        }

        [ModuleAction(ControlKey = "Edit", TitleKey = "AddItem")]
        public ActionResult Index()
        {
            var moduleId = ModuleContext.ModuleId;
            var userId = DotNetNuke.Entities.Users.UserController.Instance.GetCurrentUserInfo().UserID;

            var config = _configRepository.GetOrCreateDefault(moduleId, userId);

            var user = DotNetNuke.Entities.Users.UserController.Instance.GetCurrentUserInfo();
            var isAdmin = user != null && (
                user.IsSuperUser ||
                user.IsInRole(PortalSettings.AdministratorRoleName)
            );

            var vm = new ChatbotConfigViewModel
            {
                ModuleId = config.ModuleId,
                Enabled = config.Enabled,
                Endpoint = config.Endpoint,
                HistoryWindow = config.HistoryWindow,
                Title = config.Title,
                InputPlaceholder = config.InputPlaceholder,
                WelcomeMessage = config.WelcomeMessage,
                StarterQuestions = config.StarterQuestions,
                IsEditable = ModuleContext.IsEditable,
                IsAdmin = isAdmin
            };

            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(ChatbotConfigViewModel vm)
        {
            var user = DotNetNuke.Entities.Users.UserController.Instance.GetCurrentUserInfo();
            var isAdmin = user != null && (
                user.IsSuperUser ||
                user.IsInRole(PortalSettings.AdministratorRoleName)
            );

            if (!isAdmin)
            {
                return new HttpUnauthorizedResult();
            }

            var existing = _configRepository.GetOrCreateDefault(ModuleContext.ModuleId, user.UserID);

            existing.Enabled = vm.Enabled;
            existing.Endpoint = vm.Endpoint;
            existing.HistoryWindow = vm.HistoryWindow;
            existing.Title = vm.Title;
            existing.InputPlaceholder = vm.InputPlaceholder;
            existing.WelcomeMessage = vm.WelcomeMessage;
            existing.StarterQuestions = vm.StarterQuestions;
            existing.LastModifiedOnDate = DateTime.UtcNow;
            existing.LastModifiedByUserId = user.UserID;

            _configRepository.Save(existing);

            return RedirectToAction("Index");
        }
    }
}
