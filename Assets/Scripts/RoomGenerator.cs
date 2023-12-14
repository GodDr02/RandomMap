using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    public class Room
    {
        public bool visited = false;
        public bool[] status = new bool[4]; 
    }

    public Vector2 size; // 방 사이즈
    public Vector2 offset; 
    public int startPos; // 시작지점

    public GameObject room; // 방 프리팹 받아오기

    List<Room> board; // 배열

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
