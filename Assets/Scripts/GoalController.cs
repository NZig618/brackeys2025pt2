using System;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    //Can likely be removed once "LevelComplete" overlay can be activated
    [SerializeField] SceneChanger sceneChanger;

    public void FinishLevel()
    {
        //Add logic to activate "LevelComplete" overlay
        sceneChanger.LevelComplete();
    }

    public void CollectTreat()
    {
        //Add collection animation here
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CollectTreat();
            FinishLevel();
        }
    }
}
