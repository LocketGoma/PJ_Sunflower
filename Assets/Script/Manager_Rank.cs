using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Manager_Rank : MonoBehaviour {
    public RankItem[] Ranktems;

    [System.Serializable]
    public struct ScoreItemJson
    {
        public long ticks;
        public int score;
    }

    [System.Serializable]
    public struct ScoreItemArray
    {
        public ScoreItemJson[] scoreItems;
    }

    private static string HIGHSCORE_KEY = "highscore";

    private void Awake()
    {
        //AddNewHighscore(123);

        var scoreItemArray = JsonUtility.FromJson<ScoreItemArray>(PlayerPrefs.GetString(HIGHSCORE_KEY, "{}"));
        if (scoreItemArray.scoreItems == null)
        {
            return;
        }
        var scoreItemArraySorted = scoreItemArray.scoreItems.OrderByDescending(e => e.score).ThenByDescending(e => e.ticks).ToArray();
        int i = 0;
        Debug.Log(scoreItemArraySorted.Length);
        foreach (var si in Ranktems)
        {
            if (i < scoreItemArraySorted.Length)
            {
                Ranktems[i].rankText.text = string.Format("{0}위", i + 1);
                Ranktems[i].scoreText.text = string.Format("{0}점", scoreItemArraySorted[i].score);
            }
            else
            {
                Ranktems[i].rankText.text = "";
                Ranktems[i].scoreText.text = "";
            }
            i++;
        }
    }

    public static void AddNewHighscore(int score)
    {
        var scoreItemArray = JsonUtility.FromJson<ScoreItemArray>(PlayerPrefs.GetString("highscore", "{}"));
        var sij = new System.Collections.Generic.List<ScoreItemJson>();
        if (scoreItemArray.scoreItems != null)
        {
            sij.AddRange(scoreItemArray.scoreItems);
        }
        sij.Add(new ScoreItemJson { score = score, ticks = System.DateTime.Now.Ticks });
        scoreItemArray.scoreItems = sij.ToArray();
        var str = JsonUtility.ToJson(scoreItemArray);
        PlayerPrefs.SetString(HIGHSCORE_KEY, str);
        PlayerPrefs.Save();
        //이런 미친 이거 레지스트리에 박혀있어!
    }
    /*
    public void ReturnToTitle()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("title");
    }
    */
}
