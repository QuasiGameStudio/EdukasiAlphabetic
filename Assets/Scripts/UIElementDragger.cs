using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/* Copyright (C) Xenfinity LLC - All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Bilal Itani <bilalitani1@gmail.com>, June 2017
 */

public class UIElementDragger : MonoBehaviour {

    public const string DRAGGABLE_TAG = "UIDraggable";

    private bool dragging = false;

    private Vector2 originalPosition;
    private Transform objectToDrag; 
    private Image objectToDragImage;

    [SerializeField]
    private GameObject gameManager;

    List<RaycastResult> hitObjects = new List<RaycastResult>();
    
    #region Monobehaviour API

    void Update ()
    {
		if (Input.GetMouseButtonDown(0))
        {
            objectToDrag = GetDraggableTransformUnderMouse();

            if (objectToDrag != null)
            {
                Debug.Log("is true: "+objectToDrag.GetComponent<Tile_>().GetIsTarget());
                if (!objectToDrag.GetComponent<Tile_>().GetIsTarget()){
                    dragging = true;

                    objectToDrag.SetAsLastSibling();

                    originalPosition = objectToDrag.position;
                    objectToDragImage = objectToDrag.GetComponent<Image>();
                    objectToDragImage.raycastTarget = false;
                }else
                {
                    objectToDrag=null;
                }            
            }
        }

        if (dragging)
        {
            objectToDrag.position = Input.mousePosition;
        }
    
        if (Input.GetMouseButtonUp(0))
        {
            
            // Transform tempObjectToDrag; 

            if (objectToDrag != null)
            {
                var objectToReplace = GetDraggableTransformUnderMouse();

                if (objectToReplace != null)
                {
                    // gameManager.GetComponent<GM_TebakBentuk>().GiveAnswer(objectToDrag.GetComponent<Tile_>().GetNumber());
                    Debug.Log(objectToDrag.GetComponent<Tile_>().GetNumber()+" "+objectToReplace.GetComponent<Tile_>().GetNumber());
                    if(objectToReplace.GetComponent<Tile_>().GetIsTarget() && objectToDrag.GetComponent<Tile_>().GetNumber() == objectToReplace.GetComponent<Tile_>().GetNumber()){
                        // objectToDrag.position = objectToReplace.position;
                        // objectToReplace.position = originalPosition;
                        gameManager.GetComponent<GM_TebakBentuk>().CheckAnswer();
                    }
                }
                objectToDrag.position = originalPosition;
                // tempObjectToDrag = objectToDrag;

                objectToDragImage.raycastTarget = true;
                objectToDrag = null;

                
            }

            dragging = false;
           
        }
	}

    private GameObject GetObjectUnderMouse()
    {
        var pointer = new PointerEventData(EventSystem.current);

        pointer.position = Input.mousePosition;

        EventSystem.current.RaycastAll(pointer, hitObjects);

        if (hitObjects.Count <= 0) return null;

        return hitObjects.First().gameObject;        
    }

    private Transform GetDraggableTransformUnderMouse()
    {
        var clickedObject = GetObjectUnderMouse();

        // get top level object hit
        if (clickedObject != null && clickedObject.tag == DRAGGABLE_TAG)
        {
            return clickedObject.transform;
        }

        return null;
    }

    #endregion
}
