using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LoadingBar : MonoBehaviour
{
    public Transform loadingBarValue;
    public GameObject circleLoadingBar;
    public GameObject player;
    public bool exists;
    [SerializeField] public float currentAmount;
    [SerializeField] public float speed;

    void Start()
    {
        currentAmount = 100;
    }
    void Update()
    {
        if (currentAmount > 0)
        {
            currentAmount -= speed * Time.deltaTime;
        } else
        {
            Destroy(transform.parent.gameObject);
        }

        loadingBarValue.GetComponent<Image>().fillAmount = currentAmount / 100;
        
        //gameObject.transform.position = Camera.main.WorldToScreenPoint(player.transform.position);

        
    }
}
