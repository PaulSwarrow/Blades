using System;
using System.Collections;
using System.Collections.Generic;
using Game;
using Lib.UnityQuickTools.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private BaseGameController[] controllers;

    private GenericMap<BaseGameController> map;
    // Start is called before the first frame update


    private void Awake()
    {
        controllers = GetComponents<BaseGameController>();
        map = new GenericMap<BaseGameController>(controllers);
        controllers.Foreach(controller => controller.Init(this));
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        controllers.Foreach(controller => controller.Tick(Time.deltaTime));
    }

    public T Controller<T>() where T: BaseGameController
    {
        return map.Get<T>();
    }
}