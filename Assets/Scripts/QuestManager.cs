using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {

    public QuestObject[] quests; //An array of all questobjects
    public bool[] questCompleted;

    public string itemCollected;//A string to identify collected items (for quests)

	// Use this for initialization
	void Start () {
        questCompleted = new bool[quests.Length];
	}
	
	// Update is called once per frame
	void Update () {

        if (IsAllMissionComplete())
        {
            Debug.Log("YOU WON THE GAME!");


        }


	}


    private bool IsAllMissionComplete()
    {
        for (int i = 0; i < questCompleted.Length; ++i)
        {
            if (questCompleted[i] == false)
            {
                return false;
            }
        }

        return true;
    }

}
