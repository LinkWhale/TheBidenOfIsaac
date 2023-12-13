using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class spriteFacing : MonoBehaviour
{
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, GameObject.FindGameObjectWithTag("MainCamera").transform.rotation.eulerAngles.y + 180, 0);
    }
}