using System;
using UnityEngine;
public class EventManager
{
    private static int KillEnemyCount = 0;

    public static event Action<int> SetMaxPlayerHelth;
    public static event Action<int> SetPlayerHealth;
    public static event Action<int> SetPlayerPower;
    public static event Action<int> KillEnemy;
    public static event Action<int> KillEnemyRicoñhet;
    public static event Action KillAllEnemy;
    public static event Action PlayerNewPosition;
    public static event Action<Transform> CreateClonePlayer;
    public static event Action<int> EndGame;

    public static void DoSetMaxPlayerHelth(int _maxHealth)
    {
        SetMaxPlayerHelth?.Invoke(_maxHealth);
    }
    public static void DoSetPlayerHealth(int PlayerHealth)
    {
        SetPlayerHealth?.Invoke(PlayerHealth);
    }
    public static void DoSetPlayerPower(int _startStrength)
    {
        SetPlayerPower?.Invoke(_startStrength);
    }
    public static void DoKillEnemy(int strength)
    {
        KillEnemy?.Invoke(strength);
        KillEnemyCount++;
    }
    public static void DoKillEnemyRicoñhet(int Health)
    {
        KillEnemyRicoñhet?.Invoke(Health);
        KillEnemyCount++;
    }
    public static void DoKillAllEnemy()
    {
        KillAllEnemy?.Invoke(); 
        SetPlayerPower?.Invoke(0);
    }
    public static void DoPlayerNewPosition()
    {
        PlayerNewPosition?.Invoke();
    }
    public static void DoCreateClonePlayer(Transform ClonePlayer)
    {
        CreateClonePlayer?.Invoke(ClonePlayer);
    }
    public static void DoEndGame()
    {
        EndGame?.Invoke(KillEnemyCount);
    }
}
