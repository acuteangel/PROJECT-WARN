using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRooms : MonoBehaviour
{
    private RoomTemplates templates;
   
    void Start(){
        templates = FindObjectOfType<RoomTemplates>().GetComponent<RoomTemplates>();
        templates.rooms.Add(this.gameObject);
    }
}
