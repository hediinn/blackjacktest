// See https://aka.ms/new-console-template for more information
using System;
using BlackJackTest;
using static BlackJackTest.Shoe;


Shoe shoe = new();


Player player = new Player("player");
Player player2 = new Player("opp");
Game game = new(1);
game.ShuffleShoe(5);

game.GivePlayerAHand(player2);
game.GivePlayerAHand(player);



List<IPlayer> players = [player2, player];
foreach (var item in players)
{
item.PrintHand();
Console.WriteLine($"{item.GetPlayerState()}");
Console.WriteLine($"{item.KnownScore()}");
Console.WriteLine($"{item.GetName()}");
Console.WriteLine("---------------------------------");

   
}
bool state = true;
for (int i = 0; i < 4; i++)
{
    if (state)
    {
        state = game.PlayRound(players);
    }
    else
    {

        players = [player, player2];
        game.PlayRound(players);
        
    }
}
foreach (var item in players)
{
    item.PrintHand();
    Console.WriteLine($"{item.GetPlayerState()}");
    Console.WriteLine($"{item.KnownScore()}");
    Console.WriteLine($"{item.GetName()}");
    Console.WriteLine("---------------------------------");
}



players = [player2, player];
Utils.WhoWon(players);