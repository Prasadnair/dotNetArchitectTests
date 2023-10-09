using NetArchTest.Rules;

namespace CleanArchitecture.Tests
{
    public class ArchitectureTests
    {
        [Fact]
        public void Domain_Should_Not_HaveDependencyOnOtherProjects()
        {
            //Arrange
           var assembly =  typeof(Domains.AssemblyReference).Assembly;
            //Act
            var result = Types.InAssembly(assembly)
                .Should()
                .NotHaveDependencyOn("Application")
                .And()
                .NotHaveDependencyOn("Presentation")
                .And()
                .NotHaveDependencyOn("Infrastructure")
                .And()
                .NotHaveDependencyOn("WebAPI")
                .GetResult();
            //Assert
            Assert.True(result.IsSuccessful);
        }

        [Fact]
        public void Application_Should_Not_HaveDependencyOnOtherProjects()
        {
            //Arrange
            var assembly = typeof(Application.AssemblyReference).Assembly;
            //Act
            var result = Types.InAssembly(assembly)
                .Should()
                .NotHaveDependencyOn("Presentation")
                .And()
                .NotHaveDependencyOn("Infrastructure")
                .And()
                .NotHaveDependencyOn("WebAPI")
                .GetResult();
            //Assert
            Assert.True(result.IsSuccessful);
        }
    }
}