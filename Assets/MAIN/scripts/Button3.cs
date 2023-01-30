using UnityEngine;
using UnityEngine.Events;

public class Button3 : MonoBehaviour
{
    [System.Serializable]
    public class ButtonEvent : UnityEvent { }
    public GameObject rotatedObject;
    [SerializeField] private Vector3 _rotation;
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
                //  rotatedObject.transform.Rotate(_rotation * Time.deltaTime);
            }
            else
            {
                pressed = false;
            }
        }
        else
        {
            // If we aren't all the way down, reset our press
            if (pressed)
            {
                rotatedObject.transform.Rotate(_rotation * Time.deltaTime);

            }
        }
        // Prevent button from springing back up past its original position
        if (transform.position.y > startPos.y)
        {
            transform.position = new Vector3(transform.position.x, startPos.y, transform.position.z);
        }
    }
}