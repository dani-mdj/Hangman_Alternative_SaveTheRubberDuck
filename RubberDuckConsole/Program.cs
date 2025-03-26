
    bool playAgain = true;
    while (playAgain)
    {

        DuckyConsole duck = new DuckyConsole();
        bool gameOn = true;

        duck.Introduction();

        while (gameOn)
        {
            duck.DrawBoard();
            gameOn = duck.PlayerTurn();

        }
        playAgain = duck.PlayAgain();
    }
