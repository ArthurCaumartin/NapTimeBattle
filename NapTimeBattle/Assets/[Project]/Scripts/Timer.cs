using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private Daroned _d;
    public void Update()
    {
        transform.eulerAngles = new Vector3(0, 0, -Mathf.Lerp(0, 360, _d.GetRatio()));        
    }
}
