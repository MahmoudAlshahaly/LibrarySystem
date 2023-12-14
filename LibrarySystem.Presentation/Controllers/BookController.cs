using LibrarySystem.BL.DTOS.BookDTO;
using LibrarySystem.BL.DTOS.BorrowBookDTO;
using LibrarySystem.BL.Manager.BookManagers;
using LibrarySystem.BL.Manager.BorrowBookManagers;
using LibrarySystem.DAL.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
                return RedirectToAction(nameof(GetAllBooks));
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            try
            {
                bookManager.Delete(id);
                return RedirectToAction(nameof(GetAllBooks));
            }
            catch(Exception ex)
            {
                return View(nameof(GetAllBooks));
            }
        }
        public ActionResult BorrowingBook(int id)
        {
            try
            {
                BookUpdateStatusDTO bookUpdateStatusDTO = new BookUpdateStatusDTO
                {
                    BookID = id,
                    BookStatus = BookStatus.Unavailable
                };
                bookManager.UpdateStatus(bookUpdateStatusDTO);

                BorrowBookWriteDTO borrowBookWriteDTO = new BorrowBookWriteDTO
                {
                    BookID = id,
                    //BorrowStatus = BorrowStatus.Borrowing,
                    //BorrowDate = DateTime.Now,
                    UserID= Convert.ToInt32(User.FindFirst(claim => claim.Type == System.Security.Claims.ClaimTypes.NameIdentifier)?.Value)
                };
                borrowBookManager.Insert(borrowBookWriteDTO);
                return RedirectToAction(nameof(GetAllBooks));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ReturnBorrowingBook(int id)
        {
            try
            {
                BookUpdateStatusDTO bookUpdateStatusDTO = new BookUpdateStatusDTO
                {
                    BookID = id,
                    BookStatus = BookStatus.Available
                };
                bookManager.UpdateStatus(bookUpdateStatusDTO);

                BorrowBookUpdateBorrowStatusDTO borrowBookUpdateBorrowStatusDTO = new BorrowBookUpdateBorrowStatusDTO
                {
                    BorrowID = id,
                    BorrowStatus = BorrowStatus.Returned
                };
                borrowBookManager.UpdateStatus(borrowBookUpdateBorrowStatusDTO);
                return RedirectToAction("GetAllForUser", "BorrowBook");

            }
            catch
            {
                return View();
            }
        }
    }
}
