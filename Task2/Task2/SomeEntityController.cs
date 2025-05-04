namespace Task2
{
    public class SomeEntityController
    {
        private List<SomeEntity> _entities = new();

        public void Create(SomeEntity entity) => _entities.Add(entity);

        public void Update(SomeEntity entity)
        {
            var existing = _entities.FirstOrDefault(e => e.Id == entity.Id);
            if (existing != null)
            {
                existing.Name = entity.Name;
                existing.Description = entity.Description;
                existing.Status = entity.Status;
            }
        }

        public SomeEntity GetOne(int id) => _entities.FirstOrDefault(e => e.Id == id);

        public List<SomeEntity> GetMany() => _entities;

        public List<SomeEntity> GetByFilter(Func<SomeEntity, bool> filter) => _entities.Where(filter).ToList();

        public void Delete(int id) => _entities.RemoveAll(e => e.Id == id);

        public void DeleteMany(List<int> ids) => _entities.RemoveAll(e => ids.Contains(e.Id));

        public void Print(int id)
        {
            var e = GetOne(id);
            if (e != null)
                Console.WriteLine($"{e.Id}: {e.Name}, {e.Description}, {e.Status}");
        }

        public void PrintMany()
        {
            foreach (var e in _entities)
                Print(e.Id);
        }

        public void SetStatus(int id, string status)
        {
            var e = GetOne(id);
            if (e != null) e.Status = status;
        }

        public void Deactivate(int id) => SetStatus(id, "Inactive");
        public void Activate(int id) => SetStatus(id, "Active");
    }
}
