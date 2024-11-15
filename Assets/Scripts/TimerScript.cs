using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI waveText;
    
    
    void Update()
    {
        waveText.text = "Oleada " + Score.wave;
    }
}
