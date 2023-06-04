using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField] Transform direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        float sin = Mathf.Sin(Mathf.PI * direction.localEulerAngles.z/180f);
        float cos = Mathf.Cos(Mathf.PI * direction.localEulerAngles.z/180f);
        
        var lookDirection = new Vector2(sin, cos*-1);
        //Debug.Log(Vector3.forward);
        //transform.Translate(lookDirection * 1.2f * Time.deltaTime);
    }
}
