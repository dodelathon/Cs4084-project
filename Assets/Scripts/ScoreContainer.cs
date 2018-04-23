using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class ScoreContainer : MonoBehaviour
{
    public static ScoreContainer container;

    private List<int> scores = new List<int>();

    private int Kills;
    private int HGath;

    // Use this for initialization
    void Awake ()
    {
        if(container == null)
        {
            container = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(container != this)
        {
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file;
        if (File.Exists(Application.persistentDataPath + "/Score.dat"))
        {
            file = File.Open(Application.persistentDataPath + "/Score.dat", FileMode.Open);
        }
        else
        {
            file = File.Create(Application.persistentDataPath + "/Score.dat");
        }

        ScoreData scoresWriter = new ScoreData(scores, Kills, HGath);

        formatter.Serialize(file, scoresWriter);
        file.Close();
    }

    public bool Load()
    {
        bool loaded = false;
        if(File.Exists(Application.persistentDataPath + "/Score.dat"))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.OpenRead(Application.persistentDataPath + "/Score.dat");

            ScoreData scoresLoader = (ScoreData)formatter.Deserialize(file);
            file.Close();

            scores = scoresLoader.getScores();
            Kills = scoresLoader.getKills();
            HGath = scoresLoader.getGathH();
            loaded = true;
            return loaded;

        }
        else
        {
            save();
            return loaded;
        }
    }

    public List<int> GetScores()
    {
        return scores;
    }

    public int getKill()
    {
        return Kills;
    }

    public int getHGath()
    {
        return HGath;
    }

    public void addScore(int nScore)
    {
        scores.Add(nScore);
    }

    public void addKills(int nkills)
    {
        Kills += nkills;
    }

    public void addGatheredH(int nHealth)
    {
        HGath += nHealth;
    }
}


[Serializable]
class ScoreData
{
    private List<int> scores = new List<int>();
    private int kills;
    private int Hgathered;

    public ScoreData()
    {

    }

    public ScoreData(List<int> nScore, int nKill, int nHGath)
    {
        scores = nScore;
        this.addKills(nKill);
        this.addGatheredH(nHGath);
    }

    public void addScore(int nScore)
    {
        scores.Add(nScore);
    }

    public void addKills(int nkills)
    {
        kills += nkills;
    }

    public void addGatheredH(int nHealth)
    {
        Hgathered += nHealth;
    }

    public List<int> getScores()
    {
        return scores;
    }

    public int getKills()
    {
        return kills;
    }

    public int getGathH()
    {
        return Hgathered;
    }
        

    void orderScoresDesc()
    {
        int holder = 0, temp;
        for (int i = 0; i < scores.Count; i++)
        {
            for (int j = i; j < scores.Count; j++)
            {
                temp = scores[j];
                if (temp > scores[i])
                {
                    holder = scores[i];
                    scores[i] = temp;
                    scores[j] = holder;
                }
            }
        }
        topTen();
    }

    void orderScoresAsc()
    {
        int holder = 0, temp;
        for (int i = scores.Count; i > 0; i--)
        {
            for (int j = i; j > 0; j--)
            {
                temp = scores[j];
                if (temp > scores[i])
                {
                    holder = scores[i];
                    scores[i] = temp;
                    scores[j] = holder;
                }
            }
        }
        topTen();
    }

    void topTen()
    {
        if(scores.Count > 10)
        {
            for(int i = 10; i < scores.Count; i++)
            {
                scores.Remove(i);
            }
        }
    }

}
