﻿using System;
using Xamarin.Forms;

namespace HOK_App.Effects
{
    public class ViewShadowEffect : RoutingEffect
    {
        public float Radius { get; set; }

        public Color Color { get; set; }

        public float DistanceX { get; set; }

        public float DistanceY { get; set; }

        public ViewShadowEffect() : base("CubiSoft.DropShadowEffect")
        {
        }
    }
}
