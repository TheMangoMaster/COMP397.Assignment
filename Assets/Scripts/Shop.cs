using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTower;
    public TurretBlueprint cornTower;
    public TurretBlueprint mushroomTower;
    public TurretBlueprint pineconeTower;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectStandardTurret()
    {
        Debug.Log("Standard Turret Bought");
        buildManager.SelectTurretToBuild(standardTower);
    }

    public void SelectCornTurret()
    {
        Debug.Log("CornTurret Bought");
        buildManager.SelectTurretToBuild(cornTower);

    }

    public void SelectMushroomTurret()
    {
        Debug.Log("Mushroom Turret Bought");
        buildManager.SelectTurretToBuild(mushroomTower);

    }

    public void SelectPineconeTurret()
    {
        Debug.Log("Pinecone Turret Bought");
        buildManager.SelectTurretToBuild(pineconeTower);

    }
}
