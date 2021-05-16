using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    public float leftBorder;
    public float rightBorder;
    public float topBorder;
    public float bottomBorder;

    void Start()
    {
        float dist = Vector3.Distance(transform.position, Camera.main.transform.position);
        leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
        rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
        topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, dist)).y;
        bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        transform.position = new Vector3(Mathf.Clamp(pos.x, leftBorder, rightBorder), Mathf.Clamp(pos.y, bottomBorder, topBorder), pos.z);
    }
}
//private void ChangeAnim(Vector2 direction)
//{
//    //if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
//    //{
//    //    if(direction.x > 0)
//    //    {
//    //        SetAnimFloat(Vector2.right);
//    //    }
//    //    else if (direction.x < 0)
//    //    {
//    //        SetAnimFloat(Vector2.left);
//    //    }
//    //}
//    //else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
//    //{
//    //    if(direction.y > 0)
//    //    {
//    //        SetAnimFloat(Vector2.right);
//    //    }
//    //    else if (direction.y < 0)
//    //    {
//    //        SetAnimFloat(Vector2.left);
//    //    }
//    //}
//}