using LibrarySystem.BL.DTOS.BookDTO;
using LibrarySystem.BL.DTOS.BorrowBookDTO;
using LibrarySystem.BL.Manager.BookManagers;
using LibrarySystem.BL.Manager.BorrowBookManagers;
using LibrarySystem.DAL.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System;

namespace LibrarySystem.PL.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly IBookManager bookManager;
        private readonly IBorrowBookManager borrowBookManager;
        
        public BookController(IBookManager bookManager,IBorrowBookManager borrowBookManager)
        {
            this.bookManager = bookManager;
            this.borrowBookManager = borrowBookManager;
        }
        public  ActionResult GetAllBooks()
        {
            return View( bookManager.GetAll());
        }

        public  ActionResult GetBookByID(int id)
        {
            return View( bookManager.GetById(id));
        }
        public ActionResult GetByAuthorOrTitleOrISBN(string Pattern)
        {
            if (string.IsNullOrEmpty(Pattern)) return RedirectToAction(nameof(GetAllBooks));


            return View(nameof(GetAllBooks),bookManager.GetByAuthorOrTitleOrISBN(Pattern));
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookWriteDTO bookWriteDTO)
        {
            if (ModelState.IsValid)
            {
                bookManager.Insert(bookWriteDTO);
                return RedirectToAction(nameof(GetAllBooks));
            }

            return View();
        }

        public ActionResult Edit(int id)
        {
            return View(bookManager.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BookUpdateDTO bookUpdateDTO)
        {
            if (ModelState.IsValid && id == bookUpdateDTO.BookID)
            {
                bookManager.Update(bookUpdateDTO);
                TempData["Message"] = "Book Edited Successfully";

                return RedirectToAction(nameof(GetAllBooks));
            }
            return View();
        }
        public ActionResult Delete(int id, BookStatus bookStatus)
        {

            if (bookStatus == BookStatus.Available)
            {
                bookManager.Delete(id);
                TempData["Message"] = "Book Deleted Successfully";

                return RedirectToAction(nameof(GetAllBooks));
            }
            else
            {
                TempData["Message"] = "You Can not Delete this Book Because it is borrowing";
                return RedirectToAction(nameof(GetAllBooks));
            }
        }
        public ActionResult BorrowingBook(int id)
        {
            //try
            //{
            //    BookUpdateStatusDTO bookUpdateStatusDTO = new BookUpdateStatusDTO
            //    {
            //        BookID = id,
            //        BookStatus = BookStatus.Unavailable
            //    };
            //    bookManager.UpdateStatus(bookUpdateStatusDTO);

            //    BorrowBookWriteDTO borrowBookWriteDTO = new BorrowBookWriteDTO
            //    {
            //        BookID = id,
            //        //BorrowStatus = BorrowStatus.Borrowing,
            //        //BorrowDate = DateTime.Now,
            //        UserID= Convert.ToInt32(User.FindFirst(claim => claim.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value)
            //    };
            //    borrowBookManager.Insert(borrowBookWriteDTO);
            //    TempData["Message"] = "Book Borrowing Successfuly";
            //    return RedirectToAction(nameof(GetAllBooks));
            //}
            //catch
            //{
            //    TempData["Message"] = "Erorr During Borrowing";

            //    return View();
            //}


            try
            {
                BorrowBookWriteDTO borrowBookWriteDTO = new BorrowBookWriteDTO
                {
                    Book = new BookUpdateStatusDTO {
                        BookID = id,
                        BookStatus = BookStatus.Unavailable
                    },
                    BorrowStatus = BorrowStatus.Borrowing,
                    BorrowDate = DateTime.Now,
                    UserID = Convert.ToInt32(User.FindFirst(claim => claim.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value)
                };

                borrowBookManager.BorrowingBook(borrowBookWriteDTO);
                TempData["Message"] = "Book Borrowing Successfuly";
                return RedirectToAction(nameof(GetAllBooks));
            }
            catch
            {
                TempData["Message"] = "Erorr During Borrowing";

                return View();
            }
        }


    }
}
