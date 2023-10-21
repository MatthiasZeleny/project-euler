namespace Numbers;

public class Grid
{
    private long EdgeCountWidth { get; }
    private long EdgeCountHeight { get; }

    public Grid(long edgeCountWidth, long edgeCountHeight)
    {
        EdgeCountWidth = edgeCountWidth;
        EdgeCountHeight = edgeCountHeight;
    }

    public (long edgeCountWidth, long edgeCoundHeight) NormalizedSize => EdgeCountWidth > EdgeCountHeight
        ? (EdgeCountWidth, EdgeCountHeight)
        : (EdgeCountHeight, EdgeCountWidth);
}