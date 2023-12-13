using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    /*Define which direction the room that spawns needs a door
    1 --> SOUTH
    2 --> WEST
    3 --> NORTH
    4 --> EAST
    */

    private RoomTemplate room;
    private int rand;
    private bool spawned = false;

    void Start()
    {
        room = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplate>();
        Invoke("Spawn", 0.1f);
    }

    void Spawn()
    {
        if(spawned == false)
        {
            if (openingDirection == 1)
            {
                rand = Random.Range(0, room.southRooms.Length);
                Instantiate(room.southRooms[rand], transform.position, room.southRooms[rand].transform.rotation);
            }
            else if (openingDirection == 2)
            {
                rand = Random.Range(0, room.westRooms.Length);
                Instantiate(room.westRooms[rand], transform.position, room.westRooms[rand].transform.rotation);
            }
            else if (openingDirection == 3)
            {
                rand = Random.Range(0, room.northRooms.Length);
                Instantiate(room.northRooms[rand], transform.position, room.northRooms[rand].transform.rotation);
            }
            else if (openingDirection == 4)
            {
                rand = Random.Range(0, room.eastRooms.Length);
                Instantiate(room.eastRooms[rand], transform.position, room.eastRooms[rand].transform.rotation);
            }
            spawned = true;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            if(other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                Instantiate(room.closedRooms, transform.position + new Vector3(0, 2.5f, 0), Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;
        }
    }
}
