using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleSpawner : MonoBehaviour {

    public float gap = 20;
    public float followers = 4;
    public GameObject prefab;

    private void Awake()
    {
        int j = 1;
        bool left = true;
        Vector3 leftGaps = new Vector3(gap, 0, gap);
        Vector3 rightGaps = new Vector3(gap, 0, -gap);
        GameObject leader = GameObject.Instantiate(prefab);
        leader.name = "leader";
        List<GameObject> followerShips = new List<GameObject>();
        for(int i = 1; i <= (followers * 2); i++)
        {
            followerShips.Add(GameObject.Instantiate(prefab));
            followerShips[i - 1].name = "follower";
            if(left == true)
            {
                followerShips[i - 1].transform.position = leader.transform.position - (leftGaps * i);
            }
            else
            {
                followerShips[i - 1].transform.position = leader.transform.position + (rightGaps * j);
                j++;
            }

            if(i == followers)
            {
                left = false;
            }
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
