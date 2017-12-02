using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmbilSampah : MonoBehaviour
{
    public RectTransform objekRange;
    public Image areaImage;
    GameObject kumpulanSampah;
    public GameObject[] objekSampah;
    public float delayMuncul = 12f;
    float areaSampahX;
    float areaSampahZ;

    // Use this for initialization
    void Start ()
    {
        areaSampahX = objekRange.rect.max.x;
        areaSampahZ = objekRange.rect.max.y;
    }
	
	// Update is called once per frame
	void Update ()
    {
        int num = Random.Range(0, objekSampah.Length);      // Random objek sampah

        float i = delayMuncul * Time.deltaTime;

        if(i > delayMuncul)
        {
            Instantiate(objekSampah[num], new Vector3(Random.Range(-areaSampahX, areaSampahX), 3f, Random.Range(-areaSampahZ, areaSampahZ)), Quaternion.identity);
        }

        Destroy(objekSampah[num], 13f * Time.deltaTime);

        Debug.Log("x = " + Random.Range(4f, areaSampahX) + "/nz = " + Random.Range(4f, areaSampahZ));
    }
}
