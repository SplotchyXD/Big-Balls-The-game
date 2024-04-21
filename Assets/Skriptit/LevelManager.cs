using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //Leveleiden manageri

    public static LevelManager instance;

    // Start is called before the first frame update
    private void Awake()
    {
        if(LevelManager.instance == null) 
        {
            instance = this;
        }
        else Destroy(gameObject);
    }

    // Update is called once per frame
    public void GameOver()
    {
        UiManager _ui = GetComponent<UiManager>();
        if(_ui != null)
        {
            _ui.ToggleDeathPanel();
        }
    }
}
