using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour {

    private float armsRemaining = 2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(armsRemaining == 0)
        {
            SceneManager.LoadScene("Victory");
        }
	}

    public void ArmDestroyed()
    {
        armsRemaining = armsRemaining - 1;
    }
}
