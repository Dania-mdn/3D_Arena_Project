using System;

public class EventManager
{
    public static event Action EndGame;

    public static void DoEndGame()
    {
        EndGame?.Invoke();
    }
}
