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

    List<Room> board; // �迭 -> List<int> ex = int[] ex

    // Start is called before the first frame update
    void Start()
    {
        RoomGenerate();
    }

    void RoomCreate()
    {
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                Room currentRoom = board[Mathf.FloorToInt(i + j * size.x)];

                if (currentRoom.visited)
                {
                    var newRoom = Instantiate(room, new Vector3(i * offset.x, 0, j * offset.y), Quaternion.identity, transform).GetComponent<RoomUpdator>();
                    // var ������ � ���̵� �� ���� ���������� �޸𸮸� ���� �Ծ ���� ������� �ʵ��� �Ѵ�.
                    newRoom.UpdateRoom(board[Mathf.FloorToInt(i + j * size.x)].status);

                }
            }
        }
    }

    void RoomGenerate()
    {
        board = new List<Room>();

        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                board.Add(new Room());
            }
        }

        int currentRoom = startPos;
        Stack<int> path = new Stack<int>();

        int k = 0; // while���� �����ϱ� ���� ���� ���� ����
        while(k < 100)
        {
            k++;

            board[currentRoom].visited = true;
            if (currentRoom == board.Count - 1)
            {
                break;
            }

            List<int> arond = CheckAround(currentRoom);
            Debug.Log(k + "��°" + arond.Count);
            if (arond.Count == 0)
            {
                if (path.Count == 0)
                {
                    break;
                }
                else
                {
                    currentRoom = path.Pop();
                }
            }
            else
            {
                path.Push(currentRoom);

                int newRoom = arond[Random.Range(0, arond.Count)];

                if (newRoom > currentRoom)
                {
                    if (newRoom - 1 == currentRoom)
                    {
                        board[currentRoom].status[2] = true;
                        currentRoom = newRoom;
                        board[currentRoom].status[3] = true;
                    }
                    else
                    {
                        board[currentRoom].status[1] = true;
                        currentRoom = newRoom;
                        board[currentRoom].status[0] = true;
                    }
                }
                else
                {
                    if (newRoom + 1 == currentRoom)
                    {
                        board[currentRoom].status[3] = true;
                        currentRoom = newRoom;
                        board[currentRoom].status[2] = true;
                    }
                    else
                    {
                        board[currentRoom].status[0] = true;
                        currentRoom = newRoom;
                        board[currentRoom].status[1] = true;
                    }
                }

            }
        }

        RoomCreate();
    }

    List<int> CheckAround(int room)
    {
        List<int> around = new List<int>();

        // ��
        if (room - size.x >= 0 && !board[Mathf.FloorToInt(room - size.x)].visited) // ������ ���� ���� �����ְ�, ���� �ִ� ���� �ߺ��� ���� �ƴ� ��쿡 ���ο� ���� �߰��Ѵ�
        {
            around.Add(Mathf.FloorToInt(room - size.x));
        }
        // �Ʒ�
        if (room + size.x < board.Count && !board[Mathf.FloorToInt(room + size.x)].visited)
        {
            around.Add(Mathf.FloorToInt(room + size.x));
        }
        // ������
        if ((room + 1) % size.x != 0 && !board[Mathf.FloorToInt(room + 1)].visited)
        {
            around.Add(Mathf.FloorToInt(room + 1));
        }
        // ����
        if (room % size.x != 0 && !board[Mathf.FloorToInt(room - 1)].visited)
        {
            around.Add(Mathf.FloorToInt(room - 1));
        }
        return around;
    }
}
