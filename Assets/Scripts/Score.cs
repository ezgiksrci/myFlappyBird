using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    TMPro.TextMeshProUGUI textMesh;
    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();        
    }

    private void Update()
    {
        if (BirdController.isDead == false)
        {
            textMesh.text = BirdController.score.ToString();
        }
        else if ((BirdController.isDead == true) && (gameObject.CompareTag("Score")))
        {
            textMesh.text = BirdController.score.ToString();
        }
        else if ((BirdController.isDead == true) && (gameObject.CompareTag("HighScore")))
        {
            textMesh.text = BirdController.highScore.ToString();
        }
    }
}




