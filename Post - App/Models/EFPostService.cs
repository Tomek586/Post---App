using Data;
using Data.Entities;
using System.Data.Entity.Infrastructure;


namespace Post___App.Models
{
    public class EFPostService : IPostService
    {
        private readonly AppDbContext _context;

        public EFPostService(AppDbContext context)
        {
            _context = context;
        }

        public int Add(Post post)
        {
            var entity = _context.Posts.Add(PostMapper.ToEntity(post));
            int id = entity.Entity.PostId;
            _context.SaveChanges();
            return id;
        }

        public void Update(Post post)
        {
            PostEntity entity = PostMapper.ToEntity(post);
            _context.Update(entity);
            _context.SaveChanges();

        }

        public void Delete(int id)
        {
            PostEntity? find = _context.Posts.Find(id);
            if (find != null)
            {
                _context.Posts.Remove(find);
                _context.SaveChanges();
            }
        }

        public List<Post> FindAll()
        {
            return _context.Posts.Select(e => PostMapper.FromEntity(e)).ToList();
        }

        public Post? FindById(int id)
        {
            PostEntity? find = _context.Posts.Find(id);
            return find == null ? null : PostMapper.FromEntity(find);
        }

        public List<TopicEntity> FindAllTopics()
        {
            return _context.Topics.ToList();
        }


        public PagingList<Post> FindPage(int page, int size)
        {
          var data = _context.Posts
               .OrderBy(c => c.PostId)
              .Skip((page - 1) * size)
              .Take(size)
               .Select(PostMapper.FromEntity)
               .ToList();
           return PagingList<Post>.Create(data, _context.Posts.Count(), page, size);
        }


      
    }
}
