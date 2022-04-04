using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Score
{
    static int stagesToWin = 5;

    public static int player1, player2;

    public static void Reset()
    {
        player1 = player2 = 0;
    }

    public static bool Fin()
    {
        return player1 >= stagesToWin || player2 >= stagesToWin;
    }

    public static int PlayerWin()
    {
        return player1 > player2 ? player1 : player2;
    }
}
