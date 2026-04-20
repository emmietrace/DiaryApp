//using System;
//using DiaryApp.Models;
//using System.Collections.Generic;
//using System.Linq;
//using Microsoft.EntityFrameworkCore;
//using DiaryApp.Data;
//using DiaryApp;
//using Microsoft.EntityFrameworkCore.Diagnostics;

//namespace DiaryApp
//{
//    class Program
//    {
//        public static async Task Main(string[] args)
//        {
//            // Initialize new DB Context
//            DiaryDbContext context = new DiaryDbContext();

//            // Simple Insert Operation
//            //await DiaryOperations.AddNewDiaryEntries(context);

//            //Inserting via the Console
//            //await DiaryOperations.WriteEntryFromConsole(context);

//            // Simple Select Queries
//            //await DiaryOperations.GetAllEntries(context);

//            //// Queries with filters
//            //await DiaryOperations.SearchEntries(context);

//            //// Perform Update
//            //await DiaryOperations.UpdateEntry(context);

//            // Perform Delete
//            //await DiaryOperations.DeleteEntry(context);

//            Console.WriteLine("<--- Welcome to Emmie's Diary App --->\nChoose any of the following CRUD operations to perform\nI. Simple Insert Operation II. Insertion by You! III. Select Query IV. Query with filters V. Get Diary Entry By ID VI. Perform Update VII. Perform Delete");
//            Console.Write("\nEnter your choice(1-6): ");
//            int choice = int.Parse(Console.ReadLine());

//            bool keepRunning = true;

//            while (keepRunning)
//            {
//                switch (choice)
//                {
//                    case 1:
//                        await DiaryOperations.AddNewDiaryEntries(context);
//                        break;

//                    case 2:
//                        await DiaryOperations.WriteEntryFromConsole(context);
//                        break;

//                    case 3:
//                        await DiaryOperations.GetAllEntries(context);
//                        break;

//                    case 4:
//                        await DiaryOperations.SearchEntries(context);
//                        break;

//                    case 5:
//                        await DiaryOperations.GetEntryByID(context);
//                        break;

//                    case 6:
//                        await DiaryOperations.UpdateEntry(context);
//                        break;

//                    case 7:
//                        await DiaryOperations.DeleteEntry(context);
//                        break;

//                    default:
//                        Console.WriteLine("Invalid Selection!!!");
//                        break;
//                }
//                Console.WriteLine("Do you want to perform another CRUD operation? (Yes/No): ");
//                string answer = Console.ReadLine().ToLower().Trim();

//                if (answer == "no")
//                {
//                    keepRunning = false;
//                }

//                else
//                {
//                    Console.WriteLine("\nChoose again any of the following CRUD operations to perform\nI. Simple Insert Operation II. Insertion by You! III. Select Query IV. Query with filters V. Perform Update VI. Perform Delete");
//                    Console.Write("\nEnter your choice: ");
//                    choice = int.Parse(Console.ReadLine());
//                }
//            }

//            Console.WriteLine("Closing Diary App!");
            
//            Console.WriteLine("Press any key to End...");
//            Console.ReadKey();

//        }
//    }
//}