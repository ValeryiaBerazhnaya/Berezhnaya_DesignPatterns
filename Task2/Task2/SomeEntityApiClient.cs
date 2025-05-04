namespace Task2
{
    public class SomeEntityApiClient
    {
        private SomeEntityController _controller;

        public SomeEntityApiClient(SomeEntityController controller)
        {
            _controller = controller;
        }

        public void Create(SomeEntity entity) => _controller.Create(entity);
        public void Update(SomeEntity entity) => _controller.Update(entity);
        public SomeEntity GetOne(int id) => _controller.GetOne(id);
        public List<SomeEntity> GetMany() => _controller.GetMany();
        public void Delete(int id) => _controller.Delete(id);
    }
}
