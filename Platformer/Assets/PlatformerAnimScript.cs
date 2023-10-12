using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerAnimScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = GetComponent<Rigidbody2D>().velocity.y;
        GetComponent<Animator>().SetFloat("x", x);
        GetComponent<Animator>().SetFloat("y", y);
        if(x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }else if (x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
