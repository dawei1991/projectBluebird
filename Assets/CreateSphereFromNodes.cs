﻿
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateSphereFromNodes : MonoBehaviour
{
    void Start()
    {
        int numPoints = 360;
        //Vector3 centerPoint;
        Vector3[] pts = PointsOnSphere(numPoints);
        float scaling = numPoints/12;
        List<GameObject> uspheres = new List<GameObject>();
        int i = 0;

        foreach (Vector3 value in pts)
        {
            uspheres.Add(GameObject.CreatePrimitive(PrimitiveType.Sphere));
            uspheres[i].transform.parent = transform;
            uspheres[i].transform.position = value * scaling;
            i++;
        }
    }

    Vector3[] PointsOnSphere(int n)
    {
        List<Vector3> upts = new List<Vector3>();
        float inc = Mathf.PI * (3 - Mathf.Sqrt(5));
        float off = 2.0f / n;
        float x = 0;
        float y = 0;
        float z = 0;
        float r = 0;
        float phi = 0;

        for (var k = 0; k < n; k++)
        {
            y = k * off - 1 + (off / 2);
            r = Mathf.Sqrt(1 - y * y);
            phi = k * inc;
            x = Mathf.Cos(phi) * r + (float)1;
            z = Mathf.Sin(phi) * r;

            upts.Add(new Vector3(x, y, z));
        }
        Vector3[] pts = upts.ToArray();
        return pts;
    }
}

//using UnityEngine;


////The valid range of latitude in degrees is -90 and +90 for the southern and northern hemisphere respectively.
////Longitude is in the range -180 and +180 specifying coordinates west and east of the Prime Meridian, respectively.

////For reference, the Equator has a latitude of 0°, the North pole has a latitude of 90° north (written 90° N or +90°), 
////and the South pole has a latitude of -90°.

////The Prime Meridian has a longitude of 0° that goes through Greenwich, England. The International Date Line(IDL) roughly 
////follows the 180° longitude.A longitude with a positive value falls in the eastern hemisphere and negative value falls in the western hemisphere.

//public class CreateSphereFromNodes : MonoBehaviour
//{

//    public float radius = 22; // globe ball radius (unity units)


//    // Use this for initialization
//    /// <summary>
//    ///The valid range of latitude in degrees is -90 and +90 for the southern and northern hemisphere respectively.
//    ///Longitude is in the range -180 and +180 specifying coordinates west and east of the Prime Meridian, respectively.
//    /// </summary>
//    void Start()
//    {
//        float latitude = -90; // lat
//        float longitude = -180; // long

//        for (int i = 0; i < 360; i++) {

//            float newLat = Mathf.Deg2Rad * latitude;
//            float newLong = Mathf.Deg2Rad* longitude;

//            Debug.Log(newLat + " " + newLong);
//            // and switch z and y (since z is forward)
//            //float xPos = (radius) * Mathf.Sin(latitude) * Mathf.Cos(longitude);
//            //float zPos = (radius) * Mathf.Sin(latitude) * Mathf.Sin(longitude);
//            //float yPos = (radius) * Mathf.Cos(latitude);

//            float xPos = radius * Mathf.Cos(newLat) * Mathf.Sin(newLat);
//            float yPos = radius * Mathf.Sin(newLat) * Mathf.Sin(newLong);
//            float zPos = radius * Mathf.Cos(newLong);

//            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
//            //sphere.transform.localScale = new Vector3()0.1, (float)0.1, (float)0.1);
//            sphere.transform.position = new Vector3(xPos, yPos, zPos);
//            latitude+=0.25f;
//            longitude+=0.5f;

//        }



//        // adjust position by radians	
//        //latitude -= 1.570795765134f; // subtract 90 degrees (in radians)




//        // move marker to position
//        //marker.position = new Vector3(xPos, yPos, zPos);
//    }
//}