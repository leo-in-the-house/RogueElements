﻿// <copyright file="PresetPicker.cs" company="Audino">
// Copyright (c) Audino
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Collections;

namespace RogueElements
{
    /// <summary>
    /// Generates an item that is predefined by the user.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class PresetPicker<T> : IRandPicker<T>
    {
        public T ToSpawn;
        public bool ChangesState { get { return false; } }
        public bool CanPick { get { return true; } }

        public PresetPicker() { }
        public PresetPicker(T toSpawn) { ToSpawn = toSpawn; }
        protected PresetPicker(PresetPicker<T> other)
        {
            ToSpawn = other.ToSpawn;
        }
        public IRandPicker<T> CopyState() { return new PresetPicker<T>(this); }

        public IEnumerator<T> GetEnumerator() { yield return ToSpawn; }
        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
        public T Pick(IRandom rand) { return ToSpawn; }
    }
}
