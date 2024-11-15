using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public static int score;
    public static int wave;
    public TextMeshProUGUI scoreDisplay;
    int numberOfEnemiesPerWaver;
    // Start is called before the first frame update
    void Start()
    {
        numberOfEnemiesPerWaver = 10;
        wave = 1;
    }

    public void gainScore(int gain)
    {
        score += gain;
        scoreDisplay.text = score.ToString();
        if (score == numberOfEnemiesPerWaver*10*wave)
        {
            if (wave == 3)
            {
                SceneManager.LoadScene(1);
            }
            else
            {
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                foreach (GameObject enemy in enemies)
                {
                    Destroy(enemy);
                }
                wave++;
            }
            
        }
    }
}
