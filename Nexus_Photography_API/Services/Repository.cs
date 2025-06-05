using Microsoft.EntityFrameworkCore;
using Nexus_Photography_API.Data;
using Nexus_Photography_API.DBContext.Entities.TableEntities;
using Nexus_Photography_API.Models.DTOs;
using Nexus_Photography_API.Models.Response;

namespace Nexus_Photography_API.Services
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _dbcontext;
        private readonly HttpClient _httpClient;
        private readonly IWebHostEnvironment _environment;
        public Repository(ApplicationDbContext dbcontext, IWebHostEnvironment environment)
        {
            _dbcontext = dbcontext;
            _httpClient = new HttpClient();
            _environment = environment;
        }


        public async Task<List<CoupleFilm>> GetCoupleflimsAsync()
        {
            var cf = await _dbcontext.CoupleFilms.ToListAsync();
            return cf;
        }

        public async Task<APIResponse> AddCoupleFilmAsync(CoupleFilmsDTO entity)
        {
            CoupleFilm model = new CoupleFilm
            {
                Id = entity.Id,
                Thumbnail = entity.Thumbnail,
                YoutubeLink = entity.YoutubeLink,
            };
            _dbcontext.CoupleFilms.Add(model);
            int cnt = await _dbcontext.SaveChangesAsync();
            if (cnt > 0)
            {
                return new APIResponse
                {
                    Code = 200,
                    Message = "Couple Film added successfully",
                    Data = model
                };
            }
            else
            {
                return new APIResponse
                {
                    Code = 500,
                    Message = "Failed to add Couple Film"
                };

            }
        }

        public async Task<bool> UpdateCoupleFilmAsync(CoupleFilm entity)
        {
            if (!await _dbcontext.CoupleFilms.AnyAsync(x => x.Id == entity.Id))
                return false;
            _dbcontext.CoupleFilms.Update(entity);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCoupleFilmAsync(int id)
        {
            var entity = await _dbcontext.CoupleFilms.FindAsync(id);
            if (entity == null)
                return false;
            _dbcontext.CoupleFilms.Remove(entity);
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
}
