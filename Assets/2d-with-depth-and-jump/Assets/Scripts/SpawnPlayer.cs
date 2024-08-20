using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class SpawnPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private int lv1Height;
    [SerializeField] private int lv2Height;
    [SerializeField] private int lv3Height;
    [SerializeField] private int lv4Height;
    [SerializeField] private GameObject playerCamera;
    [SerializeField] private GameObject playerUi;
    private GameObject currentPlayer;
    private GameObject delayingPlayer;
    private float numeroUno = 0;
    private float currentDistance;
    private GameObject wheel;
    private int currentLevel;
    private Vector3 camOffset;
    void Start()
    {
        currentLevel = 0;
        PlayerSpawn(true);
    }

    void PlayerSpawn(bool died)
    {
        if (died && currentLevel < 4)
        {
            currentLevel += 1;
        }

        int stickSize = 0;

        currentPlayer = Instantiate(playerPrefab, transform.position, Quaternion.identity);
        wheel = currentPlayer.transform.Find("Wheel").gameObject;

        if (currentLevel == 1)
        {
            stickSize = lv1Height;
        }
        else if (currentLevel == 2)
        {
            stickSize = lv2Height;
        }
        else if (currentLevel == 3)
        {
            stickSize = lv3Height;
        }
        else if (currentLevel >= 4)
        {
            stickSize = lv4Height;
        }

        wheel.GetComponent<MoveWheel>().stickSize = stickSize;
        playerUi.GetComponent<TextBehavior>().height = stickSize;
        playerUi.GetComponent<TextBehavior>().level = currentLevel;
        playerUi.GetComponent<TextBehavior>().distance = 0f;
        currentDistance = 0f;
    }

    void MoveCamera()
    {
        if (delayingPlayer)
        {
            Vector3 seatPos = delayingPlayer.transform.Find("Seat").gameObject.transform.position + new Vector3(0, -playerUi.GetComponent<TextBehavior>().height / 2 + 2, -10);
            camOffset = seatPos - playerCamera.transform.position;
            playerCamera.transform.position += camOffset * Time.deltaTime * 2;

            if (seatPos.x > currentDistance)
            {
                currentDistance = seatPos.x;
                playerUi.GetComponent<TextBehavior>().distance = currentDistance;
            }
        }
    }

    void OnDeath()
    {
        bool isCelebrating = wheel.GetComponent<MoveWheel>().hasSucceded;
        PlayerSpawn(isCelebrating);
    }

    void Update()
    {
        bool isDead = wheel.GetComponent<MoveWheel>().isDead;
        if (currentPlayer && isDead == false)
        {
            if (currentPlayer != delayingPlayer)
            {
                numeroUno += Time.deltaTime;
                if (numeroUno > 1)
                    delayingPlayer = currentPlayer;
            }

            else
            {
                numeroUno = 0;
            }
            MoveCamera();
        }
        else
        {
            OnDeath();
        }
        Debug.Log(playerCamera.transform.position);
    }
    // Update is called once per frame
}
