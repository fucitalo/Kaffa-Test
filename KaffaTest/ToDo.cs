using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace KaffaTest
{
    class ToDo
    {
        public void prompt(){
            string[] menu = {"1 - Create Task", "2 - Delete task", "3 - Read tasks"} ;
            foreach(string item in menu)
                Console.WriteLine(item);
            string option = "0";
            option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    createTasks();
                    break;
                case "2":
                    deleteTasks();
                    break;
                case "3":
                    readTasks();
                    break;
                default:
                    break;
            }            
        }

        private void createTasks()
        {            
            Console.WriteLine("Enter the name of the task");
            string task = Console.ReadLine();

            //Create and write the text file
            StreamWriter sw = new StreamWriter("./ToDoList.txt", true);
            sw.WriteLine(task);
            sw.Close();
        }

        private void deleteTasks()
        {
            try
            {
                Console.WriteLine("Enter the name of the task to be removed");
                string task = Console.ReadLine();
                List<string> taskRemoved = new List<string>();

                //Read the file
                StreamReader sr = new StreamReader("./ToDoList.txt");
                var taskList = sr.ReadLine();
                while (taskList != null)
                {
                    //Checks if the name of the task is in the file, if so, then it will not be included in the list
                    if (taskList != task)
                        taskRemoved.Add(taskList);
                    taskList = sr.ReadLine();
                }
                sr.Close();
                //Overwrite the file, without the task that was removed
                StreamWriter sw = new StreamWriter("./ToDoList.txt", false);
                foreach (string item in taskRemoved)
                    sw.WriteLine(item);
                sw.Close();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message + "\nTry creating a new task first, so the file can be created.");
            }
        }

        private void readTasks()
        {
            try
            {
                StreamReader sr = new StreamReader("./ToDoList.txt");
                Console.Write(sr.ReadToEnd());
                sr.Close();
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\nTry creating a new task first, so the file can be created.");
            }
        }

    }
}