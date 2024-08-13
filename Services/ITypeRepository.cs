using LearnWebAPI.Models;

namespace LearnWebAPI.Services
{
    public interface ITypeRepository
    {
        List<TypeViewModel> GetAll();
        TypeViewModel GetById(int id);
        TypeViewModel Add(TypeModel type);
        void Update(TypeViewModel type);
        void Delete(int id);

    }
}
