using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {

    public GameObject platform;
    public GameObject diamonds;
    public bool gameOver;
    Vector3 lastPosition; // position of last platform
    float size; // size of platform

	// Use this for initialization
	void Start () {
        lastPosition = platform.transform.position;
        size = platform.transform.localScale.x; // x or z, both are the same	

        for (int i = 0; i < 20; i++) // create first set of platforms
            SpawnPlatform();
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.instance.gameOver == true)
            CancelInvoke("SpawnPlatform");
	}
    
    public void StartSpawningPlatforms()
    {
        InvokeRepeating("SpawnPlatform", 0.1f, 0.2f); // begin creating the next ones
    }

    void SpawnPlatform()
    {
        int rand = Random.Range(0, 6); // 0 to 5
        if (rand < 3)
            SpawnX();
        else if (rand >= 3)
            SpawnZ();
    }

    void SpawnX() // spawn platform in X direction
    {
        Vector3 pos = lastPosition;
        pos.x += size; // move new one on x axis by the size of the platform
        Instantiate(platform, pos, Quaternion.identity);
        lastPosition = pos;

        int rand = Random.Range(0, 4);
        if (rand < 1)
            Instantiate(diamonds, new Vector3(pos.x, pos.y + 1.0f, pos.z), diamonds.transform.rotation);
    }

    void SpawnZ() // spawn platform in Z direction
    {
        Vector3 pos = lastPosition;
        pos.z += size;
        Instantiate(platform, pos, Quaternion.identity);
        lastPosition = pos;

        int rand = Random.Range(0, 4);
        if (rand < 1)
            Instantiate(diamonds, new Vector3(pos.x, pos.y + 1.0f, pos.z), diamonds.transform.rotation);
    }
}
