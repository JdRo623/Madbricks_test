using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Vector3Handler : MonoBehaviour {
    public GameObject sphere;
    public GameObject point;
    public GameObject superVector;
    public Text resultsText;
    public List<Vector3> vectors;
    private Vector3 superVectorMax;
    private Vector3 superVectorMin;
    private Vector3 superVectorMiddle;
    private float currentXmax;
    private float currentYmax;
    private float currentZmax;
    private float currentXmin;
    private float currentYmin;
    private float currentZmin;
    private float distance;
    // Use this for initialization
    void Start () {
        superVectorMax = Vector3.zero;
        superVectorMin = Vector3.zero;
        currentXmax = vectors[0].x;
        currentYmax = vectors[0].y;
        currentZmax = vectors[0].z;
        currentXmin = vectors[0].x;
        currentYmin = vectors[0].y;
        currentZmin = vectors[0].z;
        InstantiateVectors();
        foreach (Vector3 vector in vectors) {
            CheckPointOfAxis(vector.x,vector.y,vector.z);
        }
        superVectorMax = new Vector3(currentXmax,currentYmax,currentZmax);
        superVectorMin = new Vector3(currentXmin,currentYmin,currentZmin);
        InstantiateSuperVectors();
        Debug.Log("Points "+ superVectorMax + " "+ superVectorMin);
        distance = Vector3.Distance(superVectorMax, superVectorMin);
        Debug.Log("Distance / Diameter " + distance);
        Debug.Log("Radious " + distance/2);
        Middle();
        InstantiateSphere();
        Debug.Log("Middle " + superVectorMiddle);
        resultsText.text = "Radious: " + distance / 2 +" Distance / Diameter: "+ distance;
    }

    void CheckPointOfAxis(float axis1,float axis2, float axis3) {
        if (currentXmax < axis1)
        {
            currentXmax = axis1;
        }
        else if (currentXmin > axis1)
        {
            currentXmin = axis1;
        }
        if (currentYmax < axis2)
        {
            currentYmax = axis2;
        }
        else if (currentYmin > axis2)
        {
            currentYmin = axis2;
        }
        if (currentZmax < axis3)
        {
            currentZmax = axis3;
        }
        else if (currentZmin > axis3)
        {
            currentZmin = axis3;
        }

    }

    void Middle() {
        superVectorMiddle = new Vector3(
            ((superVectorMin.x + superVectorMax.x) / 2),
            ((superVectorMin.y + superVectorMax.y) / 2), 
            ((superVectorMin.z + superVectorMax.z) / 2));
    }
    void InstantiateVectors() {
        foreach (Vector3 vector in vectors)
        {
            Instantiate(point, vector, transform.rotation);
        }
    }
    void InstantiateSuperVectors() {
        Instantiate(superVector, superVectorMax, transform.rotation);
        Instantiate(superVector, superVectorMin, transform.rotation);
    }
    void InstantiateSphere() {
        sphere.gameObject.transform.localScale = new Vector3( distance, distance, distance);
        Instantiate(sphere, superVectorMiddle, transform.rotation);
    }
}
