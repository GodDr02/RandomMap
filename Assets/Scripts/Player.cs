using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    Vector3 vel = Vector3.zero;
    Vector3 target;
    Vector3 dir;
    Quaternion lookTarget;

    public float smoothTime = 0.5f;

    float range = 100f;
    bool pickUpActivated = false;
    RaycastHit hitInfo;
    public LayerMask layerMask;

    public GameObject currentItem;
    public Material[] colors;

    void PickUpItem()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hitInfo, range, layerMask))
        {
            pickUpActivated = true;
            currentItem = hitInfo.transform.gameObject;

            // Destroy(hitInfo.transform.gameObject);
        }
        else
        {
            if (currentItem != null)
            {
                currentItem = null;
            }
            pickUpActivated = false;
        }
    }

    void SetTarget()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Debug.DrawRay(Input.mousePosition, Vector3.forward, Color.green);

            if (Physics.Raycast(ray, out hit, 100f))
            {
                target = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                dir = target - transform.position;
                lookTarget = Quaternion.LookRotation(dir);
            }
        }
    }

    void UseItem()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Using Item");
            currentItem.GetComponent<MeshRenderer>().material = colors[Random.Range(0, colors.Length)];
        }
    }

    private void Move()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target, ref vel, smoothTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookTarget, 0.5f);
    }

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PickUpItem();
        UseItem();

        SetTarget();
        if (target != null)
        {
            Move();
        }
    }
}
