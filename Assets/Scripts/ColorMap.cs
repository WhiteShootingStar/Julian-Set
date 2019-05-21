using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorMap : ScriptableObject
{
    public List<Color> colors;
    public ColorMap(drawingMode mode)
    {
        colors = new List<Color>();
        float step = 1 / 255f;
        if (mode.Equals(drawingMode.NORMAL))
        {
            for (int i = 0; i < 127; i += 5)
            {
                for (int k = 0; k < 127; k += 5)
                {
                    for (int j = 0; j < 127; j += 5)
                    {
                        colors.Add(new Color(i * step, k * step, j * step));
                    }
                }
            }
        }

        else if (mode.Equals(drawingMode.WTF))
        {
            for (int i = 0; i < 255; i++)
            {
                colors.Add(new Color(i * step, 1 - (i * step), 1 - (i * step)));
                colors.Add(new Color(1 - (i * step), i * step, 1 - (i * step)));
                colors.Add(new Color(1 - (i * step), 1 - (i * step), i * step));
            }

        }
        else if( mode.Equals(drawingMode.ANOTHER))
        {
            for (int i = 0; i < 255; i++)
            {
                colors.Add(new Color(i * step,0, 0));
                colors.Add(new Color(0, i * step, 0));
                colors.Add(new Color(0, 0, i * step));
            }
        }
    }
        public Color getIterationColor(int iteration)
        {
            if (iteration > colors.Capacity)
            {
                return getIterationColor(iteration - 63);
            }

            else
            {
                Debug.Log(colors[iteration]);
                return colors[iteration];
            }
        }
    }



    ///////////
    ///ENUMERATOR OF DRAWING MODES
    //////////
    ///
    public enum drawingMode
    {
        NORMAL, WTF, ANOTHER
    }
