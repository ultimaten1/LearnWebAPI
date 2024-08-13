using LearnWebAPI.Models;

namespace LearnWebAPI.Services
{
    public class TypeRepositoryInMemory : ITypeRepository
    {

        static List<TypeViewModel> types = new List<TypeViewModel>()
        {
            new TypeViewModel { TypeId = 1, TypeName = "Tivi" },
            new TypeViewModel { TypeId = 2, TypeName = "Tu lanh" },
            new TypeViewModel { TypeId = 3, TypeName = "Dieu hoa" },
            new TypeViewModel { TypeId = 4, TypeName = "May giat" },
        };

        public TypeViewModel Add(TypeModel type)
        {
            var _type = new TypeViewModel
            {
                TypeId = types.Max(t => t.TypeId) + 1,
                TypeName = type.TypeName
            };

            types.Add(_type);

            return _type;
        }

        public void Delete(int id)
        {
            var _type = types.SingleOrDefault(t => t.TypeId == id);
            types.Remove(_type);
        }

        public List<TypeViewModel> GetAll()
        {
            return types;
        }

        public TypeViewModel GetById(int id)
        {
            return types.SingleOrDefault(t => t.TypeId == id);
        }

        public void Update(TypeViewModel type)
        {
            var _type = types.SingleOrDefault(t => t.TypeId == type.TypeId);

            if (_type != null)
            {
                _type.TypeName = type.TypeName;
            }
        }
    }
}
