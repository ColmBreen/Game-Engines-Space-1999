using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour {

    public float mass = 1;
    public float maxSpeed = 10;
    Vector3 leaderTarget = new Vector3(0, 0, 1000);
    Vector3 velocity = Vector3.zero;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Calculate();
        
	}

    public Vector3 SeekForce(Vector3 target)
    {
        Vector3 desired = target - transform.position;
        desired.Normalize();
        desired *= maxSpeed;
        return desired - velocity;
    }

    public Vector3 OffsetPursue()
    {
        float distance = Vector3.Distance(GameObject.Find("leader").transform.position , transform.position);
        float time = distance / maxSpeed;
        Vector3 leaderDistance = new Vector3(GameObject.Find("leader").transform.position.x, GameObject.Find("leader").transform.position.y,
            GameObject.Find("leader").transform.position.z + (maxSpeed * time));
        return SeekForce(leaderDistance);
    }

    public void Calculate()
    {
        if (this.name == "leader")
        {
            velocity += SeekForce(transform.position + leaderTarget);
            transform.position += velocity;
        }
        else
        {
            Debug.Log("Offset Pursue");
            velocity += OffsetPursue();
        }
    }
}
