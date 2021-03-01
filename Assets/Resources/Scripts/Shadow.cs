using System.Collections;using System.Collections.Generic;using UnityEngine;public class Shadow : MonoBehaviour{    private float yO = -3.56f;
    // Update is called once per frame
        void Update()    {        transform.rotation = Quaternion.identity;        Vector3 pos;
        if (GetComponentInParent<RollingStone>() == true)
        {
            pos = GetComponentInParent<RollingStone>().gameObject.transform.position;
            pos.y = yO;
            transform.position = pos;
        }
        else
        {
            pos = transform.position;
            pos.y = yO;
            transform.position = pos;        }
        //    if(gameObject.GetComponentInParent<RollingStone>() == true)
        //    {
        //        Debug.Log($"trans.pos = {transform.position} and ParentPos = {GetComponentInParent<RollingStone>().gameObject.transform.position} and pos = {pos}");
        //    }
    }}