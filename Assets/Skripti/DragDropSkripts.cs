using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Jāimportē, lai varētu strādāt ar EventSystems
using UnityEngine.EventSystems;

public class DragDropSkripts : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //Uzglabās norādi uz Objektu skriptu
    public Objekti objektuSkripts;
    //Velkamajam objektam piestiprinātā komponente
    private CanvasGroup kanvasGrupa;
    //Vilktā objekta atrašanās vietas koordinātu maiņai
    private RectTransform velkObjRectTransf;

    void Awake()
    {
        //Piekļūst objektam piesaistītajai CanvasGroup komponentei
        kanvasGrupa = GetComponent<CanvasGroup>();
        //Piekļūst objekta RectTransform komponentei
        velkObjRectTransf = GetComponent<RectTransform>();
    }    

    //Nostrādā nospiežot peles klikšķi uz objekta
    public void OnPointerDown(PointerEventData notikums)
    {
        Debug.Log("Uzklikšķināts uz velkamā objekta");
    }

    //Nostrādā uzsākot vilkšanu
    public void OnBeginDrag(PointerEventData notikums)
    {
        Debug.Log("Uzsākta vilkšana!");
        //Attīra pēdējo vilkto objektu
        objektuSkripts.pedejaisVilktais = null;
        //Uzsākot vilkt objektu tas paliek nedaudz caurspīdīgs
        kanvasGrupa.alpha = 0.6f;
        //Lai objektam varētu iet cauri raycasst stars
        kanvasGrupa.blocksRaycasts = false;

    }

    //Nostrādā reāli notiekot vilkšanai
    public void OnDrag(PointerEventData notikums)
    {
        Debug.Log("Notiek vilkšana!");
        velkObjRectTransf.anchoredPosition += notikums.delta / objektuSkripts.kanva.scaleFactor;
    }
        
    //Nostrādā kad tiek beigta vilkšana
    public void OnEndDrag(PointerEventData notikums)
    {
        //Atlaižot objektu iestata to kā pēdējo vilkto
        objektuSkripts.pedejaisVilktais = notikums.pointerDrag;
        Debug.Log("pēdējais vilktais objekts: " + objektuSkripts.pedejaisVilktais);
        Debug.Log("Beigta vilkšana");
        //Atlaižot objektu tas atkal paliek necaurspīdīgs
        kanvasGrupa.alpha = 1.0f;

        //Pārbauda vai objekts ir vienkārši nomests vai nomests pareizajā vietā
        if (objektuSkripts.vaiIstajaVieta == false)
        {
            //ja nav nomests pareizajā vietā, tad padara atkal velkamu
            kanvasGrupa.blocksRaycasts = true; 
        }
        else
        {
            //Ja objekts nolikts pareizajā vietā, izmērā, rotācijā, tad pēdējo vilkto attīra
            objektuSkripts.pedejaisVilktais = null;
        }
        //Ja viens objekts nomests pareizajā vietā, tad lai varētu turpināt pārvietot pārējos objektus
        objektuSkripts.vaiIstajaVieta = false; 
    }

}

