namespace PromptEvolution.Tests
{
    public class InterrogatorTests
    {
        [Theory]
        [InlineData("How do I get the current date and time?", "Get-Date")]
        [InlineData("How do I get a list of running processes?", "Get-Process")]
        [InlineData("How do I get a list of installed programs?", "Get-WmiObject -Class Win32_Product")]
        public async Task Ask_PowerShell_Command(string question, string command)
        {
            var result = await Interrogator.Ask(question).ConfigureAwait(false);
        }
    }
}
