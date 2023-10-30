using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthUI : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Camera camera;
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;


    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
    }


    // Update is called once per frame
    void Update()
    {
        transform.rotation = camera.transform.rotation;
        target.position = target.position+offset;
    }

    //Scrip creado con la ayuda de BMo en yt:]
}
