using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySettings : MonoBehaviour
{
    public float moveSpeed = 5;
    public float runSpeed = 10;


    public static EntitySettings entity { get; private set; }

    private void Awake()
    {
        if(entity != null)
        {
            Destroy(gameObject);
        }
        else
        {
            entity = this;
        }
    }
}
