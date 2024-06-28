using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryManager
{
    public record Locatoin(int startOfEntry, int endOfEntry);

    public class DailyDiary
    {
        public const string filePath = "../../../mydiary.txt";
        private static readonly StringBuilder stringBuilder = new StringBuilder();

        public static string readContent()
        {
            return File.ReadAllText(filePath);
        }

        public static void addEntry( Entry entry)
        {
            stringBuilder.AppendLine(File.ReadAllText(filePath));
            stringBuilder.AppendLine("");
            stringBuilder.AppendLine(entry.Date);
            stringBuilder.AppendLine(entry.Content);
            File.WriteAllText(filePath, stringBuilder.ToString());
            stringBuilder.Clear();
        }

        private static bool checkDateFormat(string date)
        {
            string[] dateParts = date.Trim().Split("-");

            if (dateParts.Length != 3)
            {
                return false;
            }

            foreach (string item in dateParts)
            {
                if (!int.TryParse(item, out int result))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool checkDateValidation(string date)
        {
            return DateTime.TryParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate);
        }

        private static Locatoin getEntryLocation(string date)
        {
            string[] lines = File.ReadAllLines(filePath);
            int startOfEntry = -1;
            int endOfEntry = -1;

            for (int i = 0; i < lines.Length; i++)
            {
                if (string.Equals(date, lines[i].Trim()))
                {
                    startOfEntry = i;
                    break;
                }
            }
            if (startOfEntry > -1)
            {

                for (int i = startOfEntry; i < lines.Length; i++)
                {
                    if (string.IsNullOrEmpty(lines[i]))
                    {
                        endOfEntry = i;
                        break;
                    }
                }

            }
            return new Locatoin(startOfEntry, endOfEntry);
        }

        public static string getDateFromUser()
        {
            string enterMessage = "Enter the date in this format: YYYY-MM-DD";
            Console.WriteLine(enterMessage);

            //1. Get date from user
            string date = Console.ReadLine();
            // 1.1 check the input 
            bool isDateEmpty;
            bool isDateFormatted = true;
            bool isDateValid = true;
            while ((isDateEmpty = string.IsNullOrEmpty(date)) || !(isDateFormatted = checkDateFormat(date)) || !(isDateValid = checkDateValidation(date)))
            {
                if (isDateEmpty)
                {
                    Console.WriteLine("You can't enter empty date");
                }
                else if (!isDateFormatted)
                {
                    Console.WriteLine("Date is not in the right format");
                }
                else if (!isDateValid)
                {
                    Console.WriteLine("Date is not valid");
                }
                Console.WriteLine(enterMessage);
                date = Console.ReadLine();
            }
            return date;
        }

        public static void removeEntry(string date)
        {
            string[] lines = File.ReadAllLines(filePath);
            Locatoin locatoin = getEntryLocation(date);

            //Case 1: entry does exsit
            if (locatoin.startOfEntry > -1)
            {
                for (int i = 0; i < lines.Length; i++)
                {
                    if (i >= locatoin.startOfEntry && i <= locatoin.endOfEntry)
                    {
                        continue;
                    }
                    stringBuilder.AppendLine(lines[i]);
                }
                File.WriteAllText(filePath, stringBuilder.ToString());
                stringBuilder.Clear();
            }

            //Case 2: entry doesn't exist
            else
            {
                Console.WriteLine("Entry doesn't exist");
            }
        }

        public static int countEntries()
        {
            int counter = 0;
            //flag
            bool isDate = false;
            string[] lines = File.ReadAllLines(filePath);
            for (int i = 0; i < lines.Length; i++)
            {
                // searching for a date, which is the beginning of an entry
                if (!isDate)
                {
                    isDate = checkDateValidation(lines[i]);
                }

                // means that I read a date before and I reach an empty line or the end of the file, that means there is an entry
                if (isDate && (string.IsNullOrEmpty(lines[i]) || i == lines.Length - 1))
                {
                    counter++;
                    isDate = false;
                }
            }
            return counter;
        }
        public static void readEntry(string date)
        {
            string[] lines = File.ReadAllLines(filePath);
            Locatoin locatoin = getEntryLocation(date);
            if (locatoin.startOfEntry != -1)
            {
                Console.WriteLine();
                for (int i = locatoin.startOfEntry; i < locatoin.endOfEntry; i++)
                {
                    Console.WriteLine(lines[i]);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Entry doesn't exsit");
            }
        }

    }
}
