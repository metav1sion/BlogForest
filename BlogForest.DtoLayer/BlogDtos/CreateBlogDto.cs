namespace BlogForest.DtoLayer.BlogDtos;

public class CreateBlogDto
{
    public string Title { get; set; }
    public string ThumbnailImgUrl { get; set; }
    public DateTime CreatedDate { get; set; }
    public int ViewCount { get; set; }
    public string CoverImgUrl { get; set; }
    public string Description { get; set; }
    public int CategoryId { get; set; }
    public int AppUserId { get; set; }
}