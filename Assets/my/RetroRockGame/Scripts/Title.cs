using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject operation;
    [SerializeField] GameObject operationUI;
    [SerializeField] GameObject rulePanel;
    [SerializeField] GameObject rule1;
    [SerializeField] GameObject rule2;
    // Start is called before the first frame update
    void Start()
    {
        //始まりはメニュー画面表示
        Menu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// スタートボタン
    /// </summary>
    public void StartButton()
    {
        operation.SetActive(true);
        operationUI.SetActive(true);
        menu.SetActive(false);
        //Invoke("呼び出したい関数",何秒後か)でX秒後に関数が呼び出される
        Invoke("SceneChange", 3.5f);
    }

    /// <summary>
    /// ルールボタン
    /// </summary>
    public void RuleButton()
    {
        menu.SetActive(false);
        rulePanel.SetActive(true);
        rule1.SetActive(true);
        rule2.SetActive(false);
    }
    /// <summary>
    /// ルール2表示
    /// </summary>
    public void NextRule()
    {
        menu.SetActive(false);
        rule1.SetActive(false);
        rule2.SetActive(true);
    }
    /// <summary>
    /// メニュー画面表示
    /// </summary>
    public void Menu()
    {
        menu.SetActive(true);
        operation.SetActive(false);
        operationUI.SetActive(false);
        rulePanel.SetActive(false);
        rule1.SetActive(false);
        rule2.SetActive(false);
    }

    void SceneChange()
    {
        operation.SetActive(false);
        operationUI.SetActive(false);
        rulePanel.SetActive(false);
        //シーン移行
        SceneManager.LoadScene("Game_Retro2D");
    }
}
