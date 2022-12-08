using System;

[Serializable]
public struct GridElement
{
    public GridElementType type;
    public int x;
    public int y;
}

public enum GridElementType
{
    START,
    END,
    PROP
}
