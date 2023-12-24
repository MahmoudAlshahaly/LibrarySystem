using LibrarySystem.BL.DTOS.BookDTO;
using LibrarySystem.BL.DTOS.BorrowBookDTO;
using LibrarySystem.BL.Manager.BookManagers;
using LibrarySystem.BL.Manager.BorrowBookManagers;
using LibrarySystem.DAL.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.PL.Controllers
{
    [Authorize]
    public class BorrowBookController : Controller
    {
        private readonly IBorrowBookManager borrowBookManager;

        public BorrowBookController(IBorrowBookManager borrowBookManager)
        {
            this.borrowBookManager = borrowBookManager;
        }
        public IActionResult GetAllForUser()
        {
            var UserID= Convert.ToInt32(User.FindFirst(claim => claim.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value);
            return View(borrowBookManager.GetAllForUser(UserID));
        }
        public ActionResult ReturnBorrowingBook(int borrowid, int bookid)
        {
            try
            {
                //two round trip before this code 



                //this code one round trip to database
                ReturnBorrowBookDto returnBorrowBookDto = new ReturnBorrowBookDto
                {
                    Book=new BookUpdateStatusDTO {BookID=bookid,BookStatus=BookStatus.Available },
                    BorrowID = borrowid,
                    BorrowStatus = BorrowStatus.Returned

                };

                borrowBookManager.ReturnBook(returnBorrowBookDto);
                TempData["Message"] = "Book Returned susccessfully";

                return RedirectToAction("GetAllForUser", "BorrowBook");

            }
            catch
            {
                return View();
            }
        }
    }
}
