using LearnWebAPI.Data;
using LearnWebAPI.Models;

namespace LearnWebAPI.Services
{
    public class TypeRepository : ITypeRepository
    {
        private readonly AppDbContext _context;

        public TypeRepository(AppDbContext context)
        {
             _context = context;
        }

        public TypeViewModel Add(TypeModel type)
        {
            var _type = new Data.Type
            {
                TypeName = type.TypeName
            };

            _context.Types.Add(_type);
            _context.SaveChanges();

            return new TypeViewModel
            {
                TypeId = _type.TypeId,
                TypeName = _type.TypeName
            };
        }

        public void Delete(int id)
        {
            var type = _context.Types.SingleOrDefault(t => t.TypeId == id);

            if (type == null)
            {
                return;
            }

            _context.Types.Remove(type);
            _context.SaveChanges();
        }

        public List<TypeViewModel> GetAll()
        {
            var types = _context.Types.Select(t => new TypeViewModel
            {
                TypeId = t.TypeId,
                TypeName = t.TypeName
            });

            return types.ToList();
        }

        public TypeViewModel GetById(int id)
        {
            var type = _context.Types.SingleOrDefault(t => t.TypeId == id);

            if (type == null)
            {
                return null;
            }

            return new TypeViewModel
            {
                TypeId = type.TypeId,
                TypeName = type.TypeName
            };
        }

        public void Update(TypeViewModel type)
        {
            var _type = _context.Types.SingleOrDefault(t => t.TypeId == type.TypeId);

            if (_type == null)
            {
                return;
            }

            _type.TypeName = type.TypeName;
            _context.SaveChanges();
        }
    }
}
