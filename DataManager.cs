using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public GameObject player;
    public ScoreTracker scoreTracker;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            OnSaveData();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            OnLoadData();
        }

    }

    public void OnSaveData()
    {
        SaveManager.instance.data.score = scoreTracker.getScore();
        SaveManager.instance.data.playerPosition = player.transform.position;
        SaveManager.instance.Save();
    }

    public void OnLoadData()
    {
        SaveManager.instance.Load();
        scoreTracker.setScore(SaveManager.instance.data.score);
        string currentScore = scoreTracker.getScore().ToString();
        scoreTracker.scoreValue.SetText(currentScore);

        player.transform.position = SaveManager.instance.data.playerPosition;
    }
}
