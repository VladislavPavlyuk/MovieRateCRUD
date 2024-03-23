using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieRateCRUD.Models;

namespace MovieRateCRUD.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieContext _context;

        // IWebHostEnvironment предоставляет информацию об окружении, в котором запущено приложение
        IWebHostEnvironment _appEnvironment;
        public MoviesController(MovieContext context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        // Все загружаемые файлы в ASP.NET Core представлены типом IFormFile

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Movies.ToListAsync());
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Movie = await _context.Movies
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Movie == null)
            {
                return NotFound();
            }

            return View(Movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Director,Genre,Release,Poster,Description")] Movie Movie, IFormFile uploadedImage)
        {
            if (ModelState.IsValid)
            {
                // Путь к папке Files + имя файла
                string path = "/images/" + uploadedImage.FileName;

                // Сохраняем файл в папку Images в каталоге wwwroot
                // Для получения полного пути к каталогу wwwroot
                // применяется свойство WebRootPath объекта IWebHostEnvironment
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedImage.CopyToAsync(fileStream); // копируем файл в поток
                }

                Movie.Poster = path;

                _context.Add(Movie);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(Movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Movie = await _context.Movies.FindAsync(id);
            if (Movie == null)
            {
                return NotFound();
            }
            return View(Movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [RequestSizeLimit(1000000000)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Director,Genre,Release,Poster,Description")] Movie Movie, IFormFile uploadedImage)
        {
            if (id != Movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Путь к папке Files + имя файла
                    string path = "/images/" + uploadedImage.FileName;

                    // Сохраняем файл в папку Images в каталоге wwwroot
                    // Для получения полного пути к каталогу wwwroot
                    // применяется свойство WebRootPath объекта IWebHostEnvironment
                    using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        await uploadedImage.CopyToAsync(fileStream); // копируем файл в поток
                    }

                    Movie.Poster = path;
                    _context.Update(Movie);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(Movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(Movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Movie = await _context.Movies
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Movie == null)
            {
                return NotFound();
            }

            return View(Movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Movie = await _context.Movies.FindAsync(id);
            if (Movie != null)
            {
                _context.Movies.Remove(Movie);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }
}
