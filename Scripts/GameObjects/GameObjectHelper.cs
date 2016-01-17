﻿//----------------------------------------------
// Flip Web Apps: Game Framework
// Copyright © 2016 Flip Web Apps / Mark Hewitt
//----------------------------------------------

using System;
using System.Linq;
using UnityEngine;

namespace FlipWebApps.GameFramework.Scripts.GameObjects
{
    /// <summary>
    /// Helper functions for quickly and simply finding and manipulating game objects
    /// </summary>
    internal class GameObjectHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TComponent"></typeparam>
        /// <param name="thisGameObject"></param>
        /// <param name="name"></param>
        /// <param name="includeInactive"></param>
        /// <returns></returns>
        public static TComponent GetChildComponentOnNamedGameObject<TComponent>(GameObject thisGameObject, String name, bool includeInactive = false) where TComponent : Component
        {
            TComponent[] components = thisGameObject.GetComponentsInChildren<TComponent>(includeInactive);
            return components.FirstOrDefault(component => component.gameObject.name == name);
        }

        /// <summary>
        /// Note uses transform
        /// </summary>
        /// <param name="thisGameObject"></param>
        /// <param name="name"></param>
        /// <param name="includeInactive"></param>
        /// <returns></returns>
        public static GameObject GetChildNamedGameObject(GameObject thisGameObject, string name, bool includeInactive = false)
        {
            Transform[] components = thisGameObject.GetComponentsInChildren<Transform>(includeInactive);
            return (from component in components where component.gameObject.name == name select component.gameObject).FirstOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameObject"></param>
        public static void DisableGameObjectForRemoval(GameObject gameObject)
        {
            if (gameObject.GetComponent<Collider2D>() != null)
                gameObject.GetComponent<Collider2D>().enabled = false;
            if (gameObject.GetComponent<Rigidbody2D>() != null)
                gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            gameObject.transform.position = new Vector3(0, -20); // place out of view
        }


        public static void SetLayerRecursive(GameObject gameObject, string layerName)
        {
            SetLayerRecursive(gameObject, LayerMask.NameToLayer(layerName));
        }

        public static void SetLayerRecursive(GameObject gameObject, int layer)
        {
            gameObject.layer = layer;
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                SetLayerRecursive(gameObject.transform.GetChild(i).gameObject, layer);
            }
        }

        public static void DestroyChildren(Transform root)
        {
            int childCount = root.childCount;
            for (int i = 0; i < childCount; i++)
            {
                UnityEngine.Object.Destroy(root.GetChild(i).gameObject);
            }
        }

        public static void SafeSetActive(GameObject gameObject, bool value)
        {
            if (gameObject != null)
                gameObject.SetActive(value);
        }
    }

}