using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Domain.DTO;
using WebApp.Infrastructure.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Domain.Entities;

namespace WebApp.Web.Pages.CommentPage
{
    public class ViewCommentsModel : PageModel
    {
        private readonly IFirestoreService _firestoreService;

        public List<CommentDto> Comments { get; set; }

        public ViewCommentsModel(IFirestoreService firestoreService)
        {
            _firestoreService = firestoreService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            // Получение списка комментариев из базы данных
            var comments = await _firestoreService.GetAllComments();

            // Преобразование списка комментариев в список DTO
            Comments = comments.Select(c => new CommentDto
            {
                commentId = c.commentId,
                commRating = c.commRating,
                nickname = c.nickname,
                content = c.content,
                datePostedComment = c.datePostedComment
            }).ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string nickname, string commRating, string content)
        {
            var newComment = new Comment
            {
                nickname = nickname,
                commRating = commRating,
                content = content,
                datePostedComment = DateTime.UtcNow
            };
            await _firestoreService.AddCommentAsync(newComment);
            return RedirectToPage();
        }
    }
}
