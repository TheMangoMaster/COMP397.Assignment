using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance; //singleton

    private void Awake()
    {
        if (instance != null) 
        {
            Debug.LogError("More than one BuildManager in scene!");
               return;
        }
        instance = this; //BuildManager references itself for ease of access
    }

    public GameObject standardTurretPrefab;
    public GameObject cornTurretPrefab;
    public GameObject pineconeTurretPrefab;
    public GameObject mushroomTurretPrefab;

    private TurretBlueprint turretToBuild;
    
    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return GameManager.Money >= turretToBuild.cost; } }
    public void BuildTurretOn(Node node)
    {
        if (GameManager.Money < turretToBuild.cost) //check to see if we have enough money
        {
            Debug.Log("Bish, you broke! Get a job");
            return;
        }

        GameManager.Money -= turretToBuild.cost; //substracts the cost

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret= turret;

        Debug.Log("Tower built! Money remaining: " + GameManager.Money);
    }
    public void SelectTurretToBuild(TurretBlueprint turret) 
    {
        turretToBuild= turret;
    }
}
