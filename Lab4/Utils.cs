using System;

namespace Lab4
{
    internal class Utils
    {
        public static Vector2[] Merge(float[] xs, float[] ys)
        {
            if (xs.Length != ys.Length)
                throw new ArgumentException("Unmatched sizes of argument arrays");

            var result = new Vector2[xs.Length];

            for (int i = 0; i < xs.Length; i++)
            {
                result[i] = new Vector2(xs[i], ys[i]);
            }

            return result;
        }

        public static void Split(Vector2[] args, out float[] args1, out float[] args2)
        {
            args1 = new float[args.Length];
            args2 = new float[args.Length];

            for (int i = 0; i < args.Length; i++)
            {
                args1[i] = args[i].X;
                args2[i] = args[i].Y;
            }
        }
    }
}
