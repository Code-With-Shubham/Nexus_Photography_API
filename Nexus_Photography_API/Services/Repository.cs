using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nexus_Photography_API.Data;
using Nexus_Photography_API.DBContext.Entities.TableEntities;
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


        public async Task<List<CoupleFilmDTO>> GetCoupleflimsAsync()
        {
            var cf = await _dbcontext.CoupleFilms.ToListAsync();
            return cf.Select(x => new CoupleFilmDTO
            {
                Id = x.Id,
                Thumbnail = x.Thumbnail != null ? Convert.ToBase64String(x.Thumbnail) : null,
                YoutubeLink = x.YoutubeLink
            }).ToList();
        }

        public async Task<APIResponse> AddCoupleFilmAsync(CoupleFilmDTO entity)
        {
            byte[]? thumbnailBytes = null;

            if (entity.ThumbnailFile != null)
            {
                using var memoryStream = new MemoryStream();
                await entity.ThumbnailFile.CopyToAsync(memoryStream);
                thumbnailBytes = memoryStream.ToArray();
            }
            else if (!string.IsNullOrEmpty(entity.Thumbnail))
            {
                // If Thumbnail is provided as base64 string
                thumbnailBytes = Convert.FromBase64String(entity.Thumbnail);
            }

            CoupleFilm model = new CoupleFilm
            {
   
                Thumbnail = thumbnailBytes,
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

        
        public async Task<bool> UpdateCoupleFilmAsync(CoupleFilmDTO entity)
        {
            var model = await _dbcontext.CoupleFilms.FindAsync(entity.Id);
            if (model == null)
                return false;

            model.YoutubeLink = entity.YoutubeLink;

            if (entity.ThumbnailFile != null)
            {
                using var memoryStream = new MemoryStream();
                await entity.ThumbnailFile.CopyToAsync(memoryStream);
                model.Thumbnail = memoryStream.ToArray();
            }
            else if (!string.IsNullOrEmpty(entity.Thumbnail))
            {
                // If Thumbnail is provided as base64 string
                model.Thumbnail = Convert.FromBase64String(entity.Thumbnail);
            }
            // If neither is provided, keep the existing image

            _dbcontext.CoupleFilms.Update(model);
            await _dbcontext.SaveChangesAsync();
            return true;
        }







        public async Task<List<ContactForm>> GetContactFormsAsync()
        {
            return await _dbcontext.ContactForms.ToListAsync();
        }

        public async Task<ContactForm?> GetContactFormByIdAsync(int id)
        {
            return await _dbcontext.ContactForms.FindAsync(id);
        }

        public async Task<ContactForm> AddContactFormAsync(ContactFormDTO dto)
        {
            var entity = new ContactForm
            {
                Name = dto.Name,
                LastName = dto.LastName,
                Email = dto.Email,
                Phone = dto.Phone,
                DateOfEvent = dto.DateOfEvent,
                EventType = dto.EventType,
                WeddingStyle = dto.WeddingStyle,
                Venue = dto.Venue,
                GuestCount = dto.GuestCount,
                ReachSource = dto.ReachSource
            };
            _dbcontext.ContactForms.Add(entity);
            await _dbcontext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateContactFormAsync(ContactForm entity)
        {
            if (!await _dbcontext.ContactForms.AnyAsync(x => x.Id == entity.Id))
                return false;
            _dbcontext.ContactForms.Update(entity);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteContactFormAsync(int id)
        {
            var entity = await _dbcontext.ContactForms.FindAsync(id);
            if (entity == null)
                return false;
            _dbcontext.ContactForms.Remove(entity);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCoupleFilmAsync(int id)
        {
            var entity = await _dbcontext.ContactForms.FindAsync(id);
            if (entity == null)
                return false;
            _dbcontext.ContactForms.Remove(entity);
            await _dbcontext.SaveChangesAsync();
            return true;
        }







        public async Task<List<CoupleStoryDTO>> GetCoupleStoriesAsync()
        {
            var stories = await _dbcontext.CoupleStories.ToListAsync();
            return stories.Select(x => new CoupleStoryDTO
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Image = x.Image != null ? Convert.ToBase64String(x.Image) : null,
                Location = x.Location,
                Date = x.Date
            }).ToList();
        }

        public async Task<CoupleStory> AddCoupleStoryAsync(CoupleStoryDTO dto)
        {
            byte[]? imageBytes = null;
            if (dto.ImageFile != null)
            {
                using var memoryStream = new MemoryStream();
                await dto.ImageFile.CopyToAsync(memoryStream);
                imageBytes = memoryStream.ToArray();
            }
            else if (!string.IsNullOrEmpty(dto.Image))
            {
                imageBytes = Convert.FromBase64String(dto.Image);
            }

            var entity = new CoupleStory
            {
                Title = dto.Title,
                Description = dto.Description,
                Image = imageBytes,
                Location = dto.Location,
                Date = dto.Date
            };
            _dbcontext.CoupleStories.Add(entity);
            await _dbcontext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateCoupleStoryAsync(CoupleStoryDTO dto)
        {
            var entity = await _dbcontext.CoupleStories.FindAsync(dto.Id);
            if (entity == null)
                return false;

            entity.Title = dto.Title;
            entity.Description = dto.Description;
            entity.Location = dto.Location;
            entity.Date = dto.Date;

            if (dto.ImageFile != null)
            {
                using var memoryStream = new MemoryStream();
                await dto.ImageFile.CopyToAsync(memoryStream);
                entity.Image = memoryStream.ToArray();
            }
            else if (!string.IsNullOrEmpty(dto.Image))
            {
                entity.Image = Convert.FromBase64String(dto.Image);
            }
            // If neither is provided, keep the existing image

            _dbcontext.CoupleStories.Update(entity);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCoupleStoryAsync(int id)
        {
            var entity = await _dbcontext.CoupleStories.FindAsync(id);
            if (entity == null)
                return false;
            _dbcontext.CoupleStories.Remove(entity);
            await _dbcontext.SaveChangesAsync();
            return true;
        }





        /// <summary>Client Says</summary>

        public async Task<List<ClientSayDTO>> GetClientSaysAsync()
        {
            var items = await _dbcontext.ClientSays.ToListAsync();
            return items.Select(x => new ClientSayDTO
            {
                Id = x.Id,
                Name = x.Name,
                Location = x.Location,
                Quote = x.Quote,
                Image = x.Image != null ? Convert.ToBase64String(x.Image) : null
            }).ToList();
        }

       
        public async Task<ClientSay> AddClientSayAsync(ClientSayDTO dto)
        {
            byte[]? imageBytes = null;
            if (dto.ImageFile != null)
            {
                using var memoryStream = new MemoryStream();
                await dto.ImageFile.CopyToAsync(memoryStream);
                imageBytes = memoryStream.ToArray();
            }
            else if (!string.IsNullOrEmpty(dto.Image))
            {
                imageBytes = Convert.FromBase64String(dto.Image);
            }

            var entity = new ClientSay
            {
                Name = dto.Name,
                Location = dto.Location,
                Quote = dto.Quote,
                Image = imageBytes
            };
            _dbcontext.ClientSays.Add(entity);
            await _dbcontext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateClientSayAsync(ClientSayDTO dto)
        {
            var entity = await _dbcontext.ClientSays.FindAsync(dto.Id);
            if (entity == null)
                return false;

            entity.Name = dto.Name;
            entity.Location = dto.Location;
            entity.Quote = dto.Quote;

            if (dto.ImageFile != null)
            {
                using var memoryStream = new MemoryStream();
                await dto.ImageFile.CopyToAsync(memoryStream);
                entity.Image = memoryStream.ToArray();
            }
            else if (!string.IsNullOrEmpty(dto.Image))
            {
                entity.Image = Convert.FromBase64String(dto.Image);
            }
            // If neither is provided, keep the existing image

            _dbcontext.ClientSays.Update(entity);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteClientSayAsync(int id)
        {
            var entity = await _dbcontext.ClientSays.FindAsync(id);
            if (entity == null)
                return false;
            _dbcontext.ClientSays.Remove(entity);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<List<MostPopularWeddingDTO>> GetMostPopularFilmsAsync()
        {
            var items = await _dbcontext.MostPopularWeddings.ToListAsync();
            return items.Select(x => new MostPopularWeddingDTO
            {
                Id = x.Id,
                Title = x.Title,
                Image = x.Image != null ? Convert.ToBase64String(x.Image) : null,
                Description = x.Description,
                ReadMore = x.ReadMore
            }).ToList();
        }

        public async Task<MostPopularWedding> AddMostPopularFilmAsync(MostPopularWeddingDTO dto)
        {
            byte[]? imageBytes = null;
            if (dto.ImageFile != null)
            {
                using var memoryStream = new MemoryStream();
                await dto.ImageFile.CopyToAsync(memoryStream);
                imageBytes = memoryStream.ToArray();
            }
            else if (!string.IsNullOrEmpty(dto.Image))
            {
                imageBytes = Convert.FromBase64String(dto.Image);
            }

            var entity = new MostPopularWedding
            {
                Title = dto.Title,
                Image = imageBytes,
                Description = dto.Description,
                ReadMore = dto.ReadMore
            };
            _dbcontext.MostPopularWeddings.Add(entity);
            await _dbcontext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateMostPopularFilmAsync(MostPopularWeddingDTO dto)
        {
            var entity = await _dbcontext.MostPopularWeddings.FindAsync(dto.Id);
            if (entity == null)
                return false;

            entity.Title = dto.Title;
            entity.Description = dto.Description;
            entity.ReadMore = dto.ReadMore;

            if (dto.ImageFile != null)
            {
                using var memoryStream = new MemoryStream();
                await dto.ImageFile.CopyToAsync(memoryStream);
                entity.Image = memoryStream.ToArray();
            }
            else if (!string.IsNullOrEmpty(dto.Image))
            {
                entity.Image = Convert.FromBase64String(dto.Image);
            }
            // If neither is provided, keep the existing image

            _dbcontext.MostPopularWeddings.Update(entity);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteMostPopularFilmAsync(int id)
        {
            var entity = await _dbcontext.MostPopularWeddings.FindAsync(id);
            if (entity == null)
                return false;
            _dbcontext.MostPopularWeddings.Remove(entity);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<List<AdminDTO>> GetAdminsAsync()
        {
            var admins = await _dbcontext.Admins.ToListAsync();
            return admins.Select(x => new AdminDTO
            {
                Id = x.Id,
                Username = x.Username,
                Pswd = x.Pswd,
                Type = x.Type
            }).ToList();
        }

        public async Task<Admin> AddAdminAsync(AdminDTO dto)
        {
            var entity = new Admin
            {
                Username = dto.Username,
                Pswd = dto.Pswd,
                Type = dto.Type
            };
            _dbcontext.Admins.Add(entity);
            await _dbcontext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAdminAsync(int id)
        {
            var entity = await _dbcontext.Admins.FindAsync(id);
            if (entity == null)
                return false;
            _dbcontext.Admins.Remove(entity);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        //public async Task<List<TestimonialDTO>> GetTestimonialsAsync()
        //{
        //    var items = await _dbcontext.Testimonials.ToListAsync();
        //    return items.Select(x => new TestimonialDTO
        //    {
        //        Id = x.Id,
        //        CoupleName = x.CoupleName,
        //        Thumbnail = x.Thumbnail != null ? Convert.ToBase64String(x.Thumbnail) : null,
        //        VideoLink = x.VideoLink,
        //        Quote = x.Quote
        //    }).ToList();
        //}

        //public async Task<Testimonial> AddTestimonialAsync(TestimonialDTO dto)
        //{
        //    byte[]? thumbnailBytes = null;
        //    if (dto.ThumbnailFile != null)
        //    {
        //        using var memoryStream = new MemoryStream();
        //        await dto.ThumbnailFile.CopyToAsync(memoryStream);
        //        thumbnailBytes = memoryStream.ToArray();
        //    }
        //    else if (!string.IsNullOrEmpty(dto.Thumbnail))
        //    {
        //        thumbnailBytes = Convert.FromBase64String(dto.Thumbnail);
        //    }

        //    var entity = new Testimonial
        //    {
        //        CoupleName = dto.CoupleName,
        //        Thumbnail = thumbnailBytes,
        //        VideoLink = dto.VideoLink,
        //        Quote = dto.Quote
        //    };
        //    _dbcontext.Testimonials.Add(entity);
        //    await _dbcontext.SaveChangesAsync();
        //    return entity;
        //}

        //public async Task<bool> UpdateTestimonialAsync(TestimonialDTO dto)
        //{
        //    var entity = await _dbcontext.Testimonials.FindAsync(dto.Id);
        //    if (entity == null)
        //        return false;

        //    entity.CoupleName = dto.CoupleName;
        //    entity.VideoLink = dto.VideoLink;
        //    entity.Quote = dto.Quote;

        //    if (dto.ThumbnailFile != null)
        //    {
        //        using var memoryStream = new MemoryStream();
        //        await dto.ThumbnailFile.CopyToAsync(memoryStream);
        //        entity.Thumbnail = memoryStream.ToArray();
        //    }
        //    else if (!string.IsNullOrEmpty(dto.Thumbnail))
        //    {
        //        entity.Thumbnail = Convert.FromBase64String(dto.Thumbnail);
        //    }
        //    // If neither is provided, keep the existing image

        //    _dbcontext.Testimonials.Update(entity);
        //    await _dbcontext.SaveChangesAsync();
        //    return true;
        //}

        //public async Task<bool> DeleteTestimonialAsync(int id)
        //{
        //    var entity = await _dbcontext.Testimonials.FindAsync(id);
        //    if (entity == null)
        //        return false;
        //    _dbcontext.Testimonials.Remove(entity);
        //    await _dbcontext.SaveChangesAsync();
        //    return true;
        //}


        public async Task<List<PhotographyStyleDTO>> GetPhotographyStylesAsync()
        {
            var items = await _dbcontext.PhotographyStyles.ToListAsync();
            return items.Select(x => new PhotographyStyleDTO
            {
                Id = x.Id,
                Src = x.Src != null ? Convert.ToBase64String(x.Src) : null,
                Title = x.Title,
                Description = x.Description
            }).ToList();
        }

        public async Task<PhotographyStyle> AddPhotographyStyleAsync(PhotographyStyleDTO dto)
        {
            byte[]? srcBytes = null;
            if (dto.SrcFile != null)
            {
                using var memoryStream = new MemoryStream();
                await dto.SrcFile.CopyToAsync(memoryStream);
                srcBytes = memoryStream.ToArray();
            }
            else if (!string.IsNullOrEmpty(dto.Src))
            {
                srcBytes = Convert.FromBase64String(dto.Src);
            }

            var entity = new PhotographyStyle
            {
                Title = dto.Title,
                Description = dto.Description,
                Src = srcBytes
            };
            _dbcontext.PhotographyStyles.Add(entity);
            await _dbcontext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdatePhotographyStyleAsync(PhotographyStyleDTO dto)
        {
            var entity = await _dbcontext.PhotographyStyles.FindAsync(dto.Id);
            if (entity == null)
                return false;

            entity.Title = dto.Title;
            entity.Description = dto.Description;

            if (dto.SrcFile != null)
            {
                using var memoryStream = new MemoryStream();
                await dto.SrcFile.CopyToAsync(memoryStream);
                entity.Src = memoryStream.ToArray();
            }
            else if (!string.IsNullOrEmpty(dto.Src))
            {
                entity.Src = Convert.FromBase64String(dto.Src);
            }
            // If neither is provided, keep the existing image

            _dbcontext.PhotographyStyles.Update(entity);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePhotographyStyleAsync(int id)
        {
            var entity = await _dbcontext.PhotographyStyles.FindAsync(id);
            if (entity == null)
                return false;
            _dbcontext.PhotographyStyles.Remove(entity);
            await _dbcontext.SaveChangesAsync();
            return true;
        }


        // Get all testimonials
        public async Task<List<TestimonialDTO>> GetTestimonialsAsync()
        {
            var items = await _dbcontext.Testimonials.ToListAsync();
            return items.Select(x => new TestimonialDTO
            {
                Id = x.Id,
                Thumbnail = x.Thumbnail != null ? Convert.ToBase64String(x.Thumbnail) : null,
                Quote = x.Quote
            }).ToList();
        }

        // Add a new testimonial (handles image upload)
        public async Task<Testimonial> AddTestimonialAsync(TestimonialDTO dto)
        {
            byte[]? thumbnailBytes = null;
            if (dto.ThumbnailFile != null)
            {
                using var memoryStream = new MemoryStream();
                await dto.ThumbnailFile.CopyToAsync(memoryStream);
                thumbnailBytes = memoryStream.ToArray();
            }
            else if (!string.IsNullOrEmpty(dto.Thumbnail))
            {
                thumbnailBytes = Convert.FromBase64String(dto.Thumbnail);
            }

            var entity = new Testimonial
            {
                Thumbnail = thumbnailBytes,
                Quote = dto.Quote
            };
            _dbcontext.Testimonials.Add(entity);
            await _dbcontext.SaveChangesAsync();
            return entity;
        }

        // Update an existing testimonial (handles image upload)
        public async Task<bool> UpdateTestimonialAsync(TestimonialDTO dto)
        {
            var entity = await _dbcontext.Testimonials.FindAsync(dto.Id);
            if (entity == null)
                return false;

            entity.Quote = dto.Quote;

            if (dto.ThumbnailFile != null)
            {
                using var memoryStream = new MemoryStream();
                await dto.ThumbnailFile.CopyToAsync(memoryStream);
                entity.Thumbnail = memoryStream.ToArray();
            }
            else if (!string.IsNullOrEmpty(dto.Thumbnail))
            {
                entity.Thumbnail = Convert.FromBase64String(dto.Thumbnail);
            }
            // If neither is provided, keep the existing image

            _dbcontext.Testimonials.Update(entity);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        // Delete a testimonial
        public async Task<bool> DeleteTestimonialAsync(int id)
        {
            var entity = await _dbcontext.Testimonials.FindAsync(id);
            if (entity == null)
                return false;
            _dbcontext.Testimonials.Remove(entity);
            await _dbcontext.SaveChangesAsync();
            return true;
        }



        public async Task<List<PhotoGalleryDTO>> GetPhotoGalleriesAsync()
        {
            var items = await _dbcontext.PhotoGalleries.ToListAsync();
            return items.Select(x => new PhotoGalleryDTO
            {
                Id = x.Id,
                // Convert image to base64 for API response if needed
                Src = x.Src != null ? Convert.ToBase64String(x.Src) : null,
                Layout = x.Layout,
                Category = x.Category,
                Alt = x.Alt
            }).ToList();
        }

        public async Task<PhotoGallery> AddPhotoGalleryAsync(PhotoGalleryDTO dto)
        {
            byte[]? srcBytes = null;
            if (dto.SrcFile != null)
            {
                using var memoryStream = new MemoryStream();
                await dto.SrcFile.CopyToAsync(memoryStream);
                srcBytes = memoryStream.ToArray();
            }
            else if (!string.IsNullOrEmpty(dto.Src))
            {
                srcBytes = Convert.FromBase64String(dto.Src);
            }

            var entity = new PhotoGallery
            {
                Src = srcBytes,
                Layout = dto.Layout,
                Category = dto.Category,
                Alt = dto.Alt
            };
            _dbcontext.PhotoGalleries.Add(entity);
            await _dbcontext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdatePhotoGalleryAsync(PhotoGalleryDTO dto)
        {
            var entity = await _dbcontext.PhotoGalleries.FindAsync(dto.Id);
            if (entity == null)
                return false;

            entity.Layout = dto.Layout;
            entity.Category = dto.Category;
            entity.Alt = dto.Alt;

            if (dto.SrcFile != null)
            {
                using var memoryStream = new MemoryStream();
                await dto.SrcFile.CopyToAsync(memoryStream);
                entity.Src = memoryStream.ToArray();
            }
            else if (!string.IsNullOrEmpty(dto.Src))
            {
                entity.Src = Convert.FromBase64String(dto.Src);
            }
            // If neither is provided, keep the existing image

            _dbcontext.PhotoGalleries.Update(entity);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePhotoGalleryAsync(int id)
        {
            var entity = await _dbcontext.PhotoGalleries.FindAsync(id);
            if (entity == null)
                return false;
            _dbcontext.PhotoGalleries.Remove(entity);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<List<CulturalWeddingDTO>> GetCulturalWeddingsAsync()
        {
            var items = await _dbcontext.CulturalWeddings.ToListAsync();
            return items.Select(x => new CulturalWeddingDTO
            {
                Id = x.Id,
                Title = x.Title,
                Image = x.Image != null ? Convert.ToBase64String(x.Image) : null,
                ReadBlogs = x.ReadBlogs
            }).ToList();
        }

        public async Task<CulturalWedding> AddCulturalWeddingAsync(CulturalWeddingDTO dto)
        {
            byte[]? imageBytes = null;
            if (dto.ImageFile != null)
            {
                using var memoryStream = new MemoryStream();
                await dto.ImageFile.CopyToAsync(memoryStream);
                imageBytes = memoryStream.ToArray();
            }
            else if (!string.IsNullOrEmpty(dto.Image))
            {
                imageBytes = Convert.FromBase64String(dto.Image);
            }

            var entity = new CulturalWedding
            {
                Title = dto.Title,
                Image = imageBytes,
                ReadBlogs = dto.ReadBlogs
            };
            _dbcontext.CulturalWeddings.Add(entity);
            await _dbcontext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UpdateCulturalWeddingAsync(CulturalWeddingDTO dto)
        {
            var entity = await _dbcontext.CulturalWeddings.FindAsync(dto.Id);
            if (entity == null)
                return false;

            entity.Title = dto.Title;
            entity.ReadBlogs = dto.ReadBlogs;

            if (dto.ImageFile != null)
            {
                using var memoryStream = new MemoryStream();
                await dto.ImageFile.CopyToAsync(memoryStream);
                entity.Image = memoryStream.ToArray();
            }
            else if (!string.IsNullOrEmpty(dto.Image))
            {
                entity.Image = Convert.FromBase64String(dto.Image);
            }
            // If neither is provided, keep the existing image

            _dbcontext.CulturalWeddings.Update(entity);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCulturalWeddingAsync(int id)
        {
            var entity = await _dbcontext.CulturalWeddings.FindAsync(id);
            if (entity == null)
                return false;
            _dbcontext.CulturalWeddings.Remove(entity);
            await _dbcontext.SaveChangesAsync();
            return true;
        }




    }
}
