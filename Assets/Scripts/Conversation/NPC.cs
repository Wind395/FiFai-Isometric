using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NPC : MonoBehaviour
{
    public Transform Player;
    public GameObject ConverSation;
    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, Player.transform.position) < 2f)
        {
            ConverSation.SetActive(true);
        }
    }
}
