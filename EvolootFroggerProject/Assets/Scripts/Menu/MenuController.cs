using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class MenuController : MonoBehaviour
{
    [SerializeField] Transform centerPos, exitPos;
    [SerializeField] GameObject mainMenu, options, controls, credits;
    public float tweenSpeed;

    public void TweenToCenterMenu()
    {
        mainMenu.SetActive(true);
        mainMenu.transform.DOMove(centerPos.transform.position, tweenSpeed, false);
    }

    public void TweenToCenterOptions()
    {
        options.SetActive(true);
        options.transform.DOMove(centerPos.transform.position, tweenSpeed, false);
    }

    public void TweenToCenterControls()
    {
        controls.SetActive(true);
        controls.transform.DOMove(centerPos.transform.position, tweenSpeed, false);
    }

    public void TweenToCenterCredits()
    {
        credits.SetActive(true);
        credits.transform.DOMove(centerPos.transform.position, tweenSpeed, false);
    }

    public void TweenExitMenu()
    {
        mainMenu.SetActive(false);
        mainMenu.transform.DOMove(exitPos.transform.position, tweenSpeed, false);
    }

    public void TweenExitOptions()
    {
        options.SetActive(false);
        options.transform.DOMove(exitPos.transform.position, tweenSpeed, false);
    }

    public void TweenExitControls()
    {
        controls.SetActive(false);
        controls.transform.DOMove(exitPos.transform.position, tweenSpeed, false);
    }

    public void TweenExitCredits()
    {
        credits.SetActive(false);
        credits.transform.DOMove(exitPos.transform.position, tweenSpeed, false);
    }

    public void LoadScene(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
