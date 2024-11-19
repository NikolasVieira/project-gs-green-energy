using System.Collections;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public static int Money;
    public int startMoney = 400;
    public static int Lives;
    public int startLives = 5;

    void Start() {
        Money = startMoney;
        Lives = startLives;
    }
}
