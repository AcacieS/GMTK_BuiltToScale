using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class TextBehavior : MonoBehaviour
{
    [SerializeField] private TMP_Text distanceText;
    [SerializeField] private TMP_Text heightText;
    [SerializeField] private TMP_Text levelText;
    [SerializeField] public int level;
    [SerializeField] public float distance;
    [SerializeField] public int height;

    private float hiScore = 0;
    // Start is called before the first frame update;
    void AdjustText()
    {
        string NumberDisText = math.round(distance).ToString();
        string NumberHText = height.ToString();
        string NumberLText = level.ToString();
        string highscore = hiScore.ToString();
        string DisBonus = "/100ft";
        string HBonus = "ft up :)";
        string LBonus = "Phase ";
        string LFinal = "Highscore:  ";
    // Debug.Log(NumberHText + HBonus);

        heightText.SetText(NumberHText + HBonus);
        if (level == 4)
        {   

            distanceText.SetText(NumberDisText + "ft");
            distanceText.color = Color.green;
            if (math.floor(distance) > hiScore) {
            hiScore = math.floor(distance);
            }
            levelText.SetText(LFinal + highscore);

        }
        else
        {
            levelText.SetText(LBonus + NumberLText);
            if (distance > 100)
            {
                distanceText.color = Color.green;
                distanceText.SetText("Reset to pass onto the next phase. "+NumberDisText+"ft");
            }
            else
            {
                distanceText.color = Color.yellow;
                distanceText.SetText(NumberDisText + DisBonus);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        AdjustText();
    }
}
