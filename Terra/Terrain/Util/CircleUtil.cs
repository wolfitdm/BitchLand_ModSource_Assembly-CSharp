// Decompiled with JetBrains decompiler
// Type: Terra.Terrain.Util.CircleUtil
// Assembly: Assembly-CSharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E6BFF86D-6970-4C7D-A7B5-75A5C22D94C1
// Assembly location: C:\Users\CdemyTeilnehmer\Downloads\BitchLand_build10e_preinstalledmods\build10e\Bitch Land_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace Terra.Terrain.Util;

public static class CircleUtil
{
  public static List<Vector2> GetPointsInside(Vector2 origin, float radius, float stepSize)
  {
    List<Vector2> pointsInside = new List<Vector2>();
    for (float radius1 = radius; (double) radius1 > 0.0; radius1 -= stepSize)
    {
      List<Vector2> pointsAround = CircleUtil.GetPointsAround(origin, radius1, stepSize);
      pointsInside.AddRange((IEnumerable<Vector2>) pointsAround);
    }
    return pointsInside;
  }

  public static List<Vector2> GetPointsAround(Vector2 origin, float radius, float stepSize)
  {
    float num = stepSize / radius;
    List<Vector2> pointsAround = new List<Vector2>();
    for (float f = 0.0f; (double) f < 6.2831854820251465; f += num)
    {
      float x = origin.x + radius * Mathf.Cos(f);
      float y = origin.y + radius * Mathf.Sin(f);
      pointsAround.Add(new Vector2(x, y));
    }
    return pointsAround;
  }

  public static List<Vector2> GetPointsFromGrid(Vector2 origin, float radius, float stepSize)
  {
    List<Vector2> pointsFromGrid = new List<Vector2>();
    float x1 = origin.x;
    float y1 = origin.y;
    for (float x2 = x1 - radius; (double) x2 <= (double) x1; x2 += stepSize)
    {
      for (float y2 = y1 - radius; (double) y2 <= (double) y1; y2 += stepSize)
      {
        if (((double) x2 - (double) x1) * ((double) x2 - (double) x1) + ((double) y2 - (double) y1) * ((double) y2 - (double) y1) <= (double) radius * (double) radius)
        {
          float x3 = x1 - (x2 - x1);
          float y3 = y1 - (y2 - y1);
          bool flag1 = (double) x2 - (double) x1 == 0.0;
          bool flag2 = (double) y2 - (double) y1 == 0.0;
          if (flag1 | flag2)
          {
            if (flag1 & flag2)
            {
              pointsFromGrid.Add(new Vector2(x2, y2));
            }
            else
            {
              if (flag1)
              {
                pointsFromGrid.Add(new Vector2(x2, y2));
                pointsFromGrid.Add(new Vector2(x2, y3));
              }
              if (flag2)
              {
                pointsFromGrid.Add(new Vector2(x2, y2));
                pointsFromGrid.Add(new Vector2(x3, y2));
              }
            }
          }
          else
          {
            pointsFromGrid.Add(new Vector2(x2, y2));
            pointsFromGrid.Add(new Vector2(x2, y3));
            pointsFromGrid.Add(new Vector2(x3, y2));
            pointsFromGrid.Add(new Vector2(x3, y3));
          }
        }
      }
    }
    return pointsFromGrid;
  }
}
