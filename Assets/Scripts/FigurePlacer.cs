using UnityEngine;

namespace UnavinarTestTask.Assets.Scripts
{
    public class FigurePlacer : MonoBehaviour
    {
        public static void PlaceFigure(GameObject unitPrefab, int[,,] figureArray3D, Vector3 offset, Transform transform)
        {
            int XfigureSize = figureArray3D.GetLength(0);
            int YfigureSize = figureArray3D.GetLength(1);
            int ZfigureSize = figureArray3D.GetLength(2);

            int XcenterIndex = XfigureSize / 2;
            int ZcenterIndex = ZfigureSize / 2;

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
                        }
                    }
                }
            }
        }

        public static void PlaceFigure(GameObject unitPrefab, int[,] figureArray2D, Vector3 offset, Transform transform)
        {
            for (int width = 0; width < figureArray2D.GetLength(0); width++)
            {
                for (int height = 0; height < figureArray2D.GetLength(1); height++)
                {
                    if (figureArray2D[width, height] == 0)
                    {
                        var item = Instantiate(unitPrefab, transform);
                        item.transform.localPosition = offset + new Vector3(width, height, 0);
                    }
                }
            }
        }
    }
}
