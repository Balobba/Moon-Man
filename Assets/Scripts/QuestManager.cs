using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {

    public QuestObject[] quests; //An array of all questobjects
    public bool[] questCompleted;

    public string itemCollected;//A string to identify collected items (for quests) DON'T REMOVE!

    public GameObject spaceshipDoorLeft; //The spaceship warper thats on the left side. Locked until all quests are complete

	// Use this for initialization
	void Start () {
        questCompleted = new bool[quests.Length];
	}
	
	// Update is called once per frame
	void Update () {

        if (IsAllMissionComplete())
        {
            spaceshipDoorLeft.SetActive(true);
            //CAN ADD RIGHT SPACESHIP DOOR TO FALSE AND TURN ON LIGHTS

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
