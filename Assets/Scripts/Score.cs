using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Score
{
    public static int player1, player2;

    public static void Reset()
    {
        player1 = player2 = 0;
    }
}
