using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HapusObjek : MonoBehaviour
{
    public AmbilSampah sampahDihapus;
    public Text skorTeks;

    void Start()
    {
        
    }

    void OnTriggerEnter(Collider hapus)
    {
        if(hapus.tag == "Sampah")
        {
            Destroy(hapus);
            int skorMaks = Convert.ToInt32(sampahDihapus.tempSkor[1]);
            skorMaks--;

            sampahDihapus.tempSkor[1] = skorMaks.ToString();

            skorTeks.text = sampahDihapus.tempSkor[0] + " / " + sampahDihapus.tempSkor[1];
        }
    }
}
