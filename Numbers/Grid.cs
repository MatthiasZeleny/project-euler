namespace Numbers;

public class Grid
{

    public Grid(long edgeCountWidth, long edgeCountHeight)
    {
        EdgeCountWidth = edgeCountWidth;
        EdgeCountHeight = edgeCountHeight;
    }

    private long EdgeCountWidth { get; }
    private long EdgeCountHeight { get; }

    public (long edgeCountWidth, long edgeCoundHeight) NormalizedSize => EdgeCountWidth > EdgeCountHeight
        ? (EdgeCountWidth, EdgeCountHeight)
        : (EdgeCountHeight, EdgeCountWidth);
}