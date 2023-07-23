using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Threading.Channels;
using PromptEvolution;
using System.IO;
using System.Runtime.Intrinsics.X86;
using System;
using Snapshooter.Xunit;
using Snapshooter;
using System.Globalization;

namespace PromptEvolution.Tests
{
    public class CalendarTest
    {
        [Theory]
        [InlineData("I need to get my tires changed from 12:00 to 2:00 pm on Friday March 15, 2024")]
        [InlineData("Search for any meetings with Gavin this week")]
        [InlineData("Set up an event for friday named Jeffs pizza party at 6pm")]
        [InlineData("Please add Jennifer to the scrum next Thursday")]
        [InlineData("Will you please add an appointment with Jerri Skinner at 9 am?  I need it to last 2 hours")]
        [InlineData("Do I have any plan with Rosy this month?")]
        [InlineData("I need to add a meeting with my boss on Monday at 10am. Also make sure to schedule and appointment with Sally, May, and Boris tomorrow at 3pm. Now just add to it Jesse and Abby and make it last ninety minutes")]
        [InlineData("Add meeting with team today at 2")]
        [InlineData("can you record lunch with Luis at 12pm on Friday and also add Isobel to the Wednesday ping pong game at 4pm")]
        [InlineData("I said I'd meet with Jenny this afternoon at 2pm and after that I need to go to the dry cleaner and then the soccer game.  Leave an hour for each of those starting at 3:30")]
        public async Task Calendar_Test(string request)
        {
            var currentDateTime = DateTimeOffset.ParseExact("20/07/2023 08.00.00 +02:00", "dd/MM/yyyy HH.mm.ss zzz", CultureInfo.InvariantCulture);
            var testResult = new TestResult<EventActionCollection>()
            {
                Request = request,
                Result = await Translator.Translate<EventActionCollection>(request, $"Current Date and Time is {currentDateTime}")
            };

            Snapshot.Match(testResult, SnapshotNameExtension.Create(request.MakeFileSystemReady()));
        }


        [Theory]
        [InlineData("Ich muss meine Reifen am Freitag, den 15. März 2024, von 12:00 bis 14:00 Uhr wechseln lassen.")]
        [InlineData("Suche nach einem Treffen mit Gavin in dieser Woche")]
        [InlineData("Bereite eine Veranstaltung für Freitag vor: Jeffs Pizza-Party um 18 Uhr")]
        [InlineData("Bitte fügen Sie Jennifer zum Scrum nächsten Donnerstag hinzu")]
        [InlineData("Fügen Sie bitte einen Termin mit Jerri Skinner um 9 Uhr hinzu.Er muss 2 Stunden dauern.")]
        [InlineData("Habe ich diesen Monat noch etwas mit Rosy vor?")]
        [InlineData("Ich muss am Montag um 10 Uhr eine Besprechung mit meinem Chef einplanen.Außerdem müssen Sie morgen um 15 Uhr einen Termin mit Sally, May und Boris vereinbaren. Fügen Sie jetzt noch Jesse und Abby hinzu, damit es neunzig Minuten dauert.")]
        [InlineData("Besprechung mit dem Team heute um 14 Uhr hinzufügen")]
        [InlineData("Kannst du das Mittagessen mit Luis am Freitag um 12 Uhr aufnehmen und füge auch Isobel zum Tischtennisspiel am Mittwoch um 16 Uhr hinzu")]
        [InlineData("Ich habe gesagt, dass ich mich heute Nachmittag um 14 Uhr mit Jenny treffe, danach muss ich zur Reinigung und dann zum Fußballspiel.Ab 15:30 Uhr habe ich jeweils eine Stunde Zeit für die beiden.")]
        public async Task Calendar_German_Test(string request)
        {
            var currentDateTime = DateTimeOffset.ParseExact("20/07/2023 08.00.00 +02:00", "dd/MM/yyyy HH.mm.ss zzz", CultureInfo.InvariantCulture);
            var testResult = new TestResult<EventActionCollection>()
            {
                Request = request,
                Result = await Translator.Translate<EventActionCollection>(request, $"Current Date and Time is {currentDateTime}")
            };
            
            Snapshot.Match(testResult, SnapshotNameExtension.Create(request.MakeFileSystemReady()));
        }

    }
}