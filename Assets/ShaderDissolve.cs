using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ShaderDissolve : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("hi1t");
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                print(hit.collider.gameObject.tag);
                if (hit.collider.gameObject.tag == "Player")
                {
                    Material targetMaterial = hit.collider.gameObject.GetComponent<Renderer>().material;

                    StartCoroutine(ChangeDissolve(targetMaterial, 0.5f, -1.5f, 1.0f));
                }
            }
        }
    }

    private IEnumerator ChangeDissolve(Material material, float startValue, float endValue, float duration)
    {
        float time = 0;
        while (time < duration)
        {
            material.SetFloat("_DissolveValue", Mathf.Lerp(startValue, endValue, time / duration));
            print(material.GetFloat("_DissolveValue"));
            time += Time.deltaTime;
            yield return null;
        }
        material.SetFloat("DissolveValue", endValue);
    }
}
