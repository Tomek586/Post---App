using Data.Entities;

namespace Post___App.Models
{
    public class PostMapper
    {
        public static PostEntity ToEntity(Post model)
        {
            return new PostEntity()
            {
                Content = model.Content,
                Author = model.Author,
                publishDate = model.publishDate,
                Tags = model.Tags,
                Comment = model.Comment,
                PostId = model.Id,
                TopicId = model.TopicId ?? 1
            };
        }

        public static Post FromEntity(PostEntity entity)
        {
            return new Post()
            {
                Content = entity.Content,
                Author = entity.Author,
                publishDate = (DateTime)entity.publishDate,
                Tags = entity.Tags,
                Comment = entity.Comment,
                Id = entity.PostId,
                TopicId = entity.TopicId

            };
        }
    }
}