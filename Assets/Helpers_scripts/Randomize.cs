using System.Collections;
using System.Collections.Generic;

public class Randomize {

    public int Rand(int min, int max)
    {
        System.Random rnd = new System.Random();
        return rnd.Next(min, max);
    }
}
