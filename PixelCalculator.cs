using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyonSense
{
    public class Get_pixels
    {
        public int number_piexel(int[,] points)
        {
            int num_pixel = 0;
            int num_point = points.GetLength(0);

            //y�� ���� ���ϱ�
            int min = 100000000;//������ ū ��
            int max = 0;
            for (int i = 0; i < num_point; i++)
            {
                if (points[i, 0] < min)
                {
                    min = points[i, 0];
                }

                if (points[i, 0] > max)
                {
                    max = points[i, 0];
                }
            }

            //�� y�࿡ ���� list �ʱ�ȭ
            List<List<int>> boundary = new List<List<int>>();
            for (int i = 0; i < max - min + 1; i++)
            {
                boundary.Add(new List<int>());
            }

            //÷���� boundary���� ���ܽ�Ű��
            if ((points[num_point - 1, 0] - points[0, 0]) * (points[1, 0] - points[0, 0]) <= 0)
                boundary[points[0, 0] - min].Add(points[0, 1]);
            else
                num_pixel += 1;
            for (int i = 1; i < num_point - 1; i++)
            {
                if ((points[i - 1, 0] - points[i, 0]) * (points[i + 1, 0] - points[i, 0]) <= 0)
                    boundary[points[i, 0] - min].Add(points[i, 1]);
                else
                    num_pixel += 1;
            }
            if ((points[0, 0] - points[num_point - 1, 0]) * (points[num_point - 2, 0] - points[num_point - 1, 0]) <= 0)
                boundary[points[num_point - 1, 0] - min].Add(points[num_point - 1, 1]);
            else
                num_pixel += 1;

            //boundary �� ���ϱ�
            for (int i = 0; i < num_point - 1; i++)
            {
                if (points[i + 1, 0] == points[i, 0])
                {
                    num_pixel += 0;
                }
                else if (points[i + 1, 0] - points[i, 0] > 0)
                {
                    for (int j = 1; j < points[i + 1, 0] - points[i, 0]; j++)
                    {
                        boundary[points[i, 0] - min + j].Add(points[i, 1] + (j * (points[i + 1, 1] - points[i, 1])) / (points[i + 1, 0] - points[i, 0]));
                    }
                }
                else //points[i+1,0] - points[i,0] < 0
                {
                    for (int j = 1; j < points[i, 0] - points[i + 1, 0]; j++)
                    {
                        boundary[points[i, 0] - min - j].Add(points[i, 1] + (j * (points[i + 1, 1] - points[i, 1])) / (points[i, 0] - points[i + 1, 0]));
                    }
                }
            }
            //list ������ ���а� ù ���� ��
            if (points[num_point - 1, 0] == points[0, 0])
            {
                num_pixel += 0;
            }
            else if (points[0, 0] - points[num_point - 1, 0] > 0)
            {
                for (int j = 1; j < points[0, 0] - points[num_point - 1, 0]; j++)
                {
                    boundary[points[num_point - 1, 0] - min + j].Add(points[num_point - 1, 1] + (j * (points[0, 1] - points[num_point - 1, 1])) / (points[0, 0] - points[num_point - 1, 0]));
                }
            }
            else //points[i+1,0] - points[i,0] < 0
            {
                for (int j = 1; j < points[num_point - 1, 0] - points[0, 0]; j++)
                {
                    boundary[points[num_point - 1, 0] - min - j].Add(points[num_point - 1, 1] + (j * (points[0, 1] - points[num_point - 1, 1])) / (points[num_point - 1, 0] - points[0, 0]));
                }
            }


            // pixel ���� ���ϱ�
            for (int i = 0; i < max - min + 1; i++)
            {
                if (boundary[i].Count == 0)
                {
                    num_pixel += 0;
                }
                else
                {
                    boundary[i].Sort();
                    for (int j = 0; j < boundary[i].Count / 2; j++)
                    {
                        num_pixel += boundary[i][2 * j + 1] - boundary[i][2 * j] + 1;
                    }
                }

            }
            return num_pixel;
        }
    }
}