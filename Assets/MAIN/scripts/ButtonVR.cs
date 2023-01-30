// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.Events;

// public class ButtonVR : MonoBehaviour
// {






    
//     public GameObject button;
//     public UnityEvent onPress;
//     public UnityEvent onRelease;
//     GameObject presser;
//     bool isPressed;
//     void Start()
//     {
//         isPressed = false;
//     }

    // private IHashCodeProvider OnTriggerEnter(Collider other)
    // {
    //     if(!isPressed)
    //     {
    //         button.transform.localPosition = new Vector3(0 , 0.003f, 0);
    //         presser = other.gameObject;
    //         onPress.Invoke();
    //         isPressed = true;
    //     }
    // }

    // private void OnTriggerExit(Collider other)
    // {
    //     if(other.gameObject == presser)
    //     {
    //         button.transform.localPosition = new Vector3(0, 0.015, 0);
    //         onRelease.Invoke();
    //         isPressed = false;
    //     }
    // }

    // public void SpawnSphere()
    // {
    //     GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    //     sphere.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
    //     sphere.transform.localPosition = new Vector3(0, 1, 2);
    //     sphere.AddComponent<Rigidbody>();
    // }

    
// }

using UnityEngine;
using UnityEngine.Events;

public class ButtonVR : MonoBehaviour
{
    [System.Serializable]
    public class ButtonEvent : UnityEvent { }

    public float pressLength;
    public bool pressed;
    public ButtonEvent downEvent;

    Vector3 startPos;
    Rigidbody rb;

    void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // If our distance is greater than what we specified as a press
        // set it to our max distance and register a press if we haven't already
        float distance = Mathf.Abs(transform.position.y - startPos.y);
        if (distance >= pressLength)
        {
            // Prevent the button from going past the pressLength
            transform.position = new Vector3(transform.position.x, startPos.y - pressLength, transform.position.z);
            if (!pressed)
            {
                pressed = true;
                // If we have an event, invoke it
                downEvent?.Invoke();
            }
        } else
        {
            // If we aren't all the way down, reset our press
            pressed = false;
        }
        // Prevent button from springing back up past its original position
        if (transform.position.y > startPos.y)
        {
            transform.position = new Vector3(transform.position.x, startPos.y, transform.position.z);
        }
    }
}
