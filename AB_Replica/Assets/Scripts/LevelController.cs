//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
* @author Tiago Ribeiro (www.github.com/TRibeiro94)
**/
public class LevelController : MonoBehaviour
{
    private static int _nextLevelID = 1;
    private static int _lastLevel = 5;
    private Enemy[] _enemies;
    
    void OnEnable()
    {
        _enemies = FindObjectsOfType<Enemy>();   
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Enemy enemy in _enemies)    //loop on all enemies each frame to check if they're dead
        {
            if(enemy != null)
            {
                return;                     
            }
        }

        Debug.Log("All enemies dead.");

        _nextLevelID++;
        if(_nextLevelID == _lastLevel)
        {
            SceneManager.LoadScene("End");
        }
        string nextLevelName = "Level" + _nextLevelID;
        SceneManager.LoadScene(nextLevelName);

        
    }
}
