using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDragScript : MonoBehaviour
{
    [SerializeField] float timer;
    [SerializeField] float fireRate = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDrag()
    {
        timer += Time.deltaTime;
        if (timer > fireRate)
        {
            if (Input.GetButton("Fire1"))
            {
                timer = 0f;
                RaycastMethod();
            }


        }
        print("Mouse Dragging");
        
    }
    public void RaycastMethod()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Ray ray = new Ray(this.transform.position, this.transform.forward);

        print(ray.direction);
        ray.direction = new Vector3(-ray.direction.x, -ray.direction.y, ray.direction.z);
        Debug.DrawRay(ray.origin, ray.direction * 30f, Color.blue, 2f);
        //RaycastHit hit;
        if (Physics.Raycast(ray, out RaycastHit hit, 100f))
        {
            Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.green, 2f);
            print(hit.collider.gameObject.name);
            GameObject currentHit = hit.collider.gameObject;
            if (currentHit.GetComponent<Collider>())
            {
                currentHit.GetComponent<Renderer>().material.color = Color.red;
            }
            StartCoroutine(ResetCubeColor(currentHit));
        }
        else
        {
            Debug.DrawRay(ray.origin, ray.direction * 30f, Color.red, 2f);
        }
    }
    IEnumerator ResetCubeColor(GameObject CurrectCube)
    {
        yield return new WaitForSeconds(2);
        CurrectCube.GetComponent<Renderer>().material.color = Color.white;
    }
}
