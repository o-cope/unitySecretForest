using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPlayer : MonoBehaviour
{
    [Header("Track Player")]
    [SerializeField] private Transform trackPlayer;
    [SerializeField] private float distanceToPlayer = 10.0f;

    void Update()
    {
        Vector3 playerInfo = trackPlayer.transform.transform.position;
        transform.position = new Vector3(playerInfo.x, playerInfo.y, playerInfo.z - distanceToPlayer);
    }
}
