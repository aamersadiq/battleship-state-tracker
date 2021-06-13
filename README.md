# Battleship
Exercise is based on the classic game [Battleship](https://en.wikipedia.org/wiki/Battleship_(game))

## The Task
The task is to implement a Battleship state-tracker for a single player that must support the following logic:

* Create a board

	```
	var board = new Board();
	```
* Add a battleship to the board

	```
	bool isAdded = board.AddShip(new Coordinates(1, 1), 5, Orientation.Horiztontal);
	```
* Take an “attack” at a given position, and report back whether the attack resulted in a hit or a miss

	```
	bool hitOrMiss = board.TakeAttack(new Coordinates(1, 3));
	```
* Return whether the player has lost the game yet (i.e. all battleships are sunk)

	```
	bool isLost = board.IsAllShipsSunk();
	```

## Dependencies
[.NET Core 3.1](https://www.microsoft.com/net/download)

## Run the project
* Open the solution in Visual Studio
* There is no UI or Console, to run the scenerios, Right click Battleship.Tests project -> Run All Tests
