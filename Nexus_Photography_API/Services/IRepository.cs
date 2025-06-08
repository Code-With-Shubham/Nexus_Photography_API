using Nexus_Photography_API.DBContext.Entities.TableEntities;
using Nexus_Photography_API.Models.DTOs;
using Nexus_Photography_API.Models.Response;

namespace Nexus_Photography_API.Services
{
    public interface IRepository
    {
        //Couple Films
        Task<List<CoupleFilmDTO>> GetCoupleflimsAsync();
        Task<APIResponse> AddCoupleFilmAsync(CoupleFilmDTO entity);
        Task<bool> UpdateCoupleFilmAsync(CoupleFilmDTO entity);
        Task<bool> DeleteCoupleFilmAsync(int id);

        Task<List<ContactForm>> GetContactFormsAsync();
        Task<ContactForm> AddContactFormAsync(ContactFormDTO dto);
        Task<bool> UpdateContactFormAsync(ContactForm entity);
        Task<bool> DeleteContactFormAsync(int id);


        Task<List<CoupleStoryDTO>> GetCoupleStoriesAsync();
        Task<CoupleStory> AddCoupleStoryAsync(CoupleStoryDTO dto);
        Task<bool> UpdateCoupleStoryAsync(CoupleStoryDTO dto);
        Task<bool> DeleteCoupleStoryAsync(int id);


        Task<List<ClientSayDTO>> GetClientSaysAsync();
        Task<ClientSay> AddClientSayAsync(ClientSayDTO dto);
        Task<bool> UpdateClientSayAsync(ClientSayDTO dto);
        Task<bool> DeleteClientSayAsync(int id);


        Task<List<MostPopularWeddingDTO>> GetMostPopularFilmsAsync();
        Task<MostPopularWedding> AddMostPopularFilmAsync(MostPopularWeddingDTO dto);
        Task<bool> UpdateMostPopularFilmAsync(MostPopularWeddingDTO entity);
        Task<bool> DeleteMostPopularFilmAsync(int id);

        // CulturalWedding
        Task<List<CulturalWeddingDTO>> GetCulturalWeddingsAsync();
        Task<CulturalWedding> AddCulturalWeddingAsync(CulturalWeddingDTO dto);
        Task<bool> UpdateCulturalWeddingAsync(CulturalWeddingDTO dto);
        Task<bool> DeleteCulturalWeddingAsync(int id);

        // DestinationWedding
        //Task<List<Models.DTOs.DestinationWeddingDTO>> GetDestinationWeddingsAsync();
        //Task<DestinationWedding> AddDestinationWeddingAsync(Models.DTOs.DestinationWeddingDTO dto);
        //Task<bool> UpdateDestinationWeddingAsync(DestinationWeddingDTO dto);
        //Task<bool> DeleteDestinationWeddingAsync(int id);


        //PhotoGallery
        Task<List<PhotoGalleryDTO>> GetPhotoGalleriesAsync();
        Task<PhotoGallery> AddPhotoGalleryAsync(PhotoGalleryDTO dto);
        Task<bool> UpdatePhotoGalleryAsync(PhotoGalleryDTO dto);
        Task<bool> DeletePhotoGalleryAsync(int id);

        // PhotographyStyle
        Task<List<PhotographyStyleDTO>> GetPhotographyStylesAsync();
        Task<PhotographyStyle> AddPhotographyStyleAsync(PhotographyStyleDTO dto);
        Task<bool> UpdatePhotographyStyleAsync(PhotographyStyleDTO dto);
        Task<bool> DeletePhotographyStyleAsync(int id);

        //Testimonial
       Task<List<TestimonialDTO>> GetTestimonialsAsync();
        Task<Testimonial> AddTestimonialAsync(TestimonialDTO dto);
        Task<bool> UpdateTestimonialAsync(TestimonialDTO dto);
        Task<bool> DeleteTestimonialAsync(int id);


        // Admin
        Task<List<AdminDTO>> GetAdminsAsync();
        Task<Admin> AddAdminAsync(AdminDTO dto);
        Task<bool> DeleteAdminAsync(int id);
    }
}
