using Microsoft.Extensions.Options;
using OpenAI_API;
using PromptEvolution.Tests.Models;
using Snapshooter;
using Snapshooter.Xunit;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace PromptEvolution.Tests
{
    public class RestaurantTest
    {
        [Theory]
        [InlineData("I'd like two large, one with pepperoni and the other with extra sauce.  The pepperoni gets basil and the extra sauce gets Canadian bacon.  And add a whole salad. Make the Canadian bacon a medium. Make the salad a Greek with no red onions.  And give me two Mack and Jacks and a Sierra Nevada.  Oh, and add another salad with no red onions.")]
        [InlineData("I'd like two large with olives and mushrooms.  And the first one gets extra sauce.  The second one gets basil.  Both get arugula.  And add a Pale Ale. Give me a two Greeks with no red onions, a half and a whole.  And a large with sausage and mushrooms.  Plus three Pale Ales and a Mack and Jacks.")]
        [InlineData("I'll take two large with pepperoni.  Put olives on one of them. Make the olive a small.  And give me whole Greek plus a Pale Ale and an M&J.")]
        [InlineData("I want three pizzas, one with mushrooms and the other two with sausage.Make one sausage a small.  And give me a whole Greek and a Pale Ale.  And give me a Mack and Jacks.")]
        [InlineData("I would like to order one with basil and one with extra sauce.Throw in a salad and an ale.")]
        [InlineData("I would love to have a pepperoni with extra sauce, basil and arugula.Lovely weather we're having. Throw in some pineapple.  And give me a whole Greek and a Pale Ale.  Boy, those Mariners are doggin it. And how about a Mack and Jacks.")]
        [InlineData("I'll have two pepperoni, the first with extra sauce and the second with basil.  Add pineapple to the first and add olives to the second.")]
        [InlineData("I sure am hungry for a pizza with pepperoni and a salad with no croutons.  And I'm thirsty for 3 Pale Ales")]
        [InlineData("give me three regular salads and two Greeks and make the regular ones with no red onions")]
        [InlineData("I'll take four large pepperoni pizzas.  Put extra sauce on two of them.  plus an M&J and a Pale Ale")]
        [InlineData("I'll take a yeti, a pale ale and a large with olives and take the extra cheese off the yeti and add a Greek")]
        [InlineData("I'll take a medium Pig with no arugula")]
        [InlineData("I'll take a small Pig with no arugula and a Greek with croutons and no red onions")]
        public async Task Restaurant_Test(string request)
        {          
            var testResult = new TestResult<OrderCollection>()
            {
                Request = request,
                Result = await Translator.Translate<OrderCollection>(request)
            };

            Snapshot.Match(testResult, SnapshotNameExtension.Create(request.MakeFileSystemReady()));
        }

        [Theory]
        [InlineData("Ich hätte gerne zwei große, eine mit Peperoni und die andere mit extra Sauce.Die Peperoni bekommt Basilikum und die Extrasauce kanadischen Speck.Und dazu einen ganzen Salat.Die mit kanadischen Speck soll medium sein.Der Salat soll griechisch sein, ohne rote Zwiebeln.Und gib mir zwei Weizen und ein Sierra Nevada.Oh, und noch einen Salat ohne rote Zwiebeln.")]
        [InlineData("Ich hätte gern zwei große mit Oliven und Pilzen.Und der erste bekommt extra Soße.  Der zweite bekommt Basilikum.  Beide bekommen Rucola.Und dazu ein Pils.Geben Sie mir zwei Griechen ohne rote Zwiebeln, eine halbe und eine ganze.Und ein großes mit Wurst und Pilzen.Dazu drei Pale Ales und ein Weizen.")]
        [InlineData("Ich nehme zwei große mit Peperoni.  Auf eine davon kommen Oliven.Machen Sie aus der Olive eine kleine.Und gib mir eine ganze griechische Pizza plus ein Pils und ein Weizen.")]
        [InlineData("Ich möchte drei Pizzen, eine mit Pilzen und die anderen beiden mit Wurst.Mach aus einer Wurst eine kleine.  Und geben Sie mir einen ganzen griechischen Salad und ein Pils.Und geben Sie mir ein Weizen.")]
        [InlineData("Ich möchte eins mit Basilikum und eins mit extra Soße bestellen.Dazu einen Salat und ein Pils.")]
        [InlineData("Ich hätte gern eine Peperoni mit extra Sauce, Basilikum und Rucola.Schönes Wetter haben wir ja.Dazu eine Ananas.Und dazu einen ganzen Griechen und ein Pils.Mann, die Mariners sind ganz schön in der Klemme. Und wie wär's mit einem Weizen.")]
        [InlineData("Ich nehme zwei Peperoni, die erste mit extra Soße und die zweite mit Basilikum.  Die erste mit Ananas und die zweite mit Oliven.")]
        [InlineData("Ich habe wirklich Hunger auf eine Pizza mit Peperoni und einen Salat ohne Croutons.  Und ich bin durstig nach 3 Pale Ales")]
        [InlineData("gib mir drei normale Salate und zwei griechische und mach die normalen ohne rote Zwiebeln")]
        [InlineData("Ich nehme vier große Peperoni-Pizzen.Zwei davon mit extra Soße, dazu ein Weizen und ein Pils")]
        [InlineData("Ich nehme eine Yeti, ein Pils und eine große mit Oliven und nehme den Extra-Käse von der Yeti und füge eine griechische hinzu")]
        [InlineData("Ich nehme eine mittlere Schinken ohne Rucola")]
        [InlineData("Ich nehme eine kleine Schinken ohne Rucola und ein griechischen Salad mit Croutons und ohne rote Zwiebeln")]
        public async Task Restaurant_German_Test(string request)
        {
            var testResult = new TestResult<OrderCollection>()
            {
                Request = request,
                Result = await Translator.Translate<OrderCollection>(request)
            };

            Snapshot.Match(testResult, SnapshotNameExtension.Create(request.MakeFileSystemReady()));
        }

    }
}
