using System.Collections.Generic;
using UnityEngine;

namespace UnavinarTestTask.Assets.Scripts.Game
{
    public class FigurePlacer : MonoBehaviour
    {
        public static List<GameObject> PlaceFigure(GameObject unitPrefab, int[,,] figureArray3D, Vector3 offset, Transform transform)
        {
            int XfigureSize = figureArray3D.GetLength(0);
            int YfigureSize = figureArray3D.GetLength(1);
            int ZfigureSize = figureArray3D.GetLength(2);

            int XcenterIndex = XfigureSize / 2;
            int ZcenterIndex = ZfigureSize / 2;

            List<GameObject> result = new List<GameObject>();

            for (int x = 0; x < XfigureSize; x++)
            {
                for (int y = 0; y < YfigureSize; y++)
                {
                    for (int z = 0; z < ZfigureSize; z++)
                    {
                        if (figureArray3D[x, y, z] == 1)
                        {
                            var figureElement = Instantiate(unitPrefab, transform);
                            figureElement.transform.localPosition = offset + new Vector3Int(x, y, z) - new Vector3Int(XcenterIndex, 0, ZcenterIndex);
                            result.Add(figureElement);
                        }
                    }
                }
            }

            return result;
        }

        public static List<GameObject> PlaceFigure(GameObject unitPrefab, int[,] figureArray2D, Vector3 offset, Transform transform)
        {
            List<GameObject> result = new List<GameObject>();

            for (int width = 0; width < figureArray2D.GetLength(0); width++)
            {
                for (int height = 0; height < figureArray2D.GetLength(1); height++)
                {
                    if (figureArray2D[width, height] == 0)
                    {
                        var item = Instantiate(unitPrefab, transform);
                        item.transform.localPosition = offset + new Vector3(width, height, 0);
                        result.Add(item);
                    }
                }
            }

            return result;
        }
    }
}
