using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierController : MonoBehaviour
{
    [SerializeField] float xPos;
    //[SerializeField] float zPos;
    [SerializeField] float objectType;

    [SerializeField] GameObject bigObject;
    [SerializeField] GameObject smallObject;
 
    [SerializeField] GameObject[] spawPoints;




    private void Start()
    {
        for (int i = 0; i < spawPoints.Length; i++)
        {
            objectType = Random.Range(0, 2);
            xPos = Random.Range(-1f, 1);
            Vector3 spawnPosBig = new Vector3(spawPoints[i].transform.position.x+2.5f, spawPoints[i].transform.position.y-0.25f, spawPoints[i].transform.position.z);
            Vector3 spawnPosSmall = new Vector3(spawPoints[i].transform.position.x +xPos, spawPoints[i].transform.position.y - 0.25f, spawPoints[i].transform.position.z);
            Quaternion spawnRotBig = spawPoints[i].transform.rotation;
            Quaternion spawnRotDiff = Quaternion.Euler(0f, 90f, 0f);
            Quaternion spawnRotSmall =spawnRotBig*spawnRotDiff;

            print(objectType);

            if (objectType == 0) //büyük obje
            {
                GameObject newBigObject=Instantiate(bigObject, spawnPosBig, spawnRotBig);
            }

            else // küçük obje
            {
                GameObject newSmallObject = Instantiate(smallObject, spawnPosSmall, spawnRotSmall);
            }
        }
        
           



        



    }
}

    


