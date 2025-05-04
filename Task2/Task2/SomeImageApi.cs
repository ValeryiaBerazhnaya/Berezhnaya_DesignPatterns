namespace Task2
{
    public class SomeImageApi
    {
        private SomeEntityController _controller;

        public SomeImageApi(SomeEntityController controller)
        {
            _controller = controller;
        }

        public string? GetImage(int id)
        {
            var entity = _controller.GetOne(id) as SomeImageEntity;
            return entity?.ImageUrl;
        }

        public void SetImage(int id, string url)
        {
            var entity = _controller.GetOne(id) as SomeImageEntity;
            if (entity != null)
            {
                entity.ImageUrl = url;
            }
        }

        public List<SomeImageEntity> GetEntitiesByFilter(Func<SomeEntity, bool> filter)
        {
            var filtered = _controller.GetByFilter(filter);
            var images = new List<SomeImageEntity>();
            foreach (var entity in filtered)
            {
                if (entity is SomeImageEntity imgEntity)
                {
                    images.Add(imgEntity);
                }
            }
            return images;
        }
    }

}
