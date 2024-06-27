# Daily Diary Manager
Welcome to the Daily Diary Manager! This application helps you manage your daily diary entries with ease. You can read, add, delete, count, and search for diary entries based on specific dates.

## Features
1. **Read Diary Content**: View the entire content of your diary.
2. **Add New Entry**: Add new entries to your diary with a specific date and content.
3. **Delete Entry**: Remove specific entries from your diary by date.
4. **Count Entries**: Get the total number of entries in your diary.
5. **Search Entries**: Search and read entries for a specific date.

## Running the Application
1. #### Clone the Repository
 ```sh
git clone https://github.com/yourusername/daily-diary-manager.git
cd daily-diary-manager
 ```
2. #### Build the Project
```sh
dotnet build
 ```
3. #### Run the Application
 ```sh
dotnet run --project DiaryManager
 ```

 ## Usage
 When you run the application, you will be presented with a menu of options:

 ```cp
 Welcome to Daily Diary
Please enter the number of the wanted operation:
[1] Read the content of the existing diary
[2] Add new entry to the diary
[3] Delete specific entry from the diary
[4] Count the total number of entries
[5] Read entry of a specific date
 ```
 You can select an option by entering the corresponding number.

#### Option 1: Read Diary Content
Displays the entire content of the diary.
#### Option 2: Add New Entry
1. Enter the date in the format YYYY-MM-DD.
2. Enter the number of lines you want to write.
3. Enter the content line by line.
#### Option 3: Delete Entry
Enter the date of the entry you want to delete in the format YYYY-MM-DD.
#### Option 4: Count Entries
Displays the total number of entries in the diary.
#### Option 5: Read Entry of a Specific Date
Enter the date of the entry you want to read in the format YYYY-MM-DD.

### Example
Here is an example of how to add a new entry:
```cpp
Welcome to Daily Diary
Please enter the number of the wanted operation:
[2]
Enter the date in this format: YYYY-MM-DD
2024-06-27
How many lines you want to write?
3
Today was a great day.
We had a lot of fun at the park.
Can't wait for tomorrow!
```

### Contact
For any questions or suggestions, please contact zaid.rjab1@gmail.com.