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

    public Vector2 size; // �� ������
    public Vector2 offset; 
    public int startPos; // ��������

    public GameObject room; // �� ������ �޾ƿ���

    List<Room> board; // �迭

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
