// See https://aka.ms/new-console-template for more information
using System;
using BlackJackTest;




IPlayer player = new Player("player");
IPlayer player2 = new Player("player2");
IPlayer oppon = new DealerPlayer();
Game game = new(2);

List<IPlayer> players = [player,player2];
List<IPlayer> opps = [oppon];
Table table = new(players, opps, game);
table.Shuffle(5);
table.GiveHandsToPlayers();
table.PlayAGame();
table.ResetGame();




