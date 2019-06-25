using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnLineVideotech.Data;
using OnLineVideotech.Data.Models;
using OnLineVideotech.Services.Interfaces;
using OnLineVideotech.Services.ServiceModels;

namespace OnLineVideotech.Services.Implementations
{
    public class CommentService : BaseService, IBaseService, ICommentService
    {
        public CommentService(OnLineVideotechDbContext db) : base(db)
        {
        }

        public async Task AddCommentForMovie(string comment, string userId, Guid movieId)
        {
            await this.Db.Comments.AddAsync(new Comment
            {
                CustomerId = userId,
                UserComment = comment,
                MovieId = movieId,
                Date = DateTime.Now
            });

            await this.Db.SaveChangesAsync();
        }

        public async Task<List<CommentServiceModel>> GetAllCommentsForMovie(Guid movieId)
        {
            List<Comment> comments = await this.Db.Comments
                .Where(x => x.MovieId == movieId).ToListAsync();

            List<CommentServiceModel> comentServiceModels = new List<CommentServiceModel>();

            foreach (Comment comment in comments)
            {
                User user = await this.Db.Users.FindAsync(comment.CustomerId);

                comentServiceModels.Add(new CommentServiceModel
                {
                    Comment = comment.UserComment,
                    UserName = user.UserName,
                    Id = comment.Id,
                    Date = comment.Date
                });
            }

            return comentServiceModels;
        }
    }
}
