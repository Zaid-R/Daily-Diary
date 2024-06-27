using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace DiaryManager
{
    internal class Program
    {
        static void Main(string[] args)
        {

            if (File.Exists(DailyDiary.filePath))
            {
                try
                {
                    string message = "Welcome to Daily Diary \n" +
                        "please enter the number of the wanted operatoin:\n" +
                        "[1] Read the content of the existing diary\n" +
                        "[2] Add new entry to the diary\n" +
                        "[3] Delete specific entry from the diary\n" +
                        "[4] Count the total number of entries\n" +
                        "[5] Read entry of a specific date";
                    Console.WriteLine(message);

                    string existKey = "";
                    while (String.Compare(existKey, "escape", true) != 0)
                    {

                        Regex regex = new Regex("^[1-5]$");
                        string operationNumber;
                        while (!regex.IsMatch(operationNumber = Console.ReadLine().Trim()))
                        {
                            Console.WriteLine("Please enter a number between 1 and 5:");
                        }

                        switch (operationNumber)
                        {
                            case "1":
                                Console.WriteLine("\n"+DailyDiary.readContent()+"\n");
                                break;
                            case "2":
                                //1. Get date from user
                                string date = DailyDiary.getDateFromUser();
                                // 2. Get number of lines from user
                                Console.WriteLine("How many lines you want to write?");
                                string linesNumberInput;
                                int linesNumber;
                                // 2.1 Check the number of lines
                                while (!int.TryParse(linesNumberInput = Console.ReadLine().Trim(), out linesNumber))
                                {
                                    Console.WriteLine("You can't enter letters or symbols, please enter the number of lines you want to write");
                                }

                                StringBuilder stringBuilder = new StringBuilder();
                                // 3. Get content from user
                                for (int i = 0; i < linesNumber; i++)
                                {
                                    stringBuilder.AppendLine(Console.ReadLine());
                                }

                                // 4. Add entry
                                DailyDiary.addEntry(new Entry(date, stringBuilder.ToString()));
                                stringBuilder.Clear();
                                break;
                            case "3":
                                Console.WriteLine("Enter the date of entry you want to delete");
                                date = DailyDiary.getDateFromUser();
                                DailyDiary.removeEntry(date);
                                break;
                            case "4":
                                Console.WriteLine($"Number of entries: {DailyDiary.countEntries()}");
                                break;
                            case "5":
                                Console.WriteLine("Enter the date of entry you want to read");
                                date = DailyDiary.getDateFromUser();
                                DailyDiary.readEntry(date);
                                break;
                        }


                        Console.WriteLine("====================");
                        Console.WriteLine("If you want to exist then press Esc, otherwise press any other key:");
                        existKey = Console.ReadKey().Key.ToString();
                    }
                    Console.WriteLine();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Something wrong happend");
                    Console.WriteLine(ex.ToString());
                }
                finally
                {

                }
            }
            else
            {
                Console.WriteLine("File doesn\'t exist!");
            }
        }
    }
}
