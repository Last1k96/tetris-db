﻿using System;
using System.Reflection;
using System.Windows.Forms;

namespace TetrisDb
{
    public static class Utils
    {
        private static readonly Action<Control, ControlStyles, bool> SetStyle =
            (Action<Control, ControlStyles, bool>) Delegate.CreateDelegate(typeof(Action<Control, ControlStyles, bool>),
                typeof(Control).GetMethod("SetStyle", BindingFlags.NonPublic | BindingFlags.Instance, null,
                    new[] {typeof(ControlStyles), typeof(bool)}, null) ?? throw new
                    InvalidOperationException());

        public static void DisableSelect(this Control target)
        {
            SetStyle(target, ControlStyles.Selectable, false);
        }
    }
}