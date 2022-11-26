using System.Collections.Generic;
using UnityEngine;

namespace UnavinarTestTask.Assets.Scripts
{
    public static class FigureGenerator
    {
        public static int[,,] GeneratePlayerFigureArray(int xFigureSize, int yFigureSize, int zFigureSize, int branchesCount)
        {
            int [,,] playerFigure = new int[xFigureSize, yFigureSize, zFigureSize];

            int XcenterIndex = xFigureSize / 2;
            int ZcenterIndex = zFigureSize / 2;


            //core
            for (int height = 0; height < yFigureSize; height++)
            {
                playerFigure[XcenterIndex, height, ZcenterIndex] = 1;
            }

            //branches
            for (int branchIndex = 0; branchIndex < branchesCount; branchIndex++)
            {
                var direction = DirectionToVector(GetRandomDirection());
                var branchAtHeight = Random.Range(0, yFigureSize);
                var branchLength = Random.Range(1, xFigureSize / 2);

                for (int branchElement = 1; branchElement <= branchLength; branchElement++)
                {
                    Vector3Int coordinatsToPlace = new Vector3Int(XcenterIndex, branchAtHeight, ZcenterIndex) + (direction * branchElement);
                    playerFigure[coordinatsToPlace.x, coordinatsToPlace.y, coordinatsToPlace.z] = 1;
                }
            }

            return playerFigure;            
        }

        public static List<int[,]> MakeBarriersArrays(int[,,] playerFigure)
        {
            List<int[,]>  barriers = new List<int[,]>();

            int XfigureSize = playerFigure.GetLength(0);
            int YfigureSize = playerFigure.GetLength(1);
            int ZfigureSize = playerFigure.GetLength(2);

            int XcenterIndex = XfigureSize / 2;
            int ZcenterIndex = ZfigureSize / 2;            

            int[,] slice1 = new int[XfigureSize, YfigureSize];
            int[,] slice2 = new int[ZfigureSize, YfigureSize];
            int[,] slice3 = new int[XfigureSize, YfigureSize];
            int[,] slice4 = new int[ZfigureSize, YfigureSize];

            for (int x = 0; x < XfigureSize; x++)
            {
                for (int y = 0; y < YfigureSize; y++)
                {
                    for (int z = 0; z < ZfigureSize; z++)
                    {
                        slice1[x, y] = playerFigure[x, y, ZcenterIndex];
                        slice3[x, y] = playerFigure[XfigureSize - x - 1, y, ZcenterIndex];
                        slice2[z, y] = playerFigure[z, y, XcenterIndex];
                        slice4[z, y] = playerFigure[ZfigureSize - z - 1, y, XcenterIndex];
                    }
                }
            }

            barriers.Add(slice1);
            barriers.Add(slice2);
            barriers.Add(slice3);
            barriers.Add(slice4);

            return barriers;
        }

        public static int[,] MakeGateArray(int gateWidth, int gateHeight)
        {
            var array = new int[gateWidth, gateHeight];

            for (int width = 0; width < gateWidth; width++)
            {
                for (int height = 0; height < gateHeight; height++)
                {
                    array[width, height] = 1;
                }
            }

            for (int height = 0; height < gateHeight; height++)
            {
                array[0, height] = 0;
                array[gateWidth - 1, height] = 0;
            }

            for (int width = 0; width < gateWidth - 1; width++)
            {
                array[width, gateHeight - 1] = 0;
            }

            return array;
        }

        private static BranchDirection GetRandomDirection()
        {
            return (BranchDirection)Random.Range(0, (int)BranchDirection.NumValues);
        }

        private static Vector3Int DirectionToVector(BranchDirection direction)
        {
            switch (direction)
            {
                case BranchDirection.Left: return Vector3Int.left;
                case BranchDirection.Right: return Vector3Int.right;
                case BranchDirection.Front: return Vector3Int.forward;
                case BranchDirection.Back: return Vector3Int.back;
            }

            return Vector3Int.zero;
        }

        private enum BranchDirection
        {
            Left,
            Right,
            Front,
            Back,

            NumValues
        }
    }
}
