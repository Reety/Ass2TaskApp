using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.Configuration;
using YourTimeApp.DB;
using YourTimeApp.ViewModels;
using YourTimeApp.Data;
using LiveChartsCore;

namespace YourTimeApp
{   
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IConfiguration Config { get; private set; }

        private CreateTaskViewModel createTaskVM;

        public App()
        {
            TaskSessionList.Tasks.Add(new Data.UserTask("working on dot net assignment")
            {
                AllocatedTime = new TimeSpan(0, 15, 0)
            });

            TaskSessionList.Tasks.Add(new Data.UserTask("writing dot net report")
            {
                AllocatedTime = new TimeSpan(0, 30, 0)
            });

            TaskSessionList.Tasks.Add(new Data.UserTask("crying because uni is hard")
            {
                AllocatedTime = new TimeSpan(1, 20, 0)
            });

            LiveCharts.Configure(config =>
                config.HasMap<TaskTimeViewModel>(
                    (task, index) => new(index, task.TimeSpent.TotalSeconds)));

            YourTimeStore appStore = new YourTimeStore();
            createTaskVM = new CreateTaskViewModel(appStore);



            Config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            CreateTask createTaskWindow = new CreateTask()
            {
                DataContext = createTaskVM
            };

            createTaskWindow.Show();
        }
    }
}
