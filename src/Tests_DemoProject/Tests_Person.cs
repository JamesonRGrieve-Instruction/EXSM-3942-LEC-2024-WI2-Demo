namespace Tests_DemoProject;
using DemoProject;
public class Tests_Person
{
    [Fact]
    public void Test_SingASong()
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