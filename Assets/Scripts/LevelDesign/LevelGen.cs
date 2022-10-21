using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelGen : MonoBehaviour
{
    public double Chaos;
    public int Size;

    public int RoomSize;

    Vector3 currPos;

    // Start is called before the first frame update
    void Start()
    {
        GenerateLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateLevel()
    {
        currPos = this.transform.position;
        int direction= new System.Random().Next(4);
        GameObject[] Rooms = Resources.LoadAll("Prefabs/Rooms", typeof(GameObject)).Cast<GameObject>().ToArray();

        Size = Math.Max(0, Size);
        for (int i = 0; i < Size; i++)
        {
            if (Chaos > new System.Random().NextDouble())
            {
                direction = new System.Random().Next(4);
            }

            var tilemap = Instantiate(Rooms[new System.Random().Next(Rooms.Length)], currPos,this.transform.rotation); // todo later

            switch (direction)
            {
                case 0:currPos.y -= RoomSize; break;
                case 1:currPos.x += RoomSize; break;
                case 2:currPos.y += RoomSize; break;
                case 3:currPos.x -= RoomSize; break;
                default:
                    break;
            }

            tilemap.transform.parent = this.transform;
        }

    }
}
