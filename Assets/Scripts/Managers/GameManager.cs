using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Managers
    [SerializeField ]private static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    private UIManager uiM = new UIManager();
    public static UIManager UIM { get { return Instance.uiM; } }
    private SceneLoadManager sceneLM = new SceneLoadManager();
    public static SceneLoadManager SceneLM { get { return instance.sceneLM; } }
    private static GridManager gridM = new GridManager();
    public static GridManager GridM { get { return gridM; } }
    private SystemManager systemM = new SystemManager();
    public static SystemManager SystemM { get { return instance.systemM; } }
    #endregion

    private void Awake()
    {
        if (instance == null)
            instance = this;
        if (instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
}
