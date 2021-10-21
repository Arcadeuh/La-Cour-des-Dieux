using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OPHand : MonoBehaviour
{
    [SerializeField] private TMP_Text planetName;
    [SerializeField] private TMP_Text activeEffect;
    [SerializeField] private TMP_Text passiveEffect;
    [SerializeField] private Canvas planetCanvas;

    public Planet planet;

    // Start is called before the first frame update
    void Start()
    {
        planetName.SetText(planet.title);
        activeEffect.SetText(planet.active.title);
        passiveEffect.SetText(planet.passive.title);
        GameObject planetGameobject = GameObject.Instantiate(planet.appearance, planetCanvas.transform);
        planetGameobject.transform.localScale = new Vector3(40, 40, 40);
        /*
        RectTransform planetRectTransform =  planetGameobject.AddComponent<RectTransform>();
        planetRectTransform.pos
        */
    }
}
