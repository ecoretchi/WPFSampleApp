using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace TestDataContextBindings
{


    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {


        Task someTask = new Task(() =>
        {
            Console.WriteLine("Do test task");
        });

        public App()
        {
            someTask.Start();
            someTask.Wait();
            someTask.Dispose();
            someTask.Start();
            someTask.Wait();
            someTask.Start();
            someTask.Wait();

        }


    }
}
