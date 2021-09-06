using System;

namespace FlixNet
{
    class Program
    {
        static SeriesRepository repository = new SeriesRepository();
        static void Main(string[] args)
        {
            string userOption = GetUserOption();

            while (userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1":
                        ListSeries();
                        break;
                    case "2":
                        InsertSeries();
                        break;
                    case "3":
                        UpdateSeries();
                        break;
                    case "4":
                        DeleteSeries();
                        break;
                    case "5":
                        ViewSeries();
                        break;
                    case "6":
                        Console.Clear();
                        break;
                                           
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                userOption = GetUserOption();
            }
            Console.WriteLine("Thank you for using our services c:");
            Console.ReadLine();

        } 
        //==============================================================================================================
        private static void DeleteSeries()
        {
            Console.Write("Enter to id series: ");
            int indexSeries = int.Parse(Console.ReadLine());

            Console.Write("Are you sure you want to delete this series? (yes = 1) (not = 0): ");
            int choose = int.Parse(Console.ReadLine());

            if(choose == 1)
            {
                repository.Delete(indexSeries);
                Console.WriteLine("The series has been deleted :c");                
            }
            if(choose == 0)
            {
                Console.WriteLine("The series has not been deleted c:"); ;
            }
            Console.WriteLine();
        }


        private static void ViewSeries()
        {
            Console.Write("Enter to id series: ");
            int indexSeries = int.Parse(Console.ReadLine());

            var series = repository.ReturnById(indexSeries);
            Console.WriteLine(series);
        }


        private static void UpdateSeries()
        {
            Console.Write("Enter to id series: ");
            int indexSeries = int.Parse(Console.ReadLine());

            // https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach(int i in Enum.GetValues(typeof(Gender)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Gender), i));
            }

            Console.Write("Enter the genre from the options above:");
                int inputGender = int.Parse(Console.ReadLine());

                Console.Write("Enter the series title:");
                string inputTitle = Console.ReadLine();

                Console.Write("Enter the start year of the series:");
                int inputYear = int.Parse(Console.ReadLine());

                Console.Write("Enter the description of the series:");
                string inputDescription = Console.ReadLine();

                Series updateSeries = new Series(
                    id: indexSeries,
                    gender: (Gender)inputGender,
                    title: inputTitle,
                    year: inputYear,
                    description: inputDescription);

                repository.Update(indexSeries, updateSeries);
        }


        private static void ListSeries()
        {
            Console.WriteLine("List series:");
            var list = repository.ToList();

            if (list.Count == 0)
            {
                Console.WriteLine("No series has been registered.");
                return;
            }

            foreach (var series in list)
            {
                var deleted = series.returnDeleted();

                Console.WriteLine("#ID {0}: - {1} {2}", series.ReturnId(), series.ReturnTitle(), (deleted ? "*Deleted*" : ""));
            }
        }


        static void InsertSeries()
        {
            Console.WriteLine("Insert new series:");

            foreach(int i in Enum.GetValues(typeof(Gender)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Gender), i));
            }
            Console.WriteLine("Enter the genre from the options above:");
            int inputGender = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the series title:");
            string inputTitle = Console.ReadLine();

            Console.WriteLine("Enter the start year of the series:");
            int inputYear = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the description of the series:");
            string inputDescription = Console.ReadLine();

            Series newSeries = new Series(
                id: repository.NextId(),
                gender: (Gender)inputGender,
                title: inputTitle,
                year: inputYear,
                description: inputDescription);

            repository.Insert(newSeries);
        }


        private static string GetUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("NetSeries at your service! c:");
            Console.WriteLine("Set your option");

            Console.WriteLine("1: List series");
            Console.WriteLine("2: Insert new series");
            Console.WriteLine("3: Update series");
            Console.WriteLine("4: Delete series");
            Console.WriteLine("5: View series");
            Console.WriteLine("6: Clear screen");
            Console.WriteLine("X: Exit");
            Console.WriteLine();

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }
    }
}
