﻿//----------------------------------------------
// Flip Web Apps: Game Framework
// Copyright © 2016 Flip Web Apps / Mark Hewitt
//----------------------------------------------

using System;
using FlipWebApps.GameFramework.Scripts.GameObjects;
using FlipWebApps.GameFramework.Scripts.Localisation;
using UnityEngine;
using UnityEngine.Assertions;

namespace FlipWebApps.GameFramework.Scripts.UI.Other
{
    /// <summary>
    /// UI Helper functions
    /// </summary>
    internal class UIHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="thisGameObject"></param>
        /// <param name="childObjectName"></param>
        /// <param name="text"></param>
        /// <param name="includeInactive"></param>
        /// <returns>bool indicating whether the text is set or not (vhild gameobject not found)</returns>
        public static bool SetTextOnChildGameObject(GameObject thisGameObject, string childObjectName, string text, bool includeInactive = false)
        {
            var uiText = GameObjectHelper.GetChildComponentOnNamedGameObject<UnityEngine.UI.Text>(thisGameObject, childObjectName, includeInactive);
            if (uiText == null) return false;
            uiText.text = text;
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="thisGameObject"></param>
        /// <param name="childObjectName"></param>
        /// <param name="textKey"></param>
        /// <param name="includeInactive"></param>
        /// <returns>bool indicating whether the text is set or not (vhild gameobject not found)</returns>
        public static bool SetTextOnChildGameObjectLocalised(GameObject thisGameObject, string childObjectName, string textKey, bool includeInactive = false)
        {
            return SetTextOnChildGameObject(thisGameObject, childObjectName, LocaliseText.Get(textKey), includeInactive);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="thisGameObject"></param>
        /// <param name="childObjectName"></param>
        /// <param name="sprite"></param>
        /// <param name="includeInactive"></param>
        /// <returns></returns>
        public static void SetSpriteOnChildGameObject(GameObject thisGameObject, string childObjectName, Sprite sprite, bool includeInactive = false)
        {
            var uiImage = GameObjectHelper.GetChildComponentOnNamedGameObject<UnityEngine.UI.Image>(thisGameObject, childObjectName, includeInactive);
            Assert.IsNotNull(uiImage);
            uiImage.sprite = sprite;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="thisGameObject"></param>
        /// <param name="childObjectName"></param>
        /// <param name="isOn"></param>
        /// <param name="includeInactive"></param>
        /// <returns></returns>
        public static void SetToggleStateOnChildGameObject(GameObject thisGameObject, string childObjectName, bool isOn, bool includeInactive = false)
        {
            var toggle = GameObjectHelper.GetChildComponentOnNamedGameObject<UnityEngine.UI.Toggle>(thisGameObject, childObjectName, includeInactive);
            Assert.IsNotNull(toggle);
            toggle.isOn = isOn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="thisGameObject"></param>
        /// <param name="childObjectName"></param>
        /// <param name="value"></param>
        /// <param name="includeInactive"></param>
        /// <returns></returns>
        public static void SetSliderValueOnChildGameObject(GameObject thisGameObject, string childObjectName, float value, bool includeInactive = false)
        {
            var slider = GameObjectHelper.GetChildComponentOnNamedGameObject<UnityEngine.UI.Slider>(thisGameObject, childObjectName, includeInactive);
            Assert.IsNotNull(slider);
            slider.value = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="thisGameObject"></param>
        /// <param name="childObjectName"></param>
        /// <param name="color"></param>
        /// <param name="includeInactive"></param>
        /// <returns></returns>
        public static void SetImageColorOnChildGameObject(GameObject thisGameObject, string childObjectName, Color color, bool includeInactive = false)
        {
            var image = GameObjectHelper.GetChildComponentOnNamedGameObject<UnityEngine.UI.Image>(thisGameObject, childObjectName, includeInactive);
            Assert.IsNotNull(image);
            image.color = color;
        }
        

        /// <summary>
        /// Sets the user interface label text on child game object - Allows passing 2 game object names where the second may be generic among similar groups
        /// (saves having seperate scripts for each group).
        /// </summary>
        /// <param name="thisGameObject">This game object.</param>
        /// <param name="childObjectName1">Child object name1.</param>
        /// <param name="childObjectName2">Child object name2.</param>
        /// <param name="text">Text.</param>
        /// <param name="includeInactive">If set to <c>true</c> include inactive.</param>
        public static void SetTextOnChildGameObject(GameObject thisGameObject, string childObjectName1, string childObjectName2, string text, bool includeInactive = false)
        {
            throw new Exception("This method doesn't seem to work as expected due to internal Unity workings.");
            //GameObject childGameObject1 = UnityHelper.GetChildNamedGameObject (thisGameObject, childObjectName1, includeInactive);
            //MyDebug.NotNull(childGameObject1);
            //SetUILabelTextOnChildGameObject(childGameObject1, childObjectName2, text, includeInactive);
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="position"></param>
        ///// <returns></returns>
        //static public bool Is3DUIInput(Vector3 position)
        //{
        //    foreach (Camera camera in Camera.allCameras)
        //    {
        //        if (camera.name == "NGUI Camera")
        //        {
        //            // pos is the Vector3 representing the screen position of the input
        //            Ray inputRay = camera.ScreenPointToRay(position);
        //            RaycastHit hit;

        //            if (Physics.Raycast(inputRay.origin, inputRay.direction, out hit, Mathf.Infinity, LayerMask.NameToLayer("NGUI")))
        //            {
        //                return true;
        //            }
        //        }
        //    }
        //    return false;
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="position"></param>
        ///// <returns></returns>
        //static public bool Is2DUIInput(Vector3 position, string layerName = "NGUI", string cameraName = "NGUI Camera")
        //{
        //    foreach (Camera camera in Camera.allCameras)
        //    {
        //        if (camera.name == cameraName)
        //        {
        //            // pos is the Vector3 representing the screen position of the input
        //            //Ray inputRay = camera.ScreenPointToRay(position);
        //            //RaycastHit hit;

        //            if (Physics2D.OverlapPoint(camera.ScreenToWorldPoint(position), 1 << LayerMask.NameToLayer(layerName)) != null)
        //            //Physics2D.Raycast(inputRay.origin, inputRay.direction, Mathf.Infinity, LayerMask.NameToLayer("NGUI")).collider != null)
        //            {
        //                return true;
        //            }
        //        }
        //    }
        //    return false;
        //}
    }
}