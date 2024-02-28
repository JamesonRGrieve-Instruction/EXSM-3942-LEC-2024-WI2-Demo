namespace Tests_DemoProject;
using DemoProject;
public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        // Arrange
        Person person = new Person();
        person.FirstName = "John";
        person.MiddleName = "Test";
        person.LastName = "Doe";

        // Act 
        string song = person.SingASong();

        // Assert
        Assert.Equal($"Happy Birthday to you, Happy Birthday to you, Happy Birthday dear {person.FirstName}... Happy Birthday to you.", song);
    }
}