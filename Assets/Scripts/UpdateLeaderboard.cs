using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateLeaderboard : MonoBehaviour
{
    public Text kills;
    public Text HighestScore;
    public Text GatheredHealth;

    private List<int> holder = new List<int>();

	void Awake ()
    {
        holder = ScoreContainer.container.GetScores();

        kills.text = "Kills: " + ScoreContainer.container.getKill();
        HighestScore.text = "HighScore: " + holder[0];
        holder = null;
        GatheredHealth.text = "Health Gathered: " + ScoreContainer.container.getHGath();
        ScoreContainer.container.save();
	}
}
