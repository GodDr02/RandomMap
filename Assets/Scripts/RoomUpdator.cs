using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomUpdator : MonoBehaviour
{
    public GameObject[] walls;
    public GameObject[] doors;

    public void UpdateRoom(bool[] state)
    {
        for (int i = 0; i < state.Length; i++)
        {
            doors[i].SetActive(state[i]);
            walls[i].SetActive(!state[i]);
        }
    }
}
