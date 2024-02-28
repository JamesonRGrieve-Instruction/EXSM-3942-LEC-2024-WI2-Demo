namespace Tests_DemoProject;
using DemoProject;
public class Tests_Person
{
    [Fact]
    public void Test_SingASong_Default()
    {
        // Arrange
        Person person = new Person();

        // Act 
        string song = person.SingASong();

        // Assert
        Assert.Equal($"Happy Birthday to you, Happy Birthday to you, Happy Birthday dear {person.FirstName}... Happy Birthday to you.", song);
    }

    [Fact]
    public void Test_SingASong_Greedy()
    {
        // Arrange
        string firstName = "Jameson";
        Person james = new Person(firstName, "R", "Grieve");

        // Act 
        string song = james.SingASong();

        // Assert
        Assert.Equal($"Happy Birthday to you, Happy Birthday to you, Happy Birthday dear {firstName}... Happy Birthday to you.", song);
    }
}