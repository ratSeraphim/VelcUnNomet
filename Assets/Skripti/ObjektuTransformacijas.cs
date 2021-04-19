using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjektuTransformacijas : MonoBehaviour
{
    //Uzglabā norādi uz Objektu skriptu
    public Objekti objektuSkripts;

    // Update is called once per frame
    void Update()
    {
        //Ja ir kāds pēdējais vilktais objekts, tad var ar to veikt darbības
        if(objektuSkripts.pedejaisVilktais != null)
        {
            //Nospiežot 'Z' objekts rotējas pretēji pulksteņrādītāja virzienā
            if (Input.GetKey(KeyCode.Z))
            {
                objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().transform.Rotate(0, 0, Time.deltaTime * 9f);
            }
            //Nospiežot 'X' objekts rotējas pulksteņrādītāja virzienā
            if (Input.GetKey(KeyCode.X))
            {
                objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().transform.Rotate(0, 0, -Time.deltaTime * 9f);
            }

            //Nospiežot bultiņu pa kreisi iespējams objektu stiept šaurāku pa x asi
            if(Input.GetKey(KeyCode.LeftArrow))
            {
                //Lai objektu nevar izstiept mīnusā
                if (objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().transform.localScale.x > 0.35)
                {
                    objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().localScale =
                        new Vector2(objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().transform.localScale.x - 0.001f,
                        objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().transform.localScale.y);
                }

                
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                //Lai objektu nevar izstiept pārāk plašu
                if (objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().transform.localScale.x < 0.9)
                {
                    objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().localScale =
                      new Vector2(objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().transform.localScale.x + 0.001f,
                      objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().transform.localScale.y);
                }
            }

            //Y ASS
            //Nospiežot bultiņu uz augšu iespējams objektu stiept mazāku pa y asi
            if (Input.GetKey(KeyCode.DownArrow))
            {
                //Lai objektu nevar izstiept mīnusā
                if (objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().transform.localScale.y > 0.35)
                {
                    objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().localScale =
                        new Vector2(objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().transform.localScale.x,
                        objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().transform.localScale.y - 0.001f);
                }


            }
            //Nospiežot bultiņu uz augšu iespējams objektu stiept lielāku pa y asi
            if (Input.GetKey(KeyCode.UpArrow))
            {
                //Lai objektu nevar izstiept pārāk plašu
                if (objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().transform.localScale.y < 0.8)
                {
                    objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().localScale =
                      new Vector2(objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().transform.localScale.x,
                      objektuSkripts.pedejaisVilktais.GetComponent<RectTransform>().transform.localScale.y + 0.001f);
                }
            }
        }
    }
}
