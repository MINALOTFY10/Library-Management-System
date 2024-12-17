using LibraryManagementSystem.Models;
using LibraryManagementSystem.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    // BookCopyController handles operations related to book copies (add, edit, delete)
    public class BookCopyController : Controller
    {
        // Injecting repositories to access book and book copy data
        private readonly IBookRepository BookRepository;
        private readonly IBookCopyRepository BookCopyRepository;

        // Constructor that initializes the repositories
        public BookCopyController(
            IBookRepository _BookRepository,
            IBookCopyRepository _BookCopyRepository)
        {
            BookRepository = _BookRepository;
            BookCopyRepository = _BookCopyRepository;
        }

        // Default action returns a "NotFound" view
        public IActionResult Index()
        {
            return View("NotFound"); 
        }

        // Action to add a new book copy (only accessible by Admin)
        [Authorize(Roles = "Admin")]
        public IActionResult Add(int id)
        {
            // Create a new ViewModel for the book copy form
            BookCopyBooksViewModel bookCopyBooksViewModel = new();

            // Get all book copies for the given book ID
            List<BookCopy> bookCopies = BookCopyRepository.GetBookCopiesByBookId(id);

            // Store the next copy number in TempData (for display in the view)
            TempData["CopyNumber"] = bookCopies.Count + 1;

            // Store book ID and title in TempData for use in the view
            TempData["BookId"] = id;
            TempData["BookName"] = BookRepository.GetById(id).Title;

            return View("Add", bookCopyBooksViewModel);
        }

        // Save the new book copy (only accessible by Admin)
        [Authorize(Roles = "Admin")]
        public IActionResult SaveAdd(BookCopyBooksViewModel bookCopyBooksViewModel)
        {
            // Check if the model is valid
            if (ModelState.IsValid)
            {
                // Ensure the BookId is valid (not -1)
                if (bookCopyBooksViewModel.BookId != -1)
                {
                    // Create a new book copy entity
                    BookCopy bookCopy = new()
                    {
                        IsAvailable = true,
                        Number = bookCopyBooksViewModel.Number,
                        ConditionStatus = bookCopyBooksViewModel.ConditionStatus,
                        Location = bookCopyBooksViewModel.Location,
                        BookId = BookRepository.GetBookBytitle(bookCopyBooksViewModel.BookName).Id
                    };

                    // Add the book copy to the repository
                    BookCopyRepository.Add(bookCopy);
                    BookCopyRepository.Save();

                    // Set a success message to display after saving
                    TempData["SuccessMessage"] = "The book Copy has been added successfully!";

                    return RedirectToAction("Index", "Book");
                }
                else
                {
                    // Add a model error if BookId is invalid
                    ModelState.AddModelError("BookId", "Book is required");
                }
            }

            // If the model is not valid, return to the "Add" view with the current ViewModel
            return View("Add", bookCopyBooksViewModel);
        }

        // Edit an existing book copy (only accessible by Admin)
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            // Retrieve the book copy from the repository
            BookCopy? copy = BookCopyRepository.GetById(id);

            // If found, return the "Edit" view with the book copy if not Return "NotFound"
            return copy != null ? View("Edit", copy) : NotFound();
        }

        // Save the changes made to a book copy (only accessible by Admin)
        [Authorize(Roles = "Admin")]
        public ActionResult SaveEdit(BookCopy bookCopy, int id)
        {
            // Retrieve the existing book copy from the repository
            BookCopy copyDB = BookCopyRepository.GetById(id);

            // If the book copy exists, update the details
            if (copyDB != null)
            {
                // Update location only if it's not null
                if (bookCopy.Location != null)
                {
                    copyDB.Location = bookCopy.Location;
                }

                // Update other fields
                copyDB.ConditionStatus = bookCopy.ConditionStatus;
                copyDB.IsAvailable = bookCopy.IsAvailable;

                // Save the updated book copy
                BookCopyRepository.Update(copyDB);
                BookCopyRepository.Save();

                // Set a success message to display after saving
                TempData["SuccessMessage"] = "The copy has been edited successfully!";
                return RedirectToAction("Index", "Book");
            }

            // If the book copy is not found, return the "Edit" view with the current model
            return View("Edit", bookCopy);
        }

        // Delete a book copy (only accessible by Admin)
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            // Retrieve the book copy from the repository
            BookCopy? bookcopy = BookCopyRepository.GetById(id);

            // Return the "Delete" view with the book copy if not found, return "NotFound"
            return bookcopy != null ? View(bookcopy) : NotFound();
        }

        // Confirm deletion of a book copy (only accessible by Admin)
        [Authorize(Roles = "Admin")]
        public ActionResult SaveDelete(int id)
        {
            // Delete the book copy from the repository
            BookCopyRepository.Delete(id);
            BookCopyRepository.Save();

            // Set a success message to display after deletion
            TempData["SuccessMessage"] = "The book copy has been deleted successfully!";
            return RedirectToAction("Index", "Book");
        }
    }
}
