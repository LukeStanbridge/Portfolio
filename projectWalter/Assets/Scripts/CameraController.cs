using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float offset;
    [SerializeField] private float offsetSmooth;
    private Vector3 playerPosition;

    private void Update()
    {
        playerPosition = new Vector3(player.transform.position.x, transform.position.y, transform.position.z); // follow player on x-axis

        // offset camera on x-axis depnding on which way the player is facing
        if (player.transform.localScale.x > 0f)
        {
            playerPosition = new Vector3(playerPosition.x + offset, playerPosition.y, playerPosition.z);
        }
        else
        {
            playerPosition = new Vector3(playerPosition.x - offset, playerPosition.y, playerPosition.z);
        }

        transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmooth * Time.deltaTime);
    }
}
