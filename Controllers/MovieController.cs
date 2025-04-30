using Microsoft.AspNetCore.Mvc;
using modul10_103022300163;

namespace tpmodul10_103022300163.Controllers
{
    [Route("api/Movies")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private static List<Movie> movieList = new List<Movie>
        {
            new Movie("The Shawshank Redemption", "Frank Darabont", new List<string> {"Tim Robbins", "Morgan Freeman", "Bob Gunton" }, "A banker convicted of uxoricide forms a friendship over a quarter century with a hardened convict, while maintaining his innocence and trying to remain hopeful through simple compassion."),
            new Movie("The Godfather", "Francis Ford Coppola", new List<string> {"Marlon Brando", "Al Pacino", "James Caan" }, "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son."),
            new Movie("The Dark Knight", "Christopher Nolan", new List<string> {"Christian Bale", "Heath Ledger", "James Caan" }, "When a menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman, James Gordon and Harvey Dent must work together to put an end to the madness.")
        };

        [HttpGet]
        public ActionResult<IEnumerable<Movie>> GetAllMovies()
        {
            return movieList;
        }

        [HttpGet("{index}")]
        public ActionResult<Movie> GetMovieByIndex(int index)
        {
            if (index < 0 || index >= movieList.Count)
                return NotFound();

            return Ok(movieList[index]);
        }

        [HttpPost]
        public ActionResult AddMovie([FromBody] Movie movie)
        {
            if (movie == null)
                return BadRequest("Data mahasiswa tidak boleh kosong.");

            movieList.Add(movie);

            return CreatedAtAction(nameof(GetMovieByIndex), new { index = movieList.Count - 1 }, movie);
        }

        [HttpDelete("{index}")]
        public ActionResult DeleteMovie(int index)
        {
            if (index < 0 || index >= movieList.Count)
                return NotFound();

            movieList.RemoveAt(index);
            return NoContent();
        }
    }
}
