public static class MathExtensions
{
  public static int Mod(int x, int m)
  {
    int r = x % m;
    return r < 0 ? r + m : r;
  }
}