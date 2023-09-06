using OpenAI_API.Moderation;
using PromptEvolution;
using Spectre.Console;
using System.Text;
using TextCopy;

Console.OutputEncoding = Encoding.UTF8;

var question = args.FirstOrDefault();
if (!String.IsNullOrWhiteSpace(question))
{
    List<string> commandSuggestions = new();

    await AnsiConsole.Status()
       .StartAsync("Thinking...", async ctx =>
       {
           ctx.Spinner(Spinner.Known.Clock);
           ctx.SpinnerStyle(Style.Parse("green"));

           commandSuggestions = await Interrogator.Ask(question).ConfigureAwait(false);
       });

    if (commandSuggestions.Count == 0)
    {
        AnsiConsole.MarkupLine($"[red]No command suggestions found for question:[/] [yellow]{question}[/]");
        return;
    }

    var command = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
        .Title("Select a Command!")
        .PageSize(10)
        .MoreChoicesText("[grey](Move up and down to reveal more commands)[/]")
        .AddChoices(commandSuggestions.ToArray()));

    await ClipboardService.SetTextAsync(command);

}
else
{
    AnsiConsole.MarkupLine($"[yellow] Usage: askai \"question\"[/]");
}