using MenuItemDemo.Models;
using System.Collections.Generic;

namespace MenuItemDemo.Services
{
    public static class DataService
    {
        public static List<Project> GetListItems(int itemCount = 10)
        {
            var items = new List<Project>();

            for (var i = 1; i <= itemCount; i++)
            {
                var project = new Project()
                {
                    ProjectId = i,
                    ProjectName = $"Project {i}"
                };

                items.Add(project);
            }

            return items;
        }
    }
}
