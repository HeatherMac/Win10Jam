using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class EndGameText : MonoBehaviour {

    public bool Scores;
    public bool Total = false;

    int WindowsLost = 0;
    int WindowsSaved = 0;
    int TotalCracks = 0;
    int CracksRepaired = 0;
    int CarsSaved = 0;
    int CarsLost = 0;
    int FiresExtinguished = 0;
    int BridgesSaved = 0;

    int TotalScore = 0;

    Text EndingText;

    List<int> ScoreList = new List<int>();
    List<int> TargetScoreList = new List<int>();

    // Use this for initialization
    void Start () {

        EndingText = GetComponent<Text>();

        ScoreList.Add(WindowsLost);
        ScoreList.Add(WindowsSaved);
        ScoreList.Add(TotalCracks);
        ScoreList.Add(CracksRepaired);
        ScoreList.Add(CarsSaved);
        ScoreList.Add(CarsLost);
        ScoreList.Add(FiresExtinguished);
        ScoreList.Add(BridgesSaved);

        TargetScoreList.Add(GameData.WindowsLost);
        TargetScoreList.Add(GameData.WindowsSaved);
        TargetScoreList.Add(GameData.TotalCracks);
        TargetScoreList.Add(GameData.CracksRepaired);
        TargetScoreList.Add(GameData.CarsSaved);
        TargetScoreList.Add(GameData.CarsLost);
        TargetScoreList.Add(GameData.FiresExtinguished);
        TargetScoreList.Add(GameData.BridgesSaved);

        //WindowsLost =  GameData.WindowsLost;
        //WindowsSaved = GameData.WindowsSaved;
        //TotalCracks = GameData.TotalCracks;
        //CracksRepaired = GameData.CracksRepaired;
        //CarsSaved = GameData.CarsSaved;
        //CarsLost = GameData.CarsLost;
        //FiresExtinguished = GameData.FiresExtinguished;
        //BridgesSaved = GameData.BridgesSaved;


    }
	
	// Update is called once per frame
	void FixedUpdate () {


        if (!Total)
        {
            if (!Scores)
            {

                EndingText.text =
                ScoreList[0] +
               "\n" + ScoreList[1] +
               "\n" + ScoreList[2] +
               "\n" + ScoreList[3] +
               "\n" + ScoreList[4] +
               "\n" + ScoreList[5] +
               "\n" + ScoreList[6] +
               "\n" + ScoreList[7];
            }
            else
            {
                EndingText.text =
                " : " + (ScoreList[0] * -100) +
               "\n : " + (ScoreList[1] * 200) +
               "\n : " + (ScoreList[2] * -10) +
               "\n : " + (ScoreList[3] * 20) +
               "\n : " + (ScoreList[4] * 300) +
               "\n : " + (ScoreList[5] * -500) +
               "\n : " + (ScoreList[6] * 200) +
               "\n : " + (ScoreList[7] * 1000);
            }
        }
        else
        {
            TotalScore  =
((ScoreList[0] * -100) +
 (ScoreList[1] * 200) +
 (ScoreList[2] * -10) +
 (ScoreList[3] * 20) +
 (ScoreList[4] * 300) +
 (ScoreList[5] * -500) +
 (ScoreList[6] * 200) +
 (ScoreList[7] * 1000));

            EndingText.text = TotalScore.ToString();
        }

        if (BridgesSaved != GameData.BridgesSaved)
        {
            for (int i = 0; i < ScoreList.Count; i++)
            {
                if (ScoreList[i] < TargetScoreList[i])
                {
                    ScoreList[i]++;
                    return;
                }

            }
        }

	}
}
