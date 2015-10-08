﻿using System;
using BootstrapMvc.Core;
using BootstrapMvc.Buttons;

namespace BootstrapMvc
{
    public static class ButtonGroupExtensions
    {
        #region Fluent

        public static IWriter2<T, ButtonGroupContent> Vertical<T>(this IWriter2<T, ButtonGroupContent> target, bool value = true) where T : ButtonGroup
        {
            target.Item.VerticalValue = value;
            return target;
        }

        public static IWriter2<T, ButtonGroupContent> Justified<T>(this IWriter2<T, ButtonGroupContent> target, bool value = true) where T : ButtonGroup
        {
            target.Item.JustifiedValue = value;
            return target;
        }

        public static IWriter2<T, ButtonGroupContent> DropUp<T>(this IWriter2<T, ButtonGroupContent> target, bool value = true) where T : ButtonGroup
        {
            target.Item.DropUpValue = value;
            return target;
        }

        public static IWriter2<T, ButtonGroupContent> AddButton<T, TButton>(this IWriter2<T, ButtonGroupContent> target, IWriter2<TButton, AnyContent> button) 
            where T : ButtonGroup
            where TButton : Button
        {
            target.Item.AddButton(button.Item);
            return target;
        }

        public static IWriter2<T, ButtonGroupContent> AddButton<T, TButton>(this IWriter2<T, ButtonGroupContent> target, params IWriter2<TButton, AnyContent>[] buttons)
            where T : ButtonGroup
            where TButton : Button
        {
            foreach (var button in buttons)
            {
                target.Item.AddButton(button.Item);
            }
            return target;
        }

        #endregion

        #region Generation

        public static IWriter2<ButtonGroup, ButtonGroupContent> ButtonGroup(this IAnyContentMarker contentHelper)
        {
            return contentHelper.Context.CreateWriter<ButtonGroup, ButtonGroupContent>();
        }

        public static IWriter2<ButtonGroup, ButtonGroupContent> ButtonGroup(this IAnyContentMarker contentHelper, ButtonSize size)
        {
            return contentHelper.Context.CreateWriter<ButtonGroup, ButtonGroupContent>().Size(size);
        }

        public static ButtonGroupContent BeginButtonGroup(this IAnyContentMarker contentHelper)
        {
            return ButtonGroup(contentHelper).BeginContent();
        }

        public static ButtonGroupContent BeginButtonGroup(this IAnyContentMarker contentHelper, ButtonSize size)
        {
            return ButtonGroup(contentHelper).Size(size).BeginContent();
        }

        #endregion
    }
}