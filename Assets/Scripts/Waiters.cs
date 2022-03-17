using UnityEngine;

public static class Waiters
{
    public static readonly WaitForSeconds Second = new WaitForSeconds(1);
    public static readonly WaitForSeconds HalfSecond = new WaitForSeconds(0.5f);
    public static readonly WaitForFixedUpdate FixedUpdate = new WaitForFixedUpdate();
}
