using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinCollector : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        ScoreSystem.dots += 1;
        Remaining_Dots.remaining_dots -= 1;
        Destroy(gameObject);

        if (Remaining_Dots.remaining_dots == 0) 
        {
            GoNextScene();
        }
    }

    private void GoNextScene()
    {
        SceneManager.LoadScene("End Scene");
    }
}
