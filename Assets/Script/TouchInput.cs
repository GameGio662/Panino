using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{

    private bool isDragging = false;
    private Vector3 touchStartPosition;
    private Vector3 objectStartPosition;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    // Memorizza la posizione del tocco all'inizio e la posizione corrente dell'oggetto
                    touchStartPosition = touch.position;
                    objectStartPosition = transform.position;
                    isDragging = true;
                    break;

                case TouchPhase.Moved:
                    if (isDragging)
                    {
                        // Calcola la differenza tra la posizione attuale e quella iniziale del tocco
                        Vector3 deltaPosition = touch.position - touchStartPosition;

                        // Calcola la nuova posizione dell'oggetto
                        Vector3 newPosition = objectStartPosition + new Vector3(deltaPosition.x, 0, 0);

                        // Assegna la nuova posizione all'oggetto
                        transform.position = newPosition;
                    }
                    break;

                case TouchPhase.Ended:
                    isDragging = false;
                    break;
            }
        }
    }




}
