using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UxColor
{
    public static Color GetRGB(byte Red, byte Green, byte Blue, byte Alpha) 
        => new Color32(Red, Green, Blue, Alpha);

    public static Color GetHex(int Hex) {
        byte R = Convert.ToByte((Hex >> 16) & 0xff);
        byte G = Convert.ToByte((Hex >> 8) & 0xff);
        byte B = Convert.ToByte(Hex & 0xff);
        return new Color32(R, G, B, 255);
    }

    public static Color GetHex(String Hex) {
        if(Hex.Length > 8) return Color.black;
        if(Hex[0] != '#') {
            for(byte i = 1; i < Hex.Length; i++) {
                if((i & 1) == 1) {
                    
                }
            }
        }
        return new Color();
    }
}
