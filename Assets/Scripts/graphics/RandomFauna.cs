using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFauna : MonoBehaviour
{

    public GameObject faunaCube;
    public Material Grass;
    public Material Rock;

    public int minObjects;
    public int maxObjects;
    public Vector2 minMaxGrassSize = new Vector2(0.05f, 0.15f);
    public Vector2 minMaxRockAmount = new Vector2(0.05f, 0.15f);
    public Vector2 minMaxRockSize = new Vector2(0.05f, 0.15f);

    void Start()
    {
        int faunaAmount = Random.Range(minObjects,maxObjects);
        int i = 0;
        while (i < faunaAmount)
        {
            //float size = Random.Range(0.05f,0.15f);
            float size = Random.Range(minMaxGrassSize.x, minMaxGrassSize.y);
            GameObject fcube = Instantiate(faunaCube, Vector3.zero, Quaternion.identity);
            fcube.transform.parent = transform;
            Vector3 pos = new Vector3(Random.Range(-0.45f,0.45f), .125f, Random.Range(-0.45f,0.45f));
            fcube.transform.localPosition = pos;
            fcube.transform.localScale = new Vector3(size, size, size);
            i++;

            //-- optimization
            var filter = fcube.GetComponent<MeshFilter>();
            filter.sharedMesh = faunaCube.GetComponent<MeshFilter>().sharedMesh;
            var rend = fcube.GetComponent<MeshRenderer>();
            rend.sharedMaterial = Grass;
        }

        int rockAmount = Random.Range((int)minMaxRockAmount.x, (int)minMaxRockAmount.y);
        i = 0;
        while (i < rockAmount)
        {
            //float size = Random.Range(0.05f,0.15f);
            float size = Random.Range(minMaxRockSize.x, minMaxRockSize.y);
            GameObject fcube = Instantiate(faunaCube, Vector3.zero, Quaternion.identity);
            fcube.transform.parent = transform;
            Vector3 pos = new Vector3(Random.Range(-0.45f, 0.45f), .125f, Random.Range(-0.45f, 0.45f));
            fcube.transform.localPosition = pos;
            fcube.transform.localScale = new Vector3(size, size, size);
            i++;

            //-- optimization
            var filter = fcube.GetComponent<MeshFilter>();
            filter.sharedMesh = faunaCube.GetComponent<MeshFilter>().sharedMesh;
            var rend = fcube.GetComponent<MeshRenderer>();
            rend.sharedMaterial = Rock;
        }
    }
}
