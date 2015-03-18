using UnityEngine;
using System;
using System.Collections;

public class OddsJob : ThreadedJob
{
    

    public double[,] OutData; // arbitary job data
    DateTime start;
    public void Start2()
    {
        Start();
    }

    protected override void ThreadFunction()
    {
        start = DateTime.Now;
      //  OutData = chanceCalc.CardHelper.Getchance(hands, board);
    }
    protected override void OnFinished()
    {
        Debug.Log("<color=green>Thread Odds Took </color>:" + (DateTime.Now - start).TotalMilliseconds);
    }
}
