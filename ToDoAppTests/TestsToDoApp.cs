using ToDoApp;
namespace ToDoAppTests
{
    [TestClass]
    public class TestsToDoApp
    {
        [TestMethod]
        public void TasksCanBeAdded()
        {
            Program.AddTaskToTaskList("Beispieltask");

            Assert.IsTrue(Program.tasks.Count() > 0);
        }
    }
}