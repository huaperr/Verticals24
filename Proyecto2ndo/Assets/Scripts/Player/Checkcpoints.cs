using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkcpoints : MonoBehaviour
{

    public GameObject player;
   public List<GameObject> checkPoints;
   public Vector3 vectorPoint;

    float dead;

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y < -dead)
        {
            player.transform.position = vectorPoint;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        vectorPoint = player.transform.position;
        Destroy(other.gameObject);
    }
}
