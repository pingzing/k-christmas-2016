﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace KChristmas.AzureFunctions
{
    public static class GetGiftHints
    {
        private static readonly string[] GiftHints = new[]
        {
            "It's smaller than a breadbox.",
            "Careful! It could be fragile!",
            "Focus, and shake again.",
            "Better not tell you now.",
            "Prediction hazy, try again.",
            "You hear...chittering?",
            "418 I'M A TEAPOT",
            "Sounds blurry.",
            "The world shakes around you, but the box remains motionless.",
            "C̖̲̩̰̼ͫ͐͐͌ͭͥ̓̋̎T̷̫͙̤͗̈̐ͦ̾̓́̈́Ḣ̢͖̘͉͚͚͈̊ͤͥ͆̎̽̀́͘U̖̟̫̳̮̥ͮ̾̈̃͘͢L̢̬̞͖̰̯̲̘ͩ͂͜U̷̲͚̞̤̗̬͍͓͉̿̑̒̊ͯ̆̈́ ̴̬͍̥͉ͦ͝F̢̖͈ͥͤ͐ͯ̋̇ͅ'̸̛̗͕̹͈̝̩̰͇ͤͥ̃ͬ͒͂̊̓Ť̈͆͆ͨͧ̚̕҉̯̣̣̝͍̤͖̬Ȟ̢͚͎̟̓̇͋̍̅ͥ̀Ã̶͎͔̪ͧ̑̑G̸̛̦̠͕̻̼͓͆̽̋̿̂̐͑̚N̨ͪ͌҉͉̳͖͙͚̝͇̱ I̡̹ͨ̊̋̀ͨͭ͜Ḁ̵̥̘̓̾̉̄͐ ̛̻̘̫̻ͭ̀̓̎͜Iͧ͏̫͇̬̲͚͓͙̘̬A̧̓ͩ̈́̇̍͏̘͚̖̳̺̦̳̕ͅ",
            "You gently tilt the box on its side and you hear a quiet 'thunk'.",
            "The box rattles. It keeps rattling even after you stop shaking.",
            "It doesn't seem very heavy...",
            "Have you tried just asking the box?",
            "The box purrs. At least, you think it's the box.",
            "'PLEASURE TO MEET YOU TOO,' the box booms.",
            "You hear a great crash, followed by ominous silence.",
            "My junk may or may not be in this box.",
            "Maybe this IS the present?",
            "Smells like Christmas.",
            "Loading...",
            "It's ticking...",
            "After you shake it, the box remains suspended in midair.",
            "You hear a satisfied sigh.",
            "What if it was an Etch-A-Sketch with a picture?",
            "Not going to be much left at this rate.",
            "The box seems happy with all this attention.",
            "Seems abstract.",
            "Seems exciting.",
            "Seems clear.",
            "Seems good.",
            "IT'S A WITCH!",
            "The box seems to be pining for the fjords...",
            "Who's a good box?",
            "Pie iesu domine, dona eis requiem.",
            "Sounds expensive.",
            "Sounds cheap.",
            "Sounds fragile.",
            "Seems dizzy.",
            "Seems confused.",
            "The box begins to wonder if it's going into withdrawal.",
            "BOX ANGRY! BOX SMASH!",
            "You shake the box! But you're still hungry...",
            "Hello to the family!",
            "It's so close you can almost taste it!",
            "Not much longer now...",
            "The box is ready for its big debut!",
            "The box would like you to know that it's ready for its close-up.",
            "You hear something fall, as though from a great distance.",
            "You hear snoring, and what sounds like something mumbling 'Come back later...'",
            "The box ponders a different shape for next year. Maybe a circle?",
            "OH YEAH",
            "EEEEEEEEEEEELLLS",
            "The box contemplates pushing your face into the mud. How rude.",
            "˙xoq ǝɥʇ ǝʞɐɥs no⅄",
            "The box shakes back.",
            "The box requests that it be stirred next time.",
            "The name's Box. Gift Box.",
            "Shake shake shake. Shakeshakeshake! Shake your booty!",
            "Alas, poor boxio. We knew him well.",
            "You hear a voice faintly shout 'We don't want any!'",
            "The box screams.",
            "The box goes flying into the sky.",
            "WELP",
            "What's...in the box? Could it be....a rrrrrrubber biscuit?",
            "SIX FOOT, SEVEN FOOT, EIGHT FOOT, BUNCH!",
            "BEEP BOOP INVALID PASSCODE",
            "It giggles.",
            "The box moans suggestively.",
            "The box gasps.",
            "You hear what sounds like hooves clopping on stone.",
            "ALL HAIL THE SUN TRIUMPHANT",
            "Praise the sun!",
            "The moon refused to yield.",
            "But it failed!",
            "*starving walrus noises*",
            "The box begins exploding. ...slowly.",
            "You hear rattling, as though the box were filled with pebbles.",
            "Each shake produces an ecstatic squeak.",
            "You hear a whoosh, and feel the sides of the box inflate slightly.",
            "You feel the stars turn their baleful gaze upon you.",
            "BEHIND YOU!",
            "Something prickling at your back...",
            "Something is wrong.",
            "It's perhaps better if I don't describe the sound the box just made.",
            "The box thinks angry thoughts at you.",
            "The box just wants to be loved.",
            "The box leans into your hand with a sigh.",
            "Something inside the box starts buzzing.",
            "\"Really, darling?\" the box sighs.",
            "One for the show, two to get ready, three for the money, and four to GO!",
            "Hasa diga, ebowai!",
            "♪ Hello. My name is Elder Box ♪",
            "OI, GEROFF ME LAWN",
            "The box attempts to form a union.",
            "SYSTEM ARMED",
            "Over/under on it just being more socks?",
            "But it hurt itself in its confusion!",
            "Whispering?",
            "Honestly, the box looks forward to this every year.",
            "Was that... a slide whistle?",
            "Amazing chest ahead",
            "\"HUZZAH!\" shouts the box. For some reason, you expect boss music to begin.",
            "The box cackles. You hope it's not a witch.",
            "PHaaS: Present Hints as a Service!",
            "Fully Automated Luxury Gay Space Communism--now with more box!",
            "Something shifts. You taste blue, and suddenly feel kind of rhubarb.",
            "\"Man, glad 2020 is over,\" the box sighs.",
            "WHAT IS LOVE",
            "BABY DON'T HURT ME",
            "Did you know that boxes are native to Rectanglia?",
            "Text 220-BOX for more exciting box facts!",
            "From hell's heart, the contents of the box seem... cozy?",
            "\"What is a box?\" the box sighs, \"A a miserable pile of wrapped secrets!\"",
            "What d'you do with a drunken box? (EARLAI IN THE MOR-NIN)",
            "The box winks at you seductively.",
            "The box attempts to wink at you seductively, but just sort of scrunches up instead.",
            "\"Back in my day, in the box mines--!\"\nOh no, here he goes again.",
            "You attempt to shake the box, but bash your shin on a coffee table. A nearby orc glares at you.",
            "\"Oh!\"",
            "\"My, aren't you a forward one...\"",
            "What would you do if, in the box was a fox, that wanted some lox?",
            "That's weird. Something tastes pink.",
            "Tastes kinda... Dream-like?",
            "Not dream-like, actually. Kinda nightmarish. Careful.",
            "Hey, that's a nice ring!",
            "The box mumbles sleepily, then turns over.",
            "\"What are you, some kinda homeowner?\"",
            "Definitely not Elon Musk. Eurgh.",
            "Smells like something brighter.",
            "🎵 Tea and chocolate \n(chocolate and tea) 🎵",
            "*inarticulate bleating noises*",
            "YELLOW BUG BUG BUG BUG BUG",
            "Beetle bonk!",
            "Smells like huckleberries.",
            "Box box box box box box box",
            "How'd the buffalo wish his kid farewell?\n\"Bye, son.\"",
            "a",
            "aa",
            "AAAAAAAAAAAAAAAAA"
        };

        [FunctionName("GetGiftHints")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req,
            ILogger log
        )
        {
            log.LogInformation($"Returning GiftHints at {DateTime.UtcNow}");

            return new OkObjectResult(GiftHints);
        }
    }
}
