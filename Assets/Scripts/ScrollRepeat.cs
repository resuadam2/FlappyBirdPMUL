using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollRepeat : MonoBehaviour
{
    private float width;
    private BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        width = boxCollider.size.x * transform.localScale.x; // Get the width of the background image and multiply it by the scale of the background image to get the actual width
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -width)
        {
            Reposition();
        }
    }

    // Reposition the background to the right
    private void Reposition()
    {
       transform.Translate(Vector2.right * width * 2);
    }
}
