using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GenerateLevels : MonoBehaviour
{
    [SerializeField] private GameObject level1;
    [SerializeField] private GameObject level2;
    [SerializeField] private GameObject neutral;
    [SerializeField] private GameObject level3;
    [SerializeField] private GameObject finishLine;
    [SerializeField] private int spawnQuantity;
    
    private int previousChosenNumber;
    // Start is called before the first frame update

    void MakeNeutral(int i) {
        Instantiate(neutral, new Vector3(i * 15 + 22.5f, 0, 0), Quaternion.identity);
    }

    void Start()
    {
        previousChosenNumber = 0;
        for (int i = 0; i < spawnQuantity; i++)
        {
            if (i == 0)
            {
                Instantiate(level1, new Vector3(i * 15 + 15, 0, 0), Quaternion.identity);
                 MakeNeutral(i);
            }
            else if (i != spawnQuantity - 1)
            {
                int level = Random.Range(1, 4);
                while (level == previousChosenNumber) {
                    level = Random.Range(1,4);
                }
                previousChosenNumber = level;
                switch (level)
                {
                    case 1:
                        Instantiate(level1, new Vector3(i * 15 + 15, 0, 0), Quaternion.identity);
                        break;
                    case 2:
                        Instantiate(level2, new Vector3(i * 15 + 15, 0, 0), Quaternion.identity);
                        break;
                    case 3:
                        Instantiate(level3, new Vector3(i * 15 + 15, 0, 0), Quaternion.identity);
                        //Debug.Log("Sheesh");
                        break;
                }
                MakeNeutral(i);
            }
            else
            {
                Instantiate(finishLine, new Vector3(i * 15 + 15, 0, 0), Quaternion.identity);
            }
        }
    }
}
