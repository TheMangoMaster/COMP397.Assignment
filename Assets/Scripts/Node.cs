using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [Header("Optional")]
    public GameObject turret;

    private Renderer rend; //render variable
    private Color startColor; //color at the start of the game

    BuildManager buildManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();//cached the renderer
        startColor = rend.material.color; //setting variable to whatever we chose at the start

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    { 
        return transform.position + positionOffset;
    }

    void OnMouseDown()//callback function on click while hovering
    {
        if (EventSystem.current.IsPointerOverGameObject())
        { return; } //ensures you can't click through the UI

        if (!buildManager.CanBuild)
            return;

        if (turret != null) 
        {
            Debug.Log("Something's here - TODO display on screen");
            return;
        }

        buildManager.BuildTurretOn(this);
    }

    private void OnMouseEnter()//called when the mouse enters the collider of the object
    {
        if (EventSystem.current.IsPointerOverGameObject()) 
        { return; }//ensures you can't click through the UI

        if (!buildManager.CanBuild)
            return;

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        } 
    }

    private void OnMouseExit()//called when mouse leaves the collider
    {
        rend.material.color = startColor; //resets to initial color
    }
}
