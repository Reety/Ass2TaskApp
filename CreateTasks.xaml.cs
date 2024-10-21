﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using YourTimeApp.Data;

namespace YourTimeApp
{
    /// <summary>
    /// Interaction logic for CreateTasks.xaml
    /// </summary>
    public partial class CreateTasks : Window
    {
        public CreateTasks()
        {
            InitializeComponent();
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            string taskDesc = Task.Text;
            float timeAlloc = float.Parse(Minutes.Text);
            ToDo newTodo = new ToDo(taskDesc);
            TaskDesc.Text = newTodo.ToString();
        }

        private void textBox1_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                
            }
        }
    }
}
