using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MatchManager
{
    private static int scorePlayer = 0;
    private static int scoreOpponent = 0;
    public static int getscore()
    {
        return scorePlayer;
    }
    public static int getoppscore()
    {
        return scoreOpponent;
    }
    public static void setscore()
    {
        scorePlayer += 1;
    }
    public static void setoppscore()
    {
        scoreOpponent += 1;
    }
    public static void resetscore()
    {
        scorePlayer = 0;
        scoreOpponent = 0;
    }
}
