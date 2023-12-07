using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EndScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI EndText;
    public GameObject end;

    // Start is called before the first frame update
    void Start()
    {
        end.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
