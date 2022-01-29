using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class panelManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject sphereObj;
    public GameObject obstacle;
    Image firstC; Image secondC; Image thirdC; Image fourthC; Image fifthC;
    public Sprite aBut; public Sprite bBut;
    public Sprite xBut; public Sprite yBut;
    public Image mashButton;

    private void spawnSphere()
    {
        GameObject a = Instantiate(sphereObj,
        new Vector3(0,5,-10), Quaternion.Euler(0,90,0))
        as GameObject;
    }

    private Sprite whichBut()
    { 
        return aBut;
    }
    void Start()
    {
        firstC = this.transform.Find("case").GetComponent<Image>();
        secondC = this.transform.Find("case (1)").GetComponent<Image>();
        thirdC = this.transform.Find("case (2)").GetComponent<Image>();
        fourthC = this.transform.Find("case (3)").GetComponent<Image>();
        fifthC = this.transform.Find("case (4)").GetComponent<Image>();
        mashButton = this.transform.Find("mashing").GetComponent<Image>();
        mashButton.enabled = false;
        spawnSphere();
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameObject.Find("Sphere")){spawnSphere();}
        float sPos = sphereObj.transform.position.z;
        if(sPos > -37 && sPos < -35){fifthC.sprite = aBut;}else{fifthC.sprite = null;}
        if(sPos > -35 && sPos < -33){fourthC.sprite = aBut;}else{fourthC.sprite = null;}
        if(sPos > -33 && sPos < -31){thirdC.sprite = aBut;}else{thirdC.sprite = null;}
        if(sPos > -31 && sPos < -29){secondC.sprite = aBut;}else{secondC.sprite = null;}
        if(sPos > -27 && sPos < -25){firstC.sprite = aBut;}else{firstC.sprite = null;}    
    }
}
