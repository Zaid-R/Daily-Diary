using Xunit;
using System;
using DiaryManager;
namespace DiaryManagerTests
{
    public class UnitTest1
    {

        [Fact]
        public void Read_Diary_File_Test()
        {
            // Act
            string output = File.ReadAllText(DailyDiary.filePath);

            // Assert
            Assert.Equal(DailyDiary.readContent(), output);
        }

        [Fact]
        public void Add_Entry_Test()
        {
            // Act
            int entriesNumberBeforeAdding = DailyDiary.countEntries();
            DailyDiary.addEntry(new Entry("2020-01-01", "Test test ...."));

            // Assert
            Assert.Equal(DailyDiary.countEntries(), entriesNumberBeforeAdding+1);
        }
    }
}