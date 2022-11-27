using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;



public class ReticlePlacement : MonoBehaviour
{
    private const string raycastLayer = "ARMeshLidAR";
    // public ARRaycastManager RaycastManager;
    //  public PlacedObject placedObject = new PlacedObject();
    [SerializeField] GameObject carPrefab;
    public Vector3 offset = Vector3.zero;
    public UnityEvent OnObjectPlaced = new UnityEvent();
    private Camera arCamera = null;
    private GameObject customReticle;

    private void Awake()
    {
        arCamera = Camera.main;
        customReticle = Instantiate(Resources.Load<GameObject>("Reticle"));
        customReticle.transform.parent = transform;
        customReticle.SetActive(false);

    }
    private void Update()
    {
        if (carPrefab != null) return;
        var ray = arCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        var hasHit = Physics.Raycast(ray, out var hit, float.PositiveInfinity, LayerMask.GetMask(raycastLayer));
        if(hasHit)
        {
            customReticle.SetActive(true);
            customReticle.transform.position = hit.point + offset;
            customReticle.transform.up = hit.normal;

            PlacedObject(hit.point);
        }
    }

    private void PlacedObject(Vector3 location)
    {
        var activeTouches = UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches;

        if(activeTouches.Count > 0)
        {
            var touch = activeTouches[0];
            bool isOverUI = touch.screenPosition.IsPointOverUIObject();
            if (isOverUI) return;
            if(touch.phase == UnityEngine.InputSystem.TouchPhase.Began)
            {
                if(carPrefab == null )
                {
                    Instantiate(carPrefab, location, Quaternion.identity);
                  //  placedObject.Placement.transform.parent = transform;
                    //var targetCollisionState = placedObject.Placement.AddComponent<TargetColls>
                }
            }

        }

    }
}
