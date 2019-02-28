using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM_LevelSelector : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject[] Icons;

    void Start()
    {
        StartCoroutine(PopUpIcon());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator PopUpIcon()
    {
        for (int i = 0; i<Icons.Length; i++){
            Icons[i].SetActive(true);
            Icons[i].GetComponent<Animator>().SetTrigger("Start");
            yield return new WaitForSeconds(2);
        }
    }
}
