using System.Collections;
using System.Collections.Generic;


public abstract class State
{
    public virtual IEnumerator Start()
    {
        yield break;
    }
    public virtual IEnumerator Move()
    {
        yield break;
    }
}
